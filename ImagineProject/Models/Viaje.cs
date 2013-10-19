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
    public partial class Viaje
    {
        public Viaje()
        {
            this.OrigenDestino = new HashSet<OrigenDestino>();
            this.Pasaje = new HashSet<Pasaje>();
        }

        [ScaffoldColumn(false)]
        public int id_viaje { get; set; }

        [Required(ErrorMessage = "Fecha de salida es obligatoria")]
        [Display(Name = "Fecha de salida")]
        public System.DateTime fecha_salida { get; set; }

        [Required(ErrorMessage = "Fecha de llegada es obligatoria")]
        [Display(Name = "Fecha de llegada")]
        public System.DateTime fecha_llegada { get; set; }

        [Required(ErrorMessage = "Descripción Viaje es obligatorio")]
        [Display(Name = "Descripción Viaje")]
        [StringLength(30, ErrorMessage = "El {0} no debe exceder los 30 caracteres.")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Seleccione barco")]
        [Display(Name = "Barco")]
        public int id_barco { get; set; }

        [Required(ErrorMessage = "Seleccione tipo de viaje")]
        [Display(Name = "Tipo de viaje")]
        public short id_tipo_viaje { get; set; }

        public virtual Barco Barco { get; set; }
        public virtual ICollection<OrigenDestino> OrigenDestino { get; set; }
        public virtual ICollection<Pasaje> Pasaje { get; set; }
        public virtual TipoViaje TipoViaje { get; set; }
    }

}
