using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImagineProject.Models
{
    public class Reporte2
    {
        public string Viaje { get; set; }
        public string Pasaporte { get; set; }
        public string Pasajero { get; set; }
        public string Tipo_recinto { get; set; }
        public string Recinto { get; set; }
        public string Maximo { get; set; }
        public string Minimo { get; set; }
    }
}