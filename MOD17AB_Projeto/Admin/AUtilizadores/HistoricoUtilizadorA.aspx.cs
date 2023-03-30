using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Admin.AUtilizadores
{
    public partial class HistoricoUtilizadorA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "2") == false)
                Response.Redirect("~/index.aspx");
            try
            {
                ConfigurarGrid();
                atualizarGrid();
            }
            catch
            {
                lbErro.Text = "O utilizador indicado não existe";
                lbErro.CssClass = "alert alert-danger";
                Redirecionar();
            }
        }

        private void ConfigurarGrid()
        {
            GvHistoricoA.RowDataBound += GvHistoricoA_RowDataBound;
        }

        private void GvHistoricoA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var c = e.Row.Cells[4].Text;
                e.Row.Cells[4].Text = DateTime.Parse(c).ToShortDateString();
            }
        }

        private void Redirecionar()
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar",
                "returnMain('/Admin/AUtilizadores/AUtilizadores.aspx');", true);
        }

        private void atualizarGrid()
        {
            GvHistoricoA.Columns.Clear();
            GvHistoricoA.DataSource = null;
            GvHistoricoA.DataBind();

            int id = int.Parse(Request["id"].ToString());
            Models.Vendas venda = new Models.Vendas();
            GvHistoricoA.DataSource = venda.listaVendasComNomes(id);
            GvHistoricoA.DataBind();
        }
    }
}