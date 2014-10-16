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
    public class RecintoPorticoController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /RecintoPortico/

        public ViewResult Index()
        {
            var recintoporticos = db.RecintoPorticos.Include(r => r.Portico).Include(r => r.Recinto);
            return View(recintoporticos.ToList());
        }

        //
        // GET: /RecintoPortico/Details/5
        /*
        public ViewResult Details(int id)
        {
            RecintoPortico recintoportico = db.RecintoPorticos.Find(id);
            return View(recintoportico);
        }
        */
        //
        // GET: /RecintoPortico/Create

        public ActionResult Create()
        {
            ViewBag.id_portico = new SelectList(db.Porticos, "id_portico", "descripcion_portico");
            ViewBag.id_recinto = new SelectList(db.Recintos, "id_recinto", "nombre_recinto");
            return View();
        } 

        //
        // POST: /RecintoPortico/Create

        [HttpPost]
        public ActionResult Create(RecintoPortico recintoportico)
        {
            if (ModelState.IsValid)
            {
                recintoportico.estado = true;
                db.RecintoPorticos.Add(recintoportico);
                db.SaveChanges();
                //return RedirectToAction("Index");  
                Operacion ok = new Operacion();
                ok.Action = "Index";
                ok.Controller = "RecintoPortico";
                //ok.Message = "Se ha ingresado el siguente portico " + recintoportico.Portico.descripcion_portico + "al reciento " + recintoportico.Recinto.nombre_recinto;
                ok.Message = "Se asociado correctamente el portico al recinto.";
                return View("~/Views/Shared/Dialog.aspx", ok);
            }

            ViewBag.id_portico = new SelectList(db.Porticos, "id_portico", "descripcion_portico", recintoportico.id_portico);
            ViewBag.id_recinto = new SelectList(db.Recintos, "id_recinto", "nombre_recinto", recintoportico.id_recinto);
            return View(recintoportico);
        }
        
        //
        // GET: /RecintoPortico/Edit/5
        /*
        public ActionResult Edit(int id_portico,int id_recinto)
        {
            RecintoPortico recintoportico = db.RecintoPorticos.Find(id_portico,id_recinto);
            ViewBag.id_portico = new SelectList(db.Porticos, "id_portico", "descripcion_portico", recintoportico.id_portico);
            ViewBag.id_recinto = new SelectList(db.Recintos, "id_recinto", "nombre_recinto", recintoportico.id_recinto);
            return View(recintoportico);
        }

        //
        // POST: /RecintoPortico/Edit/5

        [HttpPost]
        public ActionResult Edit(RecintoPortico recintoportico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recintoportico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_portico = new SelectList(db.Porticos, "id_portico", "descripcion_portico", recintoportico.id_portico);
            ViewBag.id_recinto = new SelectList(db.Recintos, "id_recinto", "nombre_recinto", recintoportico.id_recinto);
            return View(recintoportico);
        }
        */
        //
        // GET: /RecintoPortico/Delete/5

        public ActionResult Delete(int id_portico, int id_recinto)
        {
            RecintoPortico recintoportico = db.RecintoPorticos.Find(id_portico, id_recinto);
            return View(recintoportico);
        }

        //
        // POST: /RecintoPortico/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id_portico,int id_recinto)
        {
            RecintoPortico recintoportico = db.RecintoPorticos.Find(id_portico, id_recinto);
            db.RecintoPorticos.Remove(recintoportico);
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