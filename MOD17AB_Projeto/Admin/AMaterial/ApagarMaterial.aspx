<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApagarMaterial.aspx.cs" Inherits="MOD17AB_Projeto.Admin.AMaterial.ApagarMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Apagar Material</h1>
    Nº Material:<asp:Label  runat="server" ID="lbNMaterial" CssClass="form-control" /><br />
    Nome:<asp:Label runat="server" ID="lbNome" CssClass="form-control" /><br />
    Quantidade:<asp:Label runat="server" ID="lbQuantidade" CssClass="form-control" /><br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btRemover" Text="Remover" OnClick="btRemover_Click"/>
    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btVoltar" Text="Voltar" OnClick="btVoltar_Click" /><br />
    <asp:Label runat="server" ID="lbErro"></asp:Label>

</asp:Content>
