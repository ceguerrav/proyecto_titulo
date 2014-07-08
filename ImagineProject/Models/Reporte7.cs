using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImagineProject.Models
{
    public class Reporte7
    {
        public string Nombre_Barco { get; set; }
        public string Descripcion { get; set; }
        public string Viajes { get; set; }

        [Required(ErrorMessage = "Ingrese año Desde")]
        [Display(Name = "Año")]
        public string Anio1 { get; set; }

        [Required(ErrorMessage = "Ingrese año Hasta")]
        [Display(Name = "Año")]
        public string Anio2 { get; set; }

        [Required(ErrorMessage = "Seleccione Linea Naviera")]
        [Display(Name = "Linea Naviera")]
        public string Linea_naviera { get; set; }

    }
}