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
    public class CiudadController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /Ciudad/

        public ViewResult Index()
        {
            var ciudades = db.Ciudades.Include(c => c.DivisionAdministrativa);
            return View(ciudades.ToList());
        }

        //
        // GET: /Ciudad/Details/5

        public ViewResult Details(int id)
        {
            Ciudad ciudad = db.Ciudades.Find(id);
            return View(ciudad);
        }

        //
        // GET: /Ciudad/Create

        public ActionResult Create()
        {
            ViewBag.id_division_administrativa = new SelectList(db.DivisionesAdministrativas, "id_division_administrativa", "nombre");
            return View();
        } 

        //
        // POST: /Ciudad/Create

        [HttpPost]
        public ActionResult Create(Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Ciudades.Add(ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.id_division_administrativa = new SelectList(db.DivisionesAdministrativas, "id_division_administrativa", "nombre", ciudad.id_division_administrativa);
            return View(ciudad);
        }
        
        //
        // GET: /Ciudad/Edit/5
 
        public ActionResult Edit(int id)
        {
            Ciudad ciudad = db.Ciudades.Find(id);
            ViewBag.id_division_administrativa = new SelectList(db.DivisionesAdministrativas, "id_division_administrativa", "nombre", ciudad.id_division_administrativa);
            return View(ciudad);
        }

        //
        // POST: /Ciudad/Edit/5

        [HttpPost]
        public ActionResult Edit(Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_division_administrativa = new SelectList(db.DivisionesAdministrativas, "id_division_administrativa", "nombre", ciudad.id_division_administrativa);
            return View(ciudad);
        }

        //
        // GET: /Ciudad/Delete/5
 
        public ActionResult Delete(int id)
        {
            Ciudad ciudad = db.Ciudades.Find(id);
            return View(ciudad);
        }

        //
        // POST: /Ciudad/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Ciudad ciudad = db.Ciudades.Find(id);
            db.Ciudades.Remove(ciudad);
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