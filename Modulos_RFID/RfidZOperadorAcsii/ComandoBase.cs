using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfidZOperadorAscii
{
    public abstract class ComandoBase : StaticComandoBase
    {

         /// <summary>
        /// Initializes a new instance of the EchoCommandBase class
        /// </summary>
        /// <param name="command">The command to send</param>
        protected ComandoBase(string command)
            : base(command, true)
        {
        }       

        /// <summary>
        /// Gets a value indicating whether the command was a success
        /// </summary>
        /// <remarks>
        /// Echo commands are a success when the response is a single line with the upper case version of the <see cref="Command"/> received
        /// </remarks>
        public override bool IsSuccess
        {
            get
            {
                return this.Command.ToUpper(System.Globalization.CultureInfo.InvariantCulture).Equals(this.ResponseFirstLine);
            }
        }
    }
}
