<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryStringDemo.aspx.cs" Inherits="SampleWebFormApp.QueryStringDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>State Management using QueryString</h1>
    <hr />
    <p> 
        HTTP is a Stateless Protocol. It does not store any information about its previous Pages during the Page Cycle. So we use some techiques to store the information that we want to use in multiple pages of the Application. This will make the User feel that it is a continuos process.  
    </p>
    <div>
        ASP.NET has 2 kinds of State Management: Client Side and Server Side
        <br />
        The Client side techniques are:
        <ol>
            <li>Query String</li>
            <li>Cookies</li>
            <li>ViewState</li>
            <li>CrossPagePost</li>
        </ol>
        The Server side techniques are:
        <ol>
            <li>Session</li>
            <li>Application</li>
            <li>Cache</li>
        </ol>
        <p>QueryString is the most popular and simpliest form of State Management where we share the data thru the URL. The data that we want to share will be passed as Key-Value Pairs appended in the URL, and each pair is seperated by an &.</p>
    </div>

    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtInput" runat="server" />
            <asp:TextBox ID="txtInput2" runat="server" />
            <asp:TextBox ID="txtInput3" runat="server" />
            <asp:Button PostBackUrl="~/RecipientPage.aspx" Text="Send Input" runat="server" OnClick="Unnamed1_Click" />
        </div>
    </form>
</body>
</html>
