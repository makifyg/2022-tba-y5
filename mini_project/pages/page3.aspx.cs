using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full
{
    public partial class page3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*השמת ערך של הדף הנוכחי ב 
             * Session
             */
            Session["currentPage"] = "page3";

            //רק משתמשים רשומים יכולים לצפות בדף
            if((bool)Session["isLogin"])
                Session["isAuthorized"] = true;

            /*כשנכנסים לעמוד נרצה להציג את מספר הקליקים עד כה
             */
            if (!IsPostBack)
                divClickCount.InnerHtml = Session["Page3SessionClicksCount"].ToString();
        }

        protected void btnClickCount_ServerClick(object sender, EventArgs e)
        {
            //כשלוחצים על הכפתור ננוסיף אחד למספר הקליקים שנלחצו עד כה ונציג את המספר המעודכן
            Session["Page3SessionClicksCount"] = (int)Session["Page3SessionClicksCount"] + 1;
            divClickCount.InnerHtml = Session["Page3SessionClicksCount"].ToString();
        }
    }
}