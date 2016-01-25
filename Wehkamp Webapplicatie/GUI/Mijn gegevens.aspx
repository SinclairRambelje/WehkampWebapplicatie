<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="Mijn gegevens.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Mijn_gegevens" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Button ID="BtWijzigGegevens" runat="server" Text="WijzigGegevens" OnClick="BtWijzigGegevens_Click" />
    <asp:Button ID="BtWijzigWachtwoord" runat="server" Text="BtWijzigWachtwoord" OnClick="BtWijzigWachtwoord_Click" />
    <br/>
    <asp:ListBox ID="LbGegevens" runat="server" Height="327px" Width="399px"></asp:ListBox>
</asp:Content>
