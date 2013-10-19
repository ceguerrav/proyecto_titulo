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
    public class ViajeController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /Viaje/

        public ViewResult Index()
        {
            var viajes = db.Viajes.Include(v => v.Barco).Include(v => v.TipoViaje);
            return View(viajes.ToList());
        }

        //
        // GET: /Viaje/Details/5

        public ViewResult Details(int id)
        {
            Viaje viaje = db.Viajes.Find(id);
            return View(viaje);
        }

        //
        // GET: /Viaje/Create

        public ActionResult Create()
        {
            ViewBag.id_barco = new SelectList(db.Barcos, "id_barco", "nombre_barco");
            ViewBag.id_tipo_viaje = new SelectList(db.TiposViajes, "id_tipo_viaje", "tipo_viaje");
            return View();
        } 

        //
        // POST: /Viaje/Create

        [HttpPost]
        public ActionResult Create(Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Viajes.Add(viaje);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.id_barco = new SelectList(db.Barcos, "id_barco", "nombre_barco", viaje.id_barco);
            ViewBag.id_tipo_viaje = new SelectList(db.TiposViajes, "id_tipo_viaje", "tipo_viaje", viaje.id_tipo_viaje);
            return View(viaje);
        }
        
        //
        // GET: /Viaje/Edit/5
 
        public ActionResult Edit(int id)
        {
            Viaje viaje = db.Viajes.Find(id);
            ViewBag.id_barco = new SelectList(db.Barcos, "id_barco", "nombre_barco", viaje.id_barco);
            ViewBag.id_tipo_viaje = new SelectList(db.TiposViajes, "id_tipo_viaje", "tipo_viaje", viaje.id_tipo_viaje);
            return View(viaje);
        }

        //
        // POST: /Viaje/Edit/5

        [HttpPost]
        public ActionResult Edit(Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_barco = new SelectList(db.Barcos, "id_barco", "nombre_barco", viaje.id_barco);
            ViewBag.id_tipo_viaje = new SelectList(db.TiposViajes, "id_tipo_viaje", "tipo_viaje", viaje.id_tipo_viaje);
            return View(viaje);
        }

        //
        // GET: /Viaje/Delete/5
 
        public ActionResult Delete(int id)
        {
            Viaje viaje = db.Viajes.Find(id);
            return View(viaje);
        }

        //
        // POST: /Viaje/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Viaje viaje = db.Viajes.Find(id);
            db.Viajes.Remove(viaje);
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