<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="AddBeoordeling.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.AddBeoordeling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #Text2 {
            height: 264px;
            width: 462px;
        }
        #TextArea1 {
            height: 247px;
            width: 480px;
        }
        #TaBericht {
            height: 185px;
            width: 409px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <p>
        Nieuw beoordeling</p>
    <p>
        Titel</p>
    <asp:TextBox ID="TbTitel" runat="server" MaxLength="30"></asp:TextBox>
    <p>
        Waardering</p>
    <p>
        <asp:RadioButtonList ID="RbWaardering" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
        </asp:RadioButtonList>
    </p>
    <p>
        Bericht(max 250 tekens)</p>
    <p>
        <asp:TextBox ID="TbBericht" runat="server" Height="269px" MaxLength="250" TextMode="MultiLine" Width="330px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="BtPlaatsBeoordeling" runat="server" OnClick="BtPlaatsBeoordeling_Click" Text="Plaats Beoordeling" />
        <asp:Label ID="LbSuccesCheck" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
