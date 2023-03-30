<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="detalhesmaterial.aspx.cs" Inherits="MOD17AB_Projeto.detalhesmaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbNome" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lbMarca" runat="server" Text="">Marca:</asp:Label><br />
    <asp:Label ID="lbData" runat="server" Text="">Data Aquisição:</asp:Label><br />
    <asp:Label ID="lbPreco" runat="server" Text="">Preço</asp:Label><br />
    <asp:Label ID="lbQuantidade" runat="server" Text="" >Quantidade</asp:Label><br />
    <br /><a href="/index.aspx">Voltar</a>
</asp:Content>
