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
        const string animalsTableName = "animals";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "dbAdvance";

            //הדף פתוח לכולם
            Session["isAuthorized"] = true;

            if (!IsPostBack)
                ShowEnireTable();
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
        protected void ShowEnireTable()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from animals", connectionString);
            int count = adapter.Fill(dt);

            string htmlTable = getHtmlTable(dt);
            idResultTable0.InnerHtml = htmlTable;
            idCountResult0.InnerHtml = count.ToString();
        }
        protected void btnRetrieveFromTable_ServerClick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(inSqlCommand.Value, connectionString);
            int count = adapter.Fill(dt);

            string htmlTable = getHtmlTable(dt);
            idResultTable1.InnerHtml = htmlTable;
            idCountResult1.InnerHtml = count.ToString();
            ShowEnireTable();
        }
        protected void btnAddAnimal_ServerClick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from animals where 1=0", connectionString);
            adapter.Fill(dt);

            DataRow dr = dt.NewRow();
            dr["name"] = inAnimalToAdd.Value;
            dr["type"] = inTypeToAdd.Value;
            dt.Rows.Add(dr);
            new SqlCommandBuilder(adapter);
            int rowsCount = adapter.Update(dt);

            idAddAnimal.InnerHtml = "Success add animal";
            idCountResult2.InnerHtml = rowsCount.ToString();
            ShowEnireTable();
        }

        protected void btnExecuteScalar_ServerClick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(inSqlCommand2.Value, con);
            con.Open();
            int n = (int)cmd.ExecuteScalar();
            con.Close();
            idCountResult3.InnerHtml = n.ToString();
        }

        protected void btnExecuteNonQuery_ServerClick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(inSqlCommand3.Value, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            idCountResult4.InnerHtml = result.ToString();
            ShowEnireTable();
        }

        protected void btnRetrieveAll_ServerClick(object sender, EventArgs e)
        {
            ShowEnireTable();
        }
    }
}