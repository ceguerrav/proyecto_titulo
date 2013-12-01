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
    public class LineaNavieraController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        public bool HaveReferences(int id)
        {
            bool resultado = false;
            var cant = (db.Barcos.Where(b => b.id_linea_naviera == id)).Count();
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
        // GET: /LineaNaviera/

        public ViewResult Index()
        {
            return View(db.LineasNavieras.ToList());
        }

        //
        // GET: /LineaNaviera/Details/5

        public ViewResult Details(int id)
        {
            LineaNaviera lineanaviera = db.LineasNavieras.Find(id);
            return View(lineanaviera);
        }

        //
        // GET: /LineaNaviera/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /LineaNaviera/Create

        [HttpPost]
        public ActionResult Create(LineaNaviera lineanaviera)
        {
            if (ModelState.IsValid)
            {
                db.LineasNavieras.Add(lineanaviera);
                db.SaveChanges();
                //return RedirectToAction("Index");  
                Operacion ok = new Operacion();
                ok.Action = "Index";
                ok.Controller = "LineaNaviera";
                ok.Message = "La linea naviera " + lineanaviera.linea_naviera + " ha sido ingresada exitosamente.";
                return View("~/Views/Shared/Dialog.aspx", ok);
            }
            return View(lineanaviera);
            
        }
        
        //
        // GET: /LineaNaviera/Edit/5
 
        public ActionResult Edit(int id)
        {
            LineaNaviera lineanaviera = db.LineasNavieras.Find(id);
            return View(lineanaviera);
        }

        //
        // POST: /LineaNaviera/Edit/5

        [HttpPost]
        public ActionResult Edit(LineaNaviera lineanaviera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineanaviera).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                Operacion ok = new Operacion();
                ok.Action = "Index";
                ok.Controller = "LineaNaviera";
                ok.Message = "La linea naviera " + lineanaviera.linea_naviera + " ha sido actualizada exitosamente.";
                return View("~/Views/Shared/Dialog.aspx", ok);
            }
            return View(lineanaviera);
        }

        //
        // GET: /LineaNaviera/Delete/5
 
        public ActionResult Delete(int id)
        {
            LineaNaviera lineanaviera = db.LineasNavieras.Find(id);
            return View(lineanaviera);
        }

        //
        // POST: /LineaNaviera/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!HaveReferences(id))
            {
                LineaNaviera lineanaviera = db.LineasNavieras.Find(id);
                db.LineasNavieras.Remove(lineanaviera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Operacion error = new Operacion();
                error.Message = "Error: No puede eliminar esta línea naviera porque tiene barcos asociadas.";
                error.Action = "Delete";
                error.Controller = "LineaNaviera";
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