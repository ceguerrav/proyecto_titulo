using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImagineProject.Models;

using RfidZControl;

namespace ImagineProject.Controllers
{
    [Authorize(Roles = "Administrador")]   
    public class TagController : Controller
    {

        
        /************************************************************************************************/
        private static bool isCursorBusy;
        private ControlConexion conn;

        public static bool IsCursorBusy { get; set; }

        private ControlConexion contrCon
        {
            get
            {
                if (this.conn == null)
                {
                    this.conn = new ControlConexion();
                    IsCursorBusy = this.conn.IsBusy;
                }
                return this.conn;
            }
        }


        private int LastIdInserted()
        {
            int lastId = 0;
            int cant = db.Tags.Count();

            if (cant == 0)
            {
                lastId = 1;
            }
            if (cant > 0)
            {
                lastId = cant;
                lastId = lastId + 1;
            }               
            return lastId;
        }

        /************************************************************************************************/
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

        public String GenerateID() 
        {
            int lastId = LastIdInserted();
            RfidModel auxGrabar = new RfidModel();
            auxGrabar.CodigoRFID = lastId.ToString();
            string cod_rfid = auxGrabar.completaRFIDCod(lastId.ToString());
            return cod_rfid;
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
        public ActionResult Create(Tag tag,FormCollection form)
        {
            // Conexión automática al puerto COM6
            this.contrCon.Selected = "COM6";
            this.contrCon.Connect();
            string estado = "";
            int lastId = LastIdInserted();

            if (ModelState.IsValid)
            {
                RfidModel auxGrabar = new RfidModel();
                auxGrabar.PuertoCOM = "COM10";
                auxGrabar.CodigoRFID = lastId.ToString();

                estado = auxGrabar.graba();

                if (estado == "001")
                {
                    string cod_rfid = auxGrabar.completaRFIDCod(lastId.ToString());
                    tag.identificador = cod_rfid;


                    tag.fecha_registro = DateTime.Now;
                    db.Tags.Add(tag);
                    db.SaveChanges();
                }
                else if (estado == "002")
                {
                    
                }
                else if (estado == "003")
                {

                }
                else if (estado == "005")
                {

                }
                contrCon.Disconnect();
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