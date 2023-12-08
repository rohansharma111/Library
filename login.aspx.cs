
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;
using System.Text.RegularExpressions;


namespace Library
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string isAdmin = Session["isAdmin"].ToString();
            Session["username"] = TextBox1.Text;
            
            if (isAdmin == "true")
            {
                status.Text = "You are Logging in as Admin";
                Label4.Text = "Not an Admin? Login as User instead";
            }
            else
            {
                status.Text = "You are Logging in as User";
                Label4.Text = "Not a User? Login as Admin instead";
            }
        } 
       
        protected void Login(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            string isAdmin = Session["isAdmin"].ToString();
            if (isAdmin == "true")
            {
                (DataTable loginResult, bool flag) = auth.UserOperation(username, password, "login", status, GridView1, "admins");
                if (flag)
                {
                    Response.Redirect("AdminOperation.aspx");
                }
            }
            else
            {
                (DataTable loginResult, bool flag) = auth.UserOperation(username, password, "login", status, GridView1, "users");
                if (flag)
                {
                    Response.AddHeader("REFRESH", "2;URL=libraryUI.aspx");
                }
            }           
            

        }

        protected void SignIn(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            string name = TextBox1.Text;
            string pass = TextBox2.Text;
            GridView1.Visible = false;
            string isAdmin = Session["isAdmin"].ToString();
            if (isAdmin == "true")
            {
                auth.UserOperation(name, pass, "signup", status, GridView1, "admins");
                
            }
            else
            {
                auth.UserOperation(name, pass, "signup", status, GridView1, "users");
                
            }
        }

        protected void ForgotPassword(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            string isAdmin = Session["isAdmin"].ToString();
            if (isAdmin == "true")
            {
                auth.UserOperation(username, password, "forgot", status, GridView1, "admins");

            }
            else
            {
                auth.UserOperation(username, password, "forgot", status, GridView1, "users");

            }

            if (GridView1.Rows.Count == 0 && username != "")
            {
                status.Text = $"No user found by name {username}";
            }
            else if(username == "")
            {
                status.Text = "Must Enter the Username";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserOrAdmin.aspx");
        }
    }
}
