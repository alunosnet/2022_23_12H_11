using MOD17AB_Projeto.Classes;
using MOD17AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Admin.AUtilizadores
{
    public partial class ApagarUtilizadorA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "2") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (IsPostBack) return;

            try
            {
                int id = int.Parse(Request["id"].ToString());
                Utilizador uti = new Utilizador();

                DataTable dados = uti.DadosUser(id);

                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("O utilizador não existe");
                }

                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbId.Text = dados.Rows[0]["id"].ToString();
            }

            catch
            {
                Response.Redirect("~/Admin/AUtilizadores/AUtilizadores.aspx");
            }
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"].ToString());
            Utilizador uti = new Utilizador();

            uti.RemoveUser(id); 
            Response.Redirect("~/Admin/AUtilizadores/AUtilizadores.aspx");

        }
    }
}