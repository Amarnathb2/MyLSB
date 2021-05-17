<%@ Control Language="C#" AutoEventWireup="true" 
    CodeBehind="JsonTablePicker.ascx.cs" Inherits="CMSApp.CMSFormControls.JsonTable.JsonTablePicker" %>
<%@ Register Src="~/CMSAdminControls/UI/UniSelector/UniSelector.ascx" TagName="UniSelector"
    TagPrefix="cms" %>
<cms:CMSUpdatePanel ID="pnlUpdate" runat="server">
    <ContentTemplate>
        <cms:UniSelector ID="uniSelector" runat="server" AllowEditTextBox="true" DisplayNameFormat="{%DocumentName%}"
            ReturnColumnName="DocumentForeignKeyValue" ObjectType="cms.document" 
            WhereCondition="classname='custom.JsonTable' AND ([DocumentCanBePublished] = 1 AND ([DocumentPublishFrom] IS NULL OR [DocumentPublishFrom] <= GETDATE()) AND ([DocumentPublishTo] IS NULL OR [DocumentPublishTo] >= GETDATE()))" SelectionMode="SingleDropDownList" AllowEmpty="false" />
    </ContentTemplate>
</cms:CMSUpdatePanel>