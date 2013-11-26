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
    public class TipoZonaController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        public bool HaveReferences(int id)
        {
            bool resultado = false;
            var cant = (db.Zonas.Where(z => z.id_tipo_zona == id)).Count();
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
        // GET: /TipoZona/

        public ViewResult Index()
        {
            return View(db.TipoZonas.ToList());
        }

        //
        // GET: /TipoZona/Details/5

        public ViewResult Details(short id)
        {
            TipoZona tipozona = db.TipoZonas.Find(id);
            return View(tipozona);
        }

        //
        // GET: /TipoZona/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoZona/Create

        [HttpPost]
        public ActionResult Create(TipoZona tipozona)
        {
            if (ModelState.IsValid)
            {
                db.TipoZonas.Add(tipozona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipozona);
        }

        //
        // GET: /TipoZona/Edit/5

        public ActionResult Edit(short id)
        {
            TipoZona tipozona = db.TipoZonas.Find(id);
            return View(tipozona);
        }

        //
        // POST: /TipoZona/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoZona tipozona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipozona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipozona);
        }

        //
        // GET: /TipoZona/Delete/5

        public ActionResult Delete(short id)
        {
            TipoZona tipozona = db.TipoZonas.Find(id);
            return View(tipozona);
        }

        //
        // POST: /TipoZona/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {
            if (!HaveReferences(id))
            {
                TipoZona tipozona = db.TipoZonas.Find(id);
                db.TipoZonas.Remove(tipozona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Error error = new Error();
                error.Message = "Error: No puede eliminar este tipo de zona porque tiene zonas asociados.";
                error.Action = "Delete";
                error.Controller = "TipoZona";
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