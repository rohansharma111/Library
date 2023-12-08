<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualOperation.aspx.cs" Inherits="Library.ActualOperation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <form id="form1" runat="server" visible="True">
        <div class="container">
            <asp:Label ID="Label4" runat="server" Text="Enter Book Name" CssClass="label" Visible="False"></asp:Label>
            <br /><br />
            <asp:TextBox ID="TextBox1" runat="server" BorderColor="Black" BorderStyle="Dashed" BackColor="#66FF33" Width="250px" Height="20px"></asp:TextBox>
            <br /><br />
            <asp:Button runat="server" Text="Proceed" CssClass="label" BackColor="#FF6600" Visible="False" ID="Proceed" OnClick="Proceed1"></asp:Button> <asp:Button runat="server" Text="Back" CssClass="label" BackColor="#99CCFF" ID="Button1" OnClick="Back"></asp:Button>
            <br /><br />
            <asp:Label class="message" runat="server" ID="Label5"></asp:Label>
        </div>

        <asp:TextBox ID="TextBox2" runat="server" BorderColor="Black" BorderStyle="Dashed" BackColor="#66FF33" style="z-index: 1; left: 350px; top: 454px; position: absolute; right: 580px; height: 241px; width: 347px" Visible="False" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
        <asp:GridView ID="GridView1" runat="server" CssClass="table" BackColor="#66FF33"></asp:GridView>

    </form>
</body>
</html>
