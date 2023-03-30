using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Admin.AMarcacoes
{
    public partial class AMarcacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "2") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            ConfigurarGrid();
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            GvPAceitar.Columns.Clear();
            GvPAceitar.DataSource = null;
            
            Models.Servicos serv = new Models.Servicos();
            GvPAceitar.DataSource = serv.listaAnunciosPorAceitar();
            GvPAceitar.DataBind();

            GvAceites.Columns.Clear();
            GvAceites.DataSource = null;

            Models.Servicos serv2 = new Models.Servicos();
            GvAceites.DataSource = serv2.listaAnunciosAceites();
            GvAceites.DataBind();

        }

        private void ConfigurarGrid()
        {
            GvPAceitar.RowDataBound += GvPAceitar_RowDataBound;
            GvAceites.RowDataBound += GvAceites_RowDataBound;
        }

        private void GvAceites_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var c = e.Row.Cells[5].Text;
                e.Row.Cells[5].Text = DateTime.Parse(c).ToShortDateString();
            }
        }

        private void GvPAceitar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var c = e.Row.Cells[5].Text;
                e.Row.Cells[5].Text = DateTime.Parse(c).ToShortDateString();
            }
        }
    }
}