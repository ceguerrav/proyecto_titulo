using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfidZOperadorAscii
{
    public class StaticComandoBase : AsciiComandoBase
    {
        /// <summary>
        /// The command to send to the reader
        /// </summary>
        private string command;

        /// <summary>
        /// Initializes a new instance of the StaticCommandBase class
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="singleLineResponse">True if the response is expected to be one line, false if multiple lines expected or response line count unknown</param>
        protected StaticComandoBase(string command, bool singleLineResponse)
            : base(singleLineResponse ? 1 : -1)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("command");
            }

            this.command = command;
        }

        /// <summary>
        /// Gets the command to send
        /// </summary>
        public override string Command
        {
            get
            {
                return this.command;
            }
        }
    }
}
