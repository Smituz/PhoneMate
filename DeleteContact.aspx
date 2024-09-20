<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="DeleteContact.aspx.cs" Inherits="PhoneMate.DeleteContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Delete Contact</h2>
    <asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvContacts_RowDeleting" DataKeyNames="ContactID" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvContacts_PageIndexChanging">
        <Columns>

            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="Group" HeaderText="Group" />


            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this contact?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
