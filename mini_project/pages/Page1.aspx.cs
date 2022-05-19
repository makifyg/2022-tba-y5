using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full
{
    public partial class Page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*השמת ערך של הדף הנוכחי ב 
             * Session
             */
            Session["currentPage"] = "page1";

            //user1 הגבלת צפיה רק עבור 
            string currentUser = (string)Session["user"];
            if (currentUser == "user1")
                Session["isAuthorized"] = true;
        }
    }
}