<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmployeeRegistration.aspx.cs" Inherits="SampleWebFormApp.NewEmployeeRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>New Employee Registration</h2>
            <p>
                Enter the Name: <asp:TextBox runat="server" ID="txtName" />
                <asp:RequiredFieldValidator ErrorMessage="Name is required" ControlToValidate="txtName" runat="server" ForeColor="IndianRed" />
            </p>
            <p>
                Enter the Email Address: <asp:TextBox runat="server" ID="txtAddress" />
                <asp:RegularExpressionValidator ErrorMessage="Email is not in a proper format" ForeColor="IndianRed" ControlToValidate="txtAddress" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
            </p>
            <p>
                Enter the Password: <asp:TextBox runat="server" ID="txtPwd" TextMode="Password"/>
                <asp:RequiredFieldValidator ErrorMessage="Password is a must" ControlToValidate="txtPwd" runat="server" ForeColor="IndianRed" />
            </p>
                        <p>
                ReType the Password: <asp:TextBox runat="server" ID="txtRetype" TextMode="Password"/>
                            <asp:CompareValidator ErrorMessage="Password Mismatch" ControlToValidate="txtRetype" ControlToCompare="txtPwd" Type="String" runat="server" ForeColor="IndianRed" />

            </p>
            <p>
                Enter the Salary: <asp:TextBox runat="server" ID="txtSalary" />
            </p>
            <p>
                Enter the Date of Birth: <asp:TextBox runat="server" ID="txtDate" TextMode="Date"/>
            </p>
            <p>
                Select the Dept: <asp:DropDownList runat="server" ID="dpDepts" Height="33px" Width="265px">
                    
                </asp:DropDownList>
            </p>
            <p>
                <asp:Button Text="Submit" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click"/>
            </p>
        </div>
        <div>
            <asp:Label Text="" ForeColor="IndianRed" runat="server" ID="lblError" />
        </div>
    </form>
</body>
</html>
