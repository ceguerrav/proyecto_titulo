using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImagineProject.Models
{
    public class Reporte5
    {
        public string Barco { get; set; }
        public string TipoRecinto { get; set; }
        public string TipoAmbiente { get; set; }
        public string Recinto { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int MinMov { get; set; }
        public int MaxMov { get; set; }
    }
}