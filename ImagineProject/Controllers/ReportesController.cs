﻿using System;
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
        private DWH_ImagineEntities dwh = new DWH_ImagineEntities();
        private Db_ImagineEntities bd = new Db_ImagineEntities();
        
        
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
            if (id_barco == null || id_barco == "")
            {
                return Content("Seleccione barco");
            }
            if (id_viaje == null || id_viaje == "")
            {
                return Content("Seleccione viaje");
            }
            if (fecha == null || fecha == "")
            {
                return Content("Ingrese fecha");
            }


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

        // REPORTE3 --------------------------------------------------------------------------
        public ActionResult Reporte3()
        {
            var linea = (from ba in dwh.dim_barcos select new { linea_naviera = ba.linea_naviera } ).Distinct();
            ViewBag.linea_naviera = new SelectList(linea, "linea_naviera", "linea_naviera");
            return View();
        }

        [HttpPost]
        public ActionResult Reporte3(string linea_naviera)
        {
            var linea = (from ba in dwh.dim_barcos select new { linea_naviera = ba.linea_naviera }).Distinct();
            ViewBag.linea_naviera = new SelectList(linea, "linea_naviera", "linea_naviera", linea_naviera);

            var respuesta3 = ObtenerDatosReporte3(linea_naviera).ToList();
            return PartialView("ResultsPartialR3", respuesta3);
        }

        // REPORTE5 --------------------------------------------------------------------------
        public ActionResult Reporte5()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reporte5(string desde, string hasta)
        {
            var respuesta = ObtenerDatosReporte5(Convert.ToDateTime(desde), Convert.ToDateTime(hasta));
            return PartialView("ResultsPartialR5", respuesta);
        }

        // REPORTE7 --------------------------------------------------------------------------
        public ActionResult Reporte7()
        {
            ViewBag.linea_naviera = new SelectList(bd.LineasNavieras, "id_linea_naviera", "linea_naviera");
            return View();
        }

        [HttpPost]
        public ActionResult Reporte7(string linea_naviera, string anio1, string anio2)
        {
            int linea_nav = Convert.ToInt32(linea_naviera);
            int anioD = Convert.ToInt32(anio1);
            int anioH = Convert.ToInt32(anio2);

            ViewBag.linea_naviera = new SelectList(bd.LineasNavieras, "id_linea_naviera", "linea_naviera", linea_naviera);

            var respuesta7 = ObtenerDatosReporte7(linea_nav, anioD, anioH).ToList();
            return PartialView("ResultsPartialR7", respuesta7);
        }

        // REPORTE8 --------------------------------------------------------------------------
        public ActionResult Reporte8()
        {
            var linea = (from ba in dwh.dim_barcos
                         select new
                         {
                             linea_naviera = ba.linea_naviera
                         }).Distinct();
            //ViewBag.linea_naviera = new SelectList(dwh.dim_barcos.Distinct(), "linea_naviera", "linea_naviera");
            ViewBag.linea_naviera = new SelectList(linea, "linea_naviera", "linea_naviera");
            return View();
        }

        [HttpPost]
        public ActionResult Reporte8(string linea_naviera, string anio)
        {
            string linea_nav = linea_naviera;
            int anio1 = Convert.ToInt32(anio.Trim());
            var linea = (from ba in dwh.dim_barcos select new { linea_naviera = ba.linea_naviera }).Distinct();
            ViewBag.linea_naviera = new SelectList(linea, "linea_naviera", "linea_naviera", linea_naviera);

            var respuesta8 = ObtenerDatosReporte8(linea_nav, anio1).ToList();
            return PartialView("ResultsPartialR8", respuesta8);
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
        
        /***************************************************************************************************************/
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
        // Reporte 3:
        public List<Reporte3> ObtenerDatosReporte3(string linea_naviera)
        {
            List<Reporte3> listaDatos = new List<Reporte3>();
            var query = (from pjo in dwh.dim_pasajeros
                         join pje in dwh.dim_pasajes
                            on pjo.id_pasajero equals pje.id_pasajero
                         join vi in dwh.dim_viajes
                            on pje.id_viaje equals vi.id_viaje
                         join fm in
                             ((from f in dwh.fact_movimientos
                               select new
                               {
                                   f.id_barco,
                                   f.id_viaje,
                                   f.id_pasajero,
                                   f.id_tiempo
                               }).Distinct())
                            on new { pjo.id_pasajero, vi.id_viaje } equals new { fm.id_pasajero, fm.id_viaje }
                         join ba in dwh.dim_barcos
                            on fm.id_barco equals ba.id_barco
                         join ti in dwh.dim_tiempos
                            on fm.id_tiempo equals ti.id_tiempo
                         orderby ti.anio ascending, pjo.pasaporte ascending, pje.tipo_pasaje ascending
                         where ba.linea_naviera == linea_naviera
                         group new { ti, pjo, pje } by
                         new
                         {
                             ti.anio,
                             pjo.pasaporte,
                             pasajero = pjo.nombres + " " + pjo.apellidos,
                             pje.tipo_pasaje,
                             pje.id_pasaje
                         } into q_group
                         select new
                         {
                             anio = q_group.Key.anio,
                             pasaporte = q_group.Key.pasaporte,
                             pasajero = q_group.Key.pasajero,
                             tipo_pasaje = q_group.Key.tipo_pasaje,
                             cant_pasajes = q_group.Select(x => x.pje.id_pasaje).Count()
                         }).ToList();
            foreach (var rep in query)
            {
                Reporte3 r3 = new Reporte3();
                r3.Anio = rep.anio.ToString();
                r3.Pasaporte = rep.pasaporte;
                r3.Pasajero = rep.pasajero;
                r3.Tipo_pasaje = rep.tipo_pasaje;
                r3.Cant_pasajes = rep.cant_pasajes.ToString();
                listaDatos.Add(r3);
            }
            return listaDatos;
        }

        /***************************************************************************************************************/
        // Reporte 5:
        public List<Reporte5> ObtenerDatosReporte5(DateTime desde, DateTime hasta)
        { 
            List<Reporte5> listaDatos = new List<Reporte5>();
            var sub_query = (from mo in bd.Movimientos
                             join po in bd.Porticos on mo.id_portico equals po.id_portico
                             join rp in bd.RecintoPorticos on po.id_portico equals rp.id_portico
                             join re in bd.Recintos on rp.id_recinto equals re.id_recinto
                             join tr in bd.TiposRecintos on re.id_tipo_recinto equals tr.id_tipo_recinto
                             join ta in bd.TiposAmbientes on re.id_tipo_ambiente equals ta.id_tipo_ambiente
                             join ba in bd.Barcos on re.id_barco equals ba.id_barco
                             group new { mo, po, rp, re, tr, ta, ba } by new
                             {
                                 ba.nombre_barco,
                                 tr.tipo_recinto,
                                 ta.tipo_ambiente,
                                 re.nombre_recinto,
                                 mo.fecha,
                                 mo.hora,
                                 mo.id_movimiento
                             } into query_group
                               select new 
                               { 
                                   barco = query_group.Key.nombre_recinto,
	                               tipo_recinto = query_group.Key.tipo_recinto,
	                               tipo_ambiente = query_group.Key.tipo_ambiente,
	                               recinto = query_group.Key.nombre_recinto,
	                               fecha = query_group.Key.fecha,
	                               hora = query_group.Key.hora.Hours,
	                               cantidad_movimentos = query_group.Select(x => x.mo.id_movimiento).Count()
                               }).ToList();

            var reporte = (from q in sub_query
                          where q.fecha >= desde && q.fecha <= hasta
                          group q by new
                          {
                              q.barco,
                              q.tipo_recinto,
                              q.tipo_ambiente,
                              q.recinto,
                              q.fecha,
                              q.hora,
                              q.cantidad_movimentos
                          } into query_group
                          select new 
                          { 
                               barco = query_group.Key.barco,
                               tipo_recinto = query_group.Key.tipo_recinto,
                               tipo_ambiente = query_group.Key.tipo_ambiente,
                               recinto = query_group.Key.recinto,
                               fecha = query_group.Key.fecha,
                               hora = query_group.Key.hora,
                               min_mov = query_group.Min(x => x.cantidad_movimentos),
                               max_mov = query_group.Max(x => x.cantidad_movimentos)
                          }).ToList();

            foreach (var rep in reporte)
            {
                Reporte5 r5 = new Reporte5();
                r5.Barco = rep.barco;
                r5.TipoRecinto = rep.tipo_recinto;
                r5.TipoAmbiente = rep.tipo_ambiente;
                r5.Recinto = rep.recinto;
                r5.Fecha = rep.fecha.ToString();
                r5.Hora = rep.hora.ToString();
                r5.MinMov = rep.min_mov.ToString();
                r5.MaxMov = rep.max_mov.ToString();
                listaDatos.Add(r5);
            }

            return listaDatos;
        }

        /***************************************************************************************************************/
        // Reporte 7
        public List<Reporte7> ObtenerDatosReporte7(int linea_naviera, int anio1, int anio2)
        {
            List<Reporte7> listaDatos = new List<Reporte7>();
            var reporte7 = (from via in bd.Viajes
                            join bar in bd.Barcos on via.id_barco equals bar.id_barco
                            where (via.fecha_salida.Year >= anio1
                            && via.fecha_salida.Year <= anio2)
                            && bar.id_linea_naviera == linea_naviera
                            group new { bar, via } by new
                            {
                                bar.nombre_barco,
                                via.descripcion,
                                via.id_viaje
                            } into grupo7
                            select new
                            {
                                nombre_barco = grupo7.Key.nombre_barco,
                                desc_viaje = grupo7.Key.descripcion,
                                viajes = grupo7.Select(x => x.via.id_viaje).Count()
                            }).ToList();

            for (int i = 0; i < reporte7.Count; i++)
            {
                Reporte7 r7 = new Reporte7();
                r7.Nombre_Barco = reporte7[i].nombre_barco;
                r7.Descripcion = reporte7[i].desc_viaje;
                r7.Viajes = reporte7[i].viajes.ToString();
                listaDatos.Add(r7);
            }
            return listaDatos;
        }

        /***************************************************************************************************************/
        // Reporte 8
        public List<Reporte8> ObtenerDatosReporte8(string linea_naviera, int anio)
        {
            List<Reporte8> listaDatos = new List<Reporte8>();
            var reporte8 = (from pjo in dwh.dim_pasajeros
                            join pje in dwh.dim_pasajes on pjo.id_pasajero equals pje.id_pasajero
                            join vi in dwh.dim_viajes on pje.id_viaje equals vi.id_viaje
                            join mo in
                                ((from b in dwh.dim_barcos
                                  join m in dwh.fact_movimientos on b.id_barco equals m.id_barco
                                  select new
                                  {
                                      id_barco = b.id_barco,
                                      linea_nav = b.linea_naviera,
                                      id_viaje = m.id_viaje
                                  }).Distinct()) on vi.id_viaje equals mo.id_viaje
                            where mo.linea_nav == linea_naviera
                            && (vi.fecha_salida.Year == anio
                            || vi.fecha_llegada.Year == anio)
                            group new { pjo, pje, vi } by new
                            {
                                pjo.pasaporte,
                                pjo.nombres,
                                pjo.apellidos,
                                pje.tipo_pasaje,
                                vi.id_viaje
                            } into grupo8
                            select new
                            {
                                pasaporte = grupo8.Key.pasaporte,
                                nombre_completo = grupo8.Key.nombres + " " + grupo8.Key.apellidos,
                                tipo_pasaje = grupo8.Key.tipo_pasaje,
                                cantidad_viajes = grupo8.Select(x => x.vi.id_viaje).Count()
                            }).ToList();

            for (int i = 0; i < reporte8.Count; i++)
            {
                Reporte8 r8 = new Reporte8();
                r8.Pasaporte = reporte8[i].pasaporte.ToString();
                r8.Nombre_completo = reporte8[i].nombre_completo.ToString();
                r8.Tipo_pasaje = reporte8[i].tipo_pasaje.ToString();
                r8.Cantidad_viajes = reporte8[i].cantidad_viajes.ToString();
                listaDatos.Add(r8);
            }
            return listaDatos;
        }
    }
}
