using Common.Enums;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utility.Extensions;

namespace Utility.Excel
{
    public static class ExcelUtility
    {

        public async static Task<List<T>> ConvertFileToDeserilizingAsync<T>(this IFormFile file) where T : new()
        {

            var newFile = new FileInfo(file.FileName);
            var fileExtension = newFile.Extension;
            var dataTable = new DataTable();
            if (fileExtension.Contains(".xls"))
            {
                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                using var doc = SpreadsheetDocument.Open(stream, false);


                var sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                var worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                var rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                foreach (var row in rows)
                {
                    if (row.RowIndex.Value == 1)
                    {
                        foreach (var cell in row.Descendants<Cell>())
                        {
                            dataTable.Columns.Add(GetValue(doc, cell));
                        }
                    }
                    else
                    {
                        dataTable.Rows.Add();

                        for (int i = 0; i < row.Descendants<Cell>().Count(); i++)// added code
                        {
                            Cell cell = row.Descendants<Cell>().ElementAt(i);
                            int actualCellIndex = CellReferenceToIndex(cell);

                            dataTable.Rows[^1][actualCellIndex] = GetValue(doc, cell);
                        }
                    }
                }
            }
            return dataTable.CreateListFromTable<T>();
        }


        private static string GetValue(SpreadsheetDocument doc, Cell cell)
        {
            var value = cell?.CellValue?.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }
            else if (cell.StyleIndex != null) // number & dates. added code
            {
                if (doc.WorkbookPart.WorkbookStylesPart.Stylesheet.CellFormats.ChildElements[
                    int.Parse(cell.StyleIndex.InnerText)] is CellFormat cellFormat)
                {
                    var formatMethodId = cellFormat.NumberFormatId.Value;

                    if (formatMethodId == (uint)ExcelDataTypeEnums.DateShort || formatMethodId == (uint)ExcelDataTypeEnums.DateLong)
                    {
                        if (double.TryParse(cell.InnerText, out double oaDate))
                        {
                            value = DateTime.FromOADate(oaDate).ToShortDateString();
                        }
                    }
                    return value;

                }
            }
            return value;
        }
        private static int CellReferenceToIndex(Cell cell) // added code for empty cell
        {
            int index = 0;
            string reference = cell.CellReference.ToString().ToUpper();
            foreach (char ch in reference)
            {
                if (Char.IsLetter(ch))
                {
                    int value = (int)ch - (int)'A';
                    index = (index == 0) ? value : ((index + 1) * 26) + value;
                }
                else
                {
                    return index;
                }
            }
            return index;
        }

    }
}
