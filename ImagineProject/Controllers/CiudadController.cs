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
    public class CiudadController : Controller
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

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetDivisiones(int id_pais)
        {
            var model = DivisionBinding(id_pais);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /*************************************************************************************/

        //
        // GET: /Ciudad/

        public ViewResult Index()
        {
            var ciudades = db.Ciudades.Include(c => c.DivisionAdministrativa);
            return View(ciudades.ToList());
        }

        //
        // GET: /Ciudad/Details/5

        public ViewResult Details(int id)
        {
            Ciudad ciudad = db.Ciudades.Find(id);
            return View(ciudad);
        }

        //
        // GET: /Ciudad/Create

        public ActionResult Create()
        {
            //ViewBag.id_division_administrativa = new SelectList(db.DivisionesAdministrativas, "id_division_administrativa", "nombre");
            ViewBag.ddl_pais = new SelectList(db.Paises, "id_pais", "nombre_pais").OrderBy(p => p.Text);
            ViewBag.id_division_administrativa = DivisionBinding();
            return View();
        } 

        //
        // POST: /Ciudad/Create

        [HttpPost]
        public ActionResult Create(Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Ciudades.Add(ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            //ViewBag.id_division_administrativa = new SelectList(db.DivisionesAdministrativas, "id_division_administrativa", "nombre", ciudad.id_division_administrativa);
            return View(ciudad);
        }
        
        //
        // GET: /Ciudad/Edit/5
 
        public ActionResult Edit(int id)
        {
            var consulta = (from c in db.Ciudades 
                            join d in db.DivisionesAdministrativas on c.id_division_administrativa equals d.id_division_administrativa
                            join p in db.Paises on d.id_pais equals p.id_pais
                            where c.id_ciudad == id
                            select new
                            {
                                id_division_administrativa = d.id_division_administrativa,
                                id_pais = p.id_pais

                            }).ToList();
            int id_pais = consulta.FirstOrDefault().id_pais;
            int id_division_administrativa = consulta.FirstOrDefault().id_division_administrativa;

            Ciudad ciudad = db.Ciudades.Find(id);
            ViewBag.ddl_pais = new SelectList(db.Paises, "id_pais", "nombre_pais", id_pais).OrderBy(p => p.Text);
            ViewBag.id_division_administrativa = DivisionBinding(id_pais, id_division_administrativa);

            return View(ciudad);
        }

        //
        // POST: /Ciudad/Edit/5

        [HttpPost]
        public ActionResult Edit(Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_division_administrativa = new SelectList(db.DivisionesAdministrativas, "id_division_administrativa", "nombre", ciudad.id_division_administrativa);
            return View(ciudad);
        }

        //
        // GET: /Ciudad/Delete/5
 
        public ActionResult Delete(int id)
        {
            Ciudad ciudad = db.Ciudades.Find(id);
            return View(ciudad);
        }

        //
        // POST: /Ciudad/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Ciudad ciudad = db.Ciudades.Find(id);
            db.Ciudades.Remove(ciudad);
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