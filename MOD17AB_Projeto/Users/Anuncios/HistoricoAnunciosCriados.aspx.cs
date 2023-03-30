using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Users.Anuncios
{
    public partial class HistoricoAnunciosCriados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            ConfigurarGrid();
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            GvHistoricoAU.RowDataBound += GvHistoricoAU_RowDataBound;
        }

        private void GvHistoricoAU_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var c = e.Row.Cells[4].Text;
                e.Row.Cells[4].Text = DateTime.Parse(c).ToShortDateString();
            }
        }

        private void ConfigurarGrid()
        {
            GvHistoricoAU.Columns.Clear();
            GvHistoricoAU.DataSource = null;
            GvHistoricoAU.DataBind();

            int idutilizador = int.Parse(Session["id"].ToString());
            Models.Servicos ser = new Models.Servicos();
            GvHistoricoAU.DataSource = ser.ServicosCriados(idutilizador);
            GvHistoricoAU.DataBind();
        }
        //GvHistoricoAU
    }
}