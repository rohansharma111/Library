using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.PeerToPeer;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


namespace Library
{
    public partial class ActualOperation : System.Web.UI.Page
    {     
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string username = Session["username"].ToString();
            string operation = Session["operation"].ToString();
            string bookName = TextBox1.Text;
            string isAdmin = Session["isAdmin"].ToString();
            string tablename;

            if(isAdmin == "true")
            {
                tablename = "admins";
            }
            else
            {
                tablename = "users";
            }

            SqlOperation SqlOperation = new SqlOperation();
                       
                if (operation == "display" || operation == "mybooks" || operation == "terms" || operation == "viewUsers" || operation == "removeAllUsers")
                    {
                        Proceed.Visible = false;
                        TextBox1.Visible = false;
                        Label4.Visible = false;
                        
                        try
                            {
                                SqlOperation.sqloperation(username, "", operation, GridView1, Label5, tablename);
                                if (operation == "mybooks")
                                {

                                    if (GridView1.Rows.Count == 0)
                                    {
                                        Label5.Text = $"You have not receieved any Books, {username}";
                                    }
                    }
                            }
                        catch (Exception)
                            {
                                if (operation == "mybooks")
                                {
                                    Label5.Text = "You must Login First";
                                }
                            }
                    }
            
            else if (operation == "requestBook" || operation == "donateBook" || operation == "returnBook" || operation == "removeUser" || operation == "viewUserDetails" || operation == "addBooks" || operation == "removeBooks" || operation == "userBooks")
            {
                Proceed.Visible = true;
                TextBox1.Visible = true;
                Label4.Visible = true;
                if (operation == "removeUser" || operation == "viewUserDetails" || operation == "userBooks")
                {
                    Label4.Text = "Enter the name of the User";                    
                }
                else if (operation == "addBookS" || operation == "removeBooks")
                {
                    Label4.Text = "Enter the name of the Book";                    
                }

            }
            else if(operation == "readfile")
            {
                string filePath = @"C:\Users\rohan.sharma\OneDrive - NEC Software Solutions\Documents\Library\User\" + username + ".txt";                           
                string content = File.ReadAllText(filePath);
                TextBox2.Visible = true;
                TextBox1.Visible = false;
                TextBox2.Text = content;
            }
            else if (operation == "readAdmin")
            {
                string filePath = @"C:\Users\rohan.sharma\OneDrive - NEC Software Solutions\Documents\Library\Admin\" + username + ".txt";
                string content = File.ReadAllText(filePath);
                TextBox2.Visible = true;
                TextBox1.Visible = false;
                TextBox2.Text = content;
            }
        }

        protected void Proceed1(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            string operation = Session["operation"].ToString();
            string bookName = TextBox1.Text;
            string isAdmin = Session["isAdmin"].ToString();
            string tablename;

            if (isAdmin == "true")
            {
                tablename = "admins";
            }
            else
            {
                tablename = "users";
            }

            if (operation == "removeUser" || operation == "viewUserDetails" || operation == "userBooks")
            {                
                username = TextBox1.Text;
            }
            else if(operation == "addBookS" || operation == "removeBooks")
            {
                bookName = TextBox1.Text;
            }
            SqlOperation SqlOperation = new SqlOperation();
            SqlOperation.sqloperation(username, bookName, operation, GridView1, Label5, tablename);
        }

        protected void Back(object sender, EventArgs e)
        {
            string isAdmin = Session["isAdmin"].ToString();
            if ( isAdmin == "true")
            {
                Response.Redirect("AdminOperation.aspx");
            }
            else
            {
                Response.Redirect("libraryUI.aspx");
            }
            
        }
    }
}