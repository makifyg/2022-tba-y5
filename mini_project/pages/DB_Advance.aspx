<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DB_Advance.aspx.cs" Inherits="mini_project_full.DB" %>
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
    <div id="idResultTable0" runat="server" class="withBorder" style="background-color:aqua"></div>
    <div id="idCountResult0" runat="server" style="margin-top: 20px"></div>
    <button id="btnRetrieveAll" runat="server" onserverclick="btnRetrieveAll_ServerClick" style="display: block">Retrieve All</button>

    <div class="withBorder">
        <div>[connected]</div>
        <textarea id="inSqlCommand" runat="server" rows="2" cols="100">select * from animals where name like '%e%'</textarea>
        <div class="withBorder">
            <script>
                function selectCommand() {
                    inSqlCommand.innerHTML = idSelectCommand.options[idSelectCommand.selectedIndex].innerHTML;
                }
            </script>
            <select id="idSelectCommand" runat="server" onchange="selectCommand();">
                <option>select * from animals</option>
                <option>select name, type from animals where type = 'birds' or type = 'reptiles'</option>
                <option>insert into animals (name, type) values('spider','insects'), ('shark','fish')</option>
                <option>update animals set isInDangers = 'false' where name='eagle'</option>
                <option>delete from animals where name = 'spider'</option>
            </select>
        </div>
        <button id="btnGetSomeFromTable" runat="server" onserverclick="btnRetrieveFromTable_ServerClick" style="display: block">Run Command</button>
        <div id="idResultTable1" runat="server" class="withBorder"></div>
        <div id="idCountResult1" runat="server" style="margin-top: 20px"></div>
    </div>

    <div class="withBorder">
        <div>[connected]</div>
        <span>Add new animal</span>        
        <input id="inAnimalToAdd" runat="server" placeholder="name"/>
        <input id="inTypeToAdd" runat="server" placeholder="type" />
        <button id="btnAddAnimal" runat="server" onserverclick="btnAddAnimal_ServerClick" style="display: block">Add Animal</button>
        <div id="idAddAnimal" runat="server" style="margin-top: 20px"></div>
        <div id="idCountResult2" runat="server" style="margin-top: 20px"></div>
    </div>

    <div class="withBorder">
        <div>[disconnected]</div>
        <textarea id="inSqlCommand2" runat="server" rows="2" cols="100">select count(id) from animals where type='mamals' and password='ab12'</textarea>
        <button id="btnExecuteScalar" runat="server" onserverclick="btnExecuteScalar_ServerClick" style="display: block">Execute Scalar</button>
        <div id="idCountResult3" runat="server" style="margin-top: 20px"></div>
    </div>

    <div class="withBorder">
        <div>[disconnected]</div>
        <textarea id="inSqlCommand3" runat="server" rows="2" cols="100">update animals set isInDanger='true' where name='eage'</textarea>
        <button id="btnExecuteNonQuery" runat="server" onserverclick="btnExecuteNonQuery_ServerClick" style="display: block">Execute NonQuery</button>
        <div id="idCountResult4" runat="server" style="margin-top: 20px"></div>
    </div>
</asp:Content>
