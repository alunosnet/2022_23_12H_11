<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApagarUtilizadorA.aspx.cs" Inherits="MOD17AB_Projeto.Admin.AUtilizadores.ApagarUtilizadorA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Apagar utilizador</h1>
    <br />
    <h3>Nome:</h3><asp:Label ID="lbNome" runat="server" Text=""></asp:Label><br />
    <br /><h3>ID do utilizador:</h3> <asp:Label ID="lbId" runat="server" Text=""></asp:Label><br/>
    <br /><asp:Button ID="btnRemover" 
        runat="server" 
        CssClass="btn btn-lg btn-danger" 
        Text="Remover" OnClick="btnRemover_Click" />
    <asp:Button CssClass="btn btn-lg btn-info" 
        runat="server" 
        ID="btVoltar" 
        Text="Voltar" 
        PostBackUrl="~/Admin/AUtilizadores/AUtilizadores.aspx"/>
</asp:Content>
