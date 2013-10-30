using System;
using System.Collections.Generic;
using System.Text;

namespace RfidZOperadorAscii
{
    public interface IAsciiExec
    {
        /// <summary>
        /// Ejecute el comando ASCII y devolver la respuesta de varias líneas
        /// 
        /// Una vez que se envía un comando al lector por respuestas predeterminadas se recogen hasta que haya una interrupción de la transmisión. Mediante la especificación de la
        /// El número de líneas de espera en la respuesta de un comando puede devolver más rápido una vez que el número de líneas que se recibe. Si el valor no es
        ///Conocido especifica -1. Si no se requiere una respuesta especifique 0.
        /// </summary>
        /// <param name="command">Se envia el comando </param>
        /// <param name="expectedResponseLineCount">El número de líneas de espera en la respuesta. -1 Por desconocido.</param>
        /// <returns>The response to the ASCII command</returns>
        IEnumerable<string> Execute(string command, int expectedResponseLineCount);
    }
}
