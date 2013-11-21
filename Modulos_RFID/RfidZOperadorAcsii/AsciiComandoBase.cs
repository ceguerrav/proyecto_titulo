using System;
using System.Collections.Generic;
using System.Text;

namespace RfidZOperadorAscii
{
    public abstract class AsciiComandoBase : IAsciiComando
    {
         /// <summary>
        /// Caché de la respuesta del lector
        /// </summary>
        private IEnumerable<string> response;

        /// <summary>
        /// Caché de la primera línea de la respuesta del lector
        /// </summary>
        private string firstLine;

        /// <summary>
        /// El número esperado de líneas para recibir como respuesta
        /// </summary>
        private int expectedResponseLineCount;

        /// <summary>
        /// Inicializa una nueva instancia de la clase AsciiCommandBase
        /// </summary>
        /// <param name="expectedResponseLineCount">
        /// The number of lines expected for the response
        /// </param>
        /// <remarks>
        /// Una vez que se envía un comando al lector por respuestas predeterminadas se recogen hasta que haya una interrupción de la transmisión. Mediante la especificación de la
        /// El número de líneas de espera en la respuesta de un comando puede devolver más rápido una vez que el número de líneas que se recibe. Si el valor no es
        ///Conocido especifica -1. Si no se requiere una respuesta especifique 0.
        /// </remarks>
        protected AsciiComandoBase(int expectedResponseLineCount)
        {
            this.expectedResponseLineCount = expectedResponseLineCount;
        }
        /// <summary>
        /// Obtiene un valor que indica si el comando ha sido un éxito
        /// </summary>
        public virtual bool IsSuccess
        {
            get
            {
                return !string.IsNullOrEmpty(this.ResponseFirstLine);
            }
        }

        /// <summary>
        /// Obtiene el comando a enviar al lector cuando se reemplaza en una clase derivada
        /// </summary>
        public abstract string Command
        {
            get;
        }

        /// <summary>
        /// Obtiene la respuesta del lector
        /// </summary>
        public IEnumerable<string> Response
        {
            get
            {
                if (this.response == null)
                {
                    return new string[] { };
                }

                return this.response;
            }
        }        

        /// <summary>
        /// Obtiene la primera línea de respuesta por parte del lector. Si no se ha recibido respuesta returns string.Empty
        /// </summary>
        protected string ResponseFirstLine
        {
            get
            {
                if (this.firstLine == null)
                {
                    this.firstLine = string.Empty;

                    foreach (string line in this.Response)
                    {
                        this.firstLine = line;
                        break;
                    }
                }

                return this.firstLine;
            }
        }

        /// <summary>
        /// Ejecuta el comando en el lector siempre
        /// </summary>
        /// <param name="value">Este metodo lee el comando y luego lo ejecuta</param>
        public virtual void Execute(IAsciiExec value)        
        {
            this.OnExecuting();
            try
            {
                this.firstLine = null;
                this.response = null;

                this.response = value.Execute(this.Command, this.expectedResponseLineCount);                
            }
            finally
            {
                this.OnExecuted();
            }
        }

        /// <summary>
        /// Override this method to perform actions before the command is executed
        /// </summary>
        protected virtual void OnExecuting()
        {            
        }

        /// <summary>
        /// Override this methods to perform actions after the command has been executed
        /// </summary>
        protected virtual void OnExecuted()
        {
        }
    }
}
