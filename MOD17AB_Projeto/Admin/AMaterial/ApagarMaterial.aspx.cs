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
    public partial class ApagarMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "2") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            try
            {
                //querystring nMaterial
                int nMaterial = int.Parse(Request["id"].ToString());

                Models.Material mt = new Models.Material();
                DataTable dados = mt.DadosMaterial(nMaterial);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o nmaterial não existe na tabela dos materiais
                    throw new Exception("Material não existe.");
                }
                //mostrar os dados do material
                lbNMaterial.Text = dados.Rows[0]["nMaterial"].ToString();
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbQuantidade.Text = dados.Rows[0]["quantidade"].ToString();
            }
            catch
            {
                Response.Redirect("~/Admin/AMaterial/AMaterial.aspx");
            }
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int nMaterial = int.Parse(Request["id"].ToString());
                Models.Material mt = new Models.Material();
                mt.Remove(nMaterial);
                
                lbErro.Text = "O Material foi removido com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('AMaterial.aspx')", true);
            }
            catch
            {
                Response.Redirect("~/Admin/AMaterial/AMaterial.aspx");

            }
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AMaterial/AMaterial.aspx");
        }
    }
}