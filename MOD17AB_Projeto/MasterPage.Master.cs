using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["trabalhoM17AB"];
            if (cookie != null)
                div_aviso.Visible = false;
        }

        protected void btaceitar_Click(object sender, EventArgs e)
        {
            HttpCookie novo = new HttpCookie("trabalhoM17AB");
            novo.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(novo);
            div_aviso.Visible = false;
        }
    }
}