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
    public partial class TipoBarco
    {
        public TipoBarco()
        {
            this.Barco = new HashSet<Barco>();
        }

        [ScaffoldColumn(false)]
        public short id_tipo_barco { get; set; }


        [Required(ErrorMessage = "Tipo de barco es obligatorio")]
        [Display(Name = "Tipo de barco")]
        [StringLength(50, ErrorMessage = "{0} no debe exceder los 50 caracteres.")]
        public string tipo_barco { get; set; }

        public virtual ICollection<Barco> Barco { get; set; }
    }

}
