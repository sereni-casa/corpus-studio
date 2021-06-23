using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace CorpusStudio
{
    public static class Excel
    {
        public static void ExportXlsx(IEnumerable<KeyValuePair<string, int>> results)
        {
            SaveFileDialog dialog = new() { DefaultExt = ".xlsx", Filter = "Excel 工作簿|*.xlsx" };
            if (dialog.ShowDialog() != true) return;
            while (File.Exists(dialog.FileName))
            {
                try
                {
                    File.Delete(dialog.FileName);
                }
                catch (Exception)
                {

                    if (MessageBox.Show($"无法删除原有文件：{dialog.FileName}\r\n是否重试？", "覆盖文件", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
                }
            }

            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(dialog.FileName, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());

            Sheet sheet = new() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "串频统计" };
            sheets.Append(sheet);

            SharedStringTablePart shareStringPart = spreadsheetDocument.WorkbookPart.AddNewPart<SharedStringTablePart>();
            shareStringPart.SharedStringTable = new SharedStringTable();

            InsertText("字符串", "A", 1, worksheetPart, shareStringPart);
            InsertText("频次", "B", 1, worksheetPart, shareStringPart);

            for (int i = 0; i < results.Count(); i++)
            {
                InsertText(results.ElementAt(i).Key, "A", (uint)i + 2, worksheetPart, shareStringPart);
                InsertNumber(results.ElementAt(i).Value, "B", (uint)i + 2, worksheetPart, shareStringPart);
            }

            workbookpart.Workbook.Save();
            spreadsheetDocument.Close();
        }


        // Given a document name and text, 
        // inserts a new work sheet and writes the text to cell "A1" of the new worksheet.
        public static void InsertText(string text, string columnName, uint rowIndex, WorksheetPart worksheetPart, SharedStringTablePart shareStringPart)
        {
            // Insert the text into the SharedStringTablePart.
            int index = InsertSharedStringItem(text, shareStringPart);

            // Insert cell A1 into the new worksheet.
            Cell cell = InsertCellInWorksheet(columnName, rowIndex, worksheetPart);

            // Set the value of cell A1.
            cell.CellValue = new CellValue(index.ToString());
            cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
        }

        public static void InsertNumber(int number, string columnName, uint rowIndex, WorksheetPart worksheetPart, SharedStringTablePart shareStringPart)
        {
            // Insert cell A1 into the new worksheet.
            Cell cell = InsertCellInWorksheet(columnName, rowIndex, worksheetPart);

            // Set the value of cell A1.
            cell.CellValue = new CellValue(number.ToString());
            cell.DataType = new EnumValue<CellValues>(CellValues.Number);
        }


        // Given text and a SharedStringTablePart, creates a SharedStringItem with the specified text 
        // and inserts it into the SharedStringTablePart. If the item already exists, returns its index.
        private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }

        // Given a column name, a row index, and a WorksheetPart, inserts a cell into the worksheet. 
        // If the cell already exists, returns it. 
        private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // If there is not a cell with the specified column name, insert one.  
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }

                Cell newCell = new Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);

                worksheet.Save();
                return newCell;
            }
        }
    }
}
