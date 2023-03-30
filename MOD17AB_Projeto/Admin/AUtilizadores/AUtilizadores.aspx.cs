using MOD17AB_Projeto.Classes;
using MOD17AB_Projeto.Models;
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
    public partial class AUtilizadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "2") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (!IsPostBack)
            AtualizaGrid();
        }

        
        private void AtualizaGrid()
        {
            
            GvUtilizadores.Columns.Clear();
            GvUtilizadores.DataSource = null;
            GvUtilizadores.DataBind();

            Utilizador utilizador = new Utilizador();
            DataTable dados = utilizador.ListUsers();

            GvUtilizadores.DataSource = dados;
            GvUtilizadores.AutoGenerateColumns = false;

            //remover
            DataColumn dcRemover = new DataColumn();
            dcRemover.ColumnName = "Remover";
            dcRemover.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcRemover);
            //editar
            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);
            //bloquear
            DataColumn dcBloquear = new DataColumn();
            dcBloquear.ColumnName = "Bloquear";
            dcBloquear.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcBloquear);
            //histórico
            DataColumn dcHistorico = new DataColumn();
            dcHistorico.ColumnName = "Historico";
            dcHistorico.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcHistorico);

            //Formatação Gridview
            //remover
            HyperLinkField hlRemover = new HyperLinkField();
            hlRemover.HeaderText = "Remover";
            hlRemover.DataTextField = "Remover";    //columnname do datatable
            hlRemover.Text = "Remover";
            //RemoverUtilizador.aspx?id={0}
            hlRemover.DataNavigateUrlFormatString = "ApagarUtilizadorA.aspx?id={0}";
            hlRemover.DataNavigateUrlFields = new string[] { "id" };
            hlRemover.ControlStyle.CssClass = "btn btn-danger";
            GvUtilizadores.Columns.Add(hlRemover);
            //editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";    //columnname do datatable
            hlEditar.Text = "Editar";
            hlEditar.DataNavigateUrlFormatString = "EditarUtilizadorA.aspx?id={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "id" };
            hlEditar.ControlStyle.CssClass = "btn btn-info";
            GvUtilizadores.Columns.Add(hlEditar);
            //bloquear
            HyperLinkField hlBloquear = new HyperLinkField();
            hlBloquear.HeaderText = "Bloquear";
            hlBloquear.DataTextField = "Bloquear";    //columnname do datatable
            hlBloquear.Text = "Bloquear";
            hlBloquear.DataNavigateUrlFormatString = "BlockUtilizadorA.aspx?id={0}";
            hlBloquear.DataNavigateUrlFields = new string[] { "id" };
            hlBloquear.ControlStyle.CssClass = "btn btn-danger";
            GvUtilizadores.Columns.Add(hlBloquear);
            //histórico
            HyperLinkField hlHistorico = new HyperLinkField();
            hlHistorico.HeaderText = "Histórico";
            hlHistorico.DataTextField = "Historico";    //columnname do datatable
            hlHistorico.Text = "Histórico";
            hlHistorico.DataNavigateUrlFormatString = "HistoricoUtilizadorA.aspx?id={0}";
            hlHistorico.DataNavigateUrlFields = new string[] { "id" };
            hlHistorico.ControlStyle.CssClass = "btn btn-success";
            GvUtilizadores.Columns.Add(hlHistorico);

            //id
            BoundField bfId = new BoundField();
            bfId.HeaderText = "Id";
            bfId.DataField = "id";
            bfId.Visible = false;
            GvUtilizadores.Columns.Add(bfId);
            //email
            BoundField bfEmail = new BoundField();
            bfEmail.HeaderText = "Email";
            bfEmail.DataField = "email";
            GvUtilizadores.Columns.Add(bfEmail);
            //nome
            BoundField bfNome = new BoundField();
            bfNome.HeaderText = "Nome";
            bfNome.DataField = "nome";
            GvUtilizadores.Columns.Add(bfNome);
            //Morada
            BoundField bfCp = new BoundField();
            bfCp.HeaderText = "Cp";
            bfCp.DataField = "cp";
            GvUtilizadores.Columns.Add(bfCp);
            //nif
            BoundField bfNif = new BoundField();
            bfNif.HeaderText = "Nif";
            bfNif.DataField = "nif";
            GvUtilizadores.Columns.Add(bfNif);
            //estado
            BoundField bfEstado = new BoundField();
            bfEstado.HeaderText = "Estado";
            bfEstado.DataField = "estado";
            GvUtilizadores.Columns.Add(bfEstado);
            //perfil
            BoundField bfPerfil = new BoundField();
            bfPerfil.HeaderText = "Perfil";
            bfPerfil.DataField = "perfil";
            GvUtilizadores.Columns.Add(bfPerfil);
            //Como fazer para aparecer a palavra Admin ou utilizador em vez 0 e 1?
            GvUtilizadores.DataBind();
        }

        protected void bt_Adicionar_Click(object sender, EventArgs e)
        {
            try
            {
                //validar o form
                string nome = tb_nome.Text.Trim();
                if (nome.Length < 4 || Regex.IsMatch(nome, @"[0-9]"))
                {
                    throw new Exception("O nome tem de ter pelo menos 4 letras e não pode ter números");
                }
                string email = tb_email.Text.Trim();
                if (email == String.Empty || email.Contains("@") == false ||
                   email.Contains('.') == false)
                {
                    throw new Exception("O email indicado não é válido");
                }
                string Cp = tb_CP.Text.Trim();
                if (Cp == String.Empty || !Regex.IsMatch(Cp, @"^\d{4}-\d{3}$"))
                {
                    throw new Exception("O Codigo Postal indicado não é valido");
                }
                
                string nif = tb_nif.Text.Trim();
                if (nif.Length != 9 || nif == String.Empty)
                {
                    throw new Exception("O nif tem de ter 9 números");
                }
                string password = tb_password.Text.Trim();
                if (password.Length < 3)
                {
                    throw new Exception("A password tem de ter pelo menos 3 letras");
                }
                int perfil = int.Parse(dd_perfil.SelectedValue);
                Random rnd = new Random();
                int sal = rnd.Next(1000);

                Utilizador utilizador = new Utilizador();
                utilizador.nome = nome;
                utilizador.email = email;
                utilizador.sal = sal;
                utilizador.cp = Cp;
                utilizador.nif = nif;
                utilizador.password = password;
                utilizador.perfil = perfil;

                utilizador.Add();

                //limpar form
                tb_nome.Text = "";
                tb_email.Text = "";
                tb_CP.Text = "";
                tb_nif.Text = "";
            }
            catch (Exception erro)
            {
                lb_erro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }
            //atualizar grid
            AtualizaGrid();
        }
    }
}