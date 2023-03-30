using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Admin.AUtilizadores
{
    public partial class BlockUtilizadorA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "2") == false)
                Response.Redirect("~/index.aspx");
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Models.Utilizador utilizador = new Models.Utilizador();
                utilizador.OnOffUser(id);
                Response.Redirect("~/Admin/AUtilizadores/AUtilizadores.aspx");

            }
            catch
            {

                Response.Redirect("~/Admin/AUtilizadores/AUtilizadores.aspx");
            }
        }
    }
}