<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="page3.aspx.cs" Inherits="mini_project_full.page3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size: 300%">Page 3</div>

    <br />
    <div>
        <button id="btnClickCount" runat="server" onserverclick="btnClickCount_ServerClick">Click Count</button>
        <div id="divClickCount" runat="server" style="margin-block: 30px;display:inline">0</div>
    </div>
</asp:Content>
