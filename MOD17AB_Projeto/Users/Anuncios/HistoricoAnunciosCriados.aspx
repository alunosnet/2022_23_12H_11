<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HistoricoAnunciosCriados.aspx.cs" Inherits="MOD17AB_Projeto.Users.Anuncios.HistoricoAnunciosCriados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Historico anuncios do Utilizador</h1>
<asp:GridView CssClass="table" EmptyDataText="Serviços por aceitar" ID="GvHistoricoAU" runat="server"/>
</asp:Content>
