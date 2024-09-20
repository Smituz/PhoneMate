<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PhoneMate.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register</h2>

            <!-- Username -->
            <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" 
                ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br /><br />

            <!-- Password -->
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" 
                ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" 
                ValidationExpression="^.{8}$" ErrorMessage="Password must be exactly 8 characters long" 
                ForeColor="Red"></asp:RegularExpressionValidator>
            <br /><br />

            <!-- Email -->
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" 
                ErrorMessage="Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" 
                ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ErrorMessage="Invalid email format" 
                ForeColor="Red"></asp:RegularExpressionValidator>
            <br /><br />

            <!-- Full Name -->
            <asp:Label ID="lblFullName" runat="server" Text="Full Name:"></asp:Label>
            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="txtFullName" 
                ErrorMessage="Full name is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br /><br />

            <!-- Phone Number -->
            <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:"></asp:Label>
            <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" 
                ErrorMessage="Phone number is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" 
                ValidationExpression="^\d{10,20}$" ErrorMessage="Invalid phone number (must be 10-20 digits)" 
                ForeColor="Red"></asp:RegularExpressionValidator>
            <br /><br />

            <!-- Address (Optional) -->
            <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            <br /><br />

            <!-- XID (Optional) -->
            <asp:Label ID="lblXID" runat="server" Text="X's ID:"></asp:Label>
            <asp:TextBox ID="txtXID" runat="server"></asp:TextBox>
            <br /><br />

            <!-- Instagram ID (Optional) -->
            <asp:Label ID="lblInstagramID" runat="server" Text="Instagram ID:"></asp:Label>
            <asp:TextBox ID="txtInstagramID" runat="server"></asp:TextBox>
            <br /><br />

            <!-- Register Button -->
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            <br /><br />

            <!-- Redirect to Login -->
            <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx">Already a user? Login here</asp:HyperLink>

        </div>
    </form>
</body>
</html>
