<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Emergent._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    Version&nbsp
    <asp:TextBox ID="txtVersion" runat="server"></asp:TextBox>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <br />
    <br />
    <asp:GridView ID="dgData" runat="server"></asp:GridView>
</asp:Content>
