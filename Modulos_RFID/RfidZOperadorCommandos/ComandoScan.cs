using System;
using System.Collections.Generic;
using System.Text;
using RfidZOperadorAscii;
namespace RfidZOperadorCommandos
{
    /// <summary>
    /// Command to perform a barcode scan
    /// </summary>
    public class ComandoScan : AsciiComandoBase
    {
        /// <summary>
        /// The timeout to scan for until a barcode is read
        /// </summary>
        private byte timeout = 2;

        /// <summary>
        /// Initializes a new instance of the ScanCommand class with a timeout of 2 seconds
        /// </summary>
        public ComandoScan()
            : this(2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScanCommand class with the specified timeout (0..9 seconds)
        /// </summary>
        /// <param name="timeout">The timeout in seconds (0..9)</param>
        public ComandoScan(byte timeout)
            : base(-1)
        {
            // -1 in case we have a multi line barcode
            this.Timeout = timeout;
        }

        /// <summary>
        /// Gets or sets the timeout to scan for a barcode (0..9)
        /// </summary>
        public byte Timeout
        {
            get
            {
                return this.timeout;
            }

            set
            {
                if (value > 9)
                {
                    throw new ArgumentOutOfRangeException("value", "timeout value is between 0 to 9 seconds");
                }

                this.timeout = value;
            }
        }

        /// <summary>
        /// Gets the command to send to the reader
        /// </summary>
        public override string Command
        {
            get
            {
                return string.Format(
                    System.Globalization.CultureInfo.InvariantCulture,
                    "c{0}", 
                    this.Timeout);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the command executed successfully
        /// </summary>
        public override bool IsSuccess
        {
            get
            {
                string firstLine = this.ResponseFirstLine;
                return !string.IsNullOrEmpty(firstLine) && !firstLine.Equals("No Barcode");
            }
        }
    }
}
