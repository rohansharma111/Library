using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System;
using System.IO;
using System.Text;
using System.Linq;

public class UserAuthentication
{

    bool flag = false;
    bool log = false;
    bool IsExist = false;
    string path;

    static bool IsAlphaNumeric(string input)
    {
        // Using a regular expression to check for alphanumeric characters
        Regex regex = new Regex("^[a-zA-Z0-9]+$");

        return regex.IsMatch(input);
    }
    private string connectionString = "Data Source=MUM-LAP-1132\\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";

    public (DataTable, bool) UserOperation(string username, string password, string operation, Label label, GridView gridView, string tablename)
    {
        if (username != "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query1 = $"select * from {tablename} where name = @name and pass=@pass";
                    
                    using (SqlCommand command1 = new SqlCommand(query1, connection))
                    {
                        command1.Parameters.AddWithValue("@name", username);
                        command1.Parameters.AddWithValue("@pass", password);
                        SqlDataReader reader = command1.ExecuteReader();

                        if (reader.HasRows)
                        {
                            flag = true;
                        }

                        reader.Close();
                    }
                    string query2 = $"select * from {tablename} where name = @name";
                    using (SqlCommand command2 = new SqlCommand(query2, connection))
                    {
                        command2.Parameters.AddWithValue("@name", username);
                        SqlDataReader reader1 = command2.ExecuteReader();

                        if (reader1.HasRows)
                        {
                            IsExist = true;

                        }
                        reader1.Close();
                    }

                    using (SqlCommand command = new SqlCommand("UserLoginSignup", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@name", username);
                        command.Parameters.AddWithValue("@pass", password);
                        command.Parameters.AddWithValue("@operation", operation);
                        command.Parameters.AddWithValue("@tablename", tablename);

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        gridView.DataSource = dataTable;
                        gridView.DataBind();

                        if (operation == "forgot")
                        {
                            label.Text = "Password retrieved successfully";
                            gridView.Visible = true;
                            return (dataTable, log);
                        }
                  
                            if (operation == "login")
                            {
                                if (flag && tablename == "admins")
                                {
                                    label.Text = "Logging IN, Hold ON!";
                                    log = true;
                                }
                                string tableName = username;
                                string query = $"SELECT * FROM [{tableName}]";

                                using (SqlCommand command1 = new SqlCommand(query, connection))
                                {
                                    SqlDataReader reader = command1.ExecuteReader();

                                    if (!reader.HasRows && flag)
                                    {
                                        label.Text = "Logging IN, No Books Received";
                                        log = true;
                                    }
                                    if (reader.HasRows && flag)
                                    {
                                        label.Text = "Logging IN, Hold ON!";
                                        log = true;
                                    }
                                    

                                    if (!flag)
                                    {
                                        label.Text = "Invalid Credentials.\nPLEASE enter Valid Credentials or try Creating a new Account!";
                                    }

                                    reader.Close();

                                    return (dataTable, log);
                                }
                            }

                            if (operation == "signup" && password.Length > 7 && IsAlphaNumeric(password))
                            {

                                if (IsExist)
                                {
                                    label.Text = "Account already Exists.\nTry with different username or login!";

                                }
                                else if (!IsExist)
                                {
                                    label.Text = "Account Created Successfully";
                                    if(tablename == "users")
                                    {
                                        path = $"C:\\Users\\rohan.sharma\\OneDrive - NEC Software Solutions\\Documents\\Library\\User\\{username}.txt";
                                        using (FileStream fs = File.Create(path))
                                        {

                                        }
                                    }
                                    else
                                    {
                                        path = $"C:\\Users\\rohan.sharma\\OneDrive - NEC Software Solutions\\Documents\\Library\\Admin\\{username}.txt";
                                        using (FileStream fs = File.Create(path))
                                        {

                                        }
                                        
                                        using (StreamWriter writer = new StreamWriter(path))
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
                                }
                                return (dataTable, log);
                            }

                            else
                            {
                                if (operation == "signup")
                                {
                                    if (password.Length < 7)
                                    {
                                        label.Text = "Password must contain atleast 7 characters";
                                    }
                                    else if (!char.IsLetter(username[0]))
                                    {
                                        label.Text = "Username must start with a letter";
                                    }
                                    else if (!IsAlphaNumeric(password))
                                    {
                                        label.Text = "Password must be alphanumeric";
                                    }
                                }
                                return (null, log);
                            }
                        }
                    }
                }
            
            catch (Exception e)
            {
                if (operation == "login" || operation == "forgot")
                {
                    label.Text = "User Not Found, Plz try creating an account instead" + e.Message;
                }
                else
                {
                    label.Text = e.Message;
                }
                return (null, log);
            }
        }
        else
        {
            label.Text = "Username Cannot be Empty!";
            return (null, log);
        }
    }
}