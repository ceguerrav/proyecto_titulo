using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImagineProject.Models
{
    public class Reporte10 
    {
        public string Puerto_Destino { get; set; }
        public string Pasaporte { get; set; }
        public string Nombre_Completo { get; set; }
        public string Cantidad_Viaje { get; set; }

        [Required(ErrorMessage = "Ingrese año")]
        [Display(Name = "Año")]
        public string Anio { get; set; }

        [Required(ErrorMessage = "Ingrese año Desde")]
        [Display(Name = "Año")]
        public string Anio1 { get; set; }

        [Required(ErrorMessage = "Ingrese año Hasta")]
        [Display(Name = "Año")]
        public string Anio2 { get; set; }

    }
}
