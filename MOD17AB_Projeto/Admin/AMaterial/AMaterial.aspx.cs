using MOD17AB_Projeto.Classes;
using MOD17AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Admin.Material
{
    public partial class AMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "2") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            ConfigurarGrid();

            if (!IsPostBack)
            {
                AtualizarGrid();
            }
        }

        private void AtualizarGrid()
        {
            GVMateriais.Columns.Clear();
            Models.Material mt = new Models.Material();
            DataTable dados = mt.ListaTodosMateriais();

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            DataColumn dcApagar = new DataColumn();
            dcApagar.ColumnName = "Apagar";
            dcApagar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcApagar);

            //colunas da gridview
            GVMateriais.DataSource = dados;
            GVMateriais.AutoGenerateColumns = false;

            //Editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar...";
            hlEditar.DataNavigateUrlFormatString = "EditarMaterial.aspx?id={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "id" };
            GVMateriais.Columns.Add(hlEditar);
            //Apagar
            HyperLinkField hlApagar = new HyperLinkField();
            hlApagar.HeaderText = "Apagar";
            hlApagar.DataTextField = "Apagar";
            hlApagar.Text = "Apagar...";
            hlApagar.DataNavigateUrlFormatString = "ApagarMaterial.aspx?id={0}";
            hlApagar.DataNavigateUrlFields = new string[] { "id" };
            GVMateriais.Columns.Add(hlApagar);
            //nMaterial
            BoundField bfnMaterial = new BoundField();
            bfnMaterial.HeaderText = "Nº Material";
            bfnMaterial.DataField = "ID";
            GVMateriais.Columns.Add(bfnMaterial);
            //nome
            BoundField bfnome = new BoundField();
            bfnome.HeaderText = "Nome";
            bfnome.DataField = "nome";
            GVMateriais.Columns.Add(bfnome);
            //data aquisição
            BoundField bfdata = new BoundField();
            bfdata.HeaderText = "Data aquisição";
            bfdata.DataField = "Data";
            bfdata.DataFormatString = "{0:dd-MM-yyyy}";
            GVMateriais.Columns.Add(bfdata);
            //Preço
            BoundField bfpreco = new BoundField();
            bfpreco.HeaderText = "Preço";
            bfpreco.DataField = "Preço";
            bfpreco.DataFormatString = "{0:C}";
            GVMateriais.Columns.Add(bfpreco);
            //Marca
            BoundField bfmarca = new BoundField();
            bfmarca.HeaderText = "Marca";
            bfmarca.DataField = "Marca";
            GVMateriais.Columns.Add(bfmarca);
            //Quantidade
            BoundField bfquantidade = new BoundField();
            bfquantidade.HeaderText = "Quantidade";
            bfquantidade.DataField = "Quantidade";
            GVMateriais.Columns.Add(bfquantidade);
            
            GVMateriais.DataBind();
        }

        private void ConfigurarGrid()
        {
            GVMateriais.AllowPaging = true;
            GVMateriais.PageSize = 5;
            GVMateriais.PageIndexChanging += GvMateriais_PageIndexChanging;
        }
        private void GvMateriais_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVMateriais.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        /// <summary>
        /// Adicionar um Material
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bt_Add_Click(object sender, EventArgs e)
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
                if (preco < 0 || preco > 10000)
                {
                    throw new Exception("O preço deve estar entre 0 e 10000");
                }
                string marca = tbMarca.Text;
                if (marca.Trim().Length < 3)
                {
                    throw new Exception("O nome da Marca é muito pequeno");
                }
                int quantidade = int.Parse(tbQuantidade.Text);
                if (quantidade <= 0 || quantidade > 200)
                {
                    throw new Exception("A deve estar entre 0 e 199");
                }
                Models.Material material = new Models.Material();
                material.nome = nome;
                material.preco = preco;
                material.data_aquisicao = data;
                material.marca = marca;
                material.quantidade = quantidade;
                int nMaterial = material.Add();
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
            //limpar form
            tbNome.Text = "";
            tbPreco.Text = "";
            tbMarca.Text = "";
            tbQuantidade.Text = "";
            tbData.Text = DateTime.Now.ToShortDateString();
            //atualizar grid
            AtualizarGrid();
        }

    }  
}