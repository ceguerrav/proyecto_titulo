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
    public class TagController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // GET: /Tag/

        public ViewResult Index()
        {
            var tags = db.Tags.Include(t => t.Pasajero);
            return View(tags.ToList());
        }

        //
        // GET: /Tag/Details/5

        public ViewResult Details(int id)
        {
            Tag tag = db.Tags.Find(id);
            return View(tag);
        }

        //
        // GET: /Tag/Create

        public ActionResult Create()
        {
            ViewBag.id_pasajero = new SelectList(db.Pasajeros, "id_pasajero", "pasaporte");
            return View();
        } 

        //
        // POST: /Tag/Create

        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                tag.fecha_registro = DateTime.Now;
                db.Tags.Add(tag);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.id_pasajero = new SelectList(db.Pasajeros, "id_pasajero", "pasaporte", tag.id_pasajero);
            return View(tag);
        }
        
        //
        // GET: /Tag/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tag tag = db.Tags.Find(id);
            ViewBag.id_pasajero = new SelectList(db.Pasajeros, "id_pasajero", "pasaporte", tag.id_pasajero);
            return View(tag);
        }

        //
        // POST: /Tag/Edit/5

        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pasajero = new SelectList(db.Pasajeros, "id_pasajero", "pasaporte", tag.id_pasajero);
            return View(tag);
        }

        //
        // GET: /Tag/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tag tag = db.Tags.Find(id);
            return View(tag);
        }

        //
        // POST: /Tag/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tag tag = db.Tags.Find(id);
            db.Tags.Remove(tag);
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