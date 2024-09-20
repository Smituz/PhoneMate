<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PhoneMate.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>
            <asp:Label ID="lblUsername" runat="server" Text="Username:" AssociatedControlID="txtUsername"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvUsername" 
                runat="server" 
                ControlToValidate="txtUsername" 
                ErrorMessage="Username is required." 
                ForeColor="Red" 
                Display="Dynamic"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password:" AssociatedControlID="txtPassword"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvPassword" 
                runat="server" 
                ControlToValidate="txtPassword" 
                ErrorMessage="Password is required." 
                ForeColor="Red" 
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                ID="revPassword"
                runat="server"
                ControlToValidate="txtPassword"
                ValidationExpression="^.{8,}$" 
                ErrorMessage="Password must be at least 8 characters long."
                ForeColor="Red"
                Display="Dynamic"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="Register.aspx">Not a user? Register Now</asp:HyperLink>
            <br />
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
