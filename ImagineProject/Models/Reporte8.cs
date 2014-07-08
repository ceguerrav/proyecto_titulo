using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ImagineProject.Models
{
    public class Reporte8
    {
        public string Pasaporte { get; set; }
        public string Nombre_completo { get; set; }
        public string Tipo_pasaje { get; set; }
        public string Cantidad_viajes { get; set; }

        [Required(ErrorMessage = "Seleccione Linea Naviera")]
        [Display(Name = "Linea Naviera")]
        public string Linea_naviera { get; set; }

        [Required(ErrorMessage = "Ingrese año")]
        [Display(Name = "Año")]
        public string Anio { get; set; }

    }
}