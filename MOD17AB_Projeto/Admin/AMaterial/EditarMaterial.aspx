<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarMaterial.aspx.cs" Inherits="MOD17AB_Projeto.Admin.AMaterial.EditarMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Editar Material</h1>
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
        <asp:TextBox ID="tbPreco" CssClass="form-control" runat="server"  /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbMarca">Marca:</label>
        <asp:TextBox ID="tbMarca" CssClass="form-control" runat="server" placeholder="Nome da Marca" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbQuantidade">Quantidade:</label>
            <asp:TextBox ID="tbQuantidade" CssClass="form-control" runat="server" placeholder="Quantidade do Material" /><br />
    </div>
    
    <asp:Button runat="server" ID="btAtualizar" CssClass="btn btn-lg btn-success" Text="Atualizar" OnClick="btAtualizar_Click" />
    <asp:Button runat="server" ID="btVoltar" CssClass="btn btn-lg btn-info" Text="Voltar" PostBackUrl="~/Admin/AMaterial/AMaterial.aspx" />
    <br />
    <asp:Label ID="lbErro" runat="server"></asp:Label>

</asp:Content>
