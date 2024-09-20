<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="EditContact.aspx.cs" Inherits="PhoneMate.EditContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

            <asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
    OnPageIndexChanging="gvContacts_PageIndexChanging" 
    OnSorting="gvContacts_Sorting" 
    OnRowEditing="gvContacts_RowEditing" 
    OnRowUpdating="gvContacts_RowUpdating" 
    OnRowCancelingEdit="gvContacts_RowCancelingEdit"
    DataKeyNames="ContactID" PageSize="10">
    
    <Columns>
        <asp:TemplateField HeaderText="Full Name">
            <ItemTemplate>
                <asp:Label ID="lblFullName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtFullName" runat="server" Text='<%# Bind("FullName") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Phone Number">
            <ItemTemplate>
                <asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Email">
            <ItemTemplate>
                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:CommandField ShowEditButton="True" ShowCancelButton="True" />
    </Columns>
</asp:GridView>
    </form>
</asp:Content>
