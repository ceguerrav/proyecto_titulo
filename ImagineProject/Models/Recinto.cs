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
    public partial class Recinto
    {
        public Recinto()
        {
            this.RecintoPortico = new HashSet<RecintoPortico>();
        }

        [ScaffoldColumn(false)]
        public int id_recinto { get; set; }

        [Required(ErrorMessage = "Nombre del recinto es obligatorio")]
        [Display(Name = "Nombre del recinto")]
        [StringLength(100, ErrorMessage = "El {0} no debe exceder los 100 caracteres.")]
        public string nombre_recinto { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(255, ErrorMessage = "La {0} no debe exceder los 255 caracteres.")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Seleccione barco")]
        [Display(Name = "Barco")]
        public int id_barco { get; set; }

        [Required(ErrorMessage = "Seleccione tipo de recinto")]
        [Display(Name = "Tipo de recinto")]
        public short id_tipo_recinto { get; set; }

        [Required(ErrorMessage = "Seleccione tipo de ambiente")]
        [Display(Name = "Tipo de ambiente")]
        public short id_tipo_ambiente { get; set; }

        public virtual Barco Barco { get; set; }
        public virtual ICollection<RecintoPortico> RecintoPortico { get; set; }
        public virtual TipoAmbiente TipoAmbiente { get; set; }
        public virtual TipoRecinto TipoRecinto { get; set; }
    }

}
