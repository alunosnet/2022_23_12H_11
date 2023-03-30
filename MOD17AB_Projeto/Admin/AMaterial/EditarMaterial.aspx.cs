using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Admin.AMaterial
{
    public partial class EditarMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "2") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (IsPostBack) return;
            try
            {
                //querystring nmaterial
                int nMaterial = int.Parse(Request["id"].ToString());

                Models.Material mt = new Models.Material();
                DataTable dados = mt.DadosMaterial(nMaterial);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o nmt não existe na tabela dos mts
                    throw new Exception("Material não existe.");
                }
                //mostrar os dados mt
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbMarca.Text = dados.Rows[0]["marca"].ToString();
                tbPreco.Text = dados.Rows[0]["preco"].ToString();
                tbData.Text = DateTime.Parse(dados.Rows[0]["data_aquisicao"].ToString()).ToString("yyyy-MM-dd");
                tbQuantidade.Text = dados.Rows[0]["quantidade"].ToString();
            }
            catch
            {
                Response.Redirect("~/Admin/AMaterial/AMaterial.aspx");
            }
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNome.Text;
                if (nome.Trim().Length < 3)
                {
                    throw new Exception("O nome é muito pequeno.");
                }
                DateTime data = DateTime.Parse(tbData.Text);
                if (data > DateTime.Now)
                {
                    throw new Exception("A data tem de ser inferior à data atual");
                }
                Decimal preco = Decimal.Parse(tbPreco.Text);
                if (preco < 0 || preco > 100)
                {
                    throw new Exception("O preço deve estar entre 0 e 100");
                }
                string marca = tbMarca.Text;
                if (marca.Trim().Length < 3)
                {
                    throw new Exception("O nome do marca é muito pequeno");
                }
                int quantidade = int.Parse(tbQuantidade.Text);
                if (quantidade <= 0 || quantidade > 200)
                {
                    throw new Exception("A quantidade não é válido");
                }
                Models.Material mt = new Models.Material();
                mt.nome = nome;
                mt.preco = preco;
                mt.data_aquisicao = data;
                mt.marca = marca;
                mt.quantidade = quantidade;
                mt.nMaterial = int.Parse(Request["id"].ToString());
                mt.atualizaMaterial();

                lbErro.Text = "O material foi atualizado com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('AMaterial.aspx')", true);
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
        }
    }
}