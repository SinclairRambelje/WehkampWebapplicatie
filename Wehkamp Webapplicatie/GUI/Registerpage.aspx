<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="Registerpage.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Registerpage" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Registerpage.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <br />
    <br />
<div class="container">

<div class="row">
    <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
		<form role="form">
			<h2>Registreer <small>je</small></h2>
			<hr class="colorgraph">
            <asp:TextBox runat="server" ID="tbEmail" placeholder="E-mail" TextMode="Email" CssClass="form-control" required></asp:TextBox><br/><br/>
			<asp:TextBox runat="server" ID="TbVoornaam" placeholder="Voornaam" CssClass="form-control" required></asp:TextBox><br/><br/>
            <asp:TextBox runat="server" ID="TbVoorletters" placeholder="Voorletter(s)" CssClass="form-control" required></asp:TextBox><br/><br/>
            <asp:TextBox runat="server" ID="TbAchternaam" placeholder="Achternaam" CssClass="form-control" required></asp:TextBox><br/>
            <asp:RadioButtonList ID="RdGeslacht" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem>Man</asp:ListItem>
                <asp:ListItem>Vrouw</asp:ListItem>
            </asp:RadioButtonList>
            <br/>
            <asp:TextBox runat="server" ID="TbGeboortedatum" placeholder="Geboortedatum (dd/mm/jj)" CssClass="form-control" required></asp:TextBox><br/><br/>
            <asp:TextBox runat="server" ID="TbPostcode" placeholder="Postcode" CssClass="form-control" required></asp:TextBox><br/><br/>
            <asp:TextBox runat="server" ID="Adres" placeholder="Adres" CssClass="form-control" required></asp:TextBox><br/><br/>
            <asp:TextBox runat="server" ID="TbWoonplaats" placeholder="Woonplaats" CssClass="form-control" required></asp:TextBox><br/><br/>
            <asp:TextBox runat="server" ID="TbTelefoonnummer" placeholder="Telefoonnummer" CssClass="form-control" required></asp:TextBox><br/><br/>
            <asp:TextBox runat="server" ID="TbMobielnummer" placeholder="Mobielnummer" CssClass="form-control" required></asp:TextBox><br/><br/>
                    
            <asp:TextBox runat="server" ID="Tbwachtwoord" placeholder="Herhaal wachtwoord" TextMode="Password" CssClass="form-control" required></asp:TextBox>(min 8 tekens)<br/><br/>
                        <asp:TextBox runat="server" ID="TbWachtwoordherhaald" placeholder="Herhaal wachtwoord" TextMode="Password" CssClass="form-control" required></asp:TextBox><br/><br/>
                        <asp:Button runat="server" id="BtRegisteer" Text="Registreer" CssClass="btn btn-primary btn-block" OnClick="BtRegisteer_Click"/>
			
			<asp:Label ID="LbRegisterCheck" runat="server"></asp:Label>
			
			<hr class="colorgraph">
			<div class="row">
				
			</div>
		</form>
	</div>
</div>


 

    </div>
</asp:Content>
