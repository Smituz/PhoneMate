<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="MyGroups.aspx.cs" Inherits="PhoneMate.MyGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <!-- DropDownList for selecting a group -->
            <asp:DropDownList ID="ddlGroups1" runat="server" OnSelectedIndexChanged="DDLGrpChng" AutoPostBack="true">

            </asp:DropDownList>
            <!-- GridView to display contacts -->
            <asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="True" Visible="False">
                <Columns>
                    <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                </Columns>
            </asp:GridView>

            <!-- Panel to display "No Results" message -->
            <asp:Panel ID="NoResults" runat="server" Visible="False">
                <asp:Label ID="NoResultsLabel" runat="server" Text="No contacts found for the selected group."></asp:Label>
            </asp:Panel>
        </div>
    </form>
</asp:Content>
