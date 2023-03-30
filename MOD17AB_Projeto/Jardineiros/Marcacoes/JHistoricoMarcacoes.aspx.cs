using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Jardineiros.Marcacoes
{
    public partial class JHistoricoMarcacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            ConfigurarGrid();
            AtualizarGrid();
        }

        private void ConfigurarGrid()
        {
            Gvhistoricojm.RowDataBound += Gvhistoricojm_RowDataBound;
        }

        private void Gvhistoricojm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var c = e.Row.Cells[5].Text;
                e.Row.Cells[5].Text = DateTime.Parse(c).ToShortDateString();
            }
        }

        private void AtualizarGrid()
        {
            Gvhistoricojm.Columns.Clear();
            Gvhistoricojm.DataSource = null;
            Gvhistoricojm.DataBind();

            int idutilizador = int.Parse(Session["id"].ToString());
            Models.Servicos ser = new Models.Servicos();
            Gvhistoricojm.DataSource = ser.ServicosAceitesporx(idutilizador);
            Gvhistoricojm.DataBind();
        }
    }
}