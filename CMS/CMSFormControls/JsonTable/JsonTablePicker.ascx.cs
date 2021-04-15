using System;

using CMS.Base.Web.UI;
using CMS.DataEngine;
using CMS.FormEngine.Web.UI;
using CMS.Helpers;
using CMS.MacroEngine;
using CMS.SiteProvider;
using CMS.UIControls;

namespace CMSApp.CMSFormControls.JsonTable
{
    public partial class JsonTablePicker : FormEngineUserControl
    {

        /// <summary>
        /// Gets or sets the field value.
        /// </summary>
        public override object Value
        {
            get
            {
                return uniSelector.Value;
            }
            set
            {
                if (uniSelector == null)
                {
                    pnlUpdate.LoadContainer();
                }
                uniSelector.Value = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}