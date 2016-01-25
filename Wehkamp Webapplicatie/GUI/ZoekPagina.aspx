<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="ZoekPagina.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.ZoekPagina" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:TextBox ID="TbZoek" runat="server"></asp:TextBox><asp:Button ID="BtZoekOpNaam" runat="server" Text="ZoekOpNaam" OnClick="BtZoekOpNaam_Click" />
    <asp:Button ID="BtZoekOpCategorie" runat="server" OnClick="BtZoekOpCategorie_Click" Text="Zoek op categorie" />
    <br/>
    <asp:ListView ID="ListView1" runat="server">
        
        <ItemTemplate>
            
            <hr class="colorgraph">
            <img src="images/top_blue.gif" alt="Top - Style 2" />
            <br/>
            <%# Eval("productnaam") %>
            <br/>
            Prijs: <%# Eval("prijs") %>
            <br/>
            <asp:Button Text="Bekijk product" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="Bekijkproduct"/>
            <hr class="colorgraph">
            <br/>
            <br/>
            <br/>

        </ItemTemplate>
    </asp:ListView>
</asp:Content>
