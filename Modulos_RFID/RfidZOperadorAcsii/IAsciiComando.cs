using System;
using System.Collections.Generic;
using System.Text;

namespace RfidZOperadorAscii
{
    public interface IAsciiComando
    {
        #region Campos

        /// <summary>
        /// Obtiene un valor que indica si el comando se ha ejecutado correctamente
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Obtiene el comando leido para enviar 
        /// </summary>
        string Command { get; }

        /// <summary>
        /// Obtiene la respuesta recibida del lector
        /// </summary>
        IEnumerable<string> Response { get; }

        #endregion 

        #region metodos 
        /// <summary>
        /// Ejecuta el comando en el lector siempre
        /// </summary>
        /// <param name="value">El lector para ejecutar el comando</param>
        void Execute(IAsciiExec value);
        #endregion 
    }
}
