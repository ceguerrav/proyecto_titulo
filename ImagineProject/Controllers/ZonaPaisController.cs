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
    public class ZonaPaisController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();


        /*********************************************************************************/
        public MultiSelectList GetPaises()
        {
            var paises = db.Paises.ToList();
            List<int> selectedValues = new List<int>();
            foreach (Pais p in paises)
            {
                selectedValues.Add(p.id_pais);
            }
            return new MultiSelectList(paises, "id_pais", "nombre_pais", selectedValues);
        }


        /*********************************************************************************/

        //
        // GET: /ZonaPais/

        public ViewResult Index()
        {
            var zonapais = db.ZonaPaises.Include(z => z.Pais).Include(z => z.Zona);
            return View(zonapais.ToList());
        }

        //
        // GET: /ZonaPais/Details/5

        public ViewResult Details(int id_zona, int id_pais)
        {
            ZonaPais zonapais = db.ZonaPaises.Find(id_zona, id_pais);
            return View(zonapais);
        }

        //
        // GET: /ZonaPais/Create

        public ActionResult Create()
        {
            //ViewBag.id_pais = new SelectList(db.Pais, "id_pais", "nombre_pais");
            ViewBag.id_zona = new SelectList(db.Zonas, "id_zona", "nombre_zona");
            ViewBag.id_pais = new MultiSelectList(db.Paises, "id_pais", "nombre_pais").OrderBy(p => p.Text);
            return View();
        }

        //
        // POST: /ZonaPais/Create
        [HttpPost]
        public ActionResult Create(ZonaPais zonapais, List<int> id_pais, int id_zona)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<ZonaPais> lista = new List<ZonaPais>();
                    for (int i = 0; i < id_pais.Count; i++)
                    {
                        zonapais = new ZonaPais();
                        zonapais.estado = true;
                        zonapais.id_zona = id_zona;
                        zonapais.id_pais = id_pais[i];
                        lista.Add(zonapais);
                        db.ZonaPaises.Add(lista[i]);
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(zonapais);
            }
            catch (NullReferenceException ex)
            {
                Operacion error = new Operacion();
                error.Message = "Debe asociar al menos un país a una zona. Intente nuevamente.";
                error.Action = "Create";
                error.Controller = "ZonaPais";
                return View("~/Views/Shared/Error.aspx", error);
            }
        }

        //
        // GET: /ZonaPais/Edit/5

        public ActionResult Edit(int id_zona, int id_pais)
        {
            ZonaPais zonapais = db.ZonaPaises.Find(id_zona, id_pais);
            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "nombre_pais", zonapais.id_pais);
            ViewBag.id_zona = new SelectList(db.Zonas, "id_zona", "nombre_zona", zonapais.id_zona);
            return View(zonapais);
        }

        //
        // POST: /ZonaPais/Edit/5

        [HttpPost]
        public ActionResult Edit(ZonaPais zonapais)
        {
            if (ModelState.IsValid)
            {
                zonapais.estado = true;
                db.Entry(zonapais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "nombre_pais", zonapais.id_pais);
            ViewBag.id_zona = new SelectList(db.Zonas, "id_zona", "nombre_zona", zonapais.id_zona);
            return View(zonapais);
        }

        //
        // GET: /ZonaPais/Delete/5

        public ActionResult Delete(int id_zona, int id_pais)
        {
            ZonaPais zonapais = db.ZonaPaises.Find(id_zona, id_pais);
            return View(zonapais);
        }

        //
        // POST: /ZonaPais/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id_zona, int id_pais)
        {
            ZonaPais zonapais = db.ZonaPaises.Find(id_zona, id_pais);
            db.ZonaPaises.Remove(zonapais);
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