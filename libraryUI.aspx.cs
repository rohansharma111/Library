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



namespace Library
{
    public partial class libraryUI : System.Web.UI.Page
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

        protected void RequestBook(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Session["operation"] = "requestBook";
            Response.Redirect("ActualOperation.aspx");

        }

        protected void DonateBook(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Session["operation"] = "donateBook";
            Response.Redirect("ActualOperation.aspx");
        }

        protected void ReturnBook(object sender, EventArgs e)
        {
            
            string username = Session["username"].ToString();
            Session["operation"] = "returnBook"; 
            Response.Redirect("ActualOperation.aspx");          
        }       

        protected void Terms(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();            
            Session["operation"] = "terms";
            Response.Redirect("ActualOperation.aspx");

        }

        protected void mybooks(object sender, EventArgs e)
        {                            
                string username = Session["username"].ToString();
                Session["operation"] = "mybooks";
                Response.Redirect("ActualOperation.aspx");
        }
         
        protected void logout(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Label5.Text = $"Logging You out {username}, Hold On!";
            Response.AddHeader("REFRESH", "2;URL=login.aspx");
        }

        

        protected void ReadFile(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            Session["operation"] = "readfile";
            Response.Redirect("ActualOperation.aspx");
        }
    }
}