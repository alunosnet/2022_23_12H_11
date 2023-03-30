using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MOD_17E_PROJETO.Data;
using MOD_17E_PROJETO.Models;

namespace MOD_17E_PROJETO.Controllers
{
    [Authorize]
    public class TecnicosController : Controller
    {
        private MOD_17E_PROJETOContext db = new MOD_17E_PROJETOContext();

        // GET: Tecnicos
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            
            return View(db.Tecnicoes.ToList());
        }

        // GET: Tecnicos/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Tecnico tecnico = db.Tecnicoes.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // GET: Tecnicos/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            var tecnico = new Tecnico();

            tecnico.Perfis = new[]
            {
                new SelectListItem {Value="0", Text="Administrador"},
                new SelectListItem {Value="1", Text="Técnico"},
            };
            return View(tecnico);
        }

        // POST: Tecnicos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "IdTecnico,Nome,Email,Password,Perfil,Estado")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                tecnico.Perfis = new[]
                {
                    new SelectListItem {Value="0", Text="Administrador"},
                    new SelectListItem {Value="1", Text="Técnico"}
                };
                //verificar se o nome do utilizador já existe
                var temp = db.Tecnicoes.Where(u => u.Nome == tecnico.Nome).ToList();
                if (temp != null && temp.Count > 0)
                {
                    ModelState.AddModelError("Nome", "Já existe um utilizador com esse nome");
                    return View(tecnico);
                }
                //validar a password
                if (tecnico.Password.Trim().Length < 5)
                {
                    ModelState.AddModelError("Password", "A palavra passe deve ter pelo menos 5 letras");
                    return View(tecnico);
                }
                HttpPostedFileBase fotografia = Request.Files["fotografia"];
                if (fotografia != null && fotografia.ContentLength > 0)
                {
                    string nome = Server.MapPath("~/Public2/") + tecnico.IdTecnico + ".jpg";
                    fotografia.SaveAs(nome);
                }
                //hash password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 4 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(tecnico.Password));
                tecnico.Password = Convert.ToBase64String(password);
                db.Tecnicoes.Add(tecnico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tecnico);
        }

        // GET: Tecnicos/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = db.Tecnicoes.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Administrador"))
            {
                tecnico.Perfis = new[]
                {
                    new SelectListItem{Value="0", Text="Administrador"},
                    new SelectListItem{Value="1", Text="Técnico"}
                };
            }
            else
            {
                var temp = db.Tecnicoes.Where(u => u.Nome == User.Identity.Name).FirstOrDefault();
                tecnico = temp;
                tecnico.Perfis = new[]
                {
                    new SelectListItem{Value="1", Text="Técnico"}
                };

            }
            HttpPostedFileBase fotografia = Request.Files["fotografia"];
            if (fotografia != null && fotografia.ContentLength > 0)
            {
                string nome = Server.MapPath("~/Public2/") + tecnico.IdTecnico + ".jpg";
                fotografia.SaveAs(nome);
            }
            return View(tecnico);
        }

        // POST: Tecnicos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]  
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "IdTecnico,Nome,Email,Password,Perfil,Estado")] Tecnico tecnico)
        {
            tecnico.Perfis = new[]
            {
                    new SelectListItem{Value="0", Text="Administrador"},
                    new SelectListItem{Value="1", Text="Técnico"}
            };
            if (ModelState.IsValid)
            {
                if (tecnico.Password.Trim().Length < 5)
                {
                    ModelState.AddModelError("Password", "A palavra passe deve ter pelo menos 5 letras");
                    return View(tecnico);
                }

                HttpPostedFileBase fotografia = Request.Files["fotografia"];
                if (fotografia != null && fotografia.ContentLength > 0)
                {
                    string nome = Server.MapPath("~/Public2/") + tecnico.IdTecnico + ".jpg";
                    fotografia.SaveAs(nome);
                }
                //hash password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 4 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(tecnico.Password));
                tecnico.Password = Convert.ToBase64String(password);
                db.Entry(tecnico).State = EntityState.Modified;
                db.SaveChanges();
                if (User.IsInRole("Administrador"))
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Index", "Home");
            }
            if (User.IsInRole("Administrador") == false)
            {
                tecnico.Perfis = new[]
                {
                    new SelectListItem{Value="1", Text="Técnico"}
                };
            }
            return View(tecnico);
        }

        // GET: Tecnicos/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = db.Tecnicoes.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnicos/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tecnico tecnico = db.Tecnicoes.Find(id);
            db.Tecnicoes.Remove(tecnico);
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
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Pesquisa()
        {
            string nome = Request.Form["tbPesquisa"];
            var tecnico = db.Tecnicoes.Where(t => t.Nome.Contains(nome));
            return View("Index",tecnico.ToList());
        }
    }
}
