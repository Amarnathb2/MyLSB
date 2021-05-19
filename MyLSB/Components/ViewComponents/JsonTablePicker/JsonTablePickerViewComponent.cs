using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using Custom;
using MyLSB.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace MyLSB.Components
{
    public class JsonTablePickerViewComponent : ViewComponent
    {
        private readonly JsonTableRepository jsonTableRepository;

        public JsonTablePickerViewComponent(JsonTableRepository jsonTableRepository)
        {
            this.jsonTableRepository = jsonTableRepository;
        }

        public IViewComponentResult Invoke(JsonTablePicker node)
        {
            var jsonTablePickerModel = new JsonTablePickerModel()
            {
                NodeID = node.NodeID,
                Vc = node,
                ColumnNames = new List<string>(),
                Rows = new List<List<string>>(),
            };

            JsonTable Table = jsonTableRepository.GetJsonTable(node.TablePicker);
            if (Table != null)
            {
                dynamic json = JsonConvert.DeserializeObject(Table.JSONData);
                jsonTablePickerModel.ColumnNames = BuildColumnHeaders(json);
                jsonTablePickerModel.Rows = BuildTableRows(json, Table.JSONPercentCol);
            }

            if (node.TableDisplayType == "comparison")
            {
                return View("~/Components/ViewComponents/JsonTablePicker/JsonTablePickerComparison.cshtml", jsonTablePickerModel);
            }

            return View("~/Components/ViewComponents/JsonTablePicker/JsonTablePicker.cshtml", jsonTablePickerModel);
        }

        public List<string> BuildColumnHeaders(dynamic json)
        {
            List<string> ColumnNames = new List<string>();
            foreach (var Data in json[0])
            {
                string DataDecode = HttpUtility.UrlDecode(Data.Name);
                string DataMacros = CMS.MacroEngine.MacroResolver.Resolve(DataDecode);
                ColumnNames.Add(DataMacros);
            }
            return ColumnNames;
        }

        public List<List<string>> BuildTableRows(dynamic json, string percentColumns)
        {
            List<List<string>> Rows = new List<List<string>>();
            foreach (var Row in json)
            {
                List<string> row = new List<string>();
                int count = 0;

                foreach (string Data in Row)
                {
                    string DataDecode = HttpUtility.UrlDecode(Data);
                    string DataMacros = CMS.MacroEngine.MacroResolver.Resolve(DataDecode);
                    string DataPercent = percentColumns.Contains(count.ToString()) ? DataMacros + "%" : DataMacros;
                    row.Add(DataPercent);
                    count++;
                }
                Rows.Add(row);
            }

            return Rows;
        }
    }
}