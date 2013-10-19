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
            TipoZona tipozona = db.TipoZonas.Find(id);
            db.TipoZonas.Remove(tipozona);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}