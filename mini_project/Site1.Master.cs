using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //קריאת הנתונים מה
            //Session
            string currentPage = (string)Session["currentPage"];
            string currentUser = (string)Session["user"];
            bool isLogin = (bool)Session["isLogin"];
            bool isAdmin = (bool)Session["isAdmin"];

            //בדיקת הרשאות
            bool authorizedPage = (bool)Session["isAuthorized"];

            /*אם למשתמש אין הרשאות לדף הנוכחי, יש להעלים את תוכן הדף ולהשאיר הודעת שגיאה 
             *אחרת יש להשאיר את תוכן הדף ולהעלים את הודעת השגיאה 
             */
            if (authorizedPage == true)
            {
                ContentPlaceHolder1.Visible = true;
                divNotAuthorized.Visible = false;
            }
            else
            {
                ContentPlaceHolder1.Visible = false;
                divNotAuthorized.Visible = true;
            }

            //הסתרת חלקים בתפריט, בהתאם להרשאות של המשתמש
            if (isAdmin == false)
                liAdmin.Visible = false;
            if (isLogin)
            {
                if (currentUser != "user1")
                    liPage1.Visible = false;

                if (currentUser != "user2")
                    liPage2.Visible = false;

                aUser.HRef = "";
            }
            else
            {
                liPage1.Visible = false;
                liPage2.Visible = false;
                liPage3.Visible = false;
                liLogout.Visible = false;
            }

            //הדגשת הדף הנוכחי בתפריט
            if (currentPage == "home")
                pgHome.Attributes["class"] = "active";
            else if (currentPage == "page1")
                pgPage1.Attributes["class"] = "active";
            else if (currentPage == "page2")
                pgPage2.Attributes["class"] = "active";
            else if (currentPage == "page3")
                pgPage3.Attributes["class"] = "active";
            else if (currentPage == "admin1")
                pgAdmin1.Attributes["class"] = "active";
            else if (currentPage == "dbNotConnected")
            {
                pgDatabase.Attributes["class"] = "active";
                pgDatabase.InnerHtml = pgDbNotConnected.InnerHtml;
            }
            else if (currentPage == "dbConnected")
            {
                pgDatabase.Attributes["class"] = "active";
                pgDatabase.InnerHtml = pgDbConnected.InnerHtml;
            }
            else if (currentPage == "dbAdvance")
            {
                pgDatabase.Attributes["class"] = "active";
                pgDatabase.InnerHtml = pgDbAdvance.InnerHtml;
            }
        }

        protected void aLogout_ServerClick(object sender, EventArgs e)
        {
            /*כאשר המשתמש לחץ על לוג-אאוט, סוגרים את ה  
             * Session
             * ומעבירים את המשתמש לדף הבית כמשתמש לא רשום
             * ומורידים את מספר המשתמשים הרשומים שנמצאים באתר באחד
             */
            Session.Abandon();
            Response.Redirect("home.aspx");           
        }
    }
}