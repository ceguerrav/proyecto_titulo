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
    public class LineaNavieraController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /LineaNaviera/

        public ViewResult Index()
        {
            return View(db.LineasNavieras.ToList());
        }

        //
        // GET: /LineaNaviera/Details/5

        public ViewResult Details(int id)
        {
            LineaNaviera lineanaviera = db.LineasNavieras.Find(id);
            return View(lineanaviera);
        }

        //
        // GET: /LineaNaviera/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /LineaNaviera/Create

        [HttpPost]
        public ActionResult Create(LineaNaviera lineanaviera)
        {
            if (ModelState.IsValid)
            {
                db.LineasNavieras.Add(lineanaviera);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(lineanaviera);
        }
        
        //
        // GET: /LineaNaviera/Edit/5
 
        public ActionResult Edit(int id)
        {
            LineaNaviera lineanaviera = db.LineasNavieras.Find(id);
            return View(lineanaviera);
        }

        //
        // POST: /LineaNaviera/Edit/5

        [HttpPost]
        public ActionResult Edit(LineaNaviera lineanaviera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineanaviera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lineanaviera);
        }

        //
        // GET: /LineaNaviera/Delete/5
 
        public ActionResult Delete(int id)
        {
            LineaNaviera lineanaviera = db.LineasNavieras.Find(id);
            return View(lineanaviera);
        }

        //
        // POST: /LineaNaviera/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            LineaNaviera lineanaviera = db.LineasNavieras.Find(id);
            db.LineasNavieras.Remove(lineanaviera);
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