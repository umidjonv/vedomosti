/******************************************************* 

  TestSigCapt.cs
  
  Displays a form with a button to start signature capture
  The captured signature is encoded in an image file which is displayed on the form
  
  Copyright (c) 2020 Wacom Co. Ltd. All rights reserved.
  
********************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Florentis;
using Vedy.Services;
using Vedy.SignService.Consts;
using Vedy.SignService.Models;
using System.Threading.Tasks;
using System.Buffers.Text;
using System.Reflection;

namespace Vedy
{
    public partial class FormSigner : Form
    {
        private IRemoteService _remoteService;
        private SignModel _signModel;
        public FormSigner()
        {
            InitializeComponent();

            _remoteService = new RemoteService();
            _remoteService.SetReceiver(OpenForSign);
            _remoteService.SetCloser(() => 
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        Close();
                    }));
                }
                
            });
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            Log("btnSign was pressed");
            SigCtl sigCtl = new SigCtl();
            sigCtl.Licence = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImV4cCI6MjE0NzQ4MzY0NywiaWF0IjoxNTYwOTUwMjcyLCJyaWdodHMiOlsiU0lHX1NES19DT1JFIiwiU0lHQ0FQVFhfQUNDRVNTIl0sImRldmljZXMiOlsiV0FDT01fQU5ZIl0sInR5cGUiOiJwcm9kIiwibGljX25hbWUiOiJTaWduYXR1cmUgU0RLIiwid2Fjb21faWQiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImxpY191aWQiOiJiODUyM2ViYi0xOGI3LTQ3OGEtYTlkZS04NDlmZTIyNmIwMDIiLCJhcHBzX3dpbmRvd3MiOltdLCJhcHBzX2lvcyI6W10sImFwcHNfYW5kcm9pZCI6W10sIm1hY2hpbmVfaWRzIjpbXX0.ONy3iYQ7lC6rQhou7rz4iJT_OJ20087gWz7GtCgYX3uNtKjmnEaNuP3QkjgxOK_vgOrTdwzD-nm-ysiTDs2GcPlOdUPErSp_bcX8kFBZVmGLyJtmeInAW6HuSp2-57ngoGFivTH_l1kkQ1KMvzDKHJbRglsPpd4nVHhx9WkvqczXyogldygvl0LRidyPOsS5H2GYmaPiyIp9In6meqeNQ1n9zkxSHo7B11mp_WXJXl0k1pek7py8XYCedCNW5qnLi4UCNlfTd6Mk9qz31arsiWsesPeR9PN121LBJtiPi023yQU8mgb9piw_a-ccciviJuNsEuRDN3sGnqONG3dMSA";
            DynamicCapture dc = new DynamicCaptureClass();
            DynamicCaptureResult res = dc.Capture(sigCtl, "J Smith", "Document approval", null, null);
            if (res == DynamicCaptureResult.DynCaptOK)
            {
                Log("signature captured successfully");
                SigObj sigObj = (SigObj)sigCtl.Signature;
                sigObj.set_ExtraData("AdditionalData", "C# test: Additional data");
                String filename = "sig1.png";
                try
                {
                    sigObj.RenderBitmap(filename, 200, 150, "image/png", 0.5f, 0xff0000, 0xffffff, 10.0f, 10.0f, RBFlags.RenderOutputFilename | RBFlags.RenderColor32BPP | RBFlags.RenderEncodeData);
                    
                    byte[] imageBytes = File.ReadAllBytes(filename);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        

                        sigImage.Image = System.Drawing.Image.FromStream(ms);
                        
                        ms.Close();
                        Log("Signature has been output to file " + filename);


                    }
                    _remoteService.Send(new SignModelResponse
                    {
                        CustomerEntryId = _signModel.CustomerEntryId,
                        FullName = _signModel.FullName,
                        Image = Convert.ToBase64String(imageBytes)
                    });
                    HideWindow();   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            else
            {
                Log("Signature capture error res=" + (int)res + "  ( " + res + " )");
                switch (res)
                {
                    case DynamicCaptureResult.DynCaptCancel: Log("signature cancelled"); break;
                    case DynamicCaptureResult.DynCaptError: Log("no capture service available"); break;
                    case DynamicCaptureResult.DynCaptPadError: Log("signing device error"); break;
                    default: Log("Unexpected error code "); break;
                }
            }
        }

        private void OpenForSign(SignModel model)
        {
            try
            {

                // Проверка: нужно ли использовать Invoke
                if (InvokeRequired)
                {
                    Invoke(new Action(()=>
                    {
                        HideWindow();
                        _signModel = model;
                    }));
                }
                else
                {
                    // Логика обновления UI (например, добавление текста в TextBox)
                    MessageBox.Show("Nothing to do");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }// Show the form

        }
        private void HideWindow()
        {
            TopMost = true;
            Show();
            this.Visible = true;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            ShowInTaskbar = true;
            this.BringToFront();// Restore window state
            TopMost = false;
            
        }
        private void Log(string txt)
        {
            txtDisplay.Text += txt + "\r\n";
            txtDisplay.SelectionStart = txtDisplay.TextLength;
            txtDisplay.ScrollToCaret();
        }

		private async void TestSigCapt_Load(object sender, EventArgs e)
		{
            _remoteService.Connect(AppConsts.Url);
            await _remoteService.Initialize();
            Hide();

		}

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _notifyIcon_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show();
        }
    }
}

