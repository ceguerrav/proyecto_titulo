using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImagineProject.Models;

namespace ImagineProject.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ZonaController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        public bool HaveReferences(int id)
        {
            bool resultado = false;
            var cant = (db.ZonaPaises.Where(zp => zp.id_zona == id)).Count();
            if (cant > 0)
            {
                resultado = true;
            }
            else if (cant == 0)
            {
                resultado = false;
            }
            return resultado;
        }  

        //
        // GET: /Zona/

        public ViewResult Index()
        {
            var zona = db.Zonas.Include(z => z.TipoZona);
            return View(zona.ToList());
        }

        //
        // GET: /Zona/Details/5

        public ViewResult Details(int id)
        {
            Zona zona = db.Zonas.Find(id);
            return View(zona);
        }

        //
        // GET: /Zona/Create

        public ActionResult Create()
        {
            ViewBag.id_tipo_zona = new SelectList(db.TipoZonas, "id_tipo_zona", "tipo_zona");
            return View();
        }

        //
        // POST: /Zona/Create

        [HttpPost]
        public ActionResult Create(Zona zona)
        {
            if (ModelState.IsValid)
            {
                db.Zonas.Add(zona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipo_zona = new SelectList(db.TipoZonas, "id_tipo_zona", "tipo_zona", zona.id_tipo_zona);
            return View(zona);
        }

        //
        // GET: /Zona/Edit/5

        public ActionResult Edit(int id)
        {
            Zona zona = db.Zonas.Find(id);
            ViewBag.id_tipo_zona = new SelectList(db.TipoZonas, "id_tipo_zona", "tipo_zona", zona.id_tipo_zona);
            return View(zona);
        }

        //
        // POST: /Zona/Edit/5

        [HttpPost]
        public ActionResult Edit(Zona zona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_zona = new SelectList(db.TipoZonas, "id_tipo_zona", "tipo_zona", zona.id_tipo_zona);
            return View(zona);
        }

        //
        // GET: /Zona/Delete/5

        public ActionResult Delete(int id)
        {
            Zona zona = db.Zonas.Find(id);
            return View(zona);
        }

        //
        // POST: /Zona/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!HaveReferences(id))
            {
                Zona zona = db.Zonas.Find(id);
                db.Zonas.Remove(zona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Error error = new Error();
                error.Message = "Error: No puede eliminar esta zona porque tiene países asociados.";
                error.Action = "Delete";
                error.Controller = "Zona";
                return View("~/Views/Shared/Error.aspx", error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}