using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MOD_17E_PROJETO.Data;
using MOD_17E_PROJETO.Models;

namespace MOD_17E_PROJETO.Controllers
{
    [Authorize]
    public class ServicoesController : Controller
    {
        private MOD_17E_PROJETOContext db = new MOD_17E_PROJETOContext();

        // GET: Servicoes
        public ActionResult Index()
        {
            var servicoes = db.Servicoes.Include(s => s.tecnico).Include(s => s.cliente);
           
            if (User.IsInRole("Técnico"))
            { 
                int tecnicoid = db.Tecnicoes.Where(t => t.Nome == User.Identity.Name).ToList()[0].IdTecnico;
                servicoes = db.Servicoes.Where(s => s.IdTecnico == tecnicoid).Include(s=> s.cliente);
            }
            
            return View(servicoes.ToList());
        }

        // GET: Servicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicoes.Find(id);
            var tecnico = db.Tecnicoes.Find(servico.IdTecnico);
            servico.tecnico = tecnico;
            var cliente = db.Clientes.Find(servico.ClienteID);
            servico.cliente = cliente;
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // GET: Servicoes/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome");
            ViewBag.IdTecnico = new SelectList(db.Tecnicoes, "IdTecnico", "Nome");
            return View();
        }

        // POST: Servicoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdServico,descricao,data_criado,data_começou,data_Acabou,valor_pago,Estado,ClienteID,IdTecnico")] Servico servico)
        {
            if (ModelState.IsValid)
            {

                servico.data_criado = DateTime.Now.Date;
                servico.data_começou = servico.data_criado;
                servico.data_Acabou = servico.data_criado;
                var cliente = db.Clientes.Find(servico.ClienteID);
                servico.Estado = 0;
                servico.IdTecnico = null; 
                db.Servicoes.Add(servico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", servico.ClienteID);
            ViewBag.IdTecnico = new SelectList(db.Tecnicoes, "IdTecnico", "Nome", servico.IdTecnico);
            return View(servico);
        }

        // GET: Servicoes/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicoes.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", servico.ClienteID);
            ViewBag.IdTecnico = new SelectList(db.Tecnicoes, "IdTecnico", "Nome", servico.IdTecnico);
            return View(servico);
        }

        // POST: Servicoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdServico,descricao,data_criado,data_começou,data_Acabou,valor_pago,Estado,ClienteID,IdTecnico")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", servico.ClienteID);
            ViewBag.IdTecnico = new SelectList(db.Tecnicoes, "IdTecnico", "Nome", servico.IdTecnico);
            return View(servico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //Lista Servicos Disponiveis
        
        public ActionResult ListaServicos()
        {
            var servico = db.Servicoes.Include(e => e.cliente);
            return View(servico.ToList());
        }
        [Authorize(Roles = "Técnico")]
        public ActionResult AceitarServico(int? id)
        {
            if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            var servico = db.Servicoes.Find(id);
            if (servico == null) { return HttpNotFound(); }
            servico.data_começou = DateTime.Now.Date;
            servico.cliente = db.Clientes.Find(servico.ClienteID);
            return View("Aceitar",servico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Técnico")]
        public ActionResult AceitarServico(Servico servico)
        {
            //atualizar a servico
            int tecnicoid = db.Tecnicoes.Where(t => t.Nome == User.Identity.Name).ToList()[0].IdTecnico;
            servico.IdTecnico = tecnicoid;
            servico.Estado = 1;
            servico.data_começou = DateTime.Now;
            servico.data_Acabou = servico.data_criado;
            db.Entry(servico).State = EntityState.Modified;
            //db.Entry(servico).CurrentValues.SetValues(servico);
            db.SaveChanges();

            return RedirectToAction("ListaServicos");
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult FinalizarServico(int? id)
        {
            if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            var servico = db.Servicoes.Find(id);
            if (servico == null) { return HttpNotFound(); }
            servico.data_Acabou = DateTime.Now.Date;
            servico.cliente = db.Clientes.Find(servico.ClienteID);
            servico.tecnico = db.Tecnicoes.Find(servico.IdTecnico);
            return View("Finalizar", servico);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FinalizarServico(Servico servico)
        {
            //atualizar a servico
            servico.Estado = 2;
            servico.data_Acabou = DateTime.Now;
            db.Entry(servico).State = EntityState.Modified;
            //db.Entry(servico).CurrentValues.SetValues(servico);
            db.SaveChanges();

            return RedirectToAction("ListaServicos");
        }

    }
}
