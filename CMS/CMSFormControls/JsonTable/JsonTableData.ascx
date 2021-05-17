<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JsonTableData.ascx.cs" Inherits="CMSApp.CMSFormControls.JsonTable.JsonTableData" %>

<cms:CMSUpdatePanel ID="pnlUpdate" runat="server">
    <ContentTemplate>
        <asp:Label runat="server" ID="LoadingStatus" Text="Loading Data..." />
        <asp:HiddenField runat="server" ID="JsonTableDataString" Value="" />
    </ContentTemplate>
</cms:CMSUpdatePanel>