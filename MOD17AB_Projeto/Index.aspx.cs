using MOD17AB_Projeto.Classes;
using MOD17AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] != null)
                divLogin.Visible = false;

            int? ordenar = 0;
            try
            {   
                ordenar = int.Parse(Request["ordena"].ToString());
            }
            catch
            {
                ordenar = null;
            }

            UpdateListaMateriais(null, ordenar);
        }
        //ListaMateriais grid
        private void UpdateListaMateriais(string pesquisa = null, int? ordena = null)
        {
            Material material = new Material();
            DataTable dados;
            if (pesquisa == null)
            {
                
                HttpCookie httpCookie = Request.Cookies["ultimoMaterial"];
                if (httpCookie == null)
                    dados = material.MaterialDisponiveis(ordena);
                else
                {
                    dados = material.MaterialMarca(Server.UrlDecode(httpCookie.Value));
                    dados.Merge(material.MaterialDisponiveis(ordena));
                }
            }
            else
            {
                dados = material.MateriaisDisponiveisComPesquisa(pesquisa, ordena);
            }
            gerarIndex(dados);
        }
        //Pesquisar material
        protected void btPesquisar_Click(object sender, EventArgs e)
        {
            UpdateListaMateriais(tbPesquisa.Text);
        }
        //Index
        private void gerarIndex(DataTable dados)
        {
            if (dados == null || dados.Rows.Count == 0)
            {
                divMaterial.InnerHtml = "";
                return;
            }
            string grelha = "<div class='container-fluid'>";
            grelha += "<div class='row'>";
            foreach (DataRow material in dados.Rows)
            {
                grelha += "<div class='col'>";
                grelha += "<p/><span class='stat-title'>" + material[1].ToString()
                    + "</span>";
                grelha += "<span class='stat-title'>" +
                    String.Format(" | {0:C}", Decimal.Parse(material["preco"].ToString()))
                    + "</span>";
                grelha += "<br/><a href='detalhesmaterial.aspx?id=" + material[0].ToString()
                    + "'>Detalhes</a>";
                grelha += "</div>";
            }
            grelha += "</div></div>";
            divMaterial.InnerHtml = grelha;
        }
        //Botao Login
        protected void bt_login_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tb_Email.Text;
                string password = tb_Password.Text;
                UserLogin user = new UserLogin();
                DataTable dados = user.VerificaLogin(email, password);
                if (dados == null)
                    throw new Exception("Login falhou");
                //iniciar sessão
                Session["nome"] = dados.Rows[0]["nome"].ToString();
                Session["id"] = dados.Rows[0]["id"].ToString();
                //autorização
                Session["perfil"] = dados.Rows[0]["perfil"].ToString();
                Session["ip"] = Request.UserHostAddress;
                Session["useragent"] = Request.UserAgent;
                //redirecionar
                if (Session["perfil"].ToString() == "2")
                    Response.Redirect("~/Admin/Admin.aspx");
                if (Session["perfil"].ToString() == "1")
                    Response.Redirect("~/Jardineiros/Jardineiro.aspx");
                if (Session["perfil"].ToString() == "0")
                    Response.Redirect("~/Users/User.aspx");
            }
            catch
            {
                lb_erro.Text = "Login falhou. Tente novamente";
            }
        }
        //Botao recuperar
        protected void bt_recuperar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_Email.Text.Trim().Length == 0)
                {
                    throw new Exception("Indique um email");
                }
                string email = tb_Email.Text.Trim();
                Utilizador utilizador = new Utilizador();
                DataTable dados = utilizador.DadosUserMail(email);
                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("Foi enviado um email para recuperação da palavra passe");
                }
                Guid guid = Guid.NewGuid();
                utilizador.RecuperarPass(email, guid.ToString());

                string mensagem = "Clique no link para recuperar a sua password.<br/>";
                mensagem += "<a href='http://" + Request.Url.Authority + "/recuperarpassword.aspx?";
                mensagem += "id=" + Server.UrlEncode(guid.ToString()) + "'>Clique aqui</a>";

                string meuemail = ConfigurationManager.AppSettings["MeuEmail"];
                string minhapassword = ConfigurationManager.AppSettings["MinhaPassword"];
                Helper.enviarMail(meuemail, minhapassword, email, "Recuperação de password", mensagem);

                lb_erro.Text = "Foi enviado um email para recuperação da palavra passe";
            }
            catch (Exception ex)
            {
                lb_erro.Text = ex.Message;
            }
        }

        
    }
}