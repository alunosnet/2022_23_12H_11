<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AConsultas.aspx.cs" Inherits="MOD17AB_Projeto.Admin.AConsultas.AConsultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Consultas</h2>
    <asp:DropDownList ID="ddConsultas" CssClass="form-control" AutoPostBack="true" 
        OnSelectedIndexChanged="ddConsultas_SelectedIndexChanged" runat="server">
        <asp:ListItem Value="0">Material mais Comprado</asp:ListItem>
        <asp:ListItem Value="1">Utilizador/Jardineiro com mais compras</asp:ListItem>
        <asp:ListItem Value="2">Nº de material por marcas</asp:ListItem>
        <asp:ListItem Value="5">Lista dos Materiais cujo preço é superior à média</asp:ListItem>
        <asp:ListItem Value="3">Nº de utilizadores bloqueados</asp:ListItem>
        <asp:ListItem Value="4">Lista dos utilizadores que compram o material mais caro</asp:ListItem>
        <asp:ListItem Value="6">Lista dos utilizadores com a mesma password</asp:ListItem>
    </asp:DropDownList>
    <asp:GridView CssClass="table" ID="GvConsultasA" runat="server" />
</asp:Content>
