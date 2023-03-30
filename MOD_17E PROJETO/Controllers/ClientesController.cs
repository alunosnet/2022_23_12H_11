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
    public class ClientesController : Controller
    {
        private MOD_17E_PROJETOContext db = new MOD_17E_PROJETOContext();

        // GET: Clientes
        [Authorize(Roles = "Administrador")]
        public ActionResult Index(int? id)
        {
            var clientes = db.Clientes.OrderBy(c=>c.ClienteID);
            if (id != null)
            {
                if( id == 1)
                {
                    clientes = db.Clientes.OrderBy(c => c.Morada);
                }
                else if (id == 5) { clientes = db.Clientes.OrderBy(c => c.DataNascimento); }

            }

            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "ClienteID,Nome,Morada,CP,Email,Telefone,DataNascimento")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                //guardar a fotografia
                HttpPostedFileBase fotografia = Request.Files["fotografia"];
                if (fotografia != null && fotografia.ContentLength > 0)
                {
                    string nome = Server.MapPath("~/Public/") + cliente.ClienteID + ".jpg";
                    fotografia.SaveAs(nome);
                }

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,Nome,Morada,CP,Email,Telefone,DataNascimento")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                HttpPostedFileBase fotografia = Request.Files["fotografia"];
                if (fotografia != null && fotografia.ContentLength > 0)
                {
                    string nome = Server.MapPath("~/Public/") + cliente.ClienteID + ".jpg";
                    fotografia.SaveAs(nome);
                } 

                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
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
