<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JsonTableCellPicker.ascx.cs" Inherits="CMSApp.CMSFormControls.JsonTable.JsonTableCellPicker" %>
<%@ Register Src="~/CMSAdminControls/UI/UniSelector/UniSelector.ascx" TagName="UniSelector" TagPrefix="cms" %>

<style>
    .row-selector-container {
        max-width: 550px !important;
        max-height: 300px !important;
        overflow-x: auto;
        overflow-y: auto;
        margin-bottom: 20px;
    }

    .row-selector {
        border: 2px solid #bdbbbb;
        border-radius: 3px;
        box-sizing: border-box;
        transition: border-color ease-in-out .15s, box-shadow ease-in-out 1.5s;
    }

        .row-selector th {
            background-color: #e5e5e5;
            padding: 4px 8px;
        }

        .row-selector td {
            padding: 4px 8px;
        }

</style>
<cms:CMSUpdatePanel ID="pnlUpdate" runat="server">
    <ContentTemplate>
        <strong>Table<br /></strong>
        <cms:UniSelector ID="uniSelector" runat="server" AllowEditTextBox="true" DisplayNameFormat="{%DocumentName%}"
            ReturnColumnName="NodeID" ObjectType="cms.document" WhereCondition="classname='custom.JsonTable' AND ([DocumentCanBePublished] = 1 AND ([DocumentPublishFrom] IS NULL OR [DocumentPublishFrom] <= GETDATE()) AND ([DocumentPublishTo] IS NULL OR [DocumentPublishTo] >= GETDATE()))" AllowDefault="true"
            SelectionMode="SingleDropDownList" OnOnSelectionChanged="uniSelector_OnSelectionChanged" AllowEmpty="true" /><br />
        
        <strong>Column Selector<br /></strong>
        <asp:HiddenField ID="SelectColumnNameValue" Value="0" runat="server" />
        <asp:DropDownList ID="SelectColumnDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ReturnColumnSelector_SelectedIndexChanged" CssClass="DropDownField form-control"></asp:DropDownList><br /><br />

        <asp:HiddenField ID="SelectedRow" Value="0" runat="server" />
        <strong>Row Selector<br /></strong>
        <div class="row-selector-container">
            <asp:GridView ID="CustomTableDataGrid" CssClass="row-selector" OnSelectedIndexChanged="CustomTableDataGrid_SelectedIndexChanged" DataKeyNames="Row"
                AutoGenerateSelectButton="true" OnRowDataBound="CustomTableDataGrid_RowDataBound" AutoGenerateColumns="true" GridLines="Horizontal"  runat="server">
                <EmptyDataTemplate>
                    Select a rate table above.
                </EmptyDataTemplate>
        </asp:GridView>
        </div>
        
        <strong>Return Value:</strong> <asp:Label ID="ReturnValueLabel" runat="server"></asp:Label>
    </ContentTemplate>
</cms:CMSUpdatePanel>

<script>
    function pageLoad(sender, args) {
        decodeText();
    }

    $cmsj('#<%=CustomTableDataGrid.ClientID%> tr td').on('change', function () {
        decodeText();
    });

    function decodeText() {
        var search = '#<%=CustomTableDataGrid.ClientID%> tr td';
        $cmsj(search).each(function () {
            var data = $cmsj(this).html();
            var dataOut = "";
            try {
                dataOut = decodeURIComponent(data);
            }
            catch{
                dataOut = data;
            }
            $cmsj(this).html(dataOut);
        });
        search = '#<%=CustomTableDataGrid.ClientID%> tr th';
        $cmsj(search).each(function () {
            var data = $cmsj(this).html();
            var dataOut = "";
            try {
                dataOut = decodeURIComponent(data);
            }
            catch{
                dataOut = data;
            }
            $cmsj(this).html(dataOut);
        });
        search = '#<%=SelectColumnDropDown.ClientID%> option';
        $cmsj(search).each(function () {
            var data = $cmsj(this).html();
            var dataOut = "";
            try {
                dataOut = decodeURIComponent(data);
            }
            catch{
                dataOut = data;
            }
            $cmsj(this).html(dataOut);
        });
        var rtnVal = $cmsj('#<%=ReturnValueLabel.ClientID%>');
        var rtnHtml = rtnVal.text();
        var rtnHtmlOut = "";
        try {
            rtnHtmlOut = decodeURIComponent(rtnHtml);
        }
        catch {
            rtnHtmlOut = rtnHtml;
        }
        rtnVal.text(rtnHtmlOut);
    }
</script>
