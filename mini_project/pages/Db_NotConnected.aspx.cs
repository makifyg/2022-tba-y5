using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full
{
    public partial class Db1 : System.Web.UI.Page
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|myDb.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "dbNotConnected";

            //הדף פתוח לכולם
            Session["isAuthorized"] = true;

            ShowAnimalTabel();
        }

        private void ShowAnimalTabel()
        {
            string command = "select * from animals";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command, connectionString);
            int count = adapter.Fill(dt);

            string htmlTable = getHtmlTableFromDataTable(dt);
            idAnimalsTable.InnerHtml = htmlTable;
        }

        protected void btnSelect_ServerClick(object sender, EventArgs e)
        {
            string command = idSelectAnimals.Value;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command, connectionString);
            int count = adapter.Fill(dt);

            string htmlTable = getHtmlTableFromDataTable(dt);
            idSelectResult.InnerHtml = htmlTable;
        }

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from animals where 1=0", connectionString);
            adapter.Fill(dt);

            DataRow dr = dt.NewRow();
            dr["name"] = inAnimalNameToAdd.Value;
            dr["type"] = inAnimalTypeToAdd.Value;
            dt.Rows.Add(dr);
            new SqlCommandBuilder(adapter);
            int rowsCount = adapter.Update(dt);

            idAddResult.InnerHtml = $"Success add {rowsCount} animal";
            ShowAnimalTabel();
        }

        protected void btnUpdate_ServerClick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string animalName = idNameToUpdate.Value;
            SqlDataAdapter adapter = new SqlDataAdapter($"select * from animals where name='{animalName}'", connectionString);
            adapter.Fill(dt);

            DataRow dr = dt.Rows[0];
            dr["type"] = idTypeToUpdate.Value;
            dr["isEndangered"] = idUpdateEndangered.Value;
            dr["size"] = idUpdateSize.Value;
            dr["estimation"] = idUpdateEstimation.Value;
            dr["updateDate"] = DateTime.Now;

            new SqlCommandBuilder(adapter);
            int rowsCount = adapter.Update(dt);

            idUpdateResult.InnerHtml = $"Success update {rowsCount} animal";
            ShowAnimalTabel();
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string animalName = idNameToDelete.Value;
            SqlDataAdapter adapter = new SqlDataAdapter($"select * from animals where name='{animalName}'", connectionString);
            adapter.Fill(dt);

            dt.Rows[0].Delete();
            new SqlCommandBuilder(adapter);
            int rowsCount = adapter.Update(dt);

            idDeleteResult.InnerHtml = $"Success delete {rowsCount} animal";
            ShowAnimalTabel();
        }

        string getHtmlTableFromDataTable(DataTable dt)
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

            for (int i = 0; i < dt.Rows.Count; i++)
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
    }
}