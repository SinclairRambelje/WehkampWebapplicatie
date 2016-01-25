<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/MasterVoorBestelProces.Master" AutoEventWireup="true" CodeBehind="Bestel - 3 - Bestelling geplaasts en factuurgegevens.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Bestelproces.Bestel___3___Bestelling_geplaasts_en_factuurgegevens" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Uw bestelling is geplaatst!"></asp:Label>
    <br />
    <br />

    <asp:Label ID="Label2" runat="server" Text="U kan de factuur terugvinden onder 'mijn bestellingen'"></asp:Label>
    <br />
    <asp:ListBox ID="LbFactuur" runat="server" Height="291px" Width="357px"></asp:ListBox>
    <br/>
    <asp:Button ID="BtGaNaarHome" runat="server" Text="Ga terug naar homepagina" OnClick="BtGaNaarHome_Click" />

</asp:Content>
