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
    public class TipoPasajeController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /TipoPasaje/

        public ViewResult Index()
        {
            return View(db.TiposPasajes.ToList());
        }

        //
        // GET: /TipoPasaje/Details/5

        public ViewResult Details(short id)
        {
            TipoPasaje tipopasaje = db.TiposPasajes.Find(id);
            return View(tipopasaje);
        }

        //
        // GET: /TipoPasaje/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TipoPasaje/Create

        [HttpPost]
        public ActionResult Create(TipoPasaje tipopasaje)
        {
            if (ModelState.IsValid)
            {
                db.TiposPasajes.Add(tipopasaje);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tipopasaje);
        }
        
        //
        // GET: /TipoPasaje/Edit/5
 
        public ActionResult Edit(short id)
        {
            TipoPasaje tipopasaje = db.TiposPasajes.Find(id);
            return View(tipopasaje);
        }

        //
        // POST: /TipoPasaje/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoPasaje tipopasaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipopasaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipopasaje);
        }

        //
        // GET: /TipoPasaje/Delete/5
 
        public ActionResult Delete(short id)
        {
            TipoPasaje tipopasaje = db.TiposPasajes.Find(id);
            return View(tipopasaje);
        }

        //
        // POST: /TipoPasaje/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {            
            TipoPasaje tipopasaje = db.TiposPasajes.Find(id);
            db.TiposPasajes.Remove(tipopasaje);
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