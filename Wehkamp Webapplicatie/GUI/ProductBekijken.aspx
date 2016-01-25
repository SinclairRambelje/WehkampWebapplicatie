<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="ProductBekijken.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.ProductBekijken" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:ListBox ID="LbSpecificaties" runat="server" BackColor="#CCCCCC" ForeColor="Black" Height="177px" OnSelectedIndexChanged="LbSpecificaties_SelectedIndexChanged" Width="233px"></asp:ListBox>
    <br/>
    <asp:Button Text="Stop in winkelmand" runat="server" ID="BtStopInWinkelmand" OnClick="StopInWinkelMand"  />
<asp:Label ID="LbWMNotificatie" runat="server"></asp:Label>
    <br/>
    <br/>
    <br />
    Beoordeling
    <br/>
    <asp:Button ID="BtMaakBeoordeling" runat="server" Text="Plaats Beoordeling" OnClick="BtMaakBeoordeling_Click" /><asp:Label ID="LbCheckLogged" runat="server" Text=""></asp:Label>
    <br/>
    Gemiddelde beoordeling: <asp:Label ID="Lbgemiddelde" runat="server" Text="N.V.T."></asp:Label>
    <br/>
    <br/>
    <br/>
  
    <asp:ListView ID="ListView1" runat="server">
        
        <ItemTemplate>
            
            <hr class="colorgraph">
           
            
            Titel:<%# Eval("Title") %>
            <br/>
 van:<%# Eval("Naam") %>
            <br/>
            Beoordelingscijfer: <%# Eval("Beoordelingcijfer") %>
            <br/>
            Bericht:
            <br/>
             <%# Eval("Bericht") %>
            <hr class="colorgraph">
            <br/>
            <br/>
            <br/>

        </ItemTemplate>
    </asp:ListView>
</asp:Content>
