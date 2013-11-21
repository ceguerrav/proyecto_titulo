using System;
using System.Collections.Generic;
using System.Text;
using RfidZOperadorAscii;
namespace RfidZOperadorCommandos
{
    /// <summary>
    /// Restaura todos los parámetros opcionales para todos los comandos a los valores predeterminados
    /// </summary>
    public class ComandoCargaPorDef : StaticComandoBase
    {
        #region  Constructor
        /// <summary>
        /// e Inicia una nueva Instancia de la clase ComandoCargaPorDef
        /// </summary>
        
        public ComandoCargaPorDef()
            : base("x", true)
        {
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Obtiene un valor que indica si los valores por defecto se cargan
        /// </summary>
        public override bool IsSuccess
        {
            get
            {
                return this.ResponseFirstLine.Equals("Valores Predeterminados Cargados", StringComparison.OrdinalIgnoreCase);
            }
        }

        #endregion 
    }
}
