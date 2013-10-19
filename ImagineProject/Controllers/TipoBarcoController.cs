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
    public class TipoBarcoController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /TipoBarco/

        public ViewResult Index()
        {
            return View(db.TiposBarcos.ToList());
        }

        //
        // GET: /TipoBarco/Details/5

        public ViewResult Details(short id)
        {
            TipoBarco tipobarco = db.TiposBarcos.Find(id);
            return View(tipobarco);
        }

        //
        // GET: /TipoBarco/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TipoBarco/Create

        [HttpPost]
        public ActionResult Create(TipoBarco tipobarco)
        {
            if (ModelState.IsValid)
            {
                db.TiposBarcos.Add(tipobarco);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tipobarco);
        }
        
        //
        // GET: /TipoBarco/Edit/5
 
        public ActionResult Edit(short id)
        {
            TipoBarco tipobarco = db.TiposBarcos.Find(id);
            return View(tipobarco);
        }

        //
        // POST: /TipoBarco/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoBarco tipobarco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipobarco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipobarco);
        }

        //
        // GET: /TipoBarco/Delete/5
 
        public ActionResult Delete(short id)
        {
            TipoBarco tipobarco = db.TiposBarcos.Find(id);
            return View(tipobarco);
        }

        //
        // POST: /TipoBarco/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {            
            TipoBarco tipobarco = db.TiposBarcos.Find(id);
            db.TiposBarcos.Remove(tipobarco);
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