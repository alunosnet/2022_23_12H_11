using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Users.Produtos
{
    public partial class Historico : System.Web.UI.Page
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

        private void ConfigurarGrid()
        {
            gvhistorico.RowDataBound += gvhistorico_RowDataBound;
        }

        private void gvhistorico_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var c = e.Row.Cells[4].Text;
                e.Row.Cells[4].Text = DateTime.Parse(c).ToShortDateString();
            }
        }

        private void AtualizarGrid()
        {
            gvhistorico.Columns.Clear();
            gvhistorico.DataSource = null;
            gvhistorico.DataBind();

            int idutilizador = int.Parse(Session["id"].ToString());
            Models.Vendas p = new Models.Vendas();
            gvhistorico.DataSource = p.listaVendasComNomes(idutilizador);
            gvhistorico.DataBind();
        }
    }
}