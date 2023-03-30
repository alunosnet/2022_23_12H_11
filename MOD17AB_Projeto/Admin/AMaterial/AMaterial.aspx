<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AMaterial.aspx.cs" Inherits="MOD17AB_Projeto.Admin.Material.AMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Gestão de Materiais</h2>
    <asp:GridView ID="GVMateriais" runat="server" CssClass="table"/>
    <h2>Adicionar Materiais</h2>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNome">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="tbNome" runat="server" MaxLength="100" Required placeholder="Nome do Material" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbData">Data de Aquisição:</label>
        <asp:TextBox CssClass="form-control" ID="tbData" runat="server" TextMode="Date" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbPreco">Preço:</label>
        <asp:TextBox ID="tbPreco" CssClass="form-control" runat="server" TextMode="Number" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbMarca">Marca:</label>
        <asp:TextBox ID="tbMarca" CssClass="form-control" runat="server" placeholder="Marca do Material" /><br />
    </div>
    <div class="from-group">
       <label for="ContentPlaceHolder1_tbQuantidade">Quantidade:</label>
        <asp:TextBox ID="tbQuantidade" CssClass="form-control" runat="server" TextMode="Number" /><br />
    </div> 
    <br />
    <asp:Button CssClass="btn btn-lg btn-success" runat="server" ID="bt_Add" Text="Adicionar" OnClick="bt_Add_Click" />
    <asp:Label runat="server" ID="lbErro" />
</asp:Content>
