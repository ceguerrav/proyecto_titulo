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
    public class TipoDivisionController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /TipoDivision/

        public ViewResult Index()
        {
            return View(db.TiposDivisiones.ToList());
        }

        //
        // GET: /TipoDivision/Details/5

        public ViewResult Details(short id)
        {
            TipoDivision tipodivision = db.TiposDivisiones.Find(id);
            return View(tipodivision);
        }

        //
        // GET: /TipoDivision/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TipoDivision/Create

        [HttpPost]
        public ActionResult Create(TipoDivision tipodivision)
        {
            if (ModelState.IsValid)
            {
                db.TiposDivisiones.Add(tipodivision);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tipodivision);
        }
        
        //
        // GET: /TipoDivision/Edit/5
 
        public ActionResult Edit(short id)
        {
            TipoDivision tipodivision = db.TiposDivisiones.Find(id);
            return View(tipodivision);
        }

        //
        // POST: /TipoDivision/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoDivision tipodivision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipodivision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipodivision);
        }

        //
        // GET: /TipoDivision/Delete/5
 
        public ActionResult Delete(short id)
        {
            TipoDivision tipodivision = db.TiposDivisiones.Find(id);
            return View(tipodivision);
        }

        //
        // POST: /TipoDivision/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {            
            TipoDivision tipodivision = db.TiposDivisiones.Find(id);
            db.TiposDivisiones.Remove(tipodivision);
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