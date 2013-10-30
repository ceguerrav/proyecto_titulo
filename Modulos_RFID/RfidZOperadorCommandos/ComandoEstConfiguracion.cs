using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RfidZOperadorAscii;

namespace RfidZOperadorCommandos
{
    /// <summary>
    /// Este comando de diagnóstico TSL da salida a la información de configuración
    /// </summary>
   public class ComandoEstConfiguracion : StaticComandoBase
    {
        /// <summary>
        /// Se Inicia una nueva Instancia de la clase  ComandoEstConfiguracion
        /// </summary>
       public ComandoEstConfiguracion()
            : base("m", false)
        {
        }
    }
}
