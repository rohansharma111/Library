<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserOrAdmin.aspx.cs" Inherits="Library.UserOrAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 246px;
        }
      
   
        body {
            background-color: #f4f4f4;
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        #form1 {
            text-align: center;
            margin-top: 100px;
        }

        #form1 div {
            background-color: #fff;
            border: 1px solid #ccc;
            padding: 20px;
            width: 600px;
            margin: auto;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 5px;
        }

        .buttonStyle {
            margin-top: 20px;
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
            border: none;
            border-radius: 3px;
            color: #fff;
        }

        #Button3 {
            background-color: #3498db;
        }

        #Button4 {
            background-color: #e74c3c;
        }

        #Label1 {
            font-size: 24px;
            color: #333;
            margin-top: 20px;
        }
    </style>
</head>

    
<body style="height: 279px">
    <form id="form1" runat="server">
        <div>
        
        <asp:Button ID="Button3" runat="server" OnClick="Users" style="z-index: 1; left: 338px; top: 190px; position: absolute" Text="User" />
        <asp:Button ID="Button4" runat="server" OnClick="Admin" style="z-index: 1; left: 477px; top: 188px; position: absolute" Text="Admin" />
        <asp:Label ID="Label1" runat="server" Font-Names="Algerian" style="z-index: 1; left: 411px; top: 132px; position: absolute" Text="You are a"></asp:Label>
    </div>
    </form>
</body>
</html>
