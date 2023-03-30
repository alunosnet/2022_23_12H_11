using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Jardineiros.Historico
{
    public partial class Historico : System.Web.UI.Page
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

        private void AtualizarGrid()
        {
            gvhistoricoj.Columns.Clear();
            gvhistoricoj.DataSource = null;
            gvhistoricoj.DataBind();

            int idutilizador = int.Parse(Session["id"].ToString());
            Models.Vendas p = new Models.Vendas();
            gvhistoricoj.DataSource = p.listaVendasComNomes(idutilizador);
            gvhistoricoj.DataBind();
        }

        private void ConfigurarGrid()
        {
            gvhistoricoj.RowDataBound += gvhistoricoj_RowDataBound; 
        }

        private void gvhistoricoj_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var c = e.Row.Cells[4].Text;
                e.Row.Cells[4].Text = DateTime.Parse(c).ToShortDateString();
            }
        }
    }
}