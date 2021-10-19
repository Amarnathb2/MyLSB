using CMS;
using CMS.CustomTables;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.MacroEngine;
using Custom;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;
using System.Web;

[assembly: RegisterExtension(typeof(CustomMacroMethods), typeof(CustomMacro))]

namespace Custom
{
    public class CustomMacroMethods : MacroMethodContainer
    {
        [MacroMethod(typeof(CustomMacro), "Inserts the current date with different formatting options", 1)]
        [MacroMethodParam(0, "Format", typeof(string), "Date time formatting")]
        public static object CurrentDate(EvaluationContext context, params object[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new NotSupportedException();
            }

            string Format = ValidationHelper.GetString(parameters[0], "");
            return DateTime.Now.ToString(Format);
        }

        [MacroMethod(typeof(CustomMacro), "Returns selected value from JSON Table", 3)]
        [MacroMethodParam(0, "Table ID", typeof(int), "Indicate the integer ID of the table from which you want to pull data")]
        [MacroMethodParam(1, "Table Row", typeof(int), "Indicate the integer value of the row from which you want to pull data")]
        [MacroMethodParam(2, "Table Column", typeof(string), "Indicate the string NAME of the column from which you want to pull data")]
        public static object JsonTableData(EvaluationContext context, params object[] parameters)
        {
            // 113, 1, "Rate"
            // check params
            switch (parameters.Length)
            {
                case 3:
                    // this is what is required
                    return GetJsonTableItem(parameters);
                default:
                    throw new NotSupportedException();
            }
        }

        public static string GetJsonTableItem(params object[] parameters)
        {
            string cellValue = string.Empty;

            string nodeID = parameters[0].ToString();
            int row = Int32.Parse(parameters[1].ToString());
            string columnName = parameters[2].ToString();

            // get page
            var page = DocumentHelper.GetDocuments("custom.JsonTable")
                                     .WhereEquals("NodeID", nodeID)
                                     .PublishedVersion()
                                     .FirstOrDefault();

            if (page != null)
            {
                var jsonData = ValidationHelper.GetString(page.GetValue("JSONData"), "");
                // if jsondata isn't empty(it shouldn't be), get the data to a datatable
                if (jsonData != "")
                {
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsonData, (typeof(DataTable)));
                    // get column number from column name
                    var columnNames = dt.Columns.Cast<DataColumn>()
                                                    .Select(x => x.ColumnName)
                                                    .ToList();
                    int col = columnNames.IndexOf(columnName);
                    var percentCol = ValidationHelper.GetString(page.GetValue("JSONPercentCol"), "").Split(',');
                    try
                    {
                        cellValue = System.Net.WebUtility.UrlDecode(dt.Rows[row][columnName].ToString());
                    }
                    catch
                    {
                        try
                        {
                            cellValue = dt.Rows[row][columnName].ToString();
                        }
                        catch
                        {
                            cellValue = "N/A";
                        }
                    }
                    if (cellValue != "N/A" && percentCol.Contains(col.ToString()))
                    {
                        cellValue = cellValue + "%";
                    }
                }
            }

            return cellValue;
        }
    }
}
