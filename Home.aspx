<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Home.aspx.cs" Inherits="PhoneMate.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <form id="serachform" runat="server">
    <asp:Label ID="Search" runat="server" Text="Label">Search a Contact</asp:Label><br /><br />
   <asp:TextBox ID="q" runat="server">John Doe</asp:TextBox>
    <asp:Button ID="SearchContact" runat="server" OnClick="SearchContact_Click" Text="Search" />
    
    <br />
    <br />
    <div>
        <asp:Panel ID="SearchPanel" runat="server" Visible="false">
            <asp:GridView ID="SearchResults" runat="server"></asp:GridView>
        </asp:Panel>
        <asp:Panel ID="Noresult" runat="server" Visible="false">
            <h6 style="color : orangeRed ">No results Found!!</h6>
        </asp:Panel>
    </div>
    <div>
        <h3>Your Contacts</h3>
        <hr />
        <asp:GridView ID="AllContacts" runat="server">

        </asp:GridView>
    </div>
</form>
</asp:Content>