using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImagineProject.Models;
//Permite usar Chart
using System.Web.Helpers;
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
        /*
        private static TagBuilder ReturnMessage(string texto)
        {
            var mensaje = new TagBuilder("span");
            mensaje.Attributes.Add("class", "field-validation-error");
            if (!string.IsNullOrEmpty(texto))
            {
                mensaje.SetInnerText(texto);
            }
            return mensaje;
        }
        */
        private static List<Reporte1> reporte1ToExcel { get; set; }
        private static List<Reporte2> reporte2ToExcel { get; set; }
        private static List<Reporte3> reporte3ToExcel { get; set; }
        //private static List<Reporte4> reporte4ToExcel { get; set; }
        private static List<Reporte5> reporte5ToExcel { get; set; }
        private static List<Reporte6> reporte6ToExcel { get; set; }
        private static List<Reporte7> reporte7ToExcel { get; set; }
        private static List<Reporte8> reporte8ToExcel { get; set; }
        private static List<Reporte9> reporte9ToExcel { get; set; }
        private static List<Reporte10> reporte10ToExcel { get; set; }

        // Método que crea gráfico de datos. Ejemplo 1.
        public ActionResult GetGraficoEjemplo1()
        {
            var myChart = new Chart(width: 600, height: 400)
                .AddTitle("Reporte 1")
                .AddSeries(
                    name: "Reporte 1",
                    chartType: "bar",
                    xValue: new[] { "A" },
                    yValues: new[] { "1" })
                .GetBytes("png");
            return File(myChart, "image/png");
        }
        // Método que crea gráfico de datos. Ejemplo 2.
        public ActionResult GetGraficoEjemplo2()
        {
            var myChart = new Chart(width: 600, height: 400)
                .AddTitle("Reporte 1")
                .AddSeries(
                    name: "Reporte 1",
                    chartType: "bar",
                    xValue: new[] { "A" },
                    yValues: new[] { "1" })
                .Write();
            return null;
        }

        public ActionResult GetGraficoRep1()
        {
            // En el DataTable se estabalece el conjunto de datos
            // que será mostrado en el gráfico. Se asigna las columnas.
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Pasaporte", typeof(string));
            dt.Columns.Add("Nombre_recinto", typeof(string));
            dt.Columns.Add("Cantidad_movimientos", typeof(int));

            // Se recibe la Variable estática de datos.
            var datos = reporte1ToExcel;

            //Se llena el DataTable con los valores necesarios desde la lista del reporte.
            foreach (var reg in datos)
            {
                dt.Rows.Add(reg.Pasaporte, reg.Nombre_recinto, reg.Cantidad_movimientos);
            }

            var myChart = new Chart(width: 600, height: 400, theme: ChartTheme.Yellow)
                .AddTitle("Visitas diarias")
                .DataBindCrossTable(dt.Rows, "Pasaporte", "Nombre_recinto", "Cantidad_movimientos", "").Write().GetBytes("png");// "Label=Cantidad_movimientos").Write();

            //return null;
            return File(myChart, "image/png");
        }

        public ActionResult GetGraficoRep5()
        {
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Recinto", typeof(string));
            dt.Columns.Add("Movimientos", typeof(int));

            // Se recibe la Variable estática de datos.
            var datos = reporte5ToExcel.Select(x => new { x.Recinto, x.MaxMov}).ToList();
            var grupo_datos = from d in datos
                              group new { d } by new
                              {
                                  d.Recinto,
                                  d.MaxMov
                              } into grupo
                              select new
                              {
                                  recinto = grupo.Key.Recinto,
                                  movimientos = grupo.Sum(m => m.d.MaxMov)
                              };

            //Se llena el DataTable con los valores necesarios desde la lista del reporte.
            foreach (var reg in datos)
            {
                dt.Rows.Add(reg.Recinto, reg.MaxMov);
            }

            var myChart = new Chart(width: 600, height: 400, theme: ChartTheme.Yellow)
                .AddTitle("Visitas a recintos por horario")
                //.AddSeries(chartType: "Column")
                // Ejemplo this.chart1.DataBindCrossTable(dt.Rows, "Name", "Day", "BugCount", "");
                .AddSeries(
                    name: "Reporte 5",
                    chartType: "Column",
                    xValue: grupo_datos.Select(d => d.recinto).ToArray(),//recinto,
                    yValues: grupo_datos.Select(d => d.movimientos).ToArray())//cant_mov)
                .Write();

            return null;        
        }

        public ActionResult ExportData()
        {
            string number = "";
            string date = DateTime.Now.ToString("yyyyMMddHHmmss");
            string reportName = "";
            System.Web.UI.WebControls.GridView gv = null; 
            gv = new System.Web.UI.WebControls.GridView();

            // Busca el DataSource para el reporte
            if (reporte1ToExcel != null)
            {
                gv.DataSource = reporte1ToExcel;
                number = "1";
            }
            if (reporte2ToExcel != null)
            {
                gv.DataSource = reporte2ToExcel;
                number = "2";
            }
            if (reporte3ToExcel != null)
            {
                gv.DataSource = reporte3ToExcel;
                number = "3";
            }
            // Reporte 4, pendiente
            /*
            if (reporte4ToExcel != null)
            {
                gv.DataSource = reporte4ToExcel;
                number = "4";
            }*/
            if (reporte5ToExcel != null)
            {
                gv.DataSource = reporte5ToExcel;
                number = "5";
            }
            if (reporte6ToExcel != null)
            {
                gv.DataSource = reporte6ToExcel;
                number = "6";
            }
            if (reporte7ToExcel != null)
            {
                gv.DataSource = reporte7ToExcel;
                number = "7";
            }
            if (reporte8ToExcel != null)
            {
                gv.DataSource = reporte8ToExcel;
                number = "8";
            }
            if (reporte9ToExcel != null)
            {
                gv.DataSource = reporte9ToExcel;
                number = "9";
            }
            if (reporte10ToExcel != null)
            {
                gv.DataSource = reporte10ToExcel;
                number = "10";
            }
            // Crea el nombre del reporte
            reportName = "Reporte"+number+"_"+date;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename="+reportName+".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("ResultsPartialR1");
        }
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
            // Se Elimina los datos de una lista anterior
            reporte1ToExcel = null;
            // Declaración e incialización de variables
            DateTime fecha_conv;
            int id_b = 0;
            int id_v = 0;
            try
            {
                if (string.IsNullOrEmpty(id_barco) && string.IsNullOrEmpty(id_viaje) && string.IsNullOrEmpty(fecha))
                    return Content(ObjetosValidacion.Mensaje("Ingrese filtros de búsqueda").ToString());
                if (string.IsNullOrEmpty(id_barco))
                    return Content(ObjetosValidacion.Mensaje("Seleccione barco").ToString());
                else
                    id_b = Convert.ToInt32(id_barco);
                if (string.IsNullOrEmpty(id_viaje))
                    return Content(ObjetosValidacion.Mensaje("Seleccione viaje").ToString());
                else
                    id_v = Convert.ToInt32(id_viaje);
                if (string.IsNullOrEmpty(fecha))
                {
                    return Content(ObjetosValidacion.Mensaje("Ingrese fecha").ToString());
                }

                try
                {
                    fecha_conv = Convert.ToDateTime(fecha);
                }
                catch (FormatException fe)
                {
                    return Content(ObjetosValidacion.Mensaje("Formato fecha inválido").ToString());
                }

                ViewBag.id_barco = new SelectList(dwh.dim_barcos, "id_barco", "nombre_barco", id_barco);
                ViewBag.id_viaje = new SelectList(dwh.dim_viajes, "id_viaje", "descripcion_viaje", id_viaje);

                var respuesta = ObtenerDatosReporte1(id_b, id_v, fecha_conv).ToList();
                // Se llena la lista temporal
                reporte1ToExcel = respuesta.ToList();
                return PartialView("ResultsPartialR1", respuesta);
            }
            catch (Exception ex)
            {
                return Content(ObjetosValidacion.Mensaje("Error inesperado. Favor, intente más tarde."/*+ex.Message*/).ToString());
            }
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
            // Se Elimina los datos de una lista anterior
            reporte2ToExcel = null;
            DateTime in_desde;
            DateTime in_hasta;
            int in_barco = 0;
            int in_viaje = 0;
            try
            {
                if (string.IsNullOrEmpty(desde) && string.IsNullOrEmpty(hasta) && string.IsNullOrEmpty(id_barco) && string.IsNullOrEmpty(id_viaje) && string.IsNullOrEmpty(pasaporte))
                    return Content(ObjetosValidacion.Mensaje("Ingrese filtros de búsqueda").ToString());
                if (string.IsNullOrEmpty(desde))
                    return Content(ObjetosValidacion.Mensaje("Ingrese fecha de inicio").ToString());
                if (string.IsNullOrEmpty(hasta))
                    return Content(ObjetosValidacion.Mensaje("Ingrese fecha de termino").ToString());
                if (string.IsNullOrEmpty(id_barco))
                    return Content(ObjetosValidacion.Mensaje("Seleccione barco").ToString());
                else
                   in_barco = Convert.ToInt32(id_barco); 
                
                if (string.IsNullOrEmpty(id_viaje))
                    return Content(ObjetosValidacion.Mensaje("Seleccione viaje").ToString());
                else
                    in_viaje = Convert.ToInt32(id_viaje);
                if (string.IsNullOrEmpty(pasaporte))
                {
                    return Content(ObjetosValidacion.Mensaje("Ingrese pasaporte").ToString());
                }
                try
                {
                    in_desde = Convert.ToDateTime(desde);
                    in_hasta = Convert.ToDateTime(hasta);
                }
                catch (FormatException fe)
                {
                    return Content(ObjetosValidacion.Mensaje("Formato fecha inválido").ToString());
                }
                string in_pasaporte = pasaporte.Trim();

                ViewBag.id_barco = new SelectList(dwh.dim_barcos, "id_barco", "nombre_barco", id_barco);
                ViewBag.id_viaje = new SelectList(dwh.dim_viajes, "id_viaje", "descripcion_viaje", id_viaje);

                var respuesta = ObtenerDatosReporte2(in_desde, in_hasta, in_barco, in_viaje, in_pasaporte).ToList();
                // Se llena la lista temporal
                reporte2ToExcel = respuesta.ToList();
                return PartialView("ResultsPartialR2", respuesta);
            }
            catch (Exception ex)
            {
                return Content(ObjetosValidacion.Mensaje("Error inesperado. Favor, intente más tarde."/*+ex.Message*/).ToString());
            }
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
            // Se Elimina los datos de una lista anterior
            reporte3ToExcel = null;
            try
            {
                if (string.IsNullOrEmpty(linea_naviera))
                {
                    return Content(ObjetosValidacion.Mensaje("Seleccione línea naviera.").ToString());
                }

                var linea = (from ba in dwh.dim_barcos select new { linea_naviera = ba.linea_naviera }).Distinct();
                ViewBag.linea_naviera = new SelectList(linea, "linea_naviera", "linea_naviera", linea_naviera);

                var respuesta3 = ObtenerDatosReporte3(linea_naviera).ToList();
                // Se llena la lista temporal
                reporte3ToExcel = respuesta3.ToList();

                return PartialView("ResultsPartialR3", respuesta3);
            }
            catch (Exception ex)
            {
                return Content(ObjetosValidacion.Mensaje("Error inesperado. Favor, intente más tarde."/*+ex.Message*/).ToString());
            }
        }

        // REPORTE5 --------------------------------------------------------------------------
        public ActionResult Reporte5()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reporte5(string desde, string hasta)
        {
            // Se Elimina los datos de una lista anterior
            reporte5ToExcel = null;
            DateTime fecha_desde;
            DateTime fecha_hasta;

            try
            {
                if (string.IsNullOrEmpty(desde) && string.IsNullOrEmpty(hasta))
                    return Content(ObjetosValidacion.Mensaje("Ingrese filtros de búsqueda").ToString());
                if (string.IsNullOrEmpty(desde))
                    return Content(ObjetosValidacion.Mensaje("Ingrese fecha de inicio").ToString());
                if (string.IsNullOrEmpty(hasta))
                {
                    return Content(ObjetosValidacion.Mensaje("Ingrese fecha de termino").ToString());
                }
                try
                {
                    fecha_desde = Convert.ToDateTime(desde);
                    fecha_hasta = Convert.ToDateTime(hasta);
                }
                catch (FormatException fe)
                {
                    return Content(ObjetosValidacion.Mensaje("Formato fecha inválido").ToString());
                }
                var respuesta = ObtenerDatosReporte5(fecha_desde, fecha_hasta);
                // Se llena la lista temporal
                reporte5ToExcel = respuesta.ToList();

                return PartialView("ResultsPartialR5", respuesta);
            }
            catch (Exception ex)
            {
                return Content(ObjetosValidacion.Mensaje("Error inesperado. Favor, intente más tarde."/*+ex.Message*/).ToString());
            }
        }

        // REPORTE6 --------------------------------------------------------------------------
        public ActionResult Reporte6()
        {
            var linea = (from ba in dwh.dim_barcos select new { linea_naviera = ba.linea_naviera }).Distinct();
            ViewBag.linea_naviera = new SelectList(linea, "linea_naviera", "linea_naviera");
            return View();
        }
        [HttpPost]
        public ActionResult Reporte6(string linea_naviera)
        {
            // Se Elimina los datos de una lista anterior
            reporte6ToExcel = null;
            try
            {
                if (string.IsNullOrEmpty(linea_naviera))
                {
                    return Content(ObjetosValidacion.Mensaje("Seleccione línea naviera.").ToString());
                }

                var linea = (from ba in dwh.dim_barcos select new { linea_naviera = ba.linea_naviera }).Distinct();
                ViewBag.linea_naviera = new SelectList(linea, "linea_naviera", "linea_naviera", linea_naviera);

                var respuesta6 = ObtenerDatosReporte6(linea_naviera).ToList();
                // Se llena la lista temporal
                reporte6ToExcel = respuesta6.ToList();
                return PartialView("ResultsPartialR6", respuesta6);
            }
            catch (Exception ex)
            {
                return Content(ObjetosValidacion.Mensaje("Error inesperado. Favor, intente más tarde."/*+ex.Message*/).ToString());
            }
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
            // Se Elimina los dartos de una lista anterior
            reporte7ToExcel = null;
            int linea_nav = 0;
            int anioD = 0;
            int anioH = 0;
            try
            {
                if (string.IsNullOrEmpty(linea_naviera) && string.IsNullOrEmpty(anio1) && string.IsNullOrEmpty(anio2))
                    return Content(ObjetosValidacion.Mensaje("Ingrese filtros de búsqueda.").ToString());
                if (string.IsNullOrEmpty(linea_naviera))
                    return Content(ObjetosValidacion.Mensaje("Seleccione línea naviera.").ToString());
                else
                    linea_nav = Convert.ToInt32(linea_naviera);
                if (string.IsNullOrEmpty(anio1))
                    return Content(ObjetosValidacion.Mensaje("Ingrese año inicio.").ToString());
                if (string.IsNullOrEmpty(anio2))
                {
                    return Content(ObjetosValidacion.Mensaje("Ingrese año fin.").ToString());
                }

                try
                {
                    anioD = Convert.ToInt32(anio1);
                    anioH = Convert.ToInt32(anio2);
                }
                catch (FormatException fe)
                {
                    return Content(ObjetosValidacion.Mensaje("Formato año inválido").ToString());
                }
                ViewBag.linea_naviera = new SelectList(bd.LineasNavieras, "id_linea_naviera", "linea_naviera", linea_naviera);

                var respuesta7 = ObtenerDatosReporte7(linea_nav, anioD, anioH).ToList();
                // Se llena la lista temporal
                reporte7ToExcel = respuesta7.ToList();
                return PartialView("ResultsPartialR7", respuesta7);
            }
            catch (Exception ex)
            {
                return Content(ObjetosValidacion.Mensaje("Error inesperado. Favor, intente más tarde."/*+ex.Message*/).ToString());
            }
        }

        // REPORTE8 --------------------------------------------------------------------------
        public ActionResult Reporte8()
        {
            var linea = (from ba in dwh.dim_barcos
                         select new
                         {
                             linea_naviera = ba.linea_naviera
                         }).Distinct();
            ViewBag.linea_naviera = new SelectList(linea, "linea_naviera", "linea_naviera");
            return View();
        }

        [HttpPost]
        public ActionResult Reporte8(string linea_naviera, string anio)
        {
            // Se Elimina los dartos de una lista anterior
            reporte8ToExcel = null;
            string linea_nav;
            int anio1 = 0;
            try
            {
                if (string.IsNullOrEmpty(linea_naviera) && string.IsNullOrEmpty(anio))
                    return Content(ObjetosValidacion.Mensaje("Ingrese filtros de búsqueda.").ToString());
                if (string.IsNullOrEmpty(linea_naviera))
                    return Content(ObjetosValidacion.Mensaje("Seleccione línea naviera.").ToString());
                else
                    linea_nav = linea_naviera;
                if (string.IsNullOrEmpty(anio))
                {
                    return Content(ObjetosValidacion.Mensaje("Ingrese año.").ToString());
                }
                try
                {
                    anio1 = Convert.ToInt32(anio.Trim());
                }
                catch (FormatException fe) //OverFlowException
                {
                    return Content(ObjetosValidacion.Mensaje("Formato año inválido.").ToString());
                }

                var linea = (from ba in dwh.dim_barcos select new { linea_naviera = ba.linea_naviera }).Distinct();
                ViewBag.linea_naviera = new SelectList(linea, "linea_naviera", "linea_naviera", linea_naviera);

                var respuesta8 = ObtenerDatosReporte8(linea_nav, anio1).ToList();
                // Se llena la lista temporal
                reporte8ToExcel = respuesta8.ToList();
                return PartialView("ResultsPartialR8", respuesta8);
            }
            catch (Exception ex)
            {
                return Content(ObjetosValidacion.Mensaje("Error inesperado. Favor, intente más tarde."/*+ex.Message*/).ToString());
            }
        }

        // REPORTE9 --------------------------------------------------------------------------
        public ActionResult Reporte9()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reporte9(string linea_naviera)
        {
            // Se Elimina los dartos de una lista anterior
            reporte9ToExcel = null;
            try
            {
                var respuesta9 = ObtenerDatosReporte9().ToList();
                // Se llena la lista temporal
                reporte9ToExcel = respuesta9.ToList();
                return PartialView("ResultsPartialR9", respuesta9);
            }
            catch (Exception ex)
            {
                return Content(ObjetosValidacion.Mensaje("Error inesperado. Favor, intente más tarde."/*+ex.Message*/).ToString());
            }
        }

        // REPORTE10 --------------------------------------------------------------------------
        public ActionResult Reporte10()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reporte10(string anio1, string anio2)
        {
            // Se Elimina los dartos de una lista anterior
            reporte10ToExcel = null;
            int anio_desde = 0;
            int anio_hasta = 0;
            try
            {
                if (string.IsNullOrEmpty(anio1) && string.IsNullOrEmpty(anio2))
                    return Content(ObjetosValidacion.Mensaje("Ingrese filtros de búsqueda.").ToString());
                if (string.IsNullOrEmpty(anio1))
                    return Content(ObjetosValidacion.Mensaje("Ingres año inicio.").ToString());
                if (string.IsNullOrEmpty(anio2))
                {
                    return Content(ObjetosValidacion.Mensaje("Ingrese año fin.").ToString());
                }

                try
                {
                    anio_desde = Convert.ToInt32(anio1);
                    anio_hasta = Convert.ToInt32(anio2);
                }
                catch (FormatException fe)
                {
                    return Content(ObjetosValidacion.Mensaje("Formato año inválido.").ToString());                
                }

                var respuesta10 = ObtenerDatosReporte10(anio_desde, anio_hasta).ToList();
                // Se llena la lista temporal
                reporte10ToExcel = respuesta10.ToList();

                return PartialView("ResultsPartialR10", respuesta10);
            }
            catch (Exception ex)
            {
                return Content(ObjetosValidacion.Mensaje("Error inesperado. Favor, intente más tarde."/*+ex.Message*/).ToString());
            }
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
                                   barco = query_group.Key.nombre_barco,
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
                               fecha = query_group.Key.fecha.Date,
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
                r5.Fecha = rep.fecha.ToShortDateString();
                r5.Hora = rep.hora.ToString();
                r5.MinMov = rep.min_mov;
                r5.MaxMov = rep.max_mov;
                listaDatos.Add(r5);
            }

            return listaDatos;
        }

        /***************************************************************************************************************/
        /***************************************************************************************************************/
        // Reporte 6
        public List<Reporte6> ObtenerDatosReporte6(string linea_naviera)
        {
            List<Reporte6> listaDatos = new List<Reporte6>();

            var sub_query6 = (from factm in dwh.fact_movimientos
                              select new
                              {
                                  id_pasajero = factm.id_pasajero,
                                  id_barco = factm.id_barco,
                                  id_viaje = factm.id_viaje
                              }).Distinct();

            var reporte6 = (from pjos in dwh.dim_pasajeros
                            join match in sub_query6 on pjos.id_pasajero equals match.id_pasajero
                            join bar in dwh.dim_barcos on match.id_barco equals bar.id_barco
                            join via in dwh.dim_viajes on match.id_viaje equals via.id_viaje
                            where bar.linea_naviera.Equals(linea_naviera)
                            group new { bar, via, pjos, match } by new
                            {
                                bar.nombre_barco,
                                via.descripcion_viaje,
                                via.fecha_salida,
                                bar.capacidad
                            } into grupo6
                            select new
                            {
                                nom_barco = grupo6.Key.nombre_barco,
                                desc_viaje = grupo6.Key.descripcion_viaje,
                                fecha_salida = grupo6.Key.fecha_salida,
                                capacidad = grupo6.Key.capacidad,
                                q_pasajeros = grupo6.Select(x => x.pjos.id_pasajero).Count(),
                                porc = ((grupo6.Select(x => x.pjos.id_pasajero).Count() * 100.0) / grupo6.Key.capacidad)
                            }).ToList();

            for (int i = 0; i < reporte6.Count; i++)
            {
                Reporte6 r6 = new Reporte6();
                r6.Nombre_Barco = reporte6[i].nom_barco.ToString();
                r6.Descripcion_Viaje = reporte6[i].desc_viaje;
                r6.Fecha_Salida = reporte6[i].fecha_salida.ToShortDateString();
                r6.Capacidad = reporte6[i].capacidad.ToString();
                r6.Cant_Pasajeros = reporte6[i].q_pasajeros.ToString();
                r6.Porcentaje = reporte6[i].porc.ToString();
                listaDatos.Add(r6);
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

        /***************************************************************************************************************/
        // Reporte 9
        //FALTA AGREGAR EN EL WHERE DE LA SUB_SUB_QUERY9 QUE LA FECHA DE SALIDA SEA IGUAL A 1 AÑO
        public List<Reporte9> ObtenerDatosReporte9()
        {
            List<Reporte9> listaDatos = new List<Reporte9>();
            DateTime now = new DateTime((DateTime.Now.Year-1), DateTime.Now.Month, DateTime.Now.Day);
            var sub_query9 = (from f in dwh.fact_movimientos
                              select new 
                              {
                                  id_viaje = f.id_viaje,
                                  id_pasajero = f.id_pasajero
                              }).Distinct();

            var sub_sub_query9 = (from v in dwh.dim_viajes
                               join m in sub_query9 on v.id_viaje equals m.id_viaje
                               //where v.id_viaje == m.id_viaje
                               where (v.fecha_salida >= now)
                               select m);

            var reporte9 = (from pjo in dwh.dim_pasajeros
                            where !(sub_sub_query9).Any(s => s.id_pasajero == pjo.id_pasajero) //(sub_sub_query9).AsEnumerable().Any() 
                            group new { pjo } by new
                            {
                                pjo.pasaporte,
                                pjo.nombres,
                                pjo.apellidos,
                                pjo.fecha_registro,
                                pjo.e_mail
                            } into grupo9
                            select new
                            {
                                pasaporte = grupo9.Key.pasaporte,
                                nombre_completo = grupo9.Key.nombres + " " + grupo9.Key.apellidos,
                                fecha_registro = grupo9.Key.fecha_registro,
                                email = grupo9.Key.e_mail
                            }).ToList();


            for (int i = 0; i < reporte9.Count; i++)
            {
                Reporte9 r9 = new Reporte9();
                r9.Pasaporte = reporte9[i].pasaporte;
                r9.Nombre_Completo = reporte9[i].nombre_completo;
                r9.Fecha_Registro = reporte9[i].fecha_registro.ToString();
                r9.Email = reporte9[i].email;
                listaDatos.Add(r9);
            }
            return listaDatos;

        }

        /***************************************************************************************************************/
        // Reporte 10
        public List<Reporte10> ObtenerDatosReporte10(int anio1, int anio2)
        {
            List<Reporte10> listaDatos = new List<Reporte10>();
            var sub_query10 = (from f in dwh.fact_movimientos
                               select new
                               {
                                   id_barco = f.id_barco,
                                   id_pasajero = f.id_pasajero,
                                   id_viaje = f.id_viaje
                               }).Distinct();
            var reporte10 = (from m in sub_query10
                             join pjo in dwh.dim_pasajeros on m.id_pasajero equals pjo.id_pasajero
                             join v in dwh.dim_viajes on m.id_viaje equals v.id_viaje
                             where (v.fecha_llegada.Year >= anio1 && v.fecha_llegada.Year <= anio2) || 
                             (v.fecha_salida.Year >= anio1 && v.fecha_salida.Year <= anio2)
                             group new { v, pjo } by new
                             {
                                 v.fecha_salida,
                                 v.puerto_destino,
                                 pjo.pasaporte,
                                 pjo.nombres,
                                 pjo.apellidos
                             } into grupo10
                             orderby grupo10.Key.fecha_salida.Year ascending //nose si funciona
                             select new
                             {
                                 anio = grupo10.Key.fecha_salida.Year,
                                 cantidad_viajes = grupo10.Select(x => x.v.id_viaje).Count(),
                                 puerto_destino = grupo10.Key.puerto_destino,
                                 pasaporte = grupo10.Key.pasaporte,
                                 pasajero = grupo10.Key.nombres + " " + grupo10.Key.apellidos
                             }).ToList();


            for (int i = 0; i < reporte10.Count; i++)
            {
                Reporte10 r10 = new Reporte10();
                r10.Anio = reporte10[i].anio.ToString();
                r10.Cantidad_Viaje = reporte10[i].cantidad_viajes.ToString();
                r10.Puerto_Destino = reporte10[i].puerto_destino;
                r10.Pasaporte = reporte10[i].pasaporte;
                r10.Nombre_Completo = reporte10[i].pasajero;
                listaDatos.Add(r10);
            }
            return listaDatos;
        }
    }
}
