using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mini_project_full.pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "FormValidation";

            //הדף פתוח לכולם
            Session["isAuthorized"] = true;
        }

        protected void btn1_ServerClick(object sender, EventArgs e)
        {
            idIsValid.InnerHtml = "Validation OK.\nServer event was called";
        }
    }
}