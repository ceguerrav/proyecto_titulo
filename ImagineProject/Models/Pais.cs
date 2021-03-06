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
    public partial class Pais
    {
        public Pais()
        {
            this.DivisionAdministrativa = new HashSet<DivisionAdministrativa>();
            this.ZonaPais = new HashSet<ZonaPais>();
        }

        [ScaffoldColumn(false)]
        public int id_pais { get; set; }

        [Display(Name = "Nombre oficial")]
        [StringLength(100, ErrorMessage = "{0} no debe exceder los 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z�������]{1}[a-zA-Z������� ]{1,}$", ErrorMessage = "Solo letras.")]
        public string nombre_oficial { get; set; }

        [Required(ErrorMessage = "Nombre de pa�s es obligatorio")]
        [Display(Name = "Nombre del pais")]
        [StringLength(30, ErrorMessage = "{0} no debe exceder los 30 caracteres.")]
        [RegularExpression(@"^[a-zA-Z�������]{1}[a-zA-Z������� ]{1,}$", ErrorMessage = "Solo letras.")]
        public string nombre_pais { get; set; }

        [Display(Name = "Codigo ISO")]
        [StringLength(3, ErrorMessage = "{0} no debe exceder los 3 caracteres.")]
        [RegularExpression(@"^[a-zA-Z�������]{1}[a-zA-Z������� ]{1,}$", ErrorMessage = "Solo letras.")]
        public string cod_iso { get; set; }

        [Required(ErrorMessage = "Seleccione un tipo de divisi�n")]
        [Display(Name = "Tipo de divisi�n administrativa")]
        //[RegularExpression(@"^[a-zA-Z�������]{1}[a-zA-Z������� ]{1,}$", ErrorMessage = "Solo letras.")]
        public short id_tipo_division { get; set; }

        public virtual ICollection<DivisionAdministrativa> DivisionAdministrativa { get; set; }
        public virtual TipoDivision TipoDivision { get; set; }
        public virtual ICollection<ZonaPais> ZonaPais { get; set; }
    }

}
