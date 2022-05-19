<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormValidation.aspx.cs" Inherits="mini_project_full.pages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/myProjectCode.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><input id="idField1" runat="server" /></div>
    <div><input id="idField2" runat="server" /></div>
    <div><button id="btn1" runat="server" onclick="if (!validateAllFields()) return false;" onserverclick="btn1_ServerClick">Run</button></div>
    <div id="idIsValid" runat="server"></div>
</asp:Content>
