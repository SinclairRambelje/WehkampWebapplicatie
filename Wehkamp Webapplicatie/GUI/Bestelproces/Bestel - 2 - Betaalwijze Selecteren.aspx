<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/MasterVoorBestelProces.Master" AutoEventWireup="true" CodeBehind="Bestel - 2 - Betaalwijze Selecteren.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Bestelproces.Bestel___2___Betaalwijze_Selecteren" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Label ID="LbSelecteerBetaalwijze" runat="server" Text="Selecteer Betaalwijze"></asp:Label><br/>
    <asp:DropDownList ID="DDlistBetaalwzijzes" runat="server">
    </asp:DropDownList>
    <br/>
    <asp:Button ID="BtPlaatsBestelling" runat="server" Text="Betaal(Plaats bestelling)" OnClick="BtPlaatsBestelling_Click" />
</asp:Content>
