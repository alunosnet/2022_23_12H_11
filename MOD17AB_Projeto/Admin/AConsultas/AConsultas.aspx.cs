using MOD17AB_Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17AB_Projeto.Admin.AConsultas
{
    public partial class AConsultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "2") == false)
                Response.Redirect("~/index.aspx");

            AtualizaGrelhaConsulta();
        }

        private void AtualizaGrelhaConsulta()
        {
            GvConsultasA.Columns.Clear();
            int iconsulta = int.Parse(ddConsultas.SelectedValue);
            DataTable dados;
            string sql = "";
            switch (iconsulta)
            {
                case 0:
                    sql = @"SELECT Nome,count(Vendas.idMaterial) as [Nº de vendas] FROM Material 
                            INNER JOIN Vendas ON Material.nMaterial=Vendas.idMaterial 
                            GROUP BY Material.nMaterial,Material.Nome
                            ORDER BY count(Vendas.idMaterial) DESC;";
                    break;
                case 1:
                    sql = @"SELECT utilizadores.nome as [Nome do Utilizador],material.nome as [Nome Material],datavenda
                            FROM vendas 
                            INNER JOIN material 
                                ON vendas.idMaterial=material.nMaterial
                            INNER JOIN utilizadores 
                                ON vendas.idutilizador=utilizadores.id ";
                    break;
                case 2:
                    sql = @"SELECT Marca, count(nMaterial) as [Nrº de Materiais] 
                            FROM material 
                            GROUP BY marca";
                    break;
                case 3:
                    sql = @"SELECT count(*) as [Nº de utilizadores bloqueados] 
                            FROM Utilizadores
                            WHERE estado = 0";
                    break;
                case 4:
                    sql = @"SELECT DISTINCT Utilizadores.nome 
                               FROM utilizadores
                               INNER JOIN vendas on vendas.idutilizador = utilizadores.id
                               WHERE vendas.idMaterial = (SELECT TOP 1 material.nMaterial FROM material ORDER BY preco DESC)";
                    break;
             
                case 5:
                    sql = @"SELECT * FROM material 
                            WHERE preco>(SELECT AVG(preco) FROM material)";
                    break;
             
                case 6:
                    sql = @"SELECT Nome, (SELECT count(*) FROM Utilizadores as UT WHERE U.password=UT.password)
                                        as [Utilizadores com a mesma password]
                                        FROM Utilizadores as U";
                    break;

            }
            BaseDados bd = new BaseDados();
            dados = bd.devolveSQL(sql);
            GvConsultasA.DataSource = dados;
            GvConsultasA.DataBind();
        }
        protected void ddConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaGrelhaConsulta();
        }
    }
}