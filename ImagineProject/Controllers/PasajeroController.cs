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
    public class PasajeroController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        /*************************************************************************************/
        /* Métodos que permiten cargar DropDownList en cascada o dinámicamente */

        public List<SelectListItem> DivisionBinding(int id_pais = 0,int id_div = 0)
        {
            var divisiones = db.DivisionesAdministrativas.Where(d => d.id_pais == id_pais).ToList();
            var model = divisiones.Select(d => new SelectListItem
            {
                Value = d.id_division_administrativa.ToString(),
                Text = d.nombre,
                Selected = id_div == d.id_division_administrativa ? true : false
            }).ToList();
            model.Insert(0, new SelectListItem { Value = "0", Text = "--- Seleccione división ---"});
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
        // GET: /Pasajero/

        public ViewResult Index()
        {
            var pasajero = db.Pasajeros.Include(p => p.Ciudad);
            return View(pasajero.ToList());
        }

        //
        // GET: /Pasajero/Details/5

        public ViewResult Details(int id)
        {
            Pasajero pasajero = db.Pasajeros.Find(id);
            return View(pasajero);
        }

        //
        // GET: /Pasajero/Create

        public ActionResult Create()
        {

            ViewBag.ddl_pais = new SelectList(db.Paises, "id_pais", "nombre_pais").OrderBy(p => p.Text);
            ViewBag.ddl_division = DivisionBinding();
            ViewBag.id_ciudad = CiudadBinding().OrderBy(c => c.Text);
            return View();
        }

        //
        // POST: /Pasajero/Create

        [HttpPost]
        public ActionResult Create(Pasajero pasajero)
        {
            if (ModelState.IsValid)
            {
                pasajero.fecha_registro = DateTime.Now;
                pasajero.estado = true;
                db.Pasajeros.Add(pasajero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.id_ciudad = new SelectList(db.Ciudad, "id_ciudad", "nombre", pasajero.id_ciudad);
            return View(pasajero);
        }

        //
        // GET: /Pasajero/Edit/5

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

            Pasajero pasajero = db.Pasajeros.Find(id);
            ViewBag.ddl_pais = new SelectList(db.Paises, "id_pais", "nombre_pais", id_pais).OrderBy(p => p.Text);
            ViewBag.ddl_division = DivisionBinding(id_pais,id_division_administrativa);
            ViewBag.id_ciudad = CiudadBinding(id_division_administrativa,id_ciudad).OrderBy(c => c.Text);

            return View(pasajero);
        }

        //
        // POST: /Pasajero/Edit/5

        [HttpPost]
        public ActionResult Edit(Pasajero pasajero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasajero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.id_ciudad = new SelectList(db.Ciudad, "id_ciudad", "nombre", pasajero.id_ciudad);
            return View(pasajero);
        }

        //
        // GET: /Pasajero/Delete/5

        public ActionResult Delete(int id)
        {
            Pasajero pasajero = db.Pasajeros.Find(id);
            return View(pasajero);
        }

        //
        // POST: /Pasajero/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pasajero pasajero = db.Pasajeros.Find(id);
            db.Pasajeros.Remove(pasajero);
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