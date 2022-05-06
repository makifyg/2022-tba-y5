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
            bool authorized = false;
            if (currentPage == "home" || currentPage == "register" || currentPage == "login")
                authorized = true;
            else if ((bool)Session["isLogin"] == true)
            {
                if(currentPage == "page1" && currentUser == "user1")
                    authorized = true;
                else if (currentPage == "page2" && currentUser == "user2")
                    authorized = true;
                else if (currentPage == "admin1" && (bool)Session["isAdmin"] == true)
                    authorized = true;
                else if (currentPage != "page1" && currentPage != "page2" && currentPage != "admin1")
                    authorized = true;
            }

            /*אם למשתמש אין הרשאות לדף הנוכחי, יש להעלים את תוכן הדף ולהשאיר הודעת שגיאה 
             *אחרת יש להשאיר את תוכן הדף ולהעלים את הודעת השגיאה 
             */
            if (authorized==false)
                ContentPlaceHolder1.Visible = false;
            else
                divNotAuthorized.Visible = false;

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

            //עדכון מספר הפעמים (מכל המשתמשים) שנכנסו לדף הנוכחי
            if (Application[currentPage + "Count"] == null)
                Application[currentPage + "Count"] = 0; 
            int currentPageHitCount = (int)Application[currentPage + "Count"];
            if (!IsPostBack)
            {
                Application[currentPage + "Count"] = ++currentPageHitCount;
                Session["currentPageCount"] = currentPageHitCount;
            }

            //אם המשתמש אינו מנהל יש להוריד את החלק שמראה את ספירת המשתמשים
            if (isAdmin == false)
                divCountersForAdmin.Visible = false;
        }

        protected void aLogout_ServerClick(object sender, EventArgs e)
        {
            /*כאשר המשתמש לחץ על לוג-אאוט, סוגרים את ה  
             * Session
             * ומעבירים את המשתמש לדף הבית כמשתמש לא רשום
             */
            Session.Abandon();
            Response.Redirect("home.aspx");           
        }
    }
}