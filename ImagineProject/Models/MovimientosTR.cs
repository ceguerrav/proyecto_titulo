using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImagineProject.Models
{
    public class MovimientosTR
    {
        public string Tipo_Recinto { get; set; }
        public string Tipo_Ambiente { get; set; }
        public string Recinto { get; set; }
        public string Tipo_Movimiento { get; set; }
        public int Cant_Movimientos { get; set; }
    }
}