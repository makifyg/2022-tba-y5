using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace mini_project_full
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["usersCount"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            /*איפוס המשתנים שנרצה לרשום ב
             * Session
             */
            Session["isAdmin"] = false;
            Session["user"] = "Guest";
            Session["isLogin"] = false;
            Session["Page3SessionClicksCount"] = 0;
            Session["isFreePage"] = false;
            Session["currentPage"] = "";

            /* כאשר נוצר 
             * Session
             * נעדכן את מספר המשתמשים שנמצאים כרגע באתר ונוסיף אחד לספירה
             */
            Application["usersCount"] = (int)Application["usersCount"] +1;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            /*כאשר מסתיים 
             * Session
             * נעדכן את מספר המשתמשים הנמצאים כרגע באתר ונוריד אחד מהספירה
             */
            Application["usersCount"] = (int)Application["usersCount"] - 1;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}