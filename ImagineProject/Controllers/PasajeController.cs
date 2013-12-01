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
    public class PasajeController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /Pasaje/

        public ViewResult Index()
        {
            var pasajes = db.Pasajes.Include(p => p.Pasajero).Include(p => p.TipoPasaje).Include(p => p.Viaje);
            return View(pasajes.ToList());
        }

        //
        // GET: /Pasaje/Details/5

        public ViewResult Details(int id)
        {
            Pasaje pasaje = db.Pasajes.Find(id);
            return View(pasaje);
        }

        //
        // GET: /Pasaje/Create

        public ActionResult Create()
        {
            ViewBag.id_pasajero = new SelectList(db.Pasajeros, "id_pasajero", "pasaporte");
            ViewBag.id_tipo_pasaje = new SelectList(db.TiposPasajes, "id_tipo_pasaje", "tipo_pasaje");
            ViewBag.id_viaje = new SelectList(db.Viajes, "id_viaje", "descripcion");
            return View();
        } 

        //
        // POST: /Pasaje/Create

        [HttpPost]
        public ActionResult Create(Pasaje pasaje)
        {
            if (ModelState.IsValid)
            {
                db.Pasajes.Add(pasaje);
                db.SaveChanges();
                //return RedirectToAction("Index");  
                Operacion ok = new Operacion();
                ok.Action = "Index";
                ok.Controller = "Pasaje";
                ok.Message = "El pasaje " + pasaje.numero_boleto + " ha sido ingresado exitosamente.";
                return View("~/Views/Shared/Dialog.aspx", ok);
            }

            ViewBag.id_pasajero = new SelectList(db.Pasajeros, "id_pasajero", "pasaporte", pasaje.id_pasajero);
            ViewBag.id_tipo_pasaje = new SelectList(db.TiposPasajes, "id_tipo_pasaje", "tipo_pasaje", pasaje.id_tipo_pasaje);
            ViewBag.id_viaje = new SelectList(db.Viajes, "id_viaje", "descripcion", pasaje.id_viaje);
            return View(pasaje);
        }
        
        //
        // GET: /Pasaje/Edit/5
 
        public ActionResult Edit(int id)
        {
            Pasaje pasaje = db.Pasajes.Find(id);
            ViewBag.id_pasajero = new SelectList(db.Pasajeros, "id_pasajero", "pasaporte", pasaje.id_pasajero);
            ViewBag.id_tipo_pasaje = new SelectList(db.TiposPasajes, "id_tipo_pasaje", "tipo_pasaje", pasaje.id_tipo_pasaje);
            ViewBag.id_viaje = new SelectList(db.Viajes, "id_viaje", "descripcion", pasaje.id_viaje);
            return View(pasaje);
        }

        //
        // POST: /Pasaje/Edit/5

        [HttpPost]
        public ActionResult Edit(Pasaje pasaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasaje).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                Operacion ok = new Operacion();
                ok.Action = "Index";
                ok.Controller = "Pasaje";
                ok.Message = "El pasaje " + pasaje.numero_boleto + " ha sido actualizado exitosamente.";
                return View("~/Views/Shared/Dialog.aspx", ok);
            }
            ViewBag.id_pasajero = new SelectList(db.Pasajeros, "id_pasajero", "pasaporte", pasaje.id_pasajero);
            ViewBag.id_tipo_pasaje = new SelectList(db.TiposPasajes, "id_tipo_pasaje", "tipo_pasaje", pasaje.id_tipo_pasaje);
            ViewBag.id_viaje = new SelectList(db.Viajes, "id_viaje", "descripcion", pasaje.id_viaje);
            return View(pasaje);
        }

        //
        // GET: /Pasaje/Delete/5
 
        public ActionResult Delete(int id)
        {
            Pasaje pasaje = db.Pasajes.Find(id);
            return View(pasaje);
        }

        //
        // POST: /Pasaje/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Pasaje pasaje = db.Pasajes.Find(id);
            db.Pasajes.Remove(pasaje);
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