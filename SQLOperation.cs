using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Linq;

namespace Library
{
    public class SqlOperation
    {
        public void sqloperation(string username, string bookName, string operation, GridView gridView, Label label, string tablename)
        {
            bool flag = true;
            bool user = false;
            bool giveBack = false;
            string connectionString = "Data Source=MUM-LAP-1132\\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                    if(tablename == "users")
                    {
                        using (SqlCommand command1 = new SqlCommand("SELECT * FROM " + username + " WHERE books = @book and available = 5", connection))
                        {
                            command1.Parameters.AddWithValue("@book", bookName);
                            SqlDataReader reader = command1.ExecuteReader();

                            if (reader.HasRows)
                            {
                                user = true;
                            }
                            reader.Close();
                        }

                        using (SqlCommand command1 = new SqlCommand("SELECT * FROM " + username + " WHERE books = @book and available > 0 and available <= 5", connection))
                        {
                            command1.Parameters.AddWithValue("@book", bookName);
                            SqlDataReader reader = command1.ExecuteReader();

                            if (reader.HasRows)
                            {
                                giveBack = true;
                            }
                            reader.Close();
                        }
                    }
                
                if (operation == "requestBook")
                {
                    using (SqlCommand command1 = new SqlCommand("SELECT * FROM library WHERE book_name = @book AND available > 0 and available <= total", connection))
                    {
                        command1.Parameters.AddWithValue("@book", bookName);
                        SqlDataReader reader = command1.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            flag = false;
                        }
                        reader.Close();
                    }
                }
                if (operation == "returnBook")
                {
                    using (SqlCommand command1 = new SqlCommand("SELECT * FROM library WHERE book_name = @book and available < total", connection))
                    {
                        command1.Parameters.AddWithValue("@book", bookName);
                        SqlDataReader reader = command1.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            flag = false;
                        }
                        reader.Close();
                    }
                }

