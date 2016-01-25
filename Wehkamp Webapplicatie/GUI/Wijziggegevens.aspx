<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="Wijziggegevens.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Wijziggegevens" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <br/>
    
			Voornaam<asp:TextBox runat="server" ID="TbVoornaam" placeholder="Voornaam" CssClass="form-control" required></asp:TextBox><br/><br/>
            Voorletter(s)<asp:TextBox runat="server" ID="TbVoorletters" placeholder="Voorletter(s)" CssClass="form-control" required></asp:TextBox><br/><br/>
            Achternaam<asp:TextBox runat="server" ID="TbAchternaam" placeholder="Achternaam" CssClass="form-control" required></asp:TextBox><br/>
            <asp:RadioButtonList ID="RdGeslacht" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem>Man</asp:ListItem>
                <asp:ListItem>Vrouw</asp:ListItem>
            </asp:RadioButtonList>
            <br/>
            Geboortedatum<asp:TextBox runat="server" ID="TbGeboortedatum" placeholder="Geboortedatum (dd/mm/jjjj)" CssClass="form-control" required></asp:TextBox><br/><br/>
            Postcode<asp:TextBox runat="server" ID="TbPostcode" placeholder="Postcode" CssClass="form-control" required></asp:TextBox><br/><br/>
            Adres<asp:TextBox runat="server" ID="TbAdres" placeholder="Adres" CssClass="form-control" required></asp:TextBox><br/><br/>
            Woonplaats<asp:TextBox runat="server" ID="TbWoonplaats" placeholder="Woonplaats" CssClass="form-control" required></asp:TextBox><br/><br/>
            Telefoonnummer<asp:TextBox runat="server" ID="TbTelefoonnummer" placeholder="Telefoonnummer" CssClass="form-control" required></asp:TextBox><br/><br/>
            Mobielnummer<asp:TextBox runat="server" ID="TbMobielnummer" placeholder="Mobielnummer" CssClass="form-control" required></asp:TextBox><br/><br/>
    Telefoonwerk<asp:TextBox runat="server" ID="TbTelefoonwerk" placeholder="Telefoonwerk" CssClass="form-control" required></asp:TextBox><br/>
   Bezorgvoorkeur <asp:RadioButtonList ID="RbBezorgvoorkeur" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="Toegestaan"></asp:ListItem>
        <asp:ListItem Value="Niet toegestaan"></asp:ListItem>
    </asp:RadioButtonList>
   Emailvoorkeur <asp:RadioButtonList ID="RbEmailvoorkeur" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="Ja, ik wil op de hoogte gehouden worden van aanbiedingen en acties van wehkamp.nl"></asp:ListItem>
        <asp:ListItem Value="Niet toegestaan"></asp:ListItem>
    </asp:RadioButtonList>
  Cookievoorkeur  <asp:RadioButtonList ID="RbCookievoorkeur" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="Ja"></asp:ListItem>
        <asp:ListItem Value="Nee"></asp:ListItem>
    </asp:RadioButtonList>
  Productvoorkeur  <asp:RadioButtonList ID="RbProductvoorkeur" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="Ja"></asp:ListItem>
        <asp:ListItem Value="Nee"></asp:ListItem>
    </asp:RadioButtonList>
  Betaalvoorkeur  <asp:RadioButtonList ID="RbBetaalvoorkeur" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="Belansrekening sluiten"></asp:ListItem>
        <asp:ListItem Value="Gespreid betalen met mijn balansrekening"></asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br/>
    <asp:Button ID="BtWijzigGegevens" runat="server" OnClick="BtWijzigGegevens_Click" Text="Wijzig Gegevens" />
    <asp:Label ID="LbGeluktCheck" runat="server"></asp:Label>
    <br/>
    

</asp:Content>
