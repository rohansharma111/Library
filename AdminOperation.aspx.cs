using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class AdminOperation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlOperation SqlOperation = new SqlOperation();
        protected void Display(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Session["operation"] = "display";
            Response.Redirect("ActualOperation.aspx");
        }

        protected void ViewUsers(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Session["operation"] = "viewUsers";
            Response.Redirect("ActualOperation.aspx");
        }

        protected void RemoveUser(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Session["operation"] = "removeUser";
            Response.Redirect("ActualOperation.aspx");
        }

        protected void ViewUserDetails(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Session["operation"] = "viewUserDetails";
            Response.Redirect("ActualOperation.aspx");
        }

        protected void AddBooks(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Session["operation"] = "addBooks";
            Response.Redirect("ActualOperation.aspx");
        }

        protected void RemoveAll(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Session["operation"] = "removeAllUsers";
            Response.Redirect("ActualOperation.aspx");
        }

        protected void RemoveBooks(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Session["operation"] = "removeBooks";
            Response.Redirect("ActualOperation.aspx");
        }

        protected void logout(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Label5.Text = $"Logging You out {username}, Hold On!";
            Response.AddHeader("REFRESH", "2;URL=login.aspx");
        }

        protected void ReadAdmin(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Session["operation"] = "readAdmin";
            Response.Redirect("ActualOperation.aspx");
        }

        protected void UserBooks(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Session["operation"] = "userBooks";
            Response.Redirect("ActualOperation.aspx");
        }
    }
}