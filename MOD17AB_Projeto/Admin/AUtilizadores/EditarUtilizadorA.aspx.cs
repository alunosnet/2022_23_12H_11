using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Admin.AUtilizadores
{
    public partial class EditarUtilizadorA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "2") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            //consultar a bd para recolher os dados do utilizador
            if (IsPostBack) return;
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Models.Utilizador utilizador = new Models.Utilizador();
                DataTable dados = utilizador.DadosUser(id);
                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("Utilizador não existe");
                }
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
                tbcp.Text = dados.Rows[0]["cp"].ToString();
            }
            catch
            {
                lbErro.Text = "O utilizador indicado não existe.";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/Admin/AUtilizadores/AUtilizadores.aspx')", true);
            }
        }

        protected void btEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNome.Text.Trim();
                if (nome.Length < 4 || Regex.IsMatch(nome, @"[0-9]"))
                {
                    throw new Exception("O nome tem de ter pelo menos 4 letras");
                }
                
                string Cp = tbcp.Text.Trim();
                if (Cp == String.Empty || !Regex.IsMatch(Cp, @"^\d{4}-\d{3}$"))
                {
                    throw new Exception("O Codigo Postal indicado não é valido");
                }

                string nif = tbNif.Text.Trim();
                if (nif.Length != 9 || nif == String.Empty)
                {
                    throw new Exception("O nif tem de ter 9 números");
                }
                int id = int.Parse(Request["id"].ToString());
                Models.Utilizador utilizador = new Models.Utilizador();
                utilizador.id = id;
                utilizador.nome = nome;
                utilizador.cp = Cp;
                utilizador.nif = nif;
                utilizador.UpdateUser();
            }
            catch (Exception error)
            {
                lbErro.Text = "Ocorreu um erro: " + error.Message;
                return;
            }
            lbErro.Text = "Utilizador atualizado com sucesso.";
            ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/Admin/AUtilizadores/AUtilizadores.aspx')", true);
        }
        
    }
}