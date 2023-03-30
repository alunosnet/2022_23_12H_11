<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="MOD17AB_Projeto.Admin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS-JS-Imagens/chartistJS/chartist.css" rel="stylesheet" />
    <script src="/CSS-JS-Imagens/chartistJS/chartist.js"></script>
    <script src="/CSS-JS-Imagens/jquery/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Perfil Admin</h1>
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
        <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btAtualizar" Text="Atualizar Perfil" OnClick="btAtualizar_Click" />
        <asp:Button CssClass="btn btn-lg btn-info"  runat="server" ID="btCancelar" Text="Cancelar" OnClick="btCancelar_Click" />
    </div>
    <button id="btnlista" class="btn btn-info">Carregar dados</button>
    <button id="btnCriaGrafico" class="btn btn-success">Dados de utilizadores</button>
    <div id="divLista"></div>
    <div class="ct-chart ct-golden-section"></div>
    <script>
        $(document).ready(function () {

            $("#btnlista").on('click', function (e) {
                //alert("btn lista");
                e.preventDefault();
                $.ajax({
                    type: "POST",
                    url: "Servicos.asmx/ListaMateriais",
                    contentType: "application/json; charset=utf-8",
                    success: OnSuccess,
                    error: OnError
                });
                function OnError(response) {
                    alert("Alguma coisa errada correu mal");
                }
                function OnSuccess(response) {
                    alert(response.d);
                    var listaMateriais = JSON.parse(response.d);
                    for (var i = 0; i < listaMateriais.length; i++) {
                        $("#divLista").append(listaMateriais[i].nome + "<br/>");
                    }
                }
            });

            $("#btnCriaGrafico").on('click', function (e) {
                //alert("btn gráfico");
                var pData = [];
                /*pData[0] = $("#ddlyear").val();*/
                var jsonData = JSON.stringify({ pData: pData });

                $.ajax({
                    type: "POST",
                    url: "Servicos.asmx/DadosUtilizadores",
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
                function OnSuccess_(response) {
                    var aData = response.d;
                    var arrLabels = [], arrSeries = [];
                    $.map(aData, function (item, index) {
                        arrLabels.push(item.perfil);
                        arrSeries.push(item.contagem);
                    });
                    var data = {
                        labels: arrLabels,
                        series: arrSeries
                    }
                    // This is themain part, where we set data and create PIE CHART
                    new Chartist.Pie('.ct-chart', data);
                }

                function OnErrorCall_(response) {
                    alert("Whoops something went wrong!");
                    console.log(response);
                }
                e.preventDefault();
            });
        });
    </script>
</asp:Content>
