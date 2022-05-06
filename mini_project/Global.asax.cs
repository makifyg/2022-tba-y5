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
            Application["Page3GlobalClicksCount"] = 0;
            Application["usersLoginCount"] = 0;
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

            /* כאשר נוצר 
             * Session
             * נעדכן את מספר המשתמשים הרשומים באתר ונוסיף אחד לספירה
             */
            Application["usersLoginCount"] = (int)Application["usersLoginCount"] +1;

            Session.Timeout = 1;
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
             * נעדכן את מספר המשתמשים הרשומים באתר ונוריד אחד מהספירה
             */
            Application["usersLoginCount"] = (int)Application["usersLoginCount"] - 1;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}