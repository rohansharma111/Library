using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class UserOrAdmin : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Users(object sender, EventArgs e)
        {
            Session["isAdmin"] = "false";
            Response.Redirect("login.aspx");
        }

        protected void Admin(object sender, EventArgs e)
        {
            Session["isAdmin"] = "true";
            Response.Redirect("login.aspx");
        }

        
    }
}