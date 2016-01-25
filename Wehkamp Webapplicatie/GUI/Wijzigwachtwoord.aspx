<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="Wijzigwachtwoord.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Wijzigwachtwoord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Label ID="LbTitel" runat="server" Text="Wijzig wachtwoord"></asp:Label>
    <br />
    <asp:TextBox runat="server" ID="Tbwachtwoord" placeholder="Wachtwoord" TextMode="Password" CssClass="form-control" required></asp:TextBox><br/><br/>
                        <asp:TextBox runat="server" ID="TbWachtwoordherhaald" placeholder="Herhaal wachtwoord" TextMode="Password" CssClass="form-control" required></asp:TextBox><br/><br/>
    <br/>
    <asp:Button ID="BtWijzigWachtwoord" runat="server" Text="Wijzig" OnClick="BtWijzigWachtwoord_Click" /><asp:Label ID="LbSuccesCheck" runat="server" Text=""></asp:Label>
</asp:Content>
