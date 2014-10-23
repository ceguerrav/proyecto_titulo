using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImagineProject.Models
{
    public class Movimientos
    {
        public string Tipo_Recinto { get; set; }
        public string Tipo_Ambiente { get; set; }
        public string Recinto { get; set; }
        public string Tipo_Movimiento { get; set; }
        public string Cant_Movimientos { get; set; }
    }
}