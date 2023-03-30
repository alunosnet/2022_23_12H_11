using MOD17AB_Projeto.Classes;
using MOD17AB_Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace MOD17AB_Projeto.Admin
{
    /// <summary>
    /// Descrição resumida de Servicos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    [System.Web.Script.Services.ScriptService]
    public class Servicos : System.Web.Services.WebService
    {
        [WebMethod]
        public string ListaMateriais()
        {
            Models.Material material = new Models.Material();
            DataTable dados = material.ListaTodosMateriais();
            List<Models.Material> Materiais = new List<Models.Material>();
            for (int i = 0; i < dados.Rows.Count; i++)
            {
                Models.Material novo = new Models.Material();
                novo.nMaterial = int.Parse(dados.Rows[i]["ID"].ToString());
                novo.nome = dados.Rows[i]["Nome"].ToString();
                novo.preco = Decimal.Parse(dados.Rows[i]["Preço"].ToString());
                Materiais.Add(novo);
            }
            return new JavaScriptSerializer().Serialize(Materiais);
        }
        public class Dados
        {
            public string perfil;
            public int contagem;
        }
        [WebMethod(EnableSession = true)]
        public List<Dados> DadosUtilizadores()
        {
            if (Session["perfil"] == null || Session["perfil"].ToString() != "2")
                return null;
            List<Dados> devolver = new List<Dados>();
            BaseDados bd = new BaseDados();
            DataTable dados = bd.devolveSQL(@"SELECT count(*), case 
                                                   when perfil=0 then 'User'
                                                   when perfil=1 then 'Jardineiro'
                                                   when perfil=2 then 'Admin'
                                                end as [perfil]
                                                FROM utilizadores GROUP BY perfil");
            for (int i = 0; i < dados.Rows.Count; i++)
            {
                Dados novo = new Dados();
                novo.perfil = dados.Rows[i][1].ToString();
                novo.contagem = int.Parse(dados.Rows[i][0].ToString());
                devolver.Add(novo);
            }
            return devolver;
        }
    }
}
