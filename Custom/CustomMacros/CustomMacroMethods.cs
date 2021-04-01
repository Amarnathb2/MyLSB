using CMS;
using CMS.CustomTables;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.MacroEngine;
using Custom;
using Custom.CustomMacros;
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

        [MacroMethod(typeof(string), "Returns selected value from JSON Table", 3)]
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

        static string GetJsonTableItem(params object[] parameters)
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
                }
            }

            return cellValue;
        }
    }
}
