<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListDemo.aspx.cs" Inherits="SampleWebFormApp.ListDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2 style="text-align: center">List of Employees from the database</h2>
            <hr />
            <table>
                <tr>
                    <td>
                        <h2>List of Names:</h2>
                        <asp:ListBox runat="server" ID="lstNames" Height="500px" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="lstNames_SelectedIndexChanged">
            </asp:ListBox>
                    </td>
                    <td>
                        <div>
                            <h2>Details of the Selected Employee</h2>
                            <p>
                                EmpID : <asp:TextBox TextMode="Number" runat="server" ID="txtId"/>
                            </p>
                            <p>
                                EmpName : <asp:TextBox runat="server" ID="txtName"/>
                            </p>
                            <p>
                                EmpAddress : <asp:TextBox runat="server" ID="txtAddress"/>
                            </p>
                            <p>
                                EmpSalary : <asp:TextBox TextMode="Number" runat="server" ID="txtSalary"/>
                            </p>
                            <p>
                                Dept : <asp:TextBox runat="server" ID="txtDept" />
                            </p>
                            <p>
                                Date Of Birth : <asp:TextBox runat="server" ID="txtDoB"/>
                            </p>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
