using CMS.DocumentEngine.Types.Custom;
using Custom;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace MyLSB.Components
{
    public class JsonTableCellPickerViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(VcJsonTableCellPicker node)
        {
            var jsonTableCellPickerModel = new JsonTableCellPickerModel()
            {
                Vc = node,
                FormattedRate = GetFormattedRate(node)
            };

            return View("/Components/ViewComponents/JsonTableCellPicker/JsonTableCellPicker.cshtml", jsonTableCellPickerModel);
        }

        public string GetFormattedRate(VcJsonTableCellPicker node)
        {
            var rateValues = node.Rate.Split(';');
            var formattedRate = "";
            if (rateValues.Length == 3)
            {
                object[] objects = (object[])rateValues;

                try
                {
                    formattedRate = HttpUtility.UrlDecode(CustomMacroMethods.GetJsonTableItem(objects));
                }
                catch
                {
                    formattedRate = CustomMacroMethods.GetJsonTableItem(objects);
                }
            }

            return formattedRate;
        }
    }
}
