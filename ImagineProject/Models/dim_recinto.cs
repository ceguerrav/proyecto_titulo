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

namespace ImagineProject.Models
{
    public partial class dim_recinto
    {
        public dim_recinto()
        {
            this.fact_movimientos = new HashSet<fact_movimiento>();
        }
    
        public long id_recinto { get; set; }
        public string tipo_recinto { get; set; }
        public string tipo_ambiente { get; set; }
        public string descripcion_tipo_ambiente { get; set; }
        public string nombre_recinto { get; set; }
        public string descripcion_recinto { get; set; }
        public int numero_portico { get; set; }
        public string descripcion_portico { get; set; }
    
        public virtual ICollection<fact_movimiento> fact_movimientos { get; set; }
    }
    
}
