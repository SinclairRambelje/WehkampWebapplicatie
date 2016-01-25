<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/MasterVoorBestelProces.Master" AutoEventWireup="true" CodeBehind="Bestel - 1 - Verzenadres.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Bestelproces.Bestel___1___Verzenadres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Label ID="LbInstructie" runat="server" Text="Stap 1"></asp:Label>
    <br />
    <br />
    Selecteer adres<br/>
    <asp:ListBox ID="lBIngelogdeAdres" runat="server" Height="166px" Width="163px"></asp:ListBox>
    
    <asp:ListBox ID="ListBox2" runat="server" Height="162px" Width="198px"></asp:ListBox>
    <br/>

    
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="Bestaande Adres"></asp:ListItem>
        <asp:ListItem Value="Ophaalpunt(werkt niet)"></asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Selecteer gewenste leverdatum"></asp:Label><br/>

    <asp:DropDownList ID="DDListLeverdatum" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <br/>

    <asp:Button ID="BtGaNaarStap2" runat="server" Text="Ga naar stap 2" OnClick="BtGaNaarStap2_Click" />
    <br/>
    
</asp:Content>
