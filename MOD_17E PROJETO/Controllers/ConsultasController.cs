using MOD_17E_PROJETO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOD_17E_PROJETO.Controllers
{
    public class ConsultasController : Controller
    {
        private MOD_17E_PROJETOContext db = new MOD_17E_PROJETOContext();
        // GET: Consultas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NServicosTecnico()
        {
            string sql = @"SELECT Tecnicoes.nome,sum(valor_pago) as valor,count(*) as [Nº Serviços]
                            FROM Servicoes INNER JOIN Tecnicoes
                            ON Servicoes.IdTecnico=Tecnicoes.IdTecnico
                            GROUP BY Servicoes.IdTecnico,Nome
                            ORDER BY valor DESC";

            var melhor = db.Database.SqlQuery<Campos>(sql);
            if (melhor != null && melhor.ToList().Count > 0)
                ViewBag.melhor = melhor.ToList()[0];
            else
            {
                Campos temp = new Campos();
                temp.nome = "Não foram encontrados registos";
                ViewBag.melhor = temp;
            }
            return View();
        }

        public ActionResult ServicosTerminados()
        {
            string sql = @"SELECT nome, count(*) as [Nª Serviços]
                            FROM Servicoes INNER JOIN Tecnicoes
                            ON Servicoes.IdTecnico=Tecnicoes.IdTecnico
                            Where Servicoes.Estado =2
                            GROUP BY Servicoes.IdTecnico,Nome
                            ";
                        

            var melhor = db.Database.SqlQuery<Campos>(sql);
            if (melhor != null && melhor.ToList().Count > 0)
                ViewBag.melhor = melhor.ToList()[0];
            else
            {
                Campos temp = new Campos();
                temp.nome = "Não foram encontrados registos";
                ViewBag.melhor = temp;
            }
            return View();
        }
        public class Campos
        {
            public string nome { get; set; }
            public decimal valor { get; set; }
            public int n_servicos { get; set; }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}