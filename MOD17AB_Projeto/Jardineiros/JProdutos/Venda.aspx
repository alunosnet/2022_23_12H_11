<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Venda.aspx.cs" Inherits="MOD17AB_Projeto.Jardineiros.Vendas.Venda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Checkout</h2>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNome">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="tbNome" runat="server" MaxLength="100" Required placeholder="Nome do produto" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbData">Data de Aquisição:</label>
        <asp:TextBox CssClass="form-control" ID="tbData" runat="server" TextMode="Date" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbPreco">Preço:</label>
        <asp:TextBox ID="tbPreco" CssClass="form-control" runat="server" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbQuantidade">Quantidade Disponivel:</label>
        <asp:TextBox CssClass="form-control" ID="tbQuantidade" runat="server" TextMode="Number"/>
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbQuantidadeCompra">Quantidade a Comprar:</label>
        <asp:TextBox CssClass="form-control" ID="tbQuantidadeComprar" runat="server" TextMode="Number"/>
    </div>
    <br />
    <asp:Button runat="server" ID="btComprar" CssClass="btn btn-lg btn-success" Text="Comprar" OnClick="btComprar_Click" />
    <asp:Button runat="server" ID="btVoltar" CssClass="btn btn-lg btn-info" Text="Voltar" PostBackUrl="~/Jardineiros/JProdutos/Produtos.aspx" />
    <br />
    <asp:Label ID="lbErro" runat="server"></asp:Label>

</asp:Content>
