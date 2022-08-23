using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace EstimateV2.Core.Excel
{
    public class TOR
    {
        public static void Main()
        {
            List<String> categories;
            List<String> companies;
            ExtractCategoriesCompanies("MSC MICHAELA IX227R USBAL FINAL TOR.xlsx", out categories, out companies);

            // Testing ClosedXML Library for Extracting from TOR and Port Log
        }

        private static void ExtractCategoriesCompanies(string torXlsx, out List<string> categories, out List<string> companies)
        {
            categories = new List<string>();
            const int coCategoryId = 1;
            const int coCategoryName = 2;

            var wb = new XLWorkbook(torXlsx);
            var ws = wb.Worksheet("Master TOR");

            //Test - Search for starting point (Starting row is not always consistant) - unexpected output 
            var list = ws.Search("Vessel", CompareOptions.OrdinalIgnoreCase);

            var foundCells = ws.Search("Vessel", CompareOptions.OrdinalIgnoreCase).FirstOrDefault().Value.ToString();
            System.Diagnostics.Debug.WriteLine(foundCells);

            foreach (var item in list)
            {
                System.Diagnostics.Debug.WriteLine(item.Value.ToString());
            }

            ws.CellsUsed(cell => cell.GetString() == "Vessel");


            //Test - Search for starting point - Temp Fix
            var foundCell = ws.Search("Vessel", CompareOptions.None).FirstOrDefault();
            System.Diagnostics.Debug.WriteLine("@@@@@@@@@@"+ foundCell.Value.ToString());

            // Look for the first row used
            var firstRowUsed = foundCell.WorksheetRow();

            // Narrow down the row so that it only includes the used part
            var categoryRow = firstRowUsed.RowUsed();

            // Move to the next row (it now has the titles)
            categoryRow = categoryRow.RowBelow();



            //// Get all categories
            //while (!categoryRow.Cell(coCategoryId).IsEmpty())
            //{
            //    String categoryName = categoryRow.Cell(coCategoryName).GetString();
            //    categories.Add(categoryName);

            //    categoryRow = categoryRow.RowBelow();
            //}

            //// There are many ways to get the company table.
            //// Here we're using a straightforward method.
            //// Another way would be to find the first row in the company table
            //// by looping while row.IsEmpty()

            //// First possible address of the company table:
            //var firstPossibleAddress = ws.Row(categoryRow.RowNumber()).FirstCell().Address;
            //// Last possible address of the company table:
            //var lastPossibleAddress = ws.LastCellUsed().Address;

            //// Get a range with the remainder of the worksheet data (the range used)
            //var companyRange = ws.Range(firstPossibleAddress, lastPossibleAddress).RangeUsed();

            //// Treat the range as a table (to be able to use the column names)
            //var companyTable = companyRange.AsTable();

            //// Get the list of company names
            //companies = companyTable.DataRange.Rows()
            //  .Select(companyRow => companyRow.Field("Company Name").GetString())
            //  .ToList();



            companies = new List<string>();
        }
    }
}
