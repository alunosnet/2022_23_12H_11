using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Users.Produtos
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            ConfigurarGrid();
            if (IsPostBack) return;
            AtualizarGrid();
        }
        private void AtualizarGrid()
        {
            GvMateriais.Columns.Clear();
            GvMateriais.DataSource = null;
            GvMateriais.DataBind();

            Models.Material mt = new Models.Material();
            GvMateriais.DataSource = mt.ListaTodosMateriais();

            ButtonField bt = new ButtonField();
            bt.HeaderText = "Comprar";
            bt.Text = "Comprar";
            bt.ButtonType = ButtonType.Button;
            bt.CommandName = "comprar";
            bt.ControlStyle.CssClass = "btn btn-danger";
            GvMateriais.Columns.Add(bt);

            GvMateriais.DataBind();
        }

        private void ConfigurarGrid()
        {
            GvMateriais.RowCommand += GvMateriais_RowCommand;
            GvMateriais.RowDataBound += GvMateriais_RowDataBound;
        }

        private void GvMateriais_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var c = e.Row.Cells[3].Text;
                e.Row.Cells[3].Text = DateTime.Parse(c).ToShortDateString();
                
            }
        }

        private void GvMateriais_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linha = int.Parse(e.CommandArgument.ToString());
            int idmaterial = int.Parse(GvMateriais.Rows[linha].Cells[1].Text);
            Models.Material mt = new Models.Material();
            DataTable dados = mt.DadosMaterial(idmaterial);

            if (e.CommandName == "comprar" && int.Parse(dados.Rows[0]["quantidade"].ToString()) > 0)
            { Response.Redirect("~/Users/Produtos/Venda.aspx?id=" + idmaterial); }
            else
            {
                lbErro.Text = "O Material fora de stock!";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                "Redirecionar", "returnMain('Produtos.aspx')", true);
                AtualizarGrid();
            }
        }
    }
}