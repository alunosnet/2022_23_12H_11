<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HistoricoUtilizadorA.aspx.cs" Inherits="MOD17AB_Projeto.Admin.AUtilizadores.HistoricoUtilizadorA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Histórico</h2>
    <asp:GridView EmptyDataText="Utilizador não tem Vendas." CssClass="table" ID="GvHistoricoA" runat="server"/><br />
    <asp:Label ID="lbErro" runat="server" Text=""/><br />
    <asp:Button CssClass="btn btn-info" ID="bt_voltar" runat="server" Text="Voltar" PostBackUrl="~/Admin/AUtilizadores/AUtilizadores.aspx" />
</asp:Content>
