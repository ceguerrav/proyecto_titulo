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
    public class MovimientosController : Controller
    {
        private Db_ImagineEntities bd = new Db_ImagineEntities();

        public ActionResult Movimientos1()
        {
            ViewBag.id_viaje = new SelectList(bd.Viajes, "id_viaje", "descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Movimientos1(string id_viaje)
        {
            //if (id_viaje == null || id_viaje == "")
            //{
            //    return Content("Seleccione viaje");
            //}

            int id_v = Convert.ToInt32(id_viaje);
            ViewBag.id_viaje = new SelectList(bd.Viajes, "id_viaje", "descripcion", id_viaje);

            var respuesta = ObtenerDatosMovimientos1(id_v).ToList();
            // Se llena la lista temporal
            return PartialView("ResultsPartialM1", respuesta);
        }

        public List<Movimientos> ObtenerDatosMovimientos1(int id_viaje)
        {
            List<Movimientos> listaDatos = new List<Movimientos>();
            var movimiento = (from mo in bd.Movimientos
                              join tm in bd.TiposMovimientos on mo.id_tipo_movimiento equals tm.id_tipo_movimiento
                              join po in bd.Porticos on mo.id_portico equals po.id_portico
                              join rp in bd.RecintoPorticos on po.id_portico equals rp.id_portico
                              join re in bd.Recintos on rp.id_recinto equals re.id_recinto
                              join tr in bd.TiposRecintos on re.id_tipo_recinto equals tr.id_tipo_recinto
                              join ta in bd.TiposAmbientes on re.id_tipo_ambiente equals ta.id_tipo_ambiente
                              join ba in bd.Barcos on re.id_barco equals ba.id_barco
                              join vi in bd.Viajes on ba.id_barco equals vi.id_viaje
                              where vi.id_viaje == id_viaje
                              group new { tr, ta, re, tm, mo } by new
                              {
                                  tr.tipo_recinto,
                                  ta.tipo_ambiente,
                                  re.nombre_recinto,
                                  tm.tipo_movimiento
                              } into grupoM
                              orderby grupoM.Key.nombre_recinto
                              select new
                              {
                                  tipoRecinto = grupoM.Key.tipo_recinto,
                                  tipoAmbiente = grupoM.Key.tipo_ambiente,
                                  recinto = grupoM.Key.nombre_recinto,
                                  tipoMovimiento = grupoM.Key.tipo_movimiento,
                                  movimientos = grupoM.Select(x => x.mo.id_movimiento).Count()
                              }).ToList();


            for (int i = 0; i < movimiento.Count; i++)
            {
                Movimientos m1 = new Movimientos();
                m1.Tipo_Recinto = movimiento[i].tipoRecinto;
                m1.Tipo_Ambiente = movimiento[i].tipoAmbiente;
                m1.Recinto = movimiento[i].recinto;
                m1.Tipo_Movimiento = movimiento[i].tipoMovimiento;
                m1.Cant_Movimientos = movimiento[i].movimientos.ToString();
                listaDatos.Add(m1);
            }
            return listaDatos;
        }

    }
}
