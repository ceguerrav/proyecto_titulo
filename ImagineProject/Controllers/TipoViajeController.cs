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
    public class TipoViajeController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /TipoViaje/

        public ViewResult Index()
        {
            return View(db.TiposViajes.ToList());
        }

        //
        // GET: /TipoViaje/Details/5

        public ViewResult Details(short id)
        {
            TipoViaje tipoviaje = db.TiposViajes.Find(id);
            return View(tipoviaje);
        }

        //
        // GET: /TipoViaje/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TipoViaje/Create

        [HttpPost]
        public ActionResult Create(TipoViaje tipoviaje)
        {
            if (ModelState.IsValid)
            {
                db.TiposViajes.Add(tipoviaje);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tipoviaje);
        }
        
        //
        // GET: /TipoViaje/Edit/5
 
        public ActionResult Edit(short id)
        {
            TipoViaje tipoviaje = db.TiposViajes.Find(id);
            return View(tipoviaje);
        }

        //
        // POST: /TipoViaje/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoViaje tipoviaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoviaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoviaje);
        }

        //
        // GET: /TipoViaje/Delete/5
 
        public ActionResult Delete(short id)
        {
            TipoViaje tipoviaje = db.TiposViajes.Find(id);
            return View(tipoviaje);
        }

        //
        // POST: /TipoViaje/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {            
            TipoViaje tipoviaje = db.TiposViajes.Find(id);
            db.TiposViajes.Remove(tipoviaje);
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