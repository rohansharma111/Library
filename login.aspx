<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Library.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
    <link rel="stylesheet" type="text/css" href="login.css" />
    <style type="text/css">
        .status-label {
            z-index: 1;
            left: 590px;
            top: 468px;
            position: absolute;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h1 draggable="false">Welcome to AmazLib</h1>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Username" BackColor="Lime" Font-Bold="False" Font-Names="Algerian" style="z-index: 1; left: 142px; top: 80px; position: absolute" ></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="input" Width="467px"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Password" BackColor="#00FFCC" Font-Names="Algerian" style="z-index: 1; left: 142px; top: 125px; position: absolute" ></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="input" Width="461px"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Login" CssClass="login-button" />
            
            <!-- Sign In button that redirects to signin.aspx -->
            <asp:Button ID="SignInButton" runat="server" Text="Sign In" OnClick="SignIn" CssClass="login-button" />
            <asp:Button ID="ForgotPasswordButton" runat="server" Text="Forgot Password" OnClick="ForgotPassword" CssClass="login-button" />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />
            <asp:Label ID="status" runat="server" BackColor="#FFFF66" BorderColor="#CCCCFF" BorderStyle="Dashed" Font-Italic="True" Font-Names="Century Gothic" style="z-index: 1; left: 511px; top: 270px; position: absolute" ></asp:Label>
            <br /><br />
            <asp:Label ID="Label4" runat="server"  style="height: 20px; z-index: 1; left: 507px; top: 334px; position: absolute;" Font-Bold="True" Font-Names="Century Gothic"></asp:Label>

            
            
        </div>
        <p>
            <asp:Button ID="Button2" runat="server" CssClass="login-button" OnClick="Button2_Click" style="z-index: 1; left: 500px; top: 380px; position: absolute" Text="Go Back" />

            
            
        </p>
    </form>
</body>
</html>
