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
    public class TipoAmbienteController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /TipoAmbiente/

        public ViewResult Index()
        {
            return View(db.TiposAmbientes.ToList());
        }

        //
        // GET: /TipoAmbiente/Details/5

        public ViewResult Details(short id)
        {
            TipoAmbiente tipoambiente = db.TiposAmbientes.Find(id);
            return View(tipoambiente);
        }

        //
        // GET: /TipoAmbiente/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TipoAmbiente/Create

        [HttpPost]
        public ActionResult Create(TipoAmbiente tipoambiente)
        {
            if (ModelState.IsValid)
            {
                db.TiposAmbientes.Add(tipoambiente);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tipoambiente);
        }
        
        //
        // GET: /TipoAmbiente/Edit/5
 
        public ActionResult Edit(short id)
        {
            TipoAmbiente tipoambiente = db.TiposAmbientes.Find(id);
            return View(tipoambiente);
        }

        //
        // POST: /TipoAmbiente/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoAmbiente tipoambiente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoambiente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoambiente);
        }

        //
        // GET: /TipoAmbiente/Delete/5
 
        public ActionResult Delete(short id)
        {
            TipoAmbiente tipoambiente = db.TiposAmbientes.Find(id);
            return View(tipoambiente);
        }

        //
        // POST: /TipoAmbiente/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {            
            TipoAmbiente tipoambiente = db.TiposAmbientes.Find(id);
            db.TiposAmbientes.Remove(tipoambiente);
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