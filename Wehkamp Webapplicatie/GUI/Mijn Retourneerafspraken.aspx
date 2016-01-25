<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="Mijn Retourneerafspraken.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Mijn_Retourneerafspraken" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Label ID="lbTitel" runat="server" Text="Retourafspraken"></asp:Label>
    <br/>
    <asp:ListBox ID="LbRetourafspraken" runat="server"></asp:ListBox>
</asp:Content>
