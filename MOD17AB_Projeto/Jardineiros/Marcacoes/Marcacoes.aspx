<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Marcacoes.aspx.cs" Inherits="MOD17AB_Projeto.Jardineiros.Marcacoes.Marcacoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Serviços de jardinagem</h2>
    <asp:GridView CssClass="table" EmptyDataText="Não existem anuncios disponíveis para emprestar" runat="server" ID="GvServicos"></asp:GridView>
    <asp:Label runat="server" ID="lbErro" />
</asp:Content>
