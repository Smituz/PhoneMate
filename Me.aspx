<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site1.Master" CodeBehind="Me.aspx.cs" Inherits="PhoneMate.Me" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblFullName" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="lblPhoneNumber" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="lblXID" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="lblInstagramID" runat="server" Text="Label"></asp:Label><br />
            <asp:GridView ID="MyProfile" runat="server">

            </asp:GridView>
        </div>
    </form>
</asp:Content>

