using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOD_17E_PROJETO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Página que fala sobre o site";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página dos contactos";

            return View();
        }
    }
}