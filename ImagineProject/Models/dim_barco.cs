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
    public partial class dim_barco
    {
        public dim_barco()
        {
            this.fact_movimientos = new HashSet<fact_movimiento>();
        }
    
        public long id_barco { get; set; }
        public string tipo_barco { get; set; }
        public string linea_naviera { get; set; }
        public string nombre_barco { get; set; }
        public string descripcion { get; set; }
        public int capacidad { get; set; }
    
        public virtual ICollection<fact_movimiento> fact_movimientos { get; set; }
    }
    
}