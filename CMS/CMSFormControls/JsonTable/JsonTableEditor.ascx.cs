using CMS.CustomTables;
using CMS.FormEngine.Web.UI;
using CMS.Helpers;
using CMS.DocumentEngine;
using CMS.DataEngine;
using CMS.WorkflowEngine;
using CMS.Membership;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSApp.CMSFormControls.JsonTable
{
    public partial class JsonTableEditor : FormEngineUserControl
    {
        #region "Properties"

        public override object Value { get; set; }
        public static string JSONData { get; set; }

        #endregion

        #region "Methods"
        protected void Page_Load(object sender, EventArgs e)
        {
            Form.OnBeforeSave += BeforeValidateHandler;
            var jsonValue = ValidationHelper.GetString(Form.GetFieldValue("JSONData"), null);
            JSONData = jsonValue;
            json.Value = jsonValue;
            var checkedCols = ValidationHelper.GetString(Form.GetFieldValue("JSONPercentCol"), null);
            percentCk.Value = checkedCols;
        }

        /// <summary>
        /// Returns true if user control is valid.
        /// </summary>
        public override bool IsValid()
        {
            // check to make sure no errors
            var errorTxt = errorField.Value;
            if (!string.IsNullOrEmpty(errorTxt) && errorTxt != "")
            {
                errorTxt = errorTxt.Replace("<br />", " ");
                this.ValidationError = errorTxt + ". The cells with errors have been reverted to the previously saved values.";
                return false;
            }

            return true;
        }

        private void BeforeValidateHandler(object sender, EventArgs e)
        {
            // check to make sure no errors
            var errorTxt = errorField.Value;
            if (!string.IsNullOrEmpty(errorTxt) && errorTxt != "")
            {
                errorTxt = errorTxt.Replace("<br />", " ");
                this.StopProcessing = true;
            }
            else
            {
                // grab json and set page value
                //var jsonVal = json.Value.ToString();
                //jsonVal = CleanJSON(jsonVal);
                var jsonID = json.ClientID.Replace("_", "$");
                var jsonChanged = Request.Params[jsonID];
                json.Value = jsonChanged;
                var objList = JsonConvert.DeserializeObject<JArray>(jsonChanged).ToObject<List<JObject>>();
                JSONData = JsonConvert.SerializeObject(objList);
                Form.Data.SetValue("JSONData", JSONData);

                // now do the same for the percent column values
                var pctCkID = percentCk.ClientID.Replace("_", "$");
                var percentCkChanged = Request.Params[pctCkID];
                percentCk.Value = percentCkChanged;
                Form.Data.SetValue("JSONPercentCol", percentCkChanged);
            }
        }

        /// <summary>
        /// Content loaded event handler.
        /// </summary>
        public override void OnContentLoaded()
        {
            base.OnContentLoaded();
            SetupControl();
        }


        /// <summary>
        /// Initializes the control properties.
        /// </summary>
        protected void SetupControl()
        {
            if (this.StopProcessing)
            {
                // Do not process
            }
            else
            {

            }
        }

        #endregion

        #region Common Controls

        private bool IsNull(dynamic item)
        {
            if (item == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        private string CleanJSON(string rawJson)
        {
            string cleanJson = rawJson.Replace("&quot;", "\"");
            return cleanJson;
        }
    }
}