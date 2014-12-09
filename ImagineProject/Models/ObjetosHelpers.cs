using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;// Chart

namespace ImagineProject.Models
{
    public class ObjetosHelpers
    {
        static TagBuilder mensaje = null;
        static Chart grafico = null;
        public static TagBuilder Mensaje(string texto)
        {
            mensaje = new TagBuilder("span");
            mensaje.Attributes.Add("class", "field-validation-error");
            if (!string.IsNullOrEmpty(texto))
            {
                mensaje.SetInnerText(texto);
            }
            return mensaje;
        }

        public static Chart Grafico(int chWidth,int chHeight,string chTitle,string chName,string chType,Array xValues,Array yValues)
        {
            grafico = new Chart(width: chWidth, height: chHeight, theme: ChartTheme.Yellow)
                .AddTitle(chTitle)
                .AddSeries(
                    name: chName,
                    chartType: chType,
                    xValue: xValues,
                    yValues: yValues)
                .Write();
            return grafico;
        }
    }
}