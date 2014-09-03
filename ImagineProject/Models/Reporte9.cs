using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImagineProject.Models
{
    public class Reporte9
    {
        public string Pasaporte { get; set; }
        public string Nombre_Completo { get; set; }
        public string Fecha_Registro { get; set; }
        public string Email { get; set; }
        public string Pasajero { get; set; }
        public string Fecha_Salida { get; set; }
    }
}