using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full
{
    public partial class Admin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*השמת ערך של הדף הנוכחי ב 
               * Session
               */
            Session["currentPage"] = "admin1";

            //Admin הדף פתוח רק ל
            if ((bool)Session["isAdmin"])
                Session["isAuthorized"] = true;


            //יצירת טבלה וכתיבתה על הדף
            string table = "<table>";
            for(int i=0; i<10; i++)
            {
                table += "<tr>";
                for(int j=0;j<3;j++)
                {
                    table += "<td>";
                    table += $"[{i},{j}]";
                    table += "</td>";
                }
                table += "</tr>";
            }
            table += "</table>";

            div1.InnerHtml = table;
        }
    }
}