using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto
{
    public partial class detalhesmaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Models.Material mt = new Models.Material();
                DataTable dados = mt.DadosMaterial(id);
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbData.Text = DateTime.Parse(dados.Rows[0]["data_aquisicao"].ToString()).ToString("yyyy-MM-dd");
                lbMarca.Text = dados.Rows[0]["marca"].ToString();
                lbPreco.Text = String.Format("{0:c}", Decimal.Parse(dados.Rows[0]["preco"].ToString()));
                lbQuantidade.Text = dados.Rows[0]["quantidade"].ToString();
                //criar cookie
                HttpCookie cookie = new HttpCookie("ultimoMaterial", Server.UrlEncode(lbMarca.Text));
                cookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(cookie);
            }
            catch
            {
                Response.Redirect("~/index.aspx");
            }
        }

        
    }
}