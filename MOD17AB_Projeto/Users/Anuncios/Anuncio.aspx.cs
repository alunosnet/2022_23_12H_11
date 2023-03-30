using MOD17AB_Projeto.Classes;
using MOD17AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Users.Anuncios
{
    public partial class Anuncio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            if (IsPostBack) return;
        }    

        protected void bt_Add_Click(object sender, EventArgs e)
        {
            try
            {
                //validar os dados do form
                //validar o form
                string tema = tb_tema.Text.Trim();
                if (tema== String.Empty || tema.Length < 4 || Regex.IsMatch(tema, @"[0-9]"))
                {
                    throw new Exception("O tema tem de ter pelo menos 4 letras");
                }
                string descricao = tb_descricao.Text.Trim();
                if (descricao == String.Empty || descricao.Length <= 3 || descricao.IndexOf(" ") <= 0)
                {
                    throw new Exception("A descrição indicado não é válida.");
                }
                DateTime datainicio = DateTime.Parse(tb_data.Text);
                if(datainicio < DateTime.Now.AddDays(7))
                {
                    throw new Exception("A data de inicio tem de ter 7 dias de diferença ou não é valida a data.");
                }
              
                //inserir o utilizador na bd
                Servicos serv = new Servicos();
                int idutilizador = int.Parse(Session["id"].ToString());
                serv.add(idutilizador,tema,descricao,datainicio);
                lbErro.Text = "Registado com sucesso";
                //redicionar para index
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Anuncio.aspx')", true);
            }
            catch (Exception erro)
            {
                lbErro.Text = erro.Message;
                lbErro.CssClass = "alert alert-danger";
            }
        }
    }
}