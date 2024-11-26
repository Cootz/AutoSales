using AutoSales.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Windows.Controls;

namespace AutoSales.ViewModel
{
    public partial class SalesViewModel : ObservableObject
    {
        private readonly AutoSalesDbContext context;

        public DatePicker? DatePicker { get; set; } = default!;
        
        public SalesViewModel(AutoSalesDbContext autoSalesDbContext) 
        { 
            context = autoSalesDbContext;

            UpdateSalesOverview();
        }

        [ObservableProperty]
        private ObservableCollection<SalesOverviewRow>? salesInfo;

        [RelayCommand]
        private void UpdateSalesOverview()
        {
            int searchYear = DatePicker?.SelectedDate!.Value.Year ?? 2024;

            var salesQuerry = context.Sales
                .Where(x => x.Date.Year == searchYear)
                .GroupBy(x => x.Car.Id)
                .Select(x => new SalesOverviewRow
                {
                    Model = x.First().Car.Model,
                    January = x.Where(sale => sale.Date.Month == 1).Sum(sale => sale.Price),
                    February = x.Where(sale => sale.Date.Month == 2).Sum(sale => sale.Price),
                    March = x.Where(sale => sale.Date.Month == 3).Sum(sale => sale.Price),
                    April = x.Where(sale => sale.Date.Month == 4).Sum(sale => sale.Price),
                    May = x.Where(sale => sale.Date.Month == 5).Sum(sale => sale.Price),
                    June = x.Where(sale => sale.Date.Month == 6).Sum(sale => sale.Price),
                    July = x.Where(sale => sale.Date.Month == 7).Sum(sale => sale.Price),
                    August = x.Where(sale => sale.Date.Month == 8).Sum(sale => sale.Price),
                    September = x.Where(sale => sale.Date.Month == 9).Sum(sale => sale.Price),
                    October = x.Where(sale => sale.Date.Month == 10).Sum(sale => sale.Price),
                    November = x.Where(sale => sale.Date.Month == 11).Sum(sale => sale.Price),
                    December = x.Where(sale => sale.Date.Month == 12).Sum(sale => sale.Price),
                });

            SalesInfo = new(salesQuerry);
        }

        [RelayCommand]
        public void ExportToExcel()
        {
            OpenFolderDialog folderDialog = new();

            if (folderDialog.ShowDialog() != true)
            {
                return;
            }

            string path = Path.Combine(folderDialog.FolderName, "AutoSalesOverview.xlsx");

            using var workbook = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook);
            WorkbookPart workbookPart = workbook.AddWorkbookPart();
            workbook.WorkbookPart!.Workbook = new Workbook();
            workbook.WorkbookPart.Workbook.Sheets = new Sheets();

            uint sheetId = 1;

            var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
            var sheetData = new SheetData();
            sheetPart.Worksheet = new Worksheet(sheetData);

            Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<Sheets>()!;
            string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

            if (sheets.Elements<Sheet>().Count() > 0)
            {
                sheetId =
                    sheets.Elements<Sheet>().Select(s => s.SheetId!.Value).Max() + 1;
            }

            Sheet sheet = new Sheet() { Id = relationshipId, SheetId = sheetId, Name = "SalesOverview" };
            sheets.Append(sheet);

            Row headerRow = new Row();

            List<string> columns =
                [
                nameof(SalesOverviewRow.Model),
                nameof(SalesOverviewRow.January),
                nameof(SalesOverviewRow.February),
                nameof(SalesOverviewRow.March),
                nameof(SalesOverviewRow.April),
                nameof(SalesOverviewRow.May),
                nameof(SalesOverviewRow.June),
                nameof(SalesOverviewRow.July),
                nameof(SalesOverviewRow.August),
                nameof(SalesOverviewRow.September),
                nameof(SalesOverviewRow.October),
                nameof(SalesOverviewRow.November),
                nameof(SalesOverviewRow.December),
                ];

            foreach (string columnName in columns)
            {
                addStringCell(columnName, headerRow);
            }

            sheetData.AppendChild(headerRow);

            foreach (SalesOverviewRow salesOverview in SalesInfo!)
            {
                Row newRow = new Row();

                addStringCell(salesOverview.Model, newRow);
                addDecimalCell(salesOverview.January, newRow);
                addDecimalCell(salesOverview.February, newRow);
                addDecimalCell(salesOverview.March, newRow);
                addDecimalCell(salesOverview.April, newRow);
                addDecimalCell(salesOverview.May, newRow);
                addDecimalCell(salesOverview.June, newRow);
                addDecimalCell(salesOverview.July, newRow);
                addDecimalCell(salesOverview.August, newRow);
                addDecimalCell(salesOverview.September, newRow);
                addDecimalCell(salesOverview.October, newRow);
                addDecimalCell(salesOverview.November, newRow);
                addDecimalCell(salesOverview.December, newRow);

                sheetData.AppendChild(newRow);
            }

            workbook.Save();

            void addStringCell(string value, Row row)
            {
                Cell cell = new Cell();
                cell.DataType = CellValues.String;
                cell.CellValue = new CellValue(value);
                row.AppendChild(cell);
            }
            void addDecimalCell(decimal value, Row row)
            {
                Cell cell = new Cell();
                cell.DataType = CellValues.Number;
                cell.CellValue = new CellValue(value);
                row.AppendChild(cell);
            }
        }
    }
}