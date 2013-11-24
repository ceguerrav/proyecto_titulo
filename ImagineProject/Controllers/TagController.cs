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

        private void SetStatus(int id_pasajero)
        {
            var query = db.Tags.Where(t => t.id_pasajero.Equals(id_pasajero));
            if (query.Count() > 0)
            {
                int ultimoId = query.Select(t => t.id_tag).Max();
                Tag tag = db.Tags.Find(ultimoId);
                if (ModelState.IsValid)
                {
                    tag.estado = false;
                    db.Entry(tag).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        public string GenerarID()
        {
            string id = "1234567890";
            return id;
        }
 
        /*
        public String GenerateID() 
        {
            int lastId = LastIdInserted();
            RfidModel auxGrabar = new RfidModel();
            auxGrabar.CodigoRFID = lastId.ToString();
            string cod_rfid = auxGrabar.completaRFIDCod(lastId.ToString());
            return cod_rfid;
        }
        */
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
            // Conexión automática al puerto COM6
            this.contrCon.Selected = "COM6";
            this.contrCon.Connect();
            string estado = "";
            int lastId = LastIdInserted();

            String mensaje;
            if (ModelState.IsValid)
            {
                RfidModel auxGrabar = new RfidModel();
                auxGrabar.PuertoCOM = "COM10";
                auxGrabar.CodigoRFID = lastId.ToString();

                estado = auxGrabar.graba();

                if (estado.Equals("001"))
                {
                    // Dejo en estado INACTIVO el último Tag del Pasajero actual.
                    SetStatus(tag.id_pasajero);
                    string cod_rfid = auxGrabar.completaRFIDCod(lastId.ToString());
                    tag.identificador = cod_rfid;
                    tag.estado = true;
                    tag.fecha_registro = DateTime.Now;
                    db.Tags.Add(tag);
                    db.SaveChanges();
                    mensaje = "Operación exitosa.";
                }
                else if (estado.Equals("002"))
                {
                    mensaje = "Error de comunicación";
                }
                else if (estado.Equals("003"))
                {
                    mensaje = "Error de lectura etiqueta";
                }
                else if (estado.Equals("005"))
                {
                    mensaje = "Error inesperado";
                }
                contrCon.Disconnect();
                //return RedirectToAction("Index");  
            }
            ViewBag.id_pasajero = new SelectList(db.Pasajeros, "id_pasajero", "pasaporte", tag.id_pasajero);
            return View(tag);
            //return View(tag);
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