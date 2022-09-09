<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayData.aspx.cs" Inherits="SampleWebFormApp.DisplayData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="rpProducts" runat="server">
                <HeaderTemplate>
                    <div>
                        <h1>List of Products with Us!!!</h1>
                        <hr />
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div style="width:65%; display:inline-block">
                        <table>
                            <tr>
                                <td>
                                    <asp:Image Width="250px" Height="100px" ImageUrl='<%#Eval("Image") %>' runat="server" />
                                </td>
                                <td>
                                    <h2>
                                        <asp:Label Text='<%#Eval("ProductName") %>' runat="server" />
                                    </h2>
                                    <hr /> 
                                    <div>
                                        Rs. <asp:Label Text='<%#Eval("Price") %>' runat="server" />
                                        <p>

                                        <asp:Button Text="Add to Cart" runat="server" />
                                        </p>

                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
