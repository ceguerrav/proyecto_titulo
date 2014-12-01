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
        private static int id_pasajero { get; set; }
        /************************************************************************************************/
        public bool HaveReferences(int id)
        {
            bool resultado = false;
            var cant = (db.Movimientos.Where(m => m.id_tag == id)).Count();
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
            //int cant = db.Tags.Count();
            lastId = db.Tags.Max(t => t.id_tag);
            if (lastId == 0)
            {
                lastId = 1;
            }
            if (lastId > 0)
            {
                ++lastId;
            }
            return lastId;
        }

        private void SetStatus(int id_pasajero)
        {
            if (id_pasajero > 0)
            {
                Tag tag = db.Tags.Where(a => a.Pasajero.id_pasajero.Equals(id_pasajero) && a.estado.Equals(true)).First();

                if (!tag.Equals(null))
                {
                    if (ModelState.IsValid)
                    {
                        tag.estado = false;
                        db.Entry(tag).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
        }

        public Pasajero ObtenerPasajeroPorPasaporte(string pasaporte)
        {
            Pasajero pasajero;
            try
            {
                pasajero = db.Pasajeros.Where(p => p.pasaporte.Equals(pasaporte)).First();
            }
            catch (InvalidOperationException ioe)
            {
                pasajero = null;
                //throw new Exception("Pasajero no encontrado");
            }
            return pasajero;
        }

        //
        // POST: 
        [HttpPost]
        public ActionResult ValidaPasaporteTag(string txt_pasaporte)
        {
            var mensaje = new TagBuilder("span");
            mensaje.Attributes.Add("class", "field-validation-error");
            if (txt_pasaporte.Equals(null) || (!txt_pasaporte.Equals(null) && txt_pasaporte.Trim().Equals("")))
            {
                mensaje.SetInnerText("Ingrese pasaporte");
            }
            return Content(mensaje.ToString());
        }
        /*
        [HttpPost]
        public ActionResult ValidaTag(string txt_pasaporte, String txt_identificador)
        {
            List<string> listaErrores = new List<string>();
            String mensajeSpan = "";
            //mensajeSpan.SetInnerText("Ingrese pasaporte.");
            //return Content(mensajeSpan.ToString());

            if (txt_pasaporte.Equals(null) || (!txt_pasaporte.Equals(null) && txt_pasaporte.Trim().Equals("")))
            {
                listaErrores.Add("Ingrese pasaporte.");
            }
            if (txt_identificador.Equals(null) || !(txt_identificador.Equals(null) && txt_identificador.Trim().Equals("")))
            {
                listaErrores.Add("Ingrese un identificador.");
            }
            if (listaErrores.Count > 0)
            { 
                var mensaje = new TagBuilder("span");
                mensaje.Attributes.Add("class", "field-validation-error");
                foreach(string error in listaErrores){
                    mensajeSpan = mensajeSpan.Insert(mensajeSpan.IndexOf(mensajeSpan), error+"<br/>");
                }
                mensaje.SetInnerText(mensajeSpan);
                return Content(mensaje.ToString());
            }
            return View();
        }
         * */
        /************************************************************************************************/
        private Db_ImagineEntities db = new Db_ImagineEntities();

        //
        // POST: 
        [HttpPost]
        public ActionResult BuscarPasajeroPorPasaporte(string txt_pasaporte)
        {
            id_pasajero = 0;
            Pasajero resultado = ObtenerPasajeroPorPasaporte(txt_pasaporte);
            
            if (resultado != null)
            {
                id_pasajero = resultado.id_pasajero;
                return PartialView("PasajeroBuscado", resultado);
            }
            else 
            {
                id_pasajero = 0;
                // Crea Span
                var mensajeSpan = new TagBuilder("span");
                mensajeSpan.Attributes.Add("class", "field-validation-error");
                mensajeSpan.SetInnerText("Pasajero no encontrado. Verifique pasaporte.");
                return Content(mensajeSpan.ToString());
            }
        }

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
        // GET: /AgregarTag/Create
        public ActionResult Create()
        {
            //ViewBag.id_pasajero = new SelectList(db.Pasajeros, "id_pasajero", "pasaporte");
            return View();
        }

        //
        // POST: /AgregarTag/Create
        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            if (id_pasajero == 0)
            {
                //
                return Content("Busque un pasajero válidooooooooooooo.");
            }
            else 
            {
                tag.id_pasajero = id_pasajero;
            }
            if (ModelState.IsValid)
            {
                SetStatus(tag.id_pasajero);
                tag.estado = true;
                tag.fecha_registro = DateTime.Now;
                db.Tags.Add(tag);
                db.SaveChanges();

                Operacion ok = new Operacion();
                ok.Action = "Index";
                ok.Controller = "Tag";
                ok.Message = "Tag " + tag.identificador + " registrado!.";
                return View("~/Views/Shared/Dialog.aspx", ok);
                //return PartialView("~/Views/Shared/Dialog.ascx", ok);
            }

            //ViewBag.id_pasajero = new SelectList(db.Pasajeros, "id_pasajero", "pasaporte", tag.id_pasajero);
            return View(tag);
        }

        //
        // GET: /Tag/Grabar
        public ActionResult Grabar()
        {
            ViewBag.id_pasajero = new SelectList(db.Pasajeros, "id_pasajero", "pasaporte");
            return View();
        }

        //
        // POST: /Tag/Grabar
        [HttpPost]
        public ActionResult Grabar(Tag tag)
        {
            // Conexión automática al puerto COM6
            this.contrCon.Selected = "COM6";
            this.contrCon.Connect();
            string estado = "000";
            int lastId = LastIdInserted();

            String mensaje = "";
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
                    mensaje = "ERROR DE COMUNICACIÓN. El dispositivo de grabación de etiquetas RFID no se encuentra conectado. \n" +
                              "Conecte el dispositivo o ingrese una etiqueta de forma manual presionando el link:";
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

                if (estado.Equals("001"))
                {
                    Operacion ok = new Operacion();
                    ok.Action = "Index";
                    ok.Controller = "Tag";
                    ok.Message = "El identificador de la etiqueta es " + tag.identificador;
                    return View("~/Views/Shared/Dialog.aspx", ok);
                }
                if (!estado.Equals("001"))
                {
                    Operacion error = new Operacion();
                    error.Message = mensaje;
                    error.Action = "Create";
                    error.Controller = "Tag";
                    return View("~/Views/Shared/Error.aspx", error);
                }
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
                //return RedirectToAction("Index");
                Operacion ok = new Operacion();
                ok.Action = "Index";
                ok.Controller = "Tag";
                ok.Message = "El identificador de la etiqueta actualizado es el " + tag.identificador;
                return View("~/Views/Shared/Dialog.aspx", ok);
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
            if (!HaveReferences(id))
            {
                Tag tag = db.Tags.Find(id);
                db.Tags.Remove(tag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Operacion error = new Operacion();
                error.Message = "Error: No puede eliminar esta etiqueta RFID porque tiene movimientos asociados.";
                error.Action = "Delete";
                error.Controller = "Tag";
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