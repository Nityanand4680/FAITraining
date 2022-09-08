<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="SampleWebFormApp.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align: center; color: #009999">Welcome to ASP.NET Training</h1>
        <p style="text-align: left; color: #000066">
            This is an Example to show how to create ASP.NET WEb Apps without much knowledge of HTML or CSS.</p>
        <br />
        <div>
            <h2>User Entry form</h2>
            <hr />
            <p>
                <asp:Label Text="Enter the Name: " runat="server" />
                <asp:TextBox runat="server" ID="txtName" />
            </p>
            <p>
                Enter the Address:<asp:TextBox ID="txtAddress" runat="server" BackColor="#6699FF" BorderColor="#CC0099" Height="42px" Width="482px"></asp:TextBox>
            </p>
            <p>
                Enter the Salary:
                <asp:TextBox ID="txtSalary" runat="server" TextMode="Number"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" Height="93px" OnClick="btnSubmit_Click" Text="Submit" Width="258px" />
            </p>

        </div>
        <asp:Label ID="lblDisplay" runat="server" BorderColor="#FF0066" BorderStyle="Dotted" Height="163px" Width="909px"></asp:Label>
    </form>
</body>
</html>
