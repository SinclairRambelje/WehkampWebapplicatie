<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Login" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="Loginpage.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
   
    
	    
		<form action="" method="post" name="Login_Form" class="form-signin">       
		    <h3 class="form-signin-heading">Welkom terug<asp:LoginView ID="LoginView1" runat="server">
                </asp:LoginView>
            </h3>
			  <hr class="colorgraph"><br>
			  
            <asp:TextBox runat="server" ID="tbEmail" placeholder="E-mail" TextMode="Email" CssClass="form-control" required></asp:TextBox>
                    
            <asp:TextBox runat="server" ID="Tbwachtwoord" placeholder="Herhaal wachtwoord" TextMode="Password" CssClass="form-control" required></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="submit" Text="Login" />
		</form>			
	    
	    <asp:Label ID="LbInlogCheck" runat="server"></asp:Label>
	
	
</asp:Content>
