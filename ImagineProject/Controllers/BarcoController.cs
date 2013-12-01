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
    public class BarcoController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        public bool HaveReferencesViaje(int id)
        {
            bool resultado = false;
            var cant = (db.Viajes.Where(v => v.id_barco == id)).Count();
            if (cant > 0)
            {
                resultado = true;
            }
            else if (cant == 0)
            {
                resultado = false;
            }
            return resultado;
        }
        public bool HaveReferencesRecintos(int id)
        {
            bool resultado = false;
            var cant = (db.Viajes.Where(v => v.id_barco == id)).Count();
            if (cant > 0)
            {
                resultado = true;
            }
            else if (cant == 0)
            {
                resultado = false;
            }
            return resultado;
        }      

        //
        // GET: /Barco/

        public ViewResult Index()
        {
            var barcos = db.Barcos.Include(b => b.LineaNaviera).Include(b => b.TipoBarco);
            return View(barcos.ToList());
        }

        //
        // GET: /Barco/Details/5

        public ViewResult Details(int id)
        {
            Barco barco = db.Barcos.Find(id);
            return View(barco);
        }

        //
        // GET: /Barco/Create

        public ActionResult Create()
        {
            ViewBag.id_linea_naviera = new SelectList(db.LineasNavieras, "id_linea_naviera", "linea_naviera");
            ViewBag.id_tipo_barco = new SelectList(db.TiposBarcos, "id_tipo_barco", "tipo_barco");
            return View();
        } 

        //
        // POST: /Barco/Create

        [HttpPost]
        public ActionResult Create(Barco barco)
        {
            if (ModelState.IsValid)
            {
                db.Barcos.Add(barco);
                db.SaveChanges();
                //return RedirectToAction("Index");  
                Operacion ok = new Operacion();
                ok.Action = "Index";
                ok.Controller = "Barco";
                ok.Message = "El barco " + barco.nombre_barco + " ha sido ingresado exitosamente.";
                return View("~/Views/Shared/Dialog.aspx", ok);
            }

            ViewBag.id_linea_naviera = new SelectList(db.LineasNavieras, "id_linea_naviera", "linea_naviera", barco.id_linea_naviera);
            ViewBag.id_tipo_barco = new SelectList(db.TiposBarcos, "id_tipo_barco", "tipo_barco", barco.id_tipo_barco);
            return View(barco);
        }
        
        //
        // GET: /Barco/Edit/5
 
        public ActionResult Edit(int id)
        {
            Barco barco = db.Barcos.Find(id);
            ViewBag.id_linea_naviera = new SelectList(db.LineasNavieras, "id_linea_naviera", "linea_naviera", barco.id_linea_naviera);
            ViewBag.id_tipo_barco = new SelectList(db.TiposBarcos, "id_tipo_barco", "tipo_barco", barco.id_tipo_barco);
            return View(barco);
        }

        //
        // POST: /Barco/Edit/5

        [HttpPost]
        public ActionResult Edit(Barco barco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barco).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                Operacion ok = new Operacion();
                ok.Action = "Index";
                ok.Controller = "Barco";
                ok.Message = "El barco " + barco.nombre_barco + " ha sido actualizado exitosamente.";
                return View("~/Views/Shared/Dialog.aspx", ok);
            }
            ViewBag.id_linea_naviera = new SelectList(db.LineasNavieras, "id_linea_naviera", "linea_naviera", barco.id_linea_naviera);
            ViewBag.id_tipo_barco = new SelectList(db.TiposBarcos, "id_tipo_barco", "tipo_barco", barco.id_tipo_barco);
            return View(barco);
        }

        //
        // GET: /Barco/Delete/5
 
        public ActionResult Delete(int id)
        {
            Barco barco = db.Barcos.Find(id);
            return View(barco);
        }

        //
        // POST: /Barco/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!HaveReferencesViaje(id) && !HaveReferencesRecintos(id))
            {
                Barco barco = db.Barcos.Find(id);
                db.Barcos.Remove(barco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Operacion error = new Operacion();
                error.Message = "Error: No puede eliminar este barco porque tiene viajes y/o recintos asociados.";
                error.Action = "Delete";
                error.Controller = "Barco";
                return View("~/Views/Shared/Error.aspx", error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}