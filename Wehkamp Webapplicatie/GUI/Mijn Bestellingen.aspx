<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="Mijn Bestellingen.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Mijn_Bestellingen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Scroll naar beneden in Listboxx om alle(!) bestellingen te zien"></asp:Label><br/>
<asp:ListBox ID="LbFactures" runat="server" Height="358px" Width="499px"></asp:ListBox>
</asp:Content>
