<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="MOD17AB_Projeto.Jardineiros.JProdutos.Produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Comprar Materiais</h2>
    <asp:GridView CssClass="table" EmptyDataText="Não existem Materiais disponíveis para Comprar" runat="server" ID="GvMateriaisJ"></asp:GridView>
    <asp:Label runat="server" ID="lbErro"></asp:Label>
</asp:Content>
