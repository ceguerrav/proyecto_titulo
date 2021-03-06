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
    public partial class Puerto
    {
        public Puerto()
        {
            this.OrigenDestino = new HashSet<OrigenDestino>();
        }

        [ScaffoldColumn(false)]
        public int id_puerto { get; set; }

        [Required(ErrorMessage = "Nombre del puerto es obligatorio")]
        [Display(Name = "Nombre del puerto")]
        [StringLength(255, ErrorMessage = "{0} no debe exceder los 255 caracteres.")]
        public string nombre_puerto { get; set; }

        [Required(ErrorMessage = "Seleccione ciudad")]
        [Display(Name = "Ciudad")]
        public int id_ciudad { get; set; }

        public virtual Ciudad Ciudad { get; set; }
        public virtual ICollection<OrigenDestino> OrigenDestino { get; set; }
    }

}
