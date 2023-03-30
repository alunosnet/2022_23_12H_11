using MOD17AB_Projeto.Classes;
using MOD17AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto
{
    public partial class Registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //validar os dados do form
                //validar o form
                string nome = tb_nome.Text.Trim();
                if (nome.Length < 4|| Regex.IsMatch(nome, @"[0-9]"))
                {
                    throw new Exception("O nome tem de ter pelo menos 4 letras");
                }
                string email = tb_email.Text.Trim();
                if (email == String.Empty || email.Contains("@") == false ||
                   email.Contains('.') == false)
                {
                    throw new Exception("O email indicado não é válido falta de caracteres especificos.");
                }
                string cp = tb_cp.Text.Trim();
                if (cp == String.Empty || !Regex.IsMatch(cp, @"^\d{4}-\d{3}$"))
                {
                    throw new Exception("O Código Postal indicado não é valido");
                }
                string nif = tb_nif.Text.Trim();
                if (nif.Length != 9 || nif == String.Empty)    
                {
                    throw new Exception("O NIF tem de ter 9 números");
                }
                string password = tb_password.Text.Trim();
                if (password.Length < 3)
                {
                    throw new Exception("A password tem de ter mais que 3 digitos");
                }
                int perfil = int.Parse(dpPerfil.SelectedValue);
                if (perfil == null ) { throw new Exception("Nenhum perfil selecionado"); }

                //validar recaptcha
                var respostaRecaptcha = Request.Form["g-Recaptcha-Response"];
                var valido = ReCaptcha.Validate(respostaRecaptcha);
                if (valido == false)
                {
                    throw new Exception("Tem de provar que não é um robot");
                }
                //inserir o utilizador na bd
                Utilizador utilizador = new Utilizador();
                utilizador.nif = nif;
                utilizador.nome = nome;
                utilizador.email = email;
                utilizador.cp = cp;
                utilizador.password = password;
                utilizador.perfil = perfil;
                utilizador.Add();
                lb_erro.Text = "Registado com sucesso";
                //redicionar para index
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/index.aspx')", true);
            }
            catch (Exception erro)
            {
                lb_erro.Text = erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }
        }
    }
}