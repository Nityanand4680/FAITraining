<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostBackFeature.aspx.cs" Inherits="SampleWebFormApp.PostBackFeature" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox runat="server" ID="lstData" Height="292px" AutoPostBack="true" OnSelectedIndexChanged="lstData_SelectedIndexChanged" Width="417px">
            </asp:ListBox>
        </div>
        <div>
            <asp:Button Text="Click Me" runat="server" />
        </div>
    </form>
</body>
</html>
