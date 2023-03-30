using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Jardineiros.Vendas
{
    public partial class Venda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (IsPostBack) return;
            try
            {
                //querystring 
                int idMaterial = int.Parse(Request["id"].ToString());

                Models.Material mt = new Models.Material();
                DataTable dados = mt.DadosMaterial(idMaterial);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o nmaterial não existe na tabela dos materiais
                    throw new Exception("Material não existe.");
                }
                //mostrar os dados materiais
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbPreco.Text = dados.Rows[0]["preco"].ToString();
                tbData.Text = DateTime.Parse(dados.Rows[0]["data_aquisicao"].ToString()).ToString("yyyy-MM-dd");
                tbQuantidade.Text = dados.Rows[0]["quantidade"].ToString();
            }
            catch
            {
                Response.Redirect("~/Jardineiros/JProdutos/Produtos.aspx");
            }

        }

        protected void btComprar_Click(object sender, EventArgs e)
        {
            Models.Material mt = new Models.Material();
            int idMaterial = int.Parse(Request["id"].ToString());
            int idUser = int.Parse(Session["id"].ToString());
            DataTable dados = mt.DadosMaterial(idMaterial);
            decimal preco = decimal.Parse(dados.Rows[0]["preco"].ToString());
            int quantidadecomprar = int.Parse(tbQuantidadeComprar.Text);
            Models.Vendas venda = new Models.Vendas();
            venda.AddVenda(idMaterial, idUser, quantidadecomprar, preco);
            Response.Redirect("~/Jardineiros/JProdutos/Produtos.aspx");
        }

        
    }
}