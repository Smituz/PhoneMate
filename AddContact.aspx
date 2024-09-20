<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="AddContact.aspx.cs" Inherits="PhoneMate.AddContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <h2>Add Contact</h2>

            <asp:Label ID="lblFullName" runat="server" Text="Full Name:" AssociatedControlID="txtFullName"></asp:Label>
            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="txtFullName" 
                ErrorMessage="Full Name is required" ForeColor="Red"></asp:RequiredFieldValidator>

            <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:" AssociatedControlID="txtPhoneNumber"></asp:Label>
            <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" 
                ErrorMessage="Phone Number is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" 
                ValidationExpression="^\d{10}$" ErrorMessage="Phone Number must be 10 digits" ForeColor="Red"></asp:RegularExpressionValidator>

            <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" 
                ErrorMessage="Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" 
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Invalid email address" ForeColor="Red"></asp:RegularExpressionValidator>

            <asp:Label ID="lblAddress" runat="server" Text="Address:" AssociatedControlID="txtAddress"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>

            <asp:Label ID="lblGroup" runat="server" Text="Group:" AssociatedControlID="ddlGroup"></asp:Label>
            <asp:DropDownList ID="ddlGroup" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvGroup" runat="server" ControlToValidate="ddlGroup" 
                InitialValue="0" ErrorMessage="Group is required" ForeColor="Red"></asp:RequiredFieldValidator>

            <asp:Button ID="btnAddContact" runat="server" Text="Add Contact" OnClick="btnAddContact_Click" />
        </div>
    </form>
</asp:Content>
