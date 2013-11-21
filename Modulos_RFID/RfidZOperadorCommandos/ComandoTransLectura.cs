using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using RfidZOperador;
namespace RfidZOperadorCommandos
{
    public class ComandoTransLectura : ComandoTransMemoria
    {
        /// <summary>
        /// The number of words to read
        /// </summary>
        private int length;

        /// <summary>
        /// The transponder read with the data read
        /// </summary>
        private IDictionary<string, byte[]> transponderData;

        /// <summary>
        /// Gets or sets the number of words to read
        /// </summary>
        public int Length
        {
            get
            {
                return this.length;
            }

            set
            {
                this.length = value;
            }
        }

        /// <summary>        
        /// Gets the command to read the requested memory from the transponder
        /// </summary>
        public override string Command
        {
            get
            {
                StringBuilder command;

                // MemoryBank e/u/t
                // StartAddress (word) 16bit 'sxxxx'
                // Length (words) 8bit 'lxx'
                // AccessPassword 32bit 'axxxxxxxx'
                // -
                // mask data follows 'm'
                // MemoryBank e/u/t
                // mask start 'sxxxx'
                // mask length 'lxx'
                // mask data 'dxx...'
                command = new StringBuilder();
                command.Append("r");

                // append Bank if it HasValue
                this.AppendMemoryBankIfDefined(command);

                if (this.StartAddress >= 0)
                {
                    command.AppendFormat(CultureInfo.InvariantCulture, "s{0:x4}", this.StartAddress);
                }

                if (this.Length > 0)
                {
                    command.AppendFormat(CultureInfo.InvariantCulture, "l{0:x2}", this.Length);
                }

                // append AccessPassword if it HasValue
                this.AppendAccessPasswordIfHasValue(command);

                // append SelectMask if it HasValue
                this.AppendSelectMaskIfHasValue(command);

                return command.ToString();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the command executed successfully
        /// </summary>
        public override bool IsSuccess
        {
            get
            {
                return this.TranspondersRead.Count > 0;
            }
        }

        /// <summary>
        /// Gets a list of transponders read and the data from the transponders
        /// </summary>
        public IDictionary<string, byte[]> TranspondersRead
        {
            get
            {
                if (this.transponderData == null)
                {
                    try
                    {
                        // parse the result
                        Dictionary<string, byte[]> transponders = new Dictionary<string, byte[]>();
                        string identifier = null;

                        foreach (string line in this.Response)
                        {
                            if (identifier == null)
                            {
                                identifier = line;
                            }
                            else
                            {
                                // ensure the id is an identifier by parsing for hex characters
                                BinaryEncoding.FromBase16String(identifier);
                                transponders.Add(identifier, BinaryEncoding.FromBase16String(line));
                                identifier = null;
                            }
                        }

                        this.transponderData = transponders;
                    }
                    catch (FormatException)
                    {
                        // command failed. set cache to no transponders
                        this.transponderData = new Dictionary<string, byte[]>();
                    }
                }

                return this.transponderData;
            }
        }

        /// <summary>
        /// Resets the cached result before the command is executed
        /// </summary>
        protected override void OnExecuting()
        {
            this.transponderData = null;
            base.OnExecuting();
        }
    }
}
