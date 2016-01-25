<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master1.Master" AutoEventWireup="true" CodeBehind="Productenlijst.aspx.cs" Inherits="Wehkamp_Webapplicatie.GUI.Kleding___Heren___Jassen" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Loginpage.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <%--<asp:ListView runat="server" ID="listView" OnItemCreated="listView_ItemCreated">
        <LayoutTemplate>
            <ul><asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder></ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li><%# Eval("GroupName") %>
                <asp:ListView runat="server" DataSource='<%# Eval("productList")%>'>
                    <LayoutTemplate>
                        <ul><asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder></ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li><%# Eval("ProductName") %> - Details: <%# Eval("ProductDetails") %></li>
                        <td>
        <asp:Button ID="Button1" runat="server" Text="Button" />
      </td>
                    </ItemTemplate>
                </asp:ListView>
            </li>
        </ItemTemplate>
    </asp:ListView>--%>
    <asp:ListView ID="ListView1" runat="server">
        
        <ItemTemplate>
            
            <hr class="colorgraph">
            <img src="/GUI/images/top_blue.gif" alt="Top - Style 2" />
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
