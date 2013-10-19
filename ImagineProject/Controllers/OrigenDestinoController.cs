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
    public class OrigenDestinoController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /OrigenDestino/

        public ViewResult Index()
        {
            var origendestinos = db.OrigenDestinos.Include(o => o.Puerto).Include(o => o.Viaje);
            return View(origendestinos.ToList());
        }

        //
        // GET: /OrigenDestino/Details/5

        public ViewResult Details(int id)
        {
            OrigenDestino origendestino = db.OrigenDestinos.Find(id);
            return View(origendestino);
        }

        //
        // GET: /OrigenDestino/Create

        public ActionResult Create()
        {
            ViewBag.id_puerto = new SelectList(db.Puertos, "id_puerto", "nombre_puerto");
            ViewBag.id_viaje = new SelectList(db.Viajes, "id_viaje", "descripcion");
            return View();
        } 

        //
        // POST: /OrigenDestino/Create

        [HttpPost]
        public ActionResult Create(OrigenDestino origendestino)
        {
            if (ModelState.IsValid)
            {
                db.OrigenDestinos.Add(origendestino);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.id_puerto = new SelectList(db.Puertos, "id_puerto", "nombre_puerto", origendestino.id_puerto);
            ViewBag.id_viaje = new SelectList(db.Viajes, "id_viaje", "descripcion", origendestino.id_viaje);
            return View(origendestino);
        }
        
        //
        // GET: /OrigenDestino/Edit/5
 
        public ActionResult Edit(int id)
        {
            OrigenDestino origendestino = db.OrigenDestinos.Find(id);
            ViewBag.id_puerto = new SelectList(db.Puertos, "id_puerto", "nombre_puerto", origendestino.id_puerto);
            ViewBag.id_viaje = new SelectList(db.Viajes, "id_viaje", "descripcion", origendestino.id_viaje);
            return View(origendestino);
        }

        //
        // POST: /OrigenDestino/Edit/5

        [HttpPost]
        public ActionResult Edit(OrigenDestino origendestino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(origendestino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_puerto = new SelectList(db.Puertos, "id_puerto", "nombre_puerto", origendestino.id_puerto);
            ViewBag.id_viaje = new SelectList(db.Viajes, "id_viaje", "descripcion", origendestino.id_viaje);
            return View(origendestino);
        }

        //
        // GET: /OrigenDestino/Delete/5
 
        public ActionResult Delete(int id)
        {
            OrigenDestino origendestino = db.OrigenDestinos.Find(id);
            return View(origendestino);
        }

        //
        // POST: /OrigenDestino/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            OrigenDestino origendestino = db.OrigenDestinos.Find(id);
            db.OrigenDestinos.Remove(origendestino);
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