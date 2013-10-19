using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImagineProject.Controllers
{
    [Authorize(Roles = "Administrador")]  
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Bienvenido al sitio web administración de viajes";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
