using iText.Kernel.Geom;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using Document = iText.Layout.Document;
using Humanizer;
using iText.Kernel.Colors;
using iText.Layout.Properties;
using Vedy.Common.DTOs.Settlement;
using iText.Layout.Borders;
using Vedy.Common;
using System.Globalization;
using Vedy.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Vedy.Services
{


    public class PdfService
    {
        public PdfService(AppConfig config) 
        {
            _config = config;
        }

        public static string FONT = @"C:\Windows\fonts\Arial.ttf";
        private readonly AppConfig _config;

        public bool CreateFile(SettlementModel model, string fileName, TotalsModel totals)
        {
            var writer = new PdfWriter(fileName);
            var pdf = new PdfDocument(writer);
            PdfFont font = PdfFontFactory.CreateFont(FONT, "Cp1251");
            var cultureInfo = new CultureInfo("ru-RU");

            Document document = new Document(pdf, PageSize.A4.Rotate());
            document.SetFont(font);
            try
            {
                Table headerTable = new Table(2);
                headerTable.SetWidth(UnitValue.CreatePercentValue(100)); 

                // Добавление текста в левую колонку
                Cell leftCell = new Cell();
                leftCell.Add(new Paragraph($"ПОКУПАТЕЛЬ"));
                leftCell.Add(new Paragraph($"{model.CompanyName}"));
                leftCell.SetTextAlignment(TextAlignment.CENTER);

                leftCell.SetBorder(Border.NO_BORDER); // Убираем границы, если нужно
                headerTable.AddCell(leftCell);

                // Добавление текста в правую колонку
                Cell rightCell = new Cell();
                rightCell.Add(new Paragraph($"ПОСТАВЩИК"));
                rightCell.Add(new Paragraph($"{_config.CompanyName}"));
                rightCell.SetTextAlignment(TextAlignment.CENTER);
                rightCell.SetBorder(Border.NO_BORDER);
                rightCell.SetFont(font);

                headerTable.AddCell(rightCell);
                document.Add(headerTable);

                Paragraph headerSender = new Paragraph($"РАЗДАТОЧНАЯ ВЕДОМОСТЬ")
                   .SetTextAlignment(TextAlignment.LEFT)
                   .SetFontSize(12)
                   .SetFont(font);
                document.Add(headerSender);

                Table centerTable = new Table(2);
                headerTable.SetWidth(UnitValue.CreatePercentValue(100));

                //Cell centerTableCell1 = new Cell();
                //centerTableCell1.Add(new Paragraph($"{model.Date.ToString("d")}"));
                //centerTableCell1.SetTextAlignment(TextAlignment.CENTER);
                //centerTableCell1.SetBorder(Border.NO_BORDER); // Убираем границы, если нужно
                //centerTable.AddCell(centerTableCell1);

                Cell centerTableCell2 = new Cell();
                centerTableCell2.Add(new Paragraph($"1 метркуб : {_config.Tarif} сум"));
                centerTableCell2.SetTextAlignment(TextAlignment.CENTER);
                centerTableCell2.SetBorder(Border.NO_BORDER); // Убираем границы, если нужно
                centerTable.AddCell(centerTableCell2);
                document.Add(centerTable);
                
                Table table = new Table(6, true);
                table.SetWidth(UnitValue.CreatePercentValue(100));
                
                var parahraph = new Paragraph(new Text("Дата"));

                Cell cell11 = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(parahraph)
                   .SetFont(font);

                   
                Cell cell12 = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("# машины"))
                   .SetFont(font);
                Cell cell13 = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("Куб"))
                   .SetFont(font);

                Cell cell14 = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("Сумма"))
                   .SetFont(font);
                
                Cell cell15 = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("Прописью"))
                   .SetFont(font);

                Cell cell16 = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("ФИО"))
                   .SetFont(font);

                


                table.AddCell(cell11);
                table.AddCell(cell12);
                table.AddCell(cell13);
                table.AddCell(cell14);
                table.AddCell(cell15);
                table.AddCell(cell16);

                var lastEntry = model.CustomerEntries.LastOrDefault();

                foreach (var entry in model.CustomerEntries)
                {

                    var date = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph(entry.CreatedDate.ToString("dd.MM.yyyy")))
                    .SetBorderBottom(new SolidBorder(1));

                    //if (lastEntry == entry)
                    //    table.AddFooterCell(date);
                    //else
                    table.AddCell(date);

                    var car = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetBorderBottom(new SolidBorder(1))
                        .Add(new Paragraph(entry.CarNumber));
                    table.AddCell(car);

                    var amount = new Cell(1, 1)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph($"{entry.Amount.ToString("N0", cultureInfo)}"))
                    .SetBorderBottom(new SolidBorder(1));
                    table.AddCell(amount);

                    var sum = new Cell(1, 1)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph($"{entry.Sum.ToString("N0", cultureInfo)}"))
                    .SetBorderBottom(new SolidBorder(1));
                    table.AddCell(sum);

                    var sumLetter = new Cell(1, 1)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph($"{entry.Sum.ToWords(culture: new CultureInfo("ru"))}"))
                    .SetBorderBottom(new SolidBorder(1));
                    table.AddCell(sumLetter);

                    var fio = new Cell(1,1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph(entry.FullName))
                        .SetBorderBottom(new SolidBorder(1));
                        table.AddCell(fio);

                }

                document.Add(table);

                #region Totals
                string totalAmount = totals.TotalAmount.ToString("N0", cultureInfo);
                Paragraph footerAmount = new Paragraph($"Общий кубометр: {totalAmount}")
                   .SetTextAlignment(TextAlignment.LEFT)
                   .SetFontSize(12)
                   .SetFont(font);
                document.Add(footerAmount);

                string totalSum = totals.TotalSum.ToString("N0", cultureInfo);
                Paragraph footerSum = new Paragraph($"Общая сумма: {totalSum} сум")
                   .SetTextAlignment(TextAlignment.LEFT)
                   .SetFontSize(12)
                   .SetFont(font);
                document.Add(footerSum);
                #endregion

                #region Sign
                Table footerTable = new Table(2);
                footerTable.SetWidth(UnitValue.CreatePercentValue(100));

                // Добавление текста в левую колонку
                Cell leftFCell = new Cell();
                leftFCell.Add(new Paragraph($"Дата: {model.Date.ToString("dd.MM.yyyy")}"));
                leftFCell.SetTextAlignment(TextAlignment.CENTER);

                leftFCell.SetBorder(Border.NO_BORDER);
                footerTable.AddCell(leftFCell);

                // Добавление текста в правую колонку
                Cell rightFCell = new Cell();
                rightFCell.Add(new Paragraph($"____________"));
                
                rightFCell.SetTextAlignment(TextAlignment.CENTER);
                rightFCell.SetBorder(Border.NO_BORDER);
                rightFCell.SetFont(font);

                footerTable.AddCell(rightFCell);
                document.Add(footerTable);
                #endregion

                document.Add(new Paragraph(""));
                document.Close();
                return true;
            }
            catch (Exception ex) {
                throw;
            } finally
            {
                // Закрываем документ
                

            }
        }
    }
}
