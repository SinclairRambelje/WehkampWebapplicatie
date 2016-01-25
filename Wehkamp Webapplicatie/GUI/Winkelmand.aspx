<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="Winkelmand.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Winkelmand"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ListView ID="ListView1" runat="server">
        
        <ItemTemplate>
            
            <hr class="colorgraph">
            <img src="images/top_blue.gif" alt="Top - Style 2" />
            <br/>
            <%# Eval("productnaam") %>
            <br/>
            Prijs: <%# Eval("prijs") %>
            <br/>
            <asp:Button Text="Bekijk product" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="BekijkProduct"/>
            <br/>
            <asp:Button Text="Verwijder Product uit winkelmand" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="VerwijderProduct"/>
            <hr class="colorgraph">
            <br/>
            <br/>
            <br/>

        </ItemTemplate>
    </asp:ListView>
    Totaal: €<asp:Label ID="LbTotaal" runat="server" Text="0,00"></asp:Label>
    <br />
    <br />
    <asp:Button ID="BtVerwijderAlles" runat="server" Text="Verwijder alle items uit winkelmand" OnClick="BtVerwijderAlles_Click" />
    <br/>
    <asp:Button ID="BtCheckOut" runat="server" OnClick="BtCheckOut_Click" Text="Check out" /><asp:Label ID="LbCheckOutCheck" runat="server" Text=""></asp:Label>
    <br/>
    <br />

</asp:Content>
