<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DB.aspx.cs" Inherits="mini_project_full.DB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .withBorder{
            border:solid;
            border-width:thin;
            margin-top: 30px;
            background-color:cadetblue;
            width:600px;
        }
        textarea{
            width:95%;
            margin:10px;
            background-color:antiquewhite;
        }
        button, span, input{
            margin:10px;
        }
        table{
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="idResultTable" runat="server" class="withBorder" style="background-color:aqua"></div>

    <div class="withBorder">
        <textarea id="inSqlCommand" runat="server" rows="2" cols="100">select * from sandboxTable where username like '%us%'</textarea>
        <button id="btnGetSomeFromTable" runat="server" onserverclick="btnRetrieveFromTable_ServerClick" style="display: block">Run Command</button>
    </div>

    <div class="withBorder">
        <span>Add new user</span>        
        <input id="inUserToAdd" runat="server" placeholder="user name"/>
        <input id="inPasswordToAdd" runat="server" placeholder="password" />
        <button id="btnAddUser" runat="server" onserverclick="btnAddUser_ServerClick" style="display: block">Add User</button>
        <div id="idAddUser" runat="server" style="margin-top: 20px"></div>
    </div>

    <div class="withBorder">
        <textarea id="inSqlCommand2" runat="server" rows="2" cols="100">select count(id) from sandboxTable  where username='user3' and password='ab12'</textarea>
        <button id="btnExecuteScalar" runat="server" onserverclick="btnExecuteScalar_ServerClick" style="display: block">Execute Scalar</button>
        <div id="idCountResult" runat="server" style="margin-top: 20px"></div>
    </div>

    <div class="withBorder">
        <textarea id="inSqlCommand3" runat="server" rows="2" cols="100">update sandboxTable set password='123456789' where userName='user2'</textarea>
        <button id="btnExecuteNonQuery" runat="server" onserverclick="btnExecuteNonQuery_ServerClick" style="display: block">Execute NonQuery</button>
        <div id="idCountResult2" runat="server" style="margin-top: 20px"></div>
    </div>
</asp:Content>