                if (!string.IsNullOrEmpty(operation))
                {
                    using (SqlCommand command = new SqlCommand("libraryOperation", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@book_name", bookName);
                        command.Parameters.AddWithValue("@operation", operation);
                        
                        // Get the number of rows affected
                                               
                            SqlParameter rowCountParam = new SqlParameter("@RowCount", SqlDbType.Int);
                            rowCountParam.Direction = ParameterDirection.Output;
                            command.Parameters.Add(rowCountParam);
                            


                            int numberOfRows = Convert.ToInt32(command.Parameters["@RowCount"].Value); 
                            
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            gridView.DataSource = dataTable;
                            gridView.DataBind();                                                      

                            if(tablename == "admins")
                            {                                
                                if (operation == "display")
                                {
                                    label.Text = "Books Displayed successfully";
                                }

                                if(operation == "viewUsers" )
                                {
                                    label.Text = "Users displayed succesfully";
                                }

                                if (operation == "removeUser")
                                {
                                    label.Text = "User removed succesfully";
                                    string filePath = @"C:\Users\rohan.sharma\OneDrive - NEC Software Solutions\Documents\Library\User\" + username + ".txt";
                                    if (File.Exists(filePath))
                                    {
                                        // If file found, delete it
                                        File.Delete(filePath);
                                        label.Text += "User File Deleted";
                                    }
                                }
                                else if (string.IsNullOrEmpty(bookName) && operation == "removeUser")
                                {
                                    label.Text = "Please Enter the name of the User";
                                }

                                if (operation == "viewUserDetails")
                                {

                                    string query = $"SELECT * FROM users where name = '{username}'";

                                    using (SqlCommand command1 = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = command1.ExecuteReader();

                                        if (!reader.HasRows)
                                        {
                                            label.Text = $"The User {username} does not exist";
                                        }
                                        else
                                        {
                                            label.Text = "User Details displayed succesfully";
                                        }
                                        reader.Close();
                                    }
                                }

                                if (operation == "addBooks")
                                {
                                    label.Text = "Book Added succesfully";
                                }
                                else if (string.IsNullOrEmpty(bookName) && operation == "addBooks")
                                {
                                    label.Text = "Please Enter the name of the Book";
                                }

                                if (operation == "removeBooks")
                                {
                                    label.Text = "Book removed succesfully";
                                }
                                else if (string.IsNullOrEmpty(bookName) && operation == "removeBooks")
                                {
                                    label.Text = "Please Enter the name of the Book";
                                }

                                if (operation == "removeAllUsers")
                                {
                                    label.Text = "All Users removed succesfully";
                                }
                            }

                            else
                            {
                                using (StreamWriter writer = new StreamWriter(@"C:\\Users\\rohan.sharma\\OneDrive - NEC Software Solutions\\Documents\\Library\\User\\" + username + ".txt"))
                                {
                                    // Write column names
                                    string header = string.Join(",", dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName));
                                    writer.WriteLine(header);

                                    // Write rows
                                    foreach (DataRow row in dataTable.Rows)
                                    {
                                        string line = string.Join(",", row.ItemArray.Select(item => item.ToString()));
                                        writer.WriteLine(line);
                                    }
                                }

                            }
                            if (!string.IsNullOrEmpty(username) && operation == "userBooks")
                            {
                                label.Text = "Books Displayed Successfully";
                            }
                            if (operation == "readAdmin")
                            {

                            }

                            if (flag)
                            {
                                if (operation == "display")
                                {
                                    label.Text = "Books Displayed successfully";
                                }
                                if (!string.IsNullOrEmpty(bookName) && operation == "requestBook" && !user)
                                {
                                    label.Text = $"Book {bookName} has been Alloted successfully";
                                }
                                else if (!string.IsNullOrEmpty(bookName) && operation == "requestBook" && user)
                                {
                                    label.Text = $"You cannot have more than 5 copies of the Book {bookName}";
                                    gridView.DataSource = null;
                                    gridView.DataBind();
                                }
                                else if (string.IsNullOrEmpty(bookName) && operation == "requestBook")
                                {
                                    label.Text = "Please Enter the name of the Book";
                                }

                                if (!string.IsNullOrEmpty(bookName) && operation == "returnBook" && giveBack)
                                {
                                    label.Text = $"Book {bookName} returned successfully\nThank you for returning the Book on Time";
                                }
                                else if (!string.IsNullOrEmpty(bookName) && operation == "returnBook" && !giveBack)
                                {
                                    label.Text = $"Book '{bookName}' Not found in your Books List";
                                }
                                else if (string.IsNullOrEmpty(bookName) && operation == "returnBook")
                                {
                                    label.Text = "Please Enter the name of the Book";
                                }

                                if (operation == "terms")
                                {
                                    label.Text = "Any Book taken from the Library must returned within 2 weeks of Time\nOtherwise you will be liable for a penalty of 200 Dollars for each date dued overtime";
                                }
                                if (!string.IsNullOrEmpty(bookName) && operation == "donateBook")
                                {
                                    label.Text = "Book Donated successfully\n Its because of people like you that our Library is able to do the Transformational Work!";
                                }
                                else if (string.IsNullOrEmpty(bookName) && operation == "donateBook")
                                {
                                    label.Text = "Please Enter the name of the Book";
                                }

                            }

                            else
                            {
                                if (operation == "requestBook")
                                {
                                    label.Text = $"Book {bookName} Not available";
                                }
                                if (operation == "returnBook")
                                {
                                    label.Text = "No Pending Books to return, try Donating a Book if you want to!";
                                }
                                
                            }
                            
                            
                        }
                        
                    }
                }
            }
            catch (Exception e)
            {
                label.Text = "Operation Failed" ;
                
                if (operation == "removeBooks")
                {
                    label.Text = "Book not found";
                }
                if (operation == "removeUser" || operation == "viewUserDetails")
                {
                    label.Text = "User not found";
                }
                if (operation == "viewUsers")
                {
                    label.Text = "No Users found";
                }
                
            }
        }
    }
}