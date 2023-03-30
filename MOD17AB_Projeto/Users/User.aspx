<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="MOD17AB_Projeto.Users.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Área de utilizador</h1>
    <div runat="server" id="divPerfil">
        Nome: <asp:Label  CssClass="form-control" runat="server" ID="lbNome"/><br />
        Codigo Postal: <asp:Label  CssClass="form-control" runat="server" ID="lbCP"/><br />
        Nif: <asp:Label  CssClass="form-control" runat="server" ID="lbnif"/><br />
        <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btEditar" Text="Editar Perfil" OnClick="btEditar_Click"/>
    </div>
    <div runat="server" id="divEditar">
        Nome:<asp:TextBox  CssClass="form-control" runat="server" ID="tbNome"/><br />
        Codigo Postal<asp:TextBox  CssClass="form-control" runat="server" ID="tbCP"/><br />
        Nif<asp:TextBox  CssClass="form-control" runat="server" ID="tbNif"/><br />
        <asp:Label runat="server" ID="lberro" />
        <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btAtualizar" Text="Atualizar Perfil" OnClick="btAtualizar_Click" />
        <asp:Button CssClass="btn btn-lg btn-info"  runat="server" ID="btCancelar" Text="Cancelar" OnClick="btCancelar_Click" />
    </div>
</asp:Content>
