using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full
{
    public partial class Login : System.Web.UI.Page
    {
        /*הגדרת משתמשים רשומים, באופן זמני עד שנלמד איך להכניס אותם במסד הנתונים
         *  שם המשתמש, סיסמא, דף נחיתה לאחר כניסה
        */
        const string userName1 = "user1";
        const string password1 = "1234";
        const string user1Page = "page1.aspx";

        const string userName2 = "user2";
        const string password2 = "4321";
        const string user2Page = "page2.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            /*השמת ערך של הדף הנוכחי ב 
             * Session
             */
            Session["currentPage"] = "login";

            //הדף פתוח לכולם
            Session["isAuthorized"] = true;
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            //איפוס משתנים 
            Session["isAdmin"] = false;
            Session["isLogin"] = false;

            /*בדיקת שם המשתמש והסיסמא
             *  אם המשתמש הקיש סיסמא נכונה הוא מועבר לדף הנחיתה ששייך אליו 
             */
            if (
                (inUserName.Value == userName1 && inPassword.Value == password1) ||
                (inUserName.Value == userName2 && inPassword.Value == password2))
            {
                //שמירת שם המשתמש כדי שנוכל להשתמש בו לאחר מכן בדפים אחרים
                Session["user"] = inUserName.Value;

                //שמירת הנתון שהמשתמש שגולש עכשיו הוא משתמש רשום בעל הרשאות
                Session["isLogin"] = true;

                //מעבר לדפי הנחיתה לפי שם המשתמש וכן סימון אם המשתמש הוא בעל הרשאות מנהל
                if (inUserName.Value == userName1)
                {
                    Session["isAdmin"] = true;
                    Response.Redirect(user1Page);
                }
                else if (inUserName.Value == userName2)
                    Response.Redirect(user2Page);
            }
            //אם לא הוקשה סיסמא נכונה מציגים הודעת שגיאה
            else
                divError.Style["display"] = "block";
        }
    }
}