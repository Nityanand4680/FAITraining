<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecipientPage.aspx.cs" Inherits="SampleWebFormApp.RecipientPage" %>
<%@ PreviousPageType VirtualPath="~/QueryStringDemo.aspx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>The contents of the Posted Data:</h2>
            <hr />
            <asp:Label Text="" ForeColor="Red" Font-Size="XX-Large" ID="lblData" runat="server" />
        </div>
    </form>
</body>
</html>
