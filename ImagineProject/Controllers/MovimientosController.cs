using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImagineProject.Models;
using System.Web.Helpers;

namespace ImagineProject.Controllers
{
    public class MovimientosController : Controller
    {
        private Db_ImagineEntities bd = new Db_ImagineEntities();

        private static List<MovimientosTR> MovimientoToExcel { get; set; }

        public ActionResult ExportData()
        {
            //string number = "";
            string date = DateTime.Now.ToString("yyyyMMddHHmmss");
            string reportName = "";
            System.Web.UI.WebControls.GridView gv = null;
            gv = new System.Web.UI.WebControls.GridView();

            // Busca el DataSource para el reporte
            if (MovimientoToExcel != null)
            {
                gv.DataSource = MovimientoToExcel;
            }

            // Crea el nombre del reporte
            reportName = "Movimientos_"+ date;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + reportName + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("ResultsPartialM1");
        }

        public ActionResult GetGraficoMovimientos()
        {
            // En el DataTable se estabalece el conjunto de datos
            // que será mostrado en el gráfico. Se asigna las columnas.
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Recinto", typeof(string));
            dt.Columns.Add("Visitas", typeof(int));
            //dt.Columns.Add("Cantidad_movimientos", typeof(int));

            // Se recibe la Variable estática de datos.
            var datos = MovimientoToExcel.Select(x => new { Recinto = x.Recinto, Visitas = x.Visitas }).ToList();
            var grupo_datos = from d in datos
                              group new { d } by new
                              {
                                d.Visitas,
                                d.Recinto
                              } into grupo
                              select new 
                              {
                                recinto = grupo.Key.Recinto,
                                visitas = grupo.Sum(m => m.d.Visitas)                                                                                                                                                                                  
                              };

            var myChart = new Chart(width: 600, height: 400)//, theme: ChartTheme.Yellow)
                .AddTitle("Visitas en tiempo real")               
                .AddSeries(
                    name: "Visitas en tiempo real",
                    chartType: "Column",
                    xValue: grupo_datos.Select(d => d.recinto).ToArray(),//recinto,
                    yValues: grupo_datos.Select(d => d.visitas).ToArray())//cant_mov)
                .Write();
                
            return null;
        }
        //---------------------------------------------------------------------------------
        public ActionResult Movimientos1()
        {
            ViewBag.id_viaje = new SelectList(bd.Viajes, "id_viaje", "descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Movimientos1(string id_viaje)
        {
            MovimientoToExcel = null;

            if(string.IsNullOrEmpty(id_viaje))
            {
                return Content(ObjetosHelpers.Mensaje("Seleccione viaje").ToString());
            }

            int id_v = Convert.ToInt32(id_viaje);
            ViewBag.id_viaje = new SelectList(bd.Viajes, "id_viaje", "descripcion", id_viaje);

            var respuesta = ObtenerDatosMovimientos1(id_v).ToList();
            // Se llena la lista temporal
            MovimientoToExcel = respuesta.ToList();
            return PartialView("ResultsPartialM1", respuesta);
        }

        public List<MovimientosTR> ObtenerDatosMovimientos1(int id_viaje)
        {
            List<MovimientosTR> listaDatos = new List<MovimientosTR>();
            DateTime fecha_actual = DateTime.Now;
            DateTime fecha_resta = fecha_actual.AddMinutes(-2);
            //short tipo_movimiento = 2;

            var query_not_in = (from m in bd.Movimientos select m);
            var movimiento = (from mo in bd.Movimientos
                              join tm in bd.TiposMovimientos on mo.id_tipo_movimiento equals tm.id_tipo_movimiento
                              join po in bd.Porticos on mo.id_portico equals po.id_portico
                              join rp in bd.RecintoPorticos on po.id_portico equals rp.id_portico
                              join re in bd.Recintos on rp.id_recinto equals re.id_recinto
                              join tr in bd.TiposRecintos on re.id_tipo_recinto equals tr.id_tipo_recinto
                              join ta in bd.TiposAmbientes on re.id_tipo_ambiente equals ta.id_tipo_ambiente
                              join ba in bd.Barcos on re.id_barco equals ba.id_barco
                              join vi in bd.Viajes on ba.id_barco equals vi.id_viaje
                              where (vi.id_viaje == id_viaje) &&
                              (mo.fecha_hora >= fecha_resta && mo.fecha_hora <= fecha_actual) &&
                              (mo.id_tipo_movimiento == 1) // Movimiento de entrada
                              && 
                              !(from m in bd.Movimientos select m).Any(m => 
                                        (m.fecha_hora > mo.fecha_hora) &&
                                        (m.id_movimiento > mo.id_movimiento) &&
                                        (m.id_tipo_movimiento == 2) && // Movimiento de salida
                                        (m.id_portico == mo.id_portico) &&
                                        (m.id_tag == mo.id_tag) ) //Subquery equivalente a Not Exists
                              group new { tr, ta, re, tm, mo } by new
                              {
                                  mo.fecha_hora,
                                  tr.tipo_recinto,
                                  ta.tipo_ambiente,
                                  re.nombre_recinto
                                  //mo.id_tag
                              } into grupoM
                              orderby grupoM.Key.fecha_hora descending, grupoM.Key.tipo_recinto, grupoM.Key.tipo_ambiente, grupoM.Key.nombre_recinto
                              select new
                              {
                                  fechaHora = grupoM.Key.fecha_hora,
                                  tipoRecinto = grupoM.Key.tipo_recinto,
                                  tipoAmbiente = grupoM.Key.tipo_ambiente,
                                  recinto = grupoM.Key.nombre_recinto,
                                  visitas = grupoM.Select(x => x.mo.id_tag).Count()
                              }).ToList();
            

            for (int i = 0; i < movimiento.Count; i++)
            {
                MovimientosTR m1 = new MovimientosTR();
                m1.Fecha_hora = movimiento[i].fechaHora;
                m1.Tipo_Recinto = movimiento[i].tipoRecinto;
                m1.Tipo_Ambiente = movimiento[i].tipoAmbiente;
                m1.Recinto = movimiento[i].recinto;
                m1.Visitas = movimiento[i].visitas;
                listaDatos.Add(m1);
            }
            return listaDatos;
        }

    }
}
