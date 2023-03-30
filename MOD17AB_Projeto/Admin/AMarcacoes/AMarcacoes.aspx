<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AMarcacoes.aspx.cs" Inherits="MOD17AB_Projeto.Admin.AMarcacoes.AMarcacoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Gestão de Serviços</h1>
    <h3>Gestão de Serviços por Aceitar</h3>
     <asp:GridView CssClass="table" EmptyDataText="Serviços por aceitar" ID="GvPAceitar" runat="server"/>
    <h3>Gestão de Serviços Aceites</h3>
    <asp:GridView CssClass="table" EmptyDataText="Nunca aceitou um serviço" ID="GvAceites" runat="server"/>

</asp:Content>
