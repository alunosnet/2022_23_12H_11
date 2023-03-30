using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Jardineiros.Marcacoes
{
    public partial class Marcacoes : System.Web.UI.Page
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
            GvServicos.Columns.Clear();
            GvServicos.DataSource = null;
            GvServicos.DataBind();

            Models.Servicos serv = new Models.Servicos();
            GvServicos.DataSource = serv.listaAnunciosDisponiveis();

            //botão reservar
            ButtonField bt = new ButtonField();
            bt.HeaderText = "Aceitar";
            bt.Text = "Aceitar";
            bt.ButtonType = ButtonType.Button;
            bt.CommandName = "aceitar";
            bt.ControlStyle.CssClass = "btn btn-danger";
            GvServicos.Columns.Add(bt);
            ButtonField btterminar = new ButtonField();
            btterminar.HeaderText = "Terminado";
            btterminar.Text = "Terminado";
            btterminar.ButtonType = ButtonType.Button;
            btterminar.CommandName = "terminar";
            btterminar.ControlStyle.CssClass = "btn btn-danger";
            GvServicos.Columns.Add(btterminar);

            GvServicos.DataBind();
        }

        private void ConfigurarGrid()
        {
            GvServicos.RowCommand += GvServicos_RowCommand;
            GvServicos.RowDataBound += GvServicos_RowDataBound;
        }

        private void GvServicos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var c = e.Row.Cells[6].Text;
                e.Row.Cells[6].Text = DateTime.Parse(c).ToShortDateString();
            }
        }

        private void GvServicos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linha = int.Parse(e.CommandArgument.ToString());
            int idMarcacao = int.Parse(GvServicos.Rows[linha].Cells[2].Text);
            int idutilizador = int.Parse(Session["id"].ToString());
            if (e.CommandName == "aceitar")
            {
                Models.Servicos serv = new Models.Servicos();
                serv.aceitar(idMarcacao, idutilizador);
                AtualizarGrid();
                
            }
            if (e.CommandName == "terminar")
            {
                Models.Servicos serv = new Models.Servicos();
                serv.terminado(idMarcacao, idutilizador);
                AtualizarGrid();
                
            }
            
        }
    }
}