<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="mini_project_full.Login" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size: 300%; margin-bottom:50px">Login</div>
    <div>
        user name: <input id="inUserName" type="text" runat="server">
    </div>
    <br />
    <div>
        password: <input id="inPassword" type="password" runat="server">
    </div>
    <button id="btnLogin" runat="server" onserverclick="btnLogin_ServerClick">Login</button>
    <div style="visibility:hidden; color:red" id="divError" runat="server">Wrong user name or password</div>
</asp:Content>
