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
    public class TipoDivisionController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        public bool HaveReferences(int id)
        {
            bool resultado = false ; 
            var cant = (db.Paises.Where(p => p.id_tipo_division == id)).Count();
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
        // GET: /TipoDivision/

        public ViewResult Index()
        {
            return View(db.TiposDivisiones.ToList());
        }

        //
        // GET: /TipoDivision/Details/5

        public ViewResult Details(short id)
        {
            TipoDivision tipodivision = db.TiposDivisiones.Find(id);
            return View(tipodivision);
        }

        //
        // GET: /TipoDivision/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TipoDivision/Create

        [HttpPost]
        public ActionResult Create(TipoDivision tipodivision)
        {
            if (ModelState.IsValid)
            {
                db.TiposDivisiones.Add(tipodivision);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tipodivision);
        }
        
        //
        // GET: /TipoDivision/Edit/5
 
        public ActionResult Edit(short id)
        {
            TipoDivision tipodivision = db.TiposDivisiones.Find(id);
            return View(tipodivision);
        }

        //
        // POST: /TipoDivision/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoDivision tipodivision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipodivision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipodivision);
        }

        //
        // GET: /TipoDivision/Delete/5
 
        public ActionResult Delete(short id)
        {
            TipoDivision tipodivision = db.TiposDivisiones.Find(id);
            return View(tipodivision);
        }

        //
        // POST: /TipoDivision/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {
            if (!HaveReferences(id))
            {
                TipoDivision tipodivision = db.TiposDivisiones.Find(id);
                db.TiposDivisiones.Remove(tipodivision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                Error error = new Error();
                error.Message = "Error: No puede eliminar este tipo de división porque tiene países asociados.";
                error.Action = "Delete";
                error.Controller = "TipoDivision";
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