using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RfidZOperadorAscii;
namespace RfidZOperadorCommandos
{
    /// <summary>
    /// Suena el timbre para dar aviso al usuario
    /// </summary>
    public class ComandoAlerta : ComandoBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Comando Alerta y pasa el comando alert hacia 
        /// el dispositivo
        /// </summary>
        public ComandoAlerta()
            : base("a")
        {
        }
    
    }
}
