using CMS.CustomTables;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.FormEngine.Web.UI;
using CMS.Helpers;
using CMS.SiteProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace CMSApp.CMSFormControls.JsonTable
{
    public partial class JsonTableCellPicker : FormEngineUserControl
    {
        #region "Public properties"

        /// <summary>
        /// Gets custom table class name
        /// </summary
        public string CustomTable
        {
            get
            {
                return ValidationHelper.GetString(this.GetOtherValue("CustomTable"), null);
            }
        }

        /// <summary>
        /// Gets select column name
        /// </summary>
        public string SelectColumnName
        {
            get
            {
                return ValidationHelper.GetString(GetOtherValue("SelectColumnName"), null);
            }
        }

        /// <summary>
        /// Gets or sets the selected item id
        /// </summary>
        public int Row
        {
            get
            {
                return ValidationHelper.GetInteger(GetOtherValue("Row"), 0);
            }
            set
            {
                SelectedRow.Value = value.ToString();
            }
        }

        /// <summary>
        /// Gets or stes the value that indicates whether selector should display 
        /// all custom tables without restriction to the current site.
        /// </summary>
        public bool AllSites
        {
            get
            {
                return ValidationHelper.GetBoolean(GetValue("AllSites"), false);
            }
            set
            {
                SetValue("AllSites", value);
            }
        }

        /// <summary>
        /// Gets or sets the enabled state of the control.
        /// </summary>
        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                if (uniSelector != null)
                    uniSelector.Enabled = value;
            }
        }


        /// <summary>
        /// Gets or sets the field value.
        /// </summary>
        public override object Value
        {
            get
            {
                List<string> values = new List<string>();
                values.Add(ValidationHelper.GetString(uniSelector.Value, ""));
                values.Add(ValidationHelper.GetString(SelectedRow.Value, "0"));
                values.Add(ValidationHelper.GetString(SelectColumnNameValue.Value, ""));

                return values.Join(";");
            }
            set
            {
                List<string> values = ValidationHelper.GetString(value, "").Split(';').ToList();
                if (values.Count == 3)
                {
                    uniSelector.Value = values[0];
                    SelectedRow.Value = values[1];
                    SelectColumnNameValue.Value = values[2];
                }
            }
        }

        /// <summary>
        /// Returns an array of values of any other fields returned by the control.
        /// </summary>
        /// <returns>It returns an array where the first dimension is the attribute name and the second is its value.</returns>
        public override object[,] GetOtherValues()
        {
            object[,] array = new object[3, 2];
            array[0, 0] = "Row";
            array[0, 1] = SelectedRow.Value;
            array[1, 0] = "CustomTable";
            array[1, 1] = uniSelector.Value.ToString();
            array[2, 0] = "SelectColumnName";
            array[2, 1] = SelectColumnNameValue.Value;
            return array;
        }

        #endregion



        #region "Page events"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (StopProcessing)
            {
                uniSelector.StopProcessing = true;
            }
            else
            {
                if (!this.IsPostBack)
                {
                    LoadColumnNames();
                    ReturnValueLabel.Text = GetReturnValue();

                    EnsureItems();
                    uniSelector.DropDownSingleSelect.AutoPostBack = true;
                }
            }
        }

        protected void uniSelector_OnSelectionChanged(object sender, EventArgs e)
        {
            this.Row = -1;
            LoadColumnNames();
            ReturnValueLabel.Text = GetReturnValue();
        }

        protected void ReturnColumnSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectColumnNameValue.Value = ((DropDownList)sender).SelectedValue;
            ReturnValueLabel.Text = GetReturnValue();
        }

        protected void CustomTableDataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedRow.Value = CustomTableDataGrid.SelectedRow.RowIndex.ToString();
            LoadColumnNames();
            ReturnValueLabel.Text = GetReturnValue();
        }

        protected void CustomTableDataGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rowView = (DataRowView)e.Row.DataItem;
                if (rowView != null && ValidationHelper.GetInteger(rowView["Row"].ToString(), 0) == this.Row)
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#1175ae");
                    e.Row.ForeColor = System.Drawing.Color.WhiteSmoke;
                }
                else
                {
                    //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(CustomTableDataGrid, "SelectRow$" + e.Row.RowIndex);
                    e.Row.ToolTip = "Click to select this row.";

                    e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#d0e8ed'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
                }
            }
        }

        protected void LoadColumnNames()
        {
            if (string.IsNullOrEmpty(this.CustomTable) || this.CustomTable == "0")
            {
                CustomTableDataGrid.DataBind();
                SelectColumnDropDown.Enabled = false;
                return;
            }
            else
            {
                // get json data from page
                var page = DocumentHelper.GetDocuments("custom.JsonTable")
                                         .WhereEquals("NodeID", this.CustomTable)
                                         .PublishedVersion()
                                         .FirstOrDefault();
                var jsonData = ValidationHelper.GetString(page.GetValue("JSONData"), "");
                // if jsondata isn't empty(it shouldn't be), get the data to a datatable
                if (jsonData != "")
                {
                    SelectColumnDropDown.Enabled = true;
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsonData, (typeof(DataTable)));
                    // get column names before adding row number column
                    var columnNames = dt.Columns.Cast<DataColumn>()
                                                .Select(x => x.ColumnName)
                                                .ToList();
                    
                    // rename any h# column names
                    foreach (var colName in columnNames)
                    {
                        if (colName.Length == 2 && colName.Substring(0, 1) == "h")
                        {
                            var colIdx = colName.Substring(1, 1);
                            var colHeader = $"EmptyHeader{colIdx}";
                            dt.Columns[colName].ColumnName = colHeader;
                        }
                    }
                    
                    columnNames.Insert(0, "(default)");
                    DataColumn newCol = new DataColumn("Row", typeof(string));
                    dt.Columns.Add(newCol);
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Row"] = i.ToString();
                        i++;
                    }
                    dt.Columns["Row"].SetOrdinal(0);
                    CustomTableDataGrid.DataSource = dt;
                    CustomTableDataGrid.DataBind();

                    
                    SelectColumnDropDown.DataSource = columnNames;
                    SelectColumnDropDown.DataBind();

                    ListItem selectedItem = null;
                    bool parsed = Int32.TryParse(SelectColumnName, out int idx);
                    if (parsed)
                    {
                        selectedItem = SelectColumnDropDown.Items.FindByValue(columnNames[idx]);
                    }
                    else
                    {
                        if (SelectColumnName != "(default)")
                        {
                            selectedItem = SelectColumnDropDown.Items.FindByValue(SelectColumnName);
                        }
                        else
                        {
                            selectedItem = null;
                        }
                    }
                    
                    if (selectedItem != null)
                        selectedItem.Selected = true;
                }
            }
        }

        protected string GetReturnValue()
        {
            string rate = "Unknown";

            // get json data from page
            var page = DocumentHelper.GetDocuments("custom.JsonTable")
                                        .WhereEquals("NodeID", this.CustomTable)
                                        .PublishedVersion()
                                        .FirstOrDefault();
            if (SelectColumnName != "(default)")
            {
                if (page != null)
                {
                    var jsonData = ValidationHelper.GetString(page.GetValue("JSONData"), "");
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsonData, (typeof(DataTable)));
                    var columnNames = dt.Columns.Cast<DataColumn>()
                                                    .Select(x => x.ColumnName)
                                                    .ToList();
                    int idx;
                    bool parsed = Int32.TryParse(SelectColumnName, out idx);
                    int col;
                    if (parsed)
                    {
                        col = idx;
                    }
                    else
                    {
                        col = columnNames.IndexOf(SelectColumnName);
                    }
                    // col is set at this point. check to see if col is in JSONPercentCol field
                    var percentCol = ValidationHelper.GetString(page.GetValue("JSONPercentCol"), "").Split(',');

                    int row;
                    bool rowParsed = Int32.TryParse(SelectedRow.Value, out row);
                    if (rowParsed && row >= 0)
                    {
                        try
                        {
                            rate = dt.Rows[row][col].ToString();
                            if (percentCol.Contains(col.ToString()))
                            {
                                rate = rate + "%";
                            }
                        }
                        catch
                        {
                            rate = "Selected cell no longer exists";
                        }
                    }
                }
            }
            return rate;

        }
        #endregion

        protected override void EnsureChildControls()
        {
            if (uniSelector == null)
            {
                pnlUpdate.LoadContainer();
            }
            base.EnsureChildControls();
        }

        /// <summary>
        /// Sets up the internal controls.
        /// </summary>
        protected void EnsureItems()
        {
            if (!string.IsNullOrEmpty(CustomTable))
                uniSelector.Value = CustomTable;
        }

        /// <summary>
        /// Returns true if user control is valid.
        /// </summary>
        public override bool IsValid()
        {
            if (this.CustomTable != "0" && this.Row < 0)
            {
                this.ValidationError = "No value selected";
                return false;
            }
            if (this.CustomTable == "0")
            {
                this.ValidationError = "No table selected";
                return false;
            }
            if (this.SelectColumnName == "(default)")
            {
                this.ValidationError = "No column selected";
                return false;
            }

            return true;
        }
    }
}