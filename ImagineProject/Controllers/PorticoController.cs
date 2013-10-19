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
    public class PorticoController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /Portico/

        public ViewResult Index()
        {
            return View(db.Porticos.ToList());
        }

        //
        // GET: /Portico/Details/5

        public ViewResult Details(int id)
        {
            Portico portico = db.Porticos.Find(id);
            return View(portico);
        }

        //
        // GET: /Portico/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Portico/Create

        [HttpPost]
        public ActionResult Create(Portico portico)
        {
            if (ModelState.IsValid)
            {
                portico.estado = true;
                db.Porticos.Add(portico);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(portico);
        }
        
        //
        // GET: /Portico/Edit/5
 
        public ActionResult Edit(int id)
        {
            Portico portico = db.Porticos.Find(id);
            return View(portico);
        }

        //
        // POST: /Portico/Edit/5

        [HttpPost]
        public ActionResult Edit(Portico portico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portico);
        }

        //
        // GET: /Portico/Delete/5
 
        public ActionResult Delete(int id)
        {
            Portico portico = db.Porticos.Find(id);
            return View(portico);
        }

        //
        // POST: /Portico/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Portico portico = db.Porticos.Find(id);
            db.Porticos.Remove(portico);
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