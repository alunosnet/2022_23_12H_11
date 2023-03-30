<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MOD17AB_Projeto.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Website Jardinagem</h1>
    <!--Login-->
     <div runat="server" id="divLogin" class="float-end col-sm-3 table-bordered divLogin" style="z-index:1">
        Email:
         <asp:TextBox CssClass="form-control" TextMode="Email" runat="server" ID="tb_Email"></asp:TextBox><br />
        Password:
         <asp:TextBox CssClass="form-control" runat="server" ID="tb_Password" TextMode="Password"></asp:TextBox><br />
        
         <asp:Label runat="server" ID="lb_erro"></asp:Label><br />
        
         <asp:Button  CssClass="btn btn-info" runat="server" ID="bt_login" Text="Login" OnClick="bt_login_Click" />
         <asp:Button  CssClass="btn btn-danger" runat="server" ID="bt_recuperar" Text="Recuperar password" OnClick="bt_recuperar_Click" />
    </div>
    
    <!--Pesquisa-->
    <div class="col-sm-8 float-start">
        <br />
        <h2>Materiais de Jardinagem</h2>

        <div class=" col-sm-8 input-group">
            <asp:TextBox CssClass="form-control" ID="tbPesquisa" runat="server"></asp:TextBox>
            <span class="input-group-btn">
                <asp:Button CssClass="btn btn-info" runat="server" ID="btPesquisar" Text="Pesquisar" OnClick="btPesquisar_Click" />
            </span>
        </div>
    </div>

    <!--Lista dos Materiais-->
    <div class="float-start col-md-8 m-1" id="divMaterial" runat="server"></div>
</asp:Content>
