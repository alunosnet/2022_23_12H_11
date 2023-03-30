<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registo.aspx.cs" Inherits="MOD17AB_Projeto.Registo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registo</h1>
    Nome:<asp:TextBox CssClass="form-control"  runat="server" ID="tb_nome"/><br />
    Email:<asp:TextBox CssClass="form-control"  runat="server" ID="tb_email"/><br />
    Código Postal:<asp:TextBox CssClass="form-control"  runat="server" ID="tb_cp"/><br />
    Nif:<asp:TextBox CssClass="form-control"  runat="server" ID="tb_nif"/><br />
    Password:<asp:TextBox CssClass="form-control"  runat="server" ID="tb_password" TextMode="Password"/><br />
    
    <div class="form-group">
        Perfil:
        <asp:DropDownList CssClass="form-control" ID="dpPerfil" runat="server">
            <asp:ListItem Text="" Value="" />
            <asp:ListItem Text="Utilizador" Value="0" />
            <asp:ListItem Text="Jardineiro" Value="1"/>
        </asp:DropDownList><br />
    </div>
    <!--Recaptcha-->
    <div class="g-recaptcha" data-sitekey="6LczdM8jAAAAAMje4BXy1d-vly027TN18ZuO0YcK"></div>
    <br /><asp:Label  runat="server" ID="lb_erro"></asp:Label>
    <asp:button CssClass="btn btn-info" runat="server" ID="bt_guardar" Text="Registar" OnClick="bt_guardar_Click" /><br/>
    
</asp:Content>
