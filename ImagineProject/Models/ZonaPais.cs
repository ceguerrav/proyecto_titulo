//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImagineProject.Models
{
    public partial class ZonaPais
    {
        [Required(ErrorMessage = "Seleccione Zona")]
        [Display(Name = "Zona")]
        public int id_zona { get; set; }

        [Required(ErrorMessage = "Seleccione Pa�s")]
        [Display(Name = "Pa�s")]
        public int id_pais { get; set; }

        [ScaffoldColumn(false)]
        public bool estado { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual Zona Zona { get; set; }
    }

}
