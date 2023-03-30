<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="JHistoricoMarcacoes.aspx.cs" Inherits="MOD17AB_Projeto.Jardineiros.Marcacoes.JHistoricoMarcacoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Histórico de serviços</h1>
     <asp:GridView CssClass="table" EmptyDataText="Nunca aceitou um serviço" ID="Gvhistoricojm" runat="server"></asp:GridView>
</asp:Content>
