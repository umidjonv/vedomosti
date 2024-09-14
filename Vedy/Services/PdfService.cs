using iText.Kernel.Geom;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using Document = iText.Layout.Document;

using iText.Kernel.Colors;
using iText.Layout.Properties;
using Vedy.Common.DTOs.Settlement;
using iText.Layout.Borders;
namespace Vedy.Services
{


    public class PdfService
    {
        public static string FONT = @"C:\Windows\fonts\Arial.ttf";

        public void CreateFile(SettlementModel model, string fileName)
        {
            var writer = new PdfWriter(fileName);
            var pdf = new PdfDocument(writer);

            Document document = new Document(pdf, PageSize.A4.Rotate());

            try
            {
                
                Paragraph subheader = new Paragraph($"Ведомость #{model.Number}/{model.Date.ToString("dd.MM.yyyy")}")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(15);
                document.Add(subheader);

                PdfFont font = PdfFontFactory.CreateFont(FONT, "Cp1251");
                Table table = new Table(4, true);
                table.SetWidth(UnitValue.CreatePercentValue(100));
                
                var parahraph = new Paragraph(new Text("\u0414\u0430\u0442\u0430"));

                Cell cell11 = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(parahraph)
                   .SetFont(font);

                   
                Cell cell12 = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("\u0424\u0418\u041E"))
                   .SetFont(font);
                Cell cell13 = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("\u041A\u0443\u0431\u043E\u043C\u0435\u0442\u0440"))
                   .SetFont(font);

                Cell cell14 = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("\u2116 \u043C\u0430\u0448\u0438\u043D\u044B"))
                   .SetFont(font);

                


                table.AddCell(cell11);
                table.AddCell(cell12);
                table.AddCell(cell13);
                table.AddCell(cell14);

                var lastEntry = model.CustomerEntries.LastOrDefault();

                foreach (var entry in model.CustomerEntries)
                {

                    var date = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph(entry.CreatedDate.ToString("dd.MM.yyyy")));

                    if (lastEntry == entry)
                        table.AddFooterCell(date);
                    else
                        table.AddCell(date);

                    var fio = new Cell(1,1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph(entry.FullName));
                    if (lastEntry == entry)
                        table.AddFooterCell(fio);
                    else
                        table.AddCell(fio);

                    

                    var amount = new Cell(1, 1)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph($"{entry.Amount}"));

                    if (lastEntry == entry)
                        table.AddFooterCell(amount);
                    else
                        table.AddCell(amount);

                    var car = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        
                        .Add(new Paragraph(entry.CarNumber));

                    if (lastEntry == entry)
                        table.AddFooterCell(car);
                    else
                        table.AddCell(car);
                    
                    

                }

                document.Add(table);

                document.Add(new Paragraph(""));

            }
            catch (Exception ex) {
                throw;
            } finally
            {
                // Закрываем документ
                document.Close();
            }
        }
    }
}
