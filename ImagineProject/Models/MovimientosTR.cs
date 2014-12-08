using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImagineProject.Models
{
    public class MovimientosTR
    {
        public DateTime Fecha_hora { get; set; }
        public string Tipo_Recinto { get; set; }
        public string Tipo_Ambiente { get; set; }
        public string Recinto { get; set; }
        public int Visitas { get; set; }
    }
}