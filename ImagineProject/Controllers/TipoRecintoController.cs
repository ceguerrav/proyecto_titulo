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
    public class TipoRecintoController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /TipoRecinto/

        public ViewResult Index()
        {
            return View(db.TiposRecintos.ToList());
        }

        //
        // GET: /TipoRecinto/Details/5

        public ViewResult Details(short id)
        {
            TipoRecinto tiporecinto = db.TiposRecintos.Find(id);
            return View(tiporecinto);
        }

        //
        // GET: /TipoRecinto/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TipoRecinto/Create

        [HttpPost]
        public ActionResult Create(TipoRecinto tiporecinto)
        {
            if (ModelState.IsValid)
            {
                db.TiposRecintos.Add(tiporecinto);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tiporecinto);
        }
        
        //
        // GET: /TipoRecinto/Edit/5
 
        public ActionResult Edit(short id)
        {
            TipoRecinto tiporecinto = db.TiposRecintos.Find(id);
            return View(tiporecinto);
        }

        //
        // POST: /TipoRecinto/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoRecinto tiporecinto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiporecinto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiporecinto);
        }

        //
        // GET: /TipoRecinto/Delete/5
 
        public ActionResult Delete(short id)
        {
            TipoRecinto tiporecinto = db.TiposRecintos.Find(id);
            return View(tiporecinto);
        }

        //
        // POST: /TipoRecinto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {            
            TipoRecinto tiporecinto = db.TiposRecintos.Find(id);
            db.TiposRecintos.Remove(tiporecinto);
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