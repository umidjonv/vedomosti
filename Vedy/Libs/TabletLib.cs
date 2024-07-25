/******************************************************* 

  TabletLib.cs
  
  Library of functions related to the use of the STU tablet
  
  Copyright (c) 2023 Wacom Ltd. All rights reserved.
  
********************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Vedy.Libs.Enums;
using wgssSTU;

namespace Vedy.Libs
{
    public class STU_Tablet
    {
        public bool useColor;
        public int clickEventCount;
        public int sigFormHeight;
        public int sigFormWidth;
        public int m_isDown;
        public int penDataOptionMode;
        public List<IPenData> penData;
        public List<IPenDataTimeCountSequence> penTimeData;
        public Tablet tablet;
        public ICapability capability;
        public IInformation information;
        public Pen penInk;  // cached object.
        public encodingMode encodingMode;
        public Bitmap bitmap;
        public byte[] bitmapData;
        public Buttons STUButtons;
        public Buttons.Button[] btns;
        public Graphics gfx;
        public Form signatureForm;
        public Form demoButtonsForm;

        public STU_Tablet(Form signatureForm, Form demoForm, int clientHeight, int clientWidth)
        {
            this.signatureForm = signatureForm;
            demoButtonsForm = demoForm;
            penData = new List<IPenData>();
            penDataOptionMode = -1;
            tablet = new Tablet();
            sigFormHeight = clientHeight;
            sigFormWidth = clientWidth;
            clickEventCount = 0;

            // Calculate the size and cache the inking pen.

            SizeF s = signatureForm.AutoScaleDimensions;
            float inkWidthMM = 0.7F;
            penInk = new Pen(Color.DarkBlue, inkWidthMM / 25.4F * ((s.Width + s.Height) / 2F));
            penInk.StartCap = penInk.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            penInk.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
        }

        public static string FindSTUModelName()
        {
            string STU_Model = "Unknown";
            IInformation information;

            Tablet tablet = new Tablet();

            UsbDevices usbDevices = new UsbDevices();
            if (usbDevices.Count != 0)
            {
                try
                {
                    IUsbDevice usbDevice = usbDevices[0]; // select a device
                    IErrorCode ec = tablet.usbConnect(usbDevice, true);
                    if (ec.value == 0)
                    {
                        information = tablet.getInformation();
                        STU_Model = information.modelName;
                        tablet.disconnect();
                    }
                }
                catch
                {
                    STU_Model = "No STU found";
                }
            }

            return STU_Model;
        }

        public PointF TabletToClient(IPenData penDataPoint)
        {
            // Client means the Windows Form coordinates.
            return new PointF((float)penDataPoint.x * sigFormWidth / capability.tabletMaxX, (float)penDataPoint.y * sigFormHeight / capability.tabletMaxY);
        }

        public PointF TabletToClientTimed(IPenDataTimeCountSequence penData)
        {
            // Client means the Windows Form coordinates.
            return new PointF((float)penData.x * sigFormWidth / capability.tabletMaxX, (float)penData.y * sigFormHeight / capability.tabletMaxY);
        }

        public Point TabletToScreen(IPenData penData)
        {
            // Screen means LCD screen of the tablet.
            return Point.Round(new PointF((float)penData.x * capability.screenWidth / capability.tabletMaxX, (float)penData.y * capability.screenHeight / capability.tabletMaxY));
        }

        public Point ClientToScreen(Point pt)
        {
            // client (window) coordinates to LCD screen coordinates. 
            // This is needed for converting mouse coordinates into LCD bitmap coordinates as that's
            // what this application uses as the coordinate space for buttons.
            return Point.Round(new PointF((float)pt.X * capability.screenWidth / sigFormWidth, (float)pt.Y * capability.screenHeight / sigFormHeight));
        }

        public ICapability getCapability()
        {
            if (penDataOptionMode == (int)PenDataOptionMode.PenDataOptionMode_TimeCountSequence)
                return penTimeData != null ? capability : null;
            else
                return penData != null ? capability : null;
        }

        public IInformation getInformation()
        {
            if (penDataOptionMode == (int)PenDataOptionMode.PenDataOptionMode_TimeCountSequence)
                return penTimeData != null ? information : null;
            else
                return penData != null ? information : null;
        }

        public void SetEncodingMode()
        {
            useColor = false;
            encodingMode encodingMode;
            ProtocolHelper protocolHelper = new ProtocolHelper();

            // Calculate the encodingMode that will be used to update the image

            ushort idP = tablet.getProductId();
            encodingFlag encodingFlag = (encodingFlag)protocolHelper.simulateEncodingFlag(idP, 0);

            if ((encodingFlag & (wgssSTU.encodingFlag.EncodingFlag_16bit | wgssSTU.encodingFlag.EncodingFlag_24bit)) != 0)
            {
                if (tablet.supportsWrite())
                    useColor = true;
            }

            if ((encodingFlag & wgssSTU.encodingFlag.EncodingFlag_24bit) != 0)
            {
                encodingMode = tablet.supportsWrite() ? wgssSTU.encodingMode.EncodingMode_24bit_Bulk : wgssSTU.encodingMode.EncodingMode_24bit;
            }
            else if ((encodingFlag & wgssSTU.encodingFlag.EncodingFlag_16bit) != 0)
            {
                encodingMode = tablet.supportsWrite() ? wgssSTU.encodingMode.EncodingMode_16bit_Bulk : wgssSTU.encodingMode.EncodingMode_16bit;
            }
            else
            {
                // assumes 1bit is available
                encodingMode = wgssSTU.encodingMode.EncodingMode_1bit;
            }
            this.encodingMode = encodingMode;
        }

        public int GetCurrentPenDataOptionMode()
        {
            int penDataOptionMode;

            try
            {
                penDataOptionMode = tablet.getPenDataOptionMode();
            }
            catch (Exception optionModeException)
            {
                penDataOptionMode = -1;
            }
            return penDataOptionMode;
        }

        public void SetCurrentPenDataOptionMode(int currentPenDataOptionMode)
        {
            // If the current option mode is TimeCount then this is a 520 so we must reset the mode
            // to basic data only as there is no handler for TimeCount

            switch (currentPenDataOptionMode)
            {
                case -1:
                    // THis must be the 300 which doesn't support getPenDataOptionMode at all so only basic data
                    penDataOptionMode = (int)PenDataOptionMode.PenDataOptionMode_None;
                    break;

                case (int)PenDataOptionMode.PenDataOptionMode_None:
                    // If the current option mode is "none" then it could be any pad so try setting the full option
                    // and if it fails or ends up as TimeCount then set it to none
                    try
                    {
                        tablet.setPenDataOptionMode((byte)wgssSTU.penDataOptionMode.PenDataOptionMode_TimeCountSequence);
                        penDataOptionMode = tablet.getPenDataOptionMode();
                        if (penDataOptionMode == (int)PenDataOptionMode.PenDataOptionMode_TimeCount)
                        {
                            tablet.setPenDataOptionMode((byte)wgssSTU.penDataOptionMode.PenDataOptionMode_None);
                            penDataOptionMode = (int)PenDataOptionMode.PenDataOptionMode_None;
                        }
                        else
                        {
                            penDataOptionMode = (int)PenDataOptionMode.PenDataOptionMode_TimeCountSequence;
                        }
                    }
                    catch (Exception ex)
                    {
                        // THis shouldn't happen but just in case...
                        penDataOptionMode = (int)PenDataOptionMode.PenDataOptionMode_None;
                    }
                    break;

                case (int)PenDataOptionMode.PenDataOptionMode_TimeCount:
                    tablet.setPenDataOptionMode((byte)wgssSTU.penDataOptionMode.PenDataOptionMode_None);
                    penDataOptionMode = (int)PenDataOptionMode.PenDataOptionMode_None;
                    break;

                case (int)PenDataOptionMode.PenDataOptionMode_TimeCountSequence:
                    // If the current mode is timecountsequence then leave it at that
                    penDataOptionMode = currentPenDataOptionMode;
                    break;
            }

            switch (penDataOptionMode)
            {
                case (int)PenDataOptionMode.PenDataOptionMode_None:
                    penData = new List<IPenData>();
                    break;
                case (int)PenDataOptionMode.PenDataOptionMode_TimeCount:
                    penData = new List<IPenData>();
                    break;
                case (int)PenDataOptionMode.PenDataOptionMode_SequenceNumber:
                    penData = new List<IPenData>();
                    break;
                case (int)PenDataOptionMode.PenDataOptionMode_TimeCountSequence:
                    penTimeData = new List<IPenDataTimeCountSequence>();
                    break;
                default:
                    penData = new List<IPenData>();
                    break;
            }
        }

        // Once the bitmap has been created, it needs to be converted to device-native format.
        public void ConvertBitmap()
        {
            // Unfortunately it is not possible for the native COM component to
            // understand .NET bitmaps. We have therefore convert the .NET bitmap
            // into a memory blob that will be understood by COM.

            ProtocolHelper protocolHelper = new ProtocolHelper();
            MemoryStream stream = new MemoryStream();

            bitmap.Save(stream, ImageFormat.Png);
            bitmapData = (byte[])protocolHelper.resizeAndFlatten(stream.ToArray(), 0, 0, (uint)bitmap.Width, (uint)bitmap.Height, capability.screenWidth, capability.screenHeight, (byte)encodingMode, Scale.Scale_Fit, 0, 0);
            protocolHelper = null;

            stream.Dispose();
        }

        public int buttonClicked(Point pt)
        {
            int btn = 0; // will be +ve if the pen is over a button.
            {
                for (int i = 0; i < btns.Length; ++i)
                {
                    if (btns[i].Bounds.Contains(pt))
                    {
                        btn = i + 1;
                        break;
                    }
                }
            }
            return btn;
        }

        public void addDelegates()
        {
            // Add the delegates that receive pen data.
            tablet.onGetReportException += new ITabletEvents2_onGetReportExceptionEventHandler(onGetReportException);

            tablet.onPenData += new ITabletEvents2_onPenDataEventHandler(onPenData);
            tablet.onPenDataEncrypted += new ITabletEvents2_onPenDataEncryptedEventHandler(onPenDataEncrypted);

            tablet.onPenDataTimeCountSequence += new ITabletEvents2_onPenDataTimeCountSequenceEventHandler(onPenDataTimeCountSequence);
            tablet.onPenDataTimeCountSequenceEncrypted += new ITabletEvents2_onPenDataTimeCountSequenceEncryptedEventHandler(onPenDataTimeCountSequenceEncrypted);
        }

        public void removeDelegates()
        {
            tablet.onGetReportException -= new ITabletEvents2_onGetReportExceptionEventHandler(onGetReportException);

            tablet.onPenData -= new ITabletEvents2_onPenDataEventHandler(onPenData);
            tablet.onPenDataEncrypted -= new ITabletEvents2_onPenDataEncryptedEventHandler(onPenDataEncrypted);

            tablet.onPenDataTimeCountSequence -= new ITabletEvents2_onPenDataTimeCountSequenceEventHandler(onPenDataTimeCountSequence);
            tablet.onPenDataTimeCountSequenceEncrypted -= new ITabletEvents2_onPenDataTimeCountSequenceEncryptedEventHandler(onPenDataTimeCountSequenceEncrypted);


            tablet.onGetReportException -= new ITabletEvents2_onGetReportExceptionEventHandler(onGetReportException);
        }

        public void onGetReportException(ITabletEventsException tabletEventsException)
        {
            try
            {
                tabletEventsException.getException();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                tablet.disconnect();
                tablet = null;
                penData = null;
                penTimeData = null;
                signatureForm.Close();
            }
        }

        public void onPenDataTimeCountSequenceEncrypted(IPenDataTimeCountSequenceEncrypted penTimeCountSequenceDataEncrypted) // Process incoming pen data
        {
            onPenDataTimeCountSequence(penTimeCountSequenceDataEncrypted);
        }

        private void onPenDataTimeCountSequence(IPenDataTimeCountSequence penTimeData)
        {
            Point pt = TabletToScreen(penTimeData);
            int btn = buttonClicked(pt); // Check if a button was clicked

            bool isDown = penTimeData.sw != 0;

            // This code uses a model of four states the pen can be in:
            // down or up, and whether this is the first sample of that state.

            if (isDown)
            {
                if (m_isDown == 0)
                {
                    // transition to down
                    if (btn > 0)
                    {
                        // We have put the pen down on a button.
                        // Track the pen without inking on the client.

                        m_isDown = btn;
                    }
                    else
                    {
                        // We have put the pen down somewhere else.
                        // Treat it as part of the signature.

                        m_isDown = -1;
                    }
                }
                else
                {
                    // already down, keep doing what we're doing!
                }

                // draw
                if (this.penTimeData.Count != 0 && m_isDown == -1)
                {
                    // Draw a line from the previous down point to this down point.
                    // This is the simplist thing you can do; a more sophisticated program
                    // can perform higher quality rendering than this!

                    IPenDataTimeCountSequence prevPenData = this.penTimeData[this.penTimeData.Count - 1];
                    PointF prev = TabletToClientTimed(prevPenData);

                    Graphics gfx = GraphicFunctions.SetQualityGraphics(signatureForm);
                    gfx.DrawLine(penInk, prev, TabletToClientTimed(penTimeData));
                    gfx.Dispose();
                }

                // The pen is down, store it for use later.
                if (m_isDown == -1)
                    this.penTimeData.Add(penTimeData);
            }
            else
            {
                if (m_isDown != 0)
                {
                    // transition to up
                    if (btn > 0)
                    {
                        // The pen is over a button

                        if (btn == m_isDown)
                        {
                            // The pen was pressed down over the same button as is was lifted now. 
                            // Consider that as a click!
                            btns[btn - 1].PerformClick();
                        }
                    }
                    m_isDown = 0;
                }
                else
                {
                    // still up
                }

                // Add up data once we have collected some down data.
                if (this.penTimeData != null)
                {
                    if (this.penTimeData.Count != 0)
                        this.penTimeData.Add(penTimeData);
                }
            }
        }

        private void onPenDataEncrypted(IPenDataEncrypted penData) // Process incoming pen data
        {
            onPenData(penData.penData1);
            onPenData(penData.penData2);
        }

        private void onPenData(IPenData penData) // Process incoming pen data
        {
            Point pt = TabletToScreen(penData);

            int btn = 0; // will be +ve if the pen is over a button.
            {
                for (int i = 0; i < btns.Length; ++i)
                {
                    if (btns[i].Bounds.Contains(pt))
                    {
                        btn = i + 1;
                        break;
                    }
                }
            }

            bool isDown = penData.sw != 0;

            // This code uses a model of four states the pen can be in:
            // down or up, and whether this is the first sample of that state.

            if (isDown)
            {
                if (m_isDown == 0)
                {
                    // transition to down
                    if (btn > 0)
                    {
                        // We have put the pen down on a button.
                        // Track the pen without inking on the client.

                        m_isDown = btn;
                    }
                    else
                    {
                        // We have put the pen down somewhere else.
                        // Treat it as part of the signature.

                        m_isDown = -1;
                    }
                }
                else
                {
                    // already down, keep doing what we're doing!
                }

                // draw
                if (this.penData.Count != 0 && m_isDown == -1)
                {
                    // Draw a line from the previous down point to this down point.
                    // This is the simplist thing you can do; a more sophisticated program
                    // can perform higher quality rendering than this!

                    IPenData prevPenData = this.penData[this.penData.Count - 1];

                    PointF prev = TabletToClient(prevPenData);

                    Graphics gfx = GraphicFunctions.SetQualityGraphics(signatureForm);
                    gfx.DrawLine(penInk, prev, TabletToClient(penData));
                    gfx.Dispose();
                }

                // The pen is down, store it for use later.
                if (m_isDown == -1)
                    this.penData.Add(penData);
            }
            else
            {
                if (m_isDown != 0)
                {
                    // transition to up
                    if (btn > 0)
                    {
                        // The pen is over a button

                        if (btn == m_isDown)
                        {
                            // The pen was pressed down over the same button as is was lifted now. 
                            // Consider that as a click!
                            btns[btn - 1].PerformClick();
                        }
                    }
                    m_isDown = 0;
                }
                else
                {
                    // still up
                }

                // Add up data once we have collected some down data.
                if (this.penData.Count != 0)
                    this.penData.Add(penData);
            }
        }

        // Count no of pixels traversed between 2 co-ordinates
        private int countPixels(ushort lastX, ushort lastY, ushort currX, ushort currY)
        {
            int pixelDistance = 0;
            int tempCurrX = 0;
            int tempCurrY = 0;
            int tempLastX = 0;
            int tempLastY = 0;

            int tempX = 0;
            int tempY = 0;
            int tempZ = 0;
            string logText;

            // Possibilities are straight line along x co-ordinate, straight line along y co-ordinate or diagonal

            if (lastX == currX)
            {
                if (lastY != currY)
                {
                    // Only y co-ordinate has changed
                    if (currY > lastY)
                    {
                        pixelDistance = currY - lastY;
                    }
                    else
                        pixelDistance = lastY - currY;
                }
                else
                {
                    // No change in either co-ordinate
                    pixelDistance = 0;
                }
            }
            else
            {
                // x has changed - what about y?
                if (lastY == currY)
                {
                    // y has not changed so just use the difference in the x co-ordinate
                    if (currX > lastX)
                    {
                        pixelDistance = currX - lastX;
                    }
                    else
                        pixelDistance = lastX - currX;
                }
                else
                {
                    // Both x and y have changed so we have to calculate the length of a diagonal line between the 2
                    // Convert x and y to positive values and then use standard Pythagorean theorem calculation for the diagonal
                    tempLastX = Math.Abs(lastX);
                    tempCurrX = Math.Abs(currX);
                    tempLastY = Math.Abs(lastY);
                    tempCurrY = Math.Abs(currY);

                    // We just want a positive difference value to calculate the diagonal distance (3rd side of the triangle)
                    tempX = Math.Abs(tempLastX - tempCurrX);
                    tempY = Math.Abs(tempLastY - tempCurrY);

                    tempZ = tempX * tempX + tempY * tempY;
                    pixelDistance = (int)Math.Round(Math.Sqrt(tempZ), 0);
                }
            }
            logText = "Distance from " + lastX + "/" + lastY + " to " + currX + "/" + currY + " = " + pixelDistance;
            logFile(logText);

            return pixelDistance;
        }


        // Calculate average speed of the pen while creating the signature
        public string calcSpeed()
        {
            int i;
            int totalPixels = 0;
            ushort endTime, startTime;
            ushort lastX, lastY;
            decimal averageSpeed;
            decimal roundedSpeed;
            float kmPerHour;
            float metresPerHour;
            float metresPerSecond;
            float mmPerSecond;
            float penPointsPerSecond;
            float roundedPixelSpeed;
            string logText;

            // Store the start and end time of the pen data input
            startTime = penTimeData[0].timeCount;
            endTime = penTimeData[penTimeData.Count - 1].timeCount;

            lastX = penTimeData[0].x;
            lastY = penTimeData[0].y;

            // Count the number of pixels traversed by the pen by using the data in the array
            for (i = 0; i < penTimeData.Count; i++)
            {
                // If both co-ordinates are zero for either pair then no calculation can be made
                if ((lastX > 0 || lastY > 0) && (penTimeData[i].x > 0 || penTimeData[i].y > 0))
                {
                    totalPixels += countPixels(lastX, lastY, penTimeData[i].x, penTimeData[i].y);
                    lastX = penTimeData[i].x;
                    lastY = penTimeData[i].y;
                }
            }
            averageSpeed = (decimal)totalPixels / (endTime - startTime);
            roundedSpeed = Math.Round(averageSpeed, 2);

            logText = "Time lapse from " + startTime + " to " + endTime + ": " + (endTime - startTime) + ". Pixels: " + totalPixels + ". Average pen points per ms: " + roundedSpeed.ToString();
            logFile(logText);

            // The 530 is 800 x 480 pixels but the # of pen points is 10800 x 6480 which is a ratio of 13.5 pen points to 1 pixel
            // Therefore the average speed in pixels is lower
            roundedPixelSpeed = (float)roundedSpeed;
            roundedPixelSpeed /= 13.5f;
            logText = "Average pixel speed per ms = " + roundedPixelSpeed;
            logFile(logText);

            // There are 100 pen points per millimeter (the pad measures 10.8 cm x 6.48cm) so we can now calculate metres per second and km per hour
            // First multiply the average no of pen points by 1000 to get the number per second
            penPointsPerSecond = (float)(roundedSpeed * 1000);

            // Divide by 100 to get the number of millimetres covered per second, then by 1000 to get the number of metres
            mmPerSecond = penPointsPerSecond / 100;
            metresPerSecond = mmPerSecond / 1000;

            // Multiple by 3600 to get the number of metres per hour
            metresPerHour = metresPerSecond * 3600;
            // Finally divide by 1000 to get the number of km per hour
            kmPerHour = metresPerHour / 1000;

            logText = "Metres per second: " + metresPerSecond.ToString() + ".  Km per hour: " + kmPerHour.ToString();
            logFile(logText);

            if (clickEventCount == 1)
            {
                logText = "Average pen points per ms: " + roundedSpeed.ToString() + "\r\nPixel speed per ms: " + roundedPixelSpeed + "\r\nMetres/sec: " + metresPerSecond.ToString() + "\r\nKm/h: " + kmPerHour.ToString();
            }
            return logText;
        }


        // Save the image in a local file
        public string saveImage(bool reverseImage)
        {
            string msgText = "";

            try
            {
                Bitmap bitmap = GraphicFunctions.GetSigImage(demoButtonsForm, signatureForm, this);

                if (reverseImage)
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);

                string saveLocation = Environment.CurrentDirectory + "\\" + "signature_output.jpg";
                bitmap.Save(saveLocation, ImageFormat.Jpeg);
                msgText = "Image saved to " + saveLocation;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
                msgText = "Exception: " + ex.Message;
            }
            return msgText;
        }

        public void logFile(string logMessage)
        {
            StreamWriter log;

            if (!File.Exists("logfile.txt"))
            {
                log = new StreamWriter("logfile.txt");
            }
            else
            {
                log = File.AppendText("logfile.txt");
            }
            // Write to the file:
            log.WriteLine("Date/Time:" + DateTime.Now);
            log.WriteLine(logMessage);
            // Close the stream:
            log.Close();
        }
    }
}