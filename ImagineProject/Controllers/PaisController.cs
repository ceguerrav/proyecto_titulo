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
    public class PaisController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /Pais/

        public ViewResult Index()
        {
            var paises = db.Paises.Include(p => p.TipoDivision);
            return View(paises.ToList());
        }

        //
        // GET: /Pais/Details/5

        public ViewResult Details(int id)
        {
            Pais pais = db.Paises.Find(id);
            return View(pais);
        }

        //
        // GET: /Pais/Create

        public ActionResult Create()
        {
            ViewBag.id_tipo_division = new SelectList(db.TiposDivisiones, "id_tipo_division", "tipo_division");
            return View();
        } 

        //
        // POST: /Pais/Create

        [HttpPost]
        public ActionResult Create(Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Paises.Add(pais);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.id_tipo_division = new SelectList(db.TiposDivisiones, "id_tipo_division", "tipo_division", pais.id_tipo_division);
            return View(pais);
        }
        
        //
        // GET: /Pais/Edit/5
 
        public ActionResult Edit(int id)
        {
            Pais pais = db.Paises.Find(id);
            ViewBag.id_tipo_division = new SelectList(db.TiposDivisiones, "id_tipo_division", "tipo_division", pais.id_tipo_division);
            return View(pais);
        }

        //
        // POST: /Pais/Edit/5

        [HttpPost]
        public ActionResult Edit(Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_division = new SelectList(db.TiposDivisiones, "id_tipo_division", "tipo_division", pais.id_tipo_division);
            return View(pais);
        }

        //
        // GET: /Pais/Delete/5
 
        public ActionResult Delete(int id)
        {
            Pais pais = db.Paises.Find(id);
            return View(pais);
        }

        //
        // POST: /Pais/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Pais pais = db.Paises.Find(id);
            db.Paises.Remove(pais);
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