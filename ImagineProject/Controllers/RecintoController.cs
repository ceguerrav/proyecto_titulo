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
    public class RecintoController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        public bool HaveReferences(int id)
        {
            bool resultado = false;
            var cant = (db.RecintoPorticos.Where(rp => rp.id_recinto == id)).Count();
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
        // GET: /Recinto/

        public ViewResult Index()
        {
            var recintos = db.Recintos.Include(r => r.Barco).Include(r => r.TipoAmbiente).Include(r => r.TipoRecinto);
            return View(recintos.ToList());
        }

        //
        // GET: /Recinto/Details/5

        public ViewResult Details(int id)
        {
            Recinto recinto = db.Recintos.Find(id);
            return View(recinto);
        }

        //
        // GET: /Recinto/Create

        public ActionResult Create()
        {
            ViewBag.id_barco = new SelectList(db.Barcos, "id_barco", "nombre_barco");
            ViewBag.id_tipo_ambiente = new SelectList(db.TiposAmbientes, "id_tipo_ambiente", "tipo_ambiente");
            ViewBag.id_tipo_recinto = new SelectList(db.TiposRecintos, "id_tipo_recinto", "tipo_recinto");
            return View();
        } 

        //
        // POST: /Recinto/Create

        [HttpPost]
        public ActionResult Create(Recinto recinto)
        {
            if (ModelState.IsValid)
            {
                db.Recintos.Add(recinto);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.id_barco = new SelectList(db.Barcos, "id_barco", "nombre_barco", recinto.id_barco);
            ViewBag.id_tipo_ambiente = new SelectList(db.TiposAmbientes, "id_tipo_ambiente", "tipo_ambiente", recinto.id_tipo_ambiente);
            ViewBag.id_tipo_recinto = new SelectList(db.TiposRecintos, "id_tipo_recinto", "tipo_recinto", recinto.id_tipo_recinto);
            return View(recinto);
        }
        
        //
        // GET: /Recinto/Edit/5
 
        public ActionResult Edit(int id)
        {
            Recinto recinto = db.Recintos.Find(id);
            ViewBag.id_barco = new SelectList(db.Barcos, "id_barco", "nombre_barco", recinto.id_barco);
            ViewBag.id_tipo_ambiente = new SelectList(db.TiposAmbientes, "id_tipo_ambiente", "tipo_ambiente", recinto.id_tipo_ambiente);
            ViewBag.id_tipo_recinto = new SelectList(db.TiposRecintos, "id_tipo_recinto", "tipo_recinto", recinto.id_tipo_recinto);
            return View(recinto);
        }

        //
        // POST: /Recinto/Edit/5

        [HttpPost]
        public ActionResult Edit(Recinto recinto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recinto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_barco = new SelectList(db.Barcos, "id_barco", "nombre_barco", recinto.id_barco);
            ViewBag.id_tipo_ambiente = new SelectList(db.TiposAmbientes, "id_tipo_ambiente", "tipo_ambiente", recinto.id_tipo_ambiente);
            ViewBag.id_tipo_recinto = new SelectList(db.TiposRecintos, "id_tipo_recinto", "tipo_recinto", recinto.id_tipo_recinto);
            return View(recinto);
        }

        //
        // GET: /Recinto/Delete/5
 
        public ActionResult Delete(int id)
        {
            Recinto recinto = db.Recintos.Find(id);
            return View(recinto);
        }

        //
        // POST: /Recinto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!HaveReferences(id))
            {
                Recinto recinto = db.Recintos.Find(id);
                db.Recintos.Remove(recinto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Operacion error = new Operacion();
                error.Message = "Error: No puede eliminar este recinto porque tiene porticos asociados.";
                error.Action = "Delete";
                error.Controller = "Recinto";
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