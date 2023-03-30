using MOD_17E_PROJETO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOD_17E_PROJETO.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace MOD_17E_PROJETO.Controllers
{
    public class LoginController : Controller
    {
        private MOD_17E_PROJETOContext db = new MOD_17E_PROJETOContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Tecnico user)
        {
            if(user.Email!=null && user.Password != null)
            {
                //hash password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 4 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                user.Password = Convert.ToBase64String(password);
                foreach(var utilizador in db.Tecnicoes.ToList())
                {
                    if(utilizador.Email == user.Email && utilizador.Password == user.Password)
                    {
                        FormsAuthentication.SetAuthCookie(utilizador.Nome, false);
                        if (Request.QueryString["ReturnUrl"] == null)
                            return RedirectToAction("Index", "Home");
                        else
                            return Redirect(Request.QueryString["ReturnUrl"].ToString());
                    }
                }

            }
            ModelState.AddModelError("", "Login Falhou. Tenta Novamente");
            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}