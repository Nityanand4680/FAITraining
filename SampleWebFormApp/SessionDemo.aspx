<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionDemo.aspx.cs" Inherits="SampleWebFormApp.SessionDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Store UR Words and Meanings</h2>
            <asp:TextBox runat="server" ID="txtWord"/>
            <asp:TextBox runat="server" ID="txtMeaning" Width="526px"/>
            <asp:Button Text="Save the Word" runat="server" OnClick="Unnamed1_Click" />
        </div>
        <div>
            <asp:GridView runat="server" ID="grdWords">

            </asp:GridView>
        </div>
    </form>
</body>
</html>
