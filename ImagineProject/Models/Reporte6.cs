using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImagineProject.Models
{
    public class Reporte6
    {
        public string Nombre_Barco { get; set; }
        public string Descripcion_Viaje { get; set; }
        public string Fecha_Salida { get; set; }
        public string Capacidad { get; set; }
        public string Cant_Pasajeros { get; set; }
        public string Porcentaje { get; set; }
    }
}