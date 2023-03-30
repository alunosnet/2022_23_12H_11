<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AUtilizadores.aspx.cs" Inherits="MOD17AB_Projeto.Admin.AUtilizadores.AUtilizadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h1>Utilizadores</h1>
    <asp:GridView CssClass="table" ID="GvUtilizadores" runat="server"/>
    <h1>Adicionar Utilizador</h1>
    Nome:<asp:TextBox CssClass="form-control" runat="server" ID="tb_nome"/><br />
    Email:<asp:TextBox CssClass="form-control" runat="server" ID="tb_email"/><br />
    Código Postal:<asp:TextBox CssClass="form-control" runat="server" ID="tb_CP"/><br />
    Nif:<asp:TextBox CssClass="form-control" runat="server" ID="tb_nif"/><br />
    Password:<asp:TextBox CssClass="form-control" runat="server" ID="tb_password" TextMode="Password"/><br />
    Perfil:<asp:DropDownList CssClass="form-control" runat="server" ID="dd_perfil">
                <asp:ListItem Value="2">Admin</asp:ListItem>
                <asp:ListItem Value="1">Jardineiro</asp:ListItem>
                <asp:ListItem Value="0">Utilizador</asp:ListItem>
            </asp:DropDownList>
    <br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="bt_Adicionar" Text="Adicionar" OnClick="bt_Adicionar_Click" />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>
