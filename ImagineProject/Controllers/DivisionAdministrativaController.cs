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
    public class DivisionAdministrativaController : Controller
    {
        private Db_ImagineEntities db = new Db_ImagineEntities();

        /***************************************************************************************/
        public bool HaveReferences(int id)
        {
            bool resultado = false;
            var cant = (db.Ciudades.Where(c => c.id_division_administrativa == id)).Count();
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
        /***************************************************************************************/

        //
        // GET: /DivisionAdministrativa/

        public ViewResult Index()
        {
            var divisionesadministrativas = db.DivisionesAdministrativas.Include(d => d.Pais);
            return View(divisionesadministrativas.ToList());
        }

        //
        // GET: /DivisionAdministrativa/Details/5

        public ViewResult Details(int id)
        {
            DivisionAdministrativa divisionadministrativa = db.DivisionesAdministrativas.Find(id);
            return View(divisionadministrativa);
        }

        //
        // GET: /DivisionAdministrativa/Create

        public ActionResult Create()
        {
            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "nombre_pais");
            return View();
        } 

        //
        // POST: /DivisionAdministrativa/Create

        [HttpPost]
        public ActionResult Create(DivisionAdministrativa divisionadministrativa)
        {
            if (ModelState.IsValid)
            {
                db.DivisionesAdministrativas.Add(divisionadministrativa);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "nombre_pais", divisionadministrativa.id_pais);
            return View(divisionadministrativa);
        }
        
        //
        // GET: /DivisionAdministrativa/Edit/5
 
        public ActionResult Edit(int id)
        {
            DivisionAdministrativa divisionadministrativa = db.DivisionesAdministrativas.Find(id);
            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "nombre_pais", divisionadministrativa.id_pais);
            return View(divisionadministrativa);
        }

        //
        // POST: /DivisionAdministrativa/Edit/5

        [HttpPost]
        public ActionResult Edit(DivisionAdministrativa divisionadministrativa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(divisionadministrativa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "nombre_pais", divisionadministrativa.id_pais);
            return View(divisionadministrativa);
        }

        //
        // GET: /DivisionAdministrativa/Delete/5
 
        public ActionResult Delete(int id)
        {
            DivisionAdministrativa divisionadministrativa = db.DivisionesAdministrativas.Find(id);
            return View(divisionadministrativa);
        }

        //
        // POST: /DivisionAdministrativa/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!HaveReferences(id))
            {
                DivisionAdministrativa divisionadministrativa = db.DivisionesAdministrativas.Find(id);
                db.DivisionesAdministrativas.Remove(divisionadministrativa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Operacion error = new Operacion();
                error.Message = "Error: No puede eliminar esta división administrativa porque tiene ciudades asociadas.";
                error.Action = "Delete";
                error.Controller = "DivisionAdministrativa";
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