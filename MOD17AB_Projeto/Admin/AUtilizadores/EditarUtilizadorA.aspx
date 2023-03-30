<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarUtilizadorA.aspx.cs" Inherits="MOD17AB_Projeto.Admin.AUtilizadores.EditarUtilizadorA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Editar Utilizador ADMIN</h1><br />
    Nome:<asp:TextBox CssClass="form-control" runat="server" ID="tbNome"/><br />
    Morada:<asp:TextBox CssClass="form-control" runat="server" ID="tbcp"/><br />
    Nif:<asp:TextBox CssClass="form-control" runat="server" ID="tbNif"/><br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btEditar" Text="Editar" OnClick="btEditar_Click" />
    <asp:Button CssClass="btn btn-lg btn-info" 
        runat="server" 
        ID="btVoltar" 
        Text="Voltar" 
        PostBackUrl="~/Admin/AUtilizadores/AUtilizadores.aspx"/>
     <br /><asp:Label runat="server" ID="lbErro" Text="" />
</asp:Content>
