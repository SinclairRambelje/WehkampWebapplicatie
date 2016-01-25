<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/MasterVoorBestelProces.Master" AutoEventWireup="true" CodeBehind="Retourneren - stap 2.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Retourproces.Retourneren___stap_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <p>
        <asp:Label ID="LbTitel" runat="server" Text="Uw retourafspraak is geplaatst, u kunt u retourafspraken vinden onder 'mijn retourafspraken'"></asp:Label>
        <br />
        <asp:ListBox ID="LbRetourAfspraak" runat="server" Height="266px" Width="339px"></asp:ListBox>
    </p>
    <p>
        <asp:Button ID="BtTerugNaarHome" runat="server" OnClick="BtTerugNaarHome_Click" Text="Terug naar homepagina" />
    </p>
    <p>
    </p>
</asp:Content>
