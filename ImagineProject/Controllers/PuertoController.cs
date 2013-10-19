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
    public class PuertoController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        /*************************************************************************************/
        /* Métodos que permiten cargar DropDownList en cascada o dinámicamente */

        public List<SelectListItem> DivisionBinding(int id_pais = 0, int id_div = 0)
        {
            var divisiones = db.DivisionesAdministrativas.Where(d => d.id_pais == id_pais).ToList();
            var model = divisiones.Select(d => new SelectListItem
            {
                Value = d.id_division_administrativa.ToString(),
                Text = d.nombre,
                Selected = id_div == d.id_division_administrativa ? true : false
            }).ToList();
            model.Insert(0, new SelectListItem { Value = "0", Text = "--- Seleccione división ---" });
            return model;
        }

        public List<SelectListItem> CiudadBinding(int id_div = 0, int id_ciu = 0)
        {
            var ciudades = db.Ciudades.Where(c => c.id_division_administrativa == id_div).ToList();
            var model = ciudades.Select(c => new SelectListItem
            {
                Value = c.id_ciudad.ToString(),
                Text = c.nombre,
                Selected = id_ciu == c.id_ciudad ? true : false
            }).ToList();
            model.Insert(0, new SelectListItem { Value = "0", Text = "--- Seleccione ciudad ---" });
            return model;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetDivisiones(int id_pais)
        {
            var model = DivisionBinding(id_pais);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCiudades(int id_division)
        {
            var model = CiudadBinding(id_division);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /*************************************************************************************/

        //
        // GET: /Puerto/

        public ViewResult Index()
        {
            var puertos = db.Puertos.Include(p => p.Ciudad);
            return View(puertos.ToList());
        }

        //
        // GET: /Puerto/Details/5

        public ViewResult Details(int id)
        {
            Puerto puerto = db.Puertos.Find(id);
            return View(puerto);
        }

        //
        // GET: /Puerto/Create

        public ActionResult Create()
        {
            ViewBag.ddl_pais = new SelectList(db.Paises, "id_pais", "nombre_pais").OrderBy(p => p.Text);
            ViewBag.ddl_division = DivisionBinding();
            ViewBag.id_ciudad = CiudadBinding().OrderBy(c => c.Text);
            return View();
        } 

        //
        // POST: /Puerto/Create

        [HttpPost]
        public ActionResult Create(Puerto puerto)
        {
            if (ModelState.IsValid)
            {
                db.Puertos.Add(puerto);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            //ViewBag.id_ciudad = new SelectList(db.Ciudades, "id_ciudad", "nombre", puerto.id_ciudad);
            return View(puerto);
        }
        
        //
        // GET: /Puerto/Edit/5
 
        public ActionResult Edit(int id)
        {
            var consulta = (from pa in db.Pasajeros
                            join c in db.Ciudades on pa.id_ciudad equals c.id_ciudad
                            join d in db.DivisionesAdministrativas on c.id_division_administrativa equals d.id_division_administrativa
                            join p in db.Paises on d.id_pais equals p.id_pais
                            where pa.id_pasajero == id
                            select new
                            {
                                id_ciudad = c.id_ciudad,
                                id_division_administrativa = d.id_division_administrativa,
                                id_pais = p.id_pais

                            }).ToList();
            int id_pais = consulta.FirstOrDefault().id_pais;
            int id_division_administrativa = consulta.FirstOrDefault().id_division_administrativa;
            int id_ciudad = consulta.FirstOrDefault().id_ciudad;

            Puerto puerto = db.Puertos.Find(id);
            ViewBag.ddl_pais = new SelectList(db.Paises, "id_pais", "nombre_pais", id_pais).OrderBy(p => p.Text);
            ViewBag.ddl_division = DivisionBinding(id_pais, id_division_administrativa);
            ViewBag.id_ciudad = CiudadBinding(id_division_administrativa, id_ciudad).OrderBy(c => c.Text);
            return View(puerto);
        }

        //
        // POST: /Puerto/Edit/5

        [HttpPost]
        public ActionResult Edit(Puerto puerto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puerto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.id_ciudad = new SelectList(db.Ciudades, "id_ciudad", "nombre", puerto.id_ciudad);
            return View(puerto);
        }

        //
        // GET: /Puerto/Delete/5
 
        public ActionResult Delete(int id)
        {
            Puerto puerto = db.Puertos.Find(id);
            return View(puerto);
        }

        //
        // POST: /Puerto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Puerto puerto = db.Puertos.Find(id);
            db.Puertos.Remove(puerto);
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