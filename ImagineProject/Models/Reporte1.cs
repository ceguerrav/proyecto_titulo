using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ImagineProject.Models
{
    public class Reporte1
    {
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "Ingrese una fecha")]
        [Display(Name = "Fecha")]
        public string Fecha { get; set; }

        public string Cantidad_movimientos { get; set; }
        public string Pasaporte { get; set; }
        public string Nombre_completo { get; set; }

        [Required(ErrorMessage = "Seleccione Barco")]
        [Display(Name = "Barco")]
        public string Nombre_barco { get; set; }

        [Required(ErrorMessage = "Seleccione Viaje")]
        [Display(Name = "Viaje")]
        public string Viaje { get; set; }

        public string Tipo_recinto { get; set; }
        public string Tipo_ambiente { get; set; }
        public string Nombre_recinto { get; set; }
    }
}