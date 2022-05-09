using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace mini_project_full
{
    public partial class DB : System.Web.UI.Page
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\myDb.mdf;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        const string sandboxTableName = "sandboxTable";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "db";

            if (!IsPostBack)
                ShowEnireTable();
        }

        protected void ShowEnireTable()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from sandboxTable", connectionString);
            adapter.Fill(dt);

            string htmlTable = getHtmlTable(dt);
            idResultTable.InnerHtml = htmlTable;
        }
        protected string getHtmlTable(DataTable dt) 
        { 
            string htmlTable = "<table border=1>";

            //הוספת שורה עליונה עם שמות השדות
            htmlTable += "<tr>";
            for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
            {
                htmlTable += "<th>";
                htmlTable += dt.Columns[colIndex].ColumnName;
                htmlTable += "</th>";
            }
            htmlTable += "</tr>";

            for (int i = 0; i<dt.Rows.Count; i++)
            {
                htmlTable += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    htmlTable += "<td>";
                    htmlTable += dt.Rows[i][j];
                    htmlTable += "</td>";
                }
                htmlTable += "</tr>";
            }
            htmlTable += "</table>";

            return htmlTable;
        }
        protected void btnRetrieveFromTable_ServerClick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(inSqlCommand.Value, connectionString);
            adapter.Fill(dt);

            string htmlTable = getHtmlTable(dt);
            idResultTable.InnerHtml = htmlTable;
        }
        protected void btnAddUser_ServerClick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from sandboxTable where 1=0", connectionString);
            adapter.Fill(dt);

            DataRow dr = dt.NewRow();
            dr["userName"] = inUserToAdd.Value;
            dr["password"] = inPasswordToAdd.Value;
            dt.Rows.Add(dr);
            new SqlCommandBuilder(adapter);
            int rowsCount = adapter.Update(dt);

            idAddUser.InnerHtml = "Success add user";

            ShowEnireTable();
        }

        protected void btnExecuteScalar_ServerClick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(inSqlCommand2.Value, con);
            con.Open();
            int n = (int)cmd.ExecuteScalar();
            con.Close();
            idCountResult.InnerHtml = n.ToString();
        }

        protected void btnExecuteNonQuery_ServerClick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(inSqlCommand3.Value, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            idCountResult2.InnerHtml = result.ToString();
            ShowEnireTable();
        }
    }
}