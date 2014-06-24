using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImagineProject.Models;
//using System.Text;
//using System.IO;
//using System.Web.UI;
//using iTextSharp.text.html.simpleparser;

namespace ImagineProject.Controllers
{
    public class ReportesController : Controller
    {
        //private Db_ImagineEntities db = new Db_ImagineEntities();
        private DWH_ImagineEntities dwh = new DWH_ImagineEntities();
        
        
        
        // REPORTE1 --------------------------------------------------------------------------        
        public ActionResult Reporte1()
        {
            ViewBag.id_barco = new SelectList(dwh.dim_barcos, "id_barco", "nombre_barco");
            ViewBag.id_viaje = new SelectList(dwh.dim_viajes, "id_viaje", "descripcion_viaje");
            return View();
        }

        [HttpPost]
        public ActionResult Reporte1(string id_barco, string id_viaje, string fecha)
        {
            int id_b = Convert.ToInt32(id_barco);
            int id_v = Convert.ToInt32(id_viaje);
            DateTime fecha_conv = Convert.ToDateTime(fecha);
            ViewBag.id_barco = new SelectList(dwh.dim_barcos, "id_barco", "nombre_barco", id_barco);
            ViewBag.id_viaje = new SelectList(dwh.dim_viajes, "id_viaje", "descripcion_viaje", id_viaje);
            var respuesta = ObtenerDatosReporte1(id_b, id_v, fecha_conv).ToList();
            return PartialView("ResultsPartialR1", respuesta);
        }


        // REPORTE2 --------------------------------------------------------------------------
        public ActionResult Reporte2()
        {
            ViewBag.id_barco = new SelectList(dwh.dim_barcos, "id_barco", "nombre_barco");
            ViewBag.id_viaje = new SelectList(dwh.dim_viajes, "id_viaje", "descripcion_viaje");
            return View();
        }
        [HttpPost]
        public ActionResult Reporte2(string desde, string hasta, string id_barco, string id_viaje, string pasaporte)
        {
            DateTime in_desde = Convert.ToDateTime(desde);
            DateTime in_hasta = Convert.ToDateTime(hasta);
            int in_barco = Convert.ToInt32(id_barco); ;
            int in_viaje = Convert.ToInt32(id_viaje);
            string in_pasaporte = pasaporte.Trim();
            ViewBag.id_barco = new SelectList(dwh.dim_barcos, "id_barco", "nombre_barco", id_barco);
            ViewBag.id_viaje = new SelectList(dwh.dim_viajes, "id_viaje", "descripcion_viaje", id_viaje);
            var respuesta = ObtenerDatosReporte2(in_desde, in_hasta, in_barco, in_viaje, in_pasaporte).ToList();
            return PartialView("ResultsPartialR2", respuesta);
        }

        /***************************************************************************************************************/
        // Reporte 1: Se obtiene cada coincidencia y se guarda en el objeto Reporte1. El objeto Reporte1 es una clase 
        // que tiene la misma cantidad de campos que la Query final, pero todos los datos son convertidos a cadena 
        // String para facilitar la muestra de datos en la vista pracial, haciendo todos las conversiones desde el 
        // Controlador y el Modelo. Luego, cada objeto Reporte1 es cargado a una lista tipada por dicho objeto.
        public List<Reporte1> ObtenerDatosReporte1(int id_barco, int id_viaje, DateTime fecha)
        {
            List<Reporte1> listaDatos = new List<Reporte1>();
            var reporte = (from f in dwh.fact_movimientos
                          join t in dwh.dim_tiempos on f.id_tiempo equals t.id_tiempo
                          join p in dwh.dim_pasajeros on f.id_pasajero equals p.id_pasajero
                          join b in dwh.dim_barcos on f.id_barco equals b.id_barco
                          join r in dwh.dim_recintos on f.id_recinto equals r.id_recinto
                          join v in dwh.dim_viajes on f.id_viaje equals v.id_viaje
                          where t.fecha ==  fecha
                          && b.id_barco == id_barco
                          && v.id_viaje == id_viaje
                          select new 
                          { 
                              fecha = t.fecha, 
                              cantidad_movimientos = f.cantidad_movimientos, 
                              pasaporte = p.pasaporte,
                              nombre_completo = p.nombres+" "+p.apellidos,
                              nombre_barco = b.nombre_barco, 
                              viaje = v.descripcion_viaje,
                              tipo_recinto = r.tipo_recinto, 
                              tipo_ambiente = r.tipo_ambiente, 
                              nombre_recinto = r.nombre_recinto
                          }).ToList();
            
            for (int i = 0; i < reporte.Count; i++)
            {
                Reporte1 r1 = new Reporte1();
                r1.Cantidad_movimientos = reporte[i].cantidad_movimientos.ToString();
                r1.Fecha = reporte[i].fecha.ToShortDateString();
                r1.Nombre_barco = reporte[i].nombre_barco;
                r1.Viaje = reporte[i].viaje;
                r1.Tipo_ambiente = reporte[i].tipo_ambiente;
                r1.Tipo_recinto = reporte[i].tipo_recinto;
                r1.Nombre_recinto = reporte[i].nombre_recinto;
                r1.Pasaporte = reporte[i].pasaporte;
                r1.Nombre_completo = reporte[i].nombre_completo;
                listaDatos.Add(r1);
            }
            return listaDatos;
        }

        // Reporte 2: Este reporte se basa en una Query SQL que contiene una SubQuery en la clausula FROM.
        // Para hacer más secillo el trabajo, al hacer el traspaso de SQL a LINQ C#, esta es dividida
        // en 2 Queries: sub_query (De la clausula FROM) y reporte (Es un select a sub_query y luego se vuelve 
        // a agrupar, agregando los criterios de búsqueda.)
        public List<Reporte2> ObtenerDatosReporte2(DateTime desde,DateTime hasta, int id_barco,int id_viaje,string pasaporte)
        {
            List<Reporte2> listaDatos = new List<Reporte2>();
            var sub_query = (from f in dwh.fact_movimientos
                          join r in dwh.dim_recintos on f.id_recinto equals r.id_recinto
                          join v in dwh.dim_viajes on f.id_viaje equals v.id_viaje
                          join p in dwh.dim_pasajeros on f.id_pasajero equals p.id_pasajero
                          join t in dwh.dim_tiempos on f.id_tiempo equals t.id_tiempo
                          join b in dwh.dim_barcos on f.id_barco equals b.id_barco
                          group new { b, v, p, r, t, f } by new
                          {
                              b.id_barco,
                              v.id_viaje,
                              v.descripcion_viaje,
                              p.pasaporte,
                              pasajero = (p.nombres+ " " + p.apellidos),
                              r.tipo_recinto,
                              r.nombre_recinto,
                              t.fecha,
                              f.cantidad_movimientos
                          }
                              into query_group
                              select new 
                              {
                                  id_barco = query_group.Key.id_barco,
                                  id_viaje = query_group.Key.id_viaje,
                                  viaje = query_group.Key.descripcion_viaje,
                                  pasaporte = query_group.Key.pasaporte,
                                  pasajero = query_group.Key.pasajero,
                                  tipo_recinto = query_group.Key.tipo_recinto,
                                  nombre_recinto = query_group.Key.nombre_recinto,
                                  fecha = query_group.Key.fecha,
                                  movimientos = query_group.Sum(x => x.f.cantidad_movimientos)
                              }).ToList();

            var reporte = (from q in sub_query
                          where (q.fecha >= desde && q.fecha <= hasta)
                          && q.id_barco == id_barco
                          && q.id_viaje == id_viaje
                          && q.pasaporte == pasaporte
                          group q by new
                          {
                              q.viaje,
                              q.pasaporte,
                              q.pasajero,
                              q.tipo_recinto,
                              q.nombre_recinto,
                              q.movimientos
                          }
                              into query_group
                              select new 
                              {
                                  viaje = query_group.Key.viaje,
                                  pasaporte = query_group.Key.pasaporte,
                                  pasajero = query_group.Key.pasajero,
                                  tipo_recinto = query_group.Key.tipo_recinto,
                                  recinto = query_group.Key.nombre_recinto,
                                  maximo = query_group.Max(x => x.movimientos),
                                  minimo = query_group.Min(x => x.movimientos)
                                  
                              }).ToList();
 
            for (int i = 0; i < reporte.Count; i++)
            {
                Reporte2 r2 = new Reporte2();
                r2.Viaje = reporte[i].viaje;
                r2.Pasaporte = reporte[i].pasaporte;
                r2.Pasajero = reporte[i].pasajero;
                r2.Tipo_recinto = reporte[i].tipo_recinto;
                r2.Recinto = reporte[i].recinto;
                r2.Maximo = reporte[i].maximo.ToString();
                r2.Minimo = reporte[i].minimo.ToString();
                listaDatos.Add(r2);   
            }
            
            return listaDatos;
        }
        /***************************************************************************************************************/
    }
}
