<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="libraryUI.aspx.cs" Inherits="Library.libraryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AmazLib - Your Personal Book Hub</title>
    <link rel="stylesheet" type="text/css" href="libraryUIcss.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
        }
        .container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            text-align: center;

        }
        .heading {
            text-align: center;
            font-size: 24px;
            margin-bottom: 20px;
            position: relative;
        }
        .btn {
            margin: 5px;
            padding: 10px 20px;
            font-size: 16px;
            background-color: #009933;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            width: 100%;
        }
        .btn:hover {
            background-color: #007726;
            
        }
        .label {
            font-size: 18px;
            margin-right: 10px;
        }
        .input-box {
            width: 200px;
            padding: 5px;
            margin: 0 auto;
            align-items: center;
        }
        .message {
            font-size: 18px;
            color: #FF33CC;
        }
        .table {
            margin-top: 20px;
            border-collapse: collapse;
            width: 100%;
        }
        .table th, .table td {
            border: 1px solid #ccc;
            padding: 8px;
            text-align: center;
        }
        .table th {
            background-color: #009933;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="heading">Welcome to AmazLib - Your Personal Hub of Books</div>
            <div class="btn-container">
                <asp:Label ID="Label5" runat="server" Font-Names="Algerian" ForeColor="#660066" style="z-index: 1; left: 474px; top: 144px; position: absolute"></asp:Label>
                <asp:Button ID="Button1" runat="server" Text="View All Books" OnClick="Display" CssClass="btn" BackColor="Blue" />
                <asp:Label ID="Label4" runat="server" Text="Enter Book Name" CssClass="label"></asp:Label>
                <br />
                <asp:Button ID="Button2" runat="server" Text="Request a Book" CssClass="btn" OnClick="RequestBook" />
            
                <asp:Button ID="Button3" runat="server" Text="Donate a Book" OnClick="DonateBook" CssClass="btn" />
                <br />
                <asp:Button ID="Button4" runat="server" Text="Return a Book" OnClick="ReturnBook" CssClass="btn" />
                <br />
                <asp:Button ID="Button5" runat="server" Text="View Terms and Conditions" OnClick="Terms" CssClass="btn" />
                <br />
                <asp:Button runat="server" Text="View My Books" OnClick="mybooks" CssClass="btn" />
                <br />
                <asp:Button ID="Button7" runat="server" Text="Read User File" OnClick="ReadFile" CssClass="btn" BackColor="Blue" />
                <br />
                <asp:Button ID="Button6" runat="server" Text="Logout" OnClick="logout" CssClass="btn" BackColor="Red" />
                <br />
                
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>    
            
            
            
        </div>
    </form>
</body>
</html>
