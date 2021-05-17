using CMS.DocumentEngine;
using CMS.FormEngine.Web.UI;
using CMS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMSApp.CMSFormControls.JsonTable
{
    public partial class JsonTableData : FormEngineUserControl
    {
        public override object Value { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> tableData = GetTableData();
                string joinedData = tableData.Join(";");
                JsonTableDataString.Value = joinedData;
                LoadingStatus.Text = "Table data loaded.";
            }
        }

        private List<string> GetTableData()
        {
            List<string> tableData = new List<string>();

            var pageQuery = DocumentHelper.GetDocuments("custom.JsonTable")
                                          .PublishedVersion();
            foreach(var page in pageQuery)
            {
                string pageName = page.GetDocumentName();
                string pageID = page.NodeID.ToString();
                string jsonTableDataString = ValidationHelper.GetString(page.GetValue("JSONData"), "");
                string data = pageName + "|" + pageID + "|"  + jsonTableDataString;
                tableData.Add(data);
            }

            return tableData;
        }
    }
}