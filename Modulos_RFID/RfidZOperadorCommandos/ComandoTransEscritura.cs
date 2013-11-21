using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace RfidZOperadorCommandos
{
    public class ComandoTransEscritura : ComandoTransMemoria
    {
        /// <summary>
        /// The response after executing a command where the write was successfull
        /// </summary>
        public const string ResponseWriteSuccess = "Write Success";

        /// <summary>
        /// The response after executing a command where the transponder was seen but the write failed
        /// </summary>
        public const string ResponseWriteFail = "Write Fail";

        /// <summary>
        /// The response after executing a command where the specified transponder was not singulated
        /// </summary>
        public const string ResponseNoTransponder = "No Transponder";

        /// <summary>
        /// The data to write
        /// </summary>
        private byte[] data;

        /// <summary>
        /// Cache of the last line of the response (holds error information)
        /// </summary>
        private string lastLine;

        /// <summary>
        /// Gets the command to send to the reader to write the memory specified
        /// </summary>
        public override string Command
        {
            get
            {
                byte[] data;
                StringBuilder command;

                data = this.GetData();

                try
                {
                    this.ValidateData(data);
                }
                catch (ArgumentException ae)
                {
                    throw new InvalidOperationException(ae.Message, ae);
                }

                // MemoryBank e/u/t
                // StartAddress (word) 16bit 'sxxxx'
                // Length (words) 8bit followed by data to write 'lxxyyyy...'
                // AccessPassword 32bit 'axxxxxxxx'
                // -
                // mask data follows 'm'
                // MemoryBank e/u/t
                // mask start 'sxxxx'
                // mask length 'lxx'
                // mask data 'dxx...'                
                command = new StringBuilder();
                command.Append("w");

                // append Bank if it HasValue
                this.AppendMemoryBankIfDefined(command);

                if (this.StartAddress >= 0)
                {
                    command.AppendFormat(CultureInfo.InvariantCulture, "s{0:x4}", this.StartAddress);
                }

                if (data != null)
                {
                    command.AppendFormat(CultureInfo.InvariantCulture, "l{0:x2}", data.Length / 2);
                    AppendAsBase16(command, data);
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
                return ResponseWriteSuccess.Equals(this.ResponseLastLine);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the error response indicates no matching transponder found
        /// </summary>
        public bool IsTransponderFound
        {
            get
            {
                // TODO: check configuration invalid error
                return !ResponseNoTransponder.Equals(this.ResponseLastLine);
            }
        }

        /// <summary>
        /// Gets the last line of the response that contains the error text
        /// </summary>
        private string ResponseLastLine
        {
            get
            {
                if (this.lastLine == null)
                {
                    this.lastLine = string.Empty;
                    foreach (string line in this.Response)
                    {
                        this.lastLine = line;
                    }
                }

                return this.lastLine;
            }
        }

        /// <summary>
        /// Returns the data to be written
        /// </summary>
        /// <returns>The data to write</returns>
        public byte[] GetData()
        {
            return this.data;
        }

        /// <summary>
        /// Sets the data to be written
        /// </summary>
        /// <param name="value">The data to write</param>
        public void SetData(byte[] value)
        {
            this.ValidateData(value);
            this.data = value;
        }

        private void ValidateData(byte[] value)
        {
            // value can be null to repeat the previous write with the same data as the last command?
            if (value != null)
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("value", "data must be at least one word (two bytes)");
                }

                if ((value.Length % 2) > 0)
                {
                    throw new ArgumentException("value", "data must be an even number of bytes, integer number of words");
                }

                if (value.Length > 32)
                {
                    throw new ArgumentException("value", "can only write up to 16 words in one command");
                }
            }
        }
    }
}
