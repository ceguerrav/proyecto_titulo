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
    public partial class Pasaje
    {
        [ScaffoldColumn(false)]
        public int id_pasaje { get; set; }

        [Required(ErrorMessage = "N�mero de boleto es obligatorio")]
        [Display(Name = "N�mero de boleto")]
        [StringLength(255, ErrorMessage = "{0} no debe exceder los 255 caracteres.")]
        public string numero_boleto { get; set; }

        [Required(ErrorMessage = "Seleccione viaje")]
        [Display(Name = "Viaje")]
        public int id_viaje { get; set; }

        [Required(ErrorMessage = "Seleccione tipo de viaje")]
        [Display(Name = "Tipo de viaje")]
        public short id_tipo_pasaje { get; set; }

        [Required(ErrorMessage = "Seleccione pasajero")]
        [Display(Name = "Pasajeros")]
        public int id_pasajero { get; set; }

        public virtual Pasajero Pasajero { get; set; }
        public virtual TipoPasaje TipoPasaje { get; set; }
        public virtual Viaje Viaje { get; set; }
    }

}
