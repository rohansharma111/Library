<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="Library.signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign In</title>
    <link rel="stylesheet" type="text/css" href="signin.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="signin-container">
            <h1>Sign In to AmazLib</h1>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Username" CssClass="label"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Password" CssClass="label"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Sign In" OnClick="SignIn" CssClass="login-button" />
        </div>
    </form>
</body>
</html>
