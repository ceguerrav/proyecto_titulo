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
            dt.Columns.Add("Cant_Movimientos", typeof(int));
            //dt.Columns.Add("Cantidad_movimientos", typeof(int));

            // Se recibe la Variable estática de datos.
            var datos = MovimientoToExcel.Select(x => new { x.Recinto, x.Cant_Movimientos }).ToList();
            var grupo_datos = from d in datos
                              group new { d } by new
                              {
                                d.Cant_Movimientos,
                                d.Recinto
                              } into grupo
                              select new 
                              {
                                recinto = grupo.Key.Recinto,
                                movimientos = grupo.Sum(m => m.d.Cant_Movimientos) //grupo.Select(m => m.d.Cant_Movimientos).Sum() //                                                                                                                                                                                    
                              };

            var myChart = new Chart(width: 600, height: 400)//, theme: ChartTheme.Yellow)
                .AddTitle("Movimientos en tiempo real")
                //.AddSeries(chartType: "Column")
                // Ejemplo this.chart1.DataBindCrossTable(dt.Rows, "Name", "Day", "BugCount", "");
                //.DataBindCrossTable(dt.Rows,"Recinto", "Cantidad_movimientos", "").Write();// "Label=Cantidad_movimientos").Write();
                //.DataBindTable(dt.Rows, "Recinto").Write();
                
                .AddSeries(
                    name: "Reporte 1",
                    chartType: "Column",
                    xValue: grupo_datos.Select(d => d.recinto).ToArray(),//recinto,
                    yValues: grupo_datos.Select(d => d.movimientos).ToArray())//cant_mov)
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
            //if (id_viaje == null || id_viaje == "")
            //{
            //    return Content("Seleccione viaje");
            //}
            MovimientoToExcel = null;

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

            var movimiento = (from mo in bd.Movimientos
                              join tm in bd.TiposMovimientos on mo.id_tipo_movimiento equals tm.id_tipo_movimiento
                              join po in bd.Porticos on mo.id_portico equals po.id_portico
                              join rp in bd.RecintoPorticos on po.id_portico equals rp.id_portico
                              join re in bd.Recintos on rp.id_recinto equals re.id_recinto
                              join tr in bd.TiposRecintos on re.id_tipo_recinto equals tr.id_tipo_recinto
                              join ta in bd.TiposAmbientes on re.id_tipo_ambiente equals ta.id_tipo_ambiente
                              join ba in bd.Barcos on re.id_barco equals ba.id_barco
                              join vi in bd.Viajes on ba.id_barco equals vi.id_viaje
                              where vi.id_viaje == id_viaje &&
                              (mo.fecha_hora >= fecha_resta && mo.fecha_hora <= fecha_actual)
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
                MovimientosTR m1 = new MovimientosTR();
                m1.Tipo_Recinto = movimiento[i].tipoRecinto;
                m1.Tipo_Ambiente = movimiento[i].tipoAmbiente;
                m1.Recinto = movimiento[i].recinto;
                m1.Tipo_Movimiento = movimiento[i].tipoMovimiento;
                m1.Cant_Movimientos = movimiento[i].movimientos;
                listaDatos.Add(m1);
            }
            return listaDatos;
        }

    }
}
