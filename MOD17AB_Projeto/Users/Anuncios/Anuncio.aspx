<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Anuncio.aspx.cs" Inherits="MOD17AB_Projeto.Users.Anuncios.Anuncio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Criar Anuncio Serviços </h1>
    
    Tema <asp:TextBox CssClass="form-control"  runat="server" ID="tb_tema"/><br />
    Descrição <asp:TextBox CssClass="form-control" runat="server" ID="tb_descricao" /><br />
    Data de Inicio:<asp:TextBox CssClass="form-control" ID="tb_data" runat="server" TextMode="Date" /><br />
   <asp:Button CssClass="btn btn-lg btn-success" runat="server" ID="bt_Add" Text="Adicionar" OnClick="bt_Add_Click" />
   <asp:Label runat="server" ID="lbErro" />
    
</asp:Content>
