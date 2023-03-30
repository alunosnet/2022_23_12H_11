<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Historico.aspx.cs" Inherits="MOD17AB_Projeto.Jardineiros.Historico.Historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Histórico</h2>
    <asp:GridView CssClass="table" EmptyDataText="Nunca comprou um material" ID="gvhistoricoj" runat="server"></asp:GridView>
</asp:Content>
