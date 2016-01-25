<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="Retourneren - stap 1.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Retourneren" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Kies Factuur"></asp:Label>
    <br/>
    <asp:ListBox ID="LbFactures" runat="server" Height="169px" Width="245px"></asp:ListBox>
    <br/>

    <asp:Button ID="BtVoegToeRetourneerLijst" runat="server" Text="Voeg items van geselecteerde factuur toe aan je retourneerlijst" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:Label ID="LbRetourneerLijstTitel" runat="server" Text="Retourneerlijst"></asp:Label>
    <br/>
    <asp:ListBox ID="LbRetourneerlijst" runat="server" Height="140px" Width="246px"></asp:ListBox>
    <br/>
    <asp:Button ID="BtVerwijderGeselecteerdeRetourneerItem" runat="server" Text="Verwijder geselecteerde retourneeritem" OnClick="BtVerwijderGeselecteerdeRetourneerItem_Click" />
    <br />
    <asp:Button ID="BtVerwijderAlleItems" runat="server" Text="Verwijder alle retourneeritem" OnClick="BtVerwijderAlleItems_Click" />
    <br/>
    <br/>
    <br/>
    <asp:Button ID="BtNaarStap2" runat="server" Text="Retourneer de retourneerlijst" OnClick="BtNaarStap2_Click" />

</asp:Content>
