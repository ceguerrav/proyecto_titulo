using System;
using System.Collections.Generic;
using RfidZOperadorAscii;
using System.Text;

namespace RfidZOperadorCommandos
{
   public class ComandoInfoVersion : StaticComandoBase
    {
         /// <summary>
        /// The manufacturer
        /// </summary>
        private string manufacturer;

        /// <summary>
        /// The serial number
        /// </summary>
        private string serial;

        /// <summary>
        /// The firmware
        /// </summary>
        private Version firmware;

        /// <summary>
        /// Initializes a new instance of the VersionInformationCommand class
        /// </summary>
        public ComandoInfoVersion()
            : base("v", false)
        {            
        }

        /// <summary>
        /// Gets the reported firmware version
        /// </summary>
        public Version Firmware
        {
            get
            {
                return this.firmware;
            }
        }

        /// <summary>
        /// Gets the manufacturer
        /// </summary>
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
        }

        /// <summary>
        /// Gets the serial number of the reader
        /// </summary>
        public string SerialNumber
        {
            get
            {
                return this.serial;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the command executed successfully
        /// </summary>
        public override bool IsSuccess
        {
            get
            {
                return !string.IsNullOrEmpty(this.SerialNumber);
            }
        }

        /// <summary>
        /// Resets the results of as required before executing a command
        /// </summary>
        protected override void OnExecuting()
        {
            base.OnExecuting();

            this.manufacturer = string.Empty;
            this.serial = string.Empty;
            this.firmware = new Version(0, 0);
        }

        /// <summary>
        /// After a response has executed parses the response
        /// </summary>
        /// <remarks>
        /// sample response:
        /// TSL UK Ltd.
        /// SN: 1101-02-001008
        /// Firmware 2.2.0
        /// </remarks>
        protected override void OnExecuted()
        {
            string other;

            other = string.Empty;
            base.OnExecuted();

            foreach (string value in this.Response)
            {
                if (value.StartsWith("SN:", StringComparison.OrdinalIgnoreCase))
                {
                    this.serial = value.Substring(3).Trim();
                }
                else if (value.StartsWith("Firmware", StringComparison.OrdinalIgnoreCase))
                {
                    // 'Firmware 2.0.0', 'Firmware V2.1.0',
                    // start at end of string and capture all digits and dots
                    for (int i = value.Length - 1; i > 0; i--)
                    {
                        char c = value[i];
                        if (char.IsDigit(c) || c.Equals('.'))
                        {
                        }
                        else
                        {
                            this.firmware = new Version(value.Substring(i + 1).Trim());
                            break;
                        }
                    }
                }
                else
                {
                    other = value;
                }
            }

            this.manufacturer = other;
        }
    }
}
