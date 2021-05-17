using CMS.Taxonomy;
using System.Collections.Generic;
using CMS.DocumentEngine.Types.Custom;

namespace MyLSB.Components
{
    public class JsonTablePickerModel
    {
        public JsonTablePicker Vc { get; set; }
        public List<string> ColumnNames { get; set; }
        public List<List<string>> Rows { get; set; }
    }
}