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

namespace MOD17AB_Projeto.Users
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (!IsPostBack)
            {
                divEditar.Visible = false;
                MostrarPerfil();
            }
        }

        private void MostrarPerfil()
        {
            int id = int.Parse(Session["id"].ToString());
            Utilizador utilizador = new Utilizador();
            DataTable dados = utilizador.DadosUser(id);
            if (divPerfil.Visible == true)
            {
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbCP.Text = dados.Rows[0]["cp"].ToString();
                lbnif.Text = dados.Rows[0]["nif"].ToString();
            }
            else
            {
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbCP.Text = dados.Rows[0]["cp"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = true;
            divEditar.Visible = false;
            MostrarPerfil();
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {
             try { 
                int id = int.Parse(Session["id"].ToString());
                string nome = tbNome.Text.Trim();
                if (nome.Length < 4 || Regex.IsMatch(nome, @"[0-9]"))
                {
                    throw new Exception("O nome tem de ter pelo menos 4 letras");
                }
                nome = tbNome.Text;
                string cp = tbCP.Text.Trim();
                if (cp == String.Empty || !Regex.IsMatch(cp, @"^\d{4}-\d{3}$"))
                {
                    throw new Exception("O Codigo Postal indicado não é valido");
                }
                string nif = tbNif.Text.Trim();
                if (nif.Length != 9 || nif == String.Empty)
                {
                    throw new Exception("O nif tem de ter 9 números");
                }
                Utilizador utilizador = new Utilizador();
                utilizador.nome = nome;
                utilizador.cp = cp;
                utilizador.nif = nif;
                utilizador.id = id;
                utilizador.UpdateUser();
                btCancelar_Click(sender, e);
             }catch (Exception ex)
                {
                    lberro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                    return;
                }
}

        protected void btEditar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = false;
            divEditar.Visible = true;
            MostrarPerfil();
        }
    }
}