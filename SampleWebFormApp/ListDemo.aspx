<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListDemo.aspx.cs" Inherits="SampleWebFormApp.ListDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>List of Employees from the database</h2>
            <hr />
            <div>
                <asp:Button Text="Get Emp List" runat="server" ID="btnGet" OnClick="btnGet_Click" />
            </div>
            <asp:ListBox runat="server" ID="lstNames" Height="500px" Width="350px">
            </asp:ListBox>
        </div>
    </form>
</body>
</html>
