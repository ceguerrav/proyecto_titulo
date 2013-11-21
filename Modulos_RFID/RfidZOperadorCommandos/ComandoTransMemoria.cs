using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using RfidZOperadorAscii;
using RfidZOperador;
namespace RfidZOperadorCommandos
{
    public abstract class ComandoTransMemoria : AsciiComandoBase
    { 
       
          /// <summary>
        /// The memory bank to use
        /// </summary>
        private  BancoMemoria? banco;

        /// <summary>
        /// The address to start from
        /// </summary>
        private int startAddress = -1;

        /// <summary>
        /// The access password
        /// </summary>
        private int? accessPassword;

        /// <summary>
        /// If provided the mask to select a transponder
        /// </summary>
        private SelMask? mask;

        /// <summary>
        /// Initializes a new instance of the TransponderMemoryCommandBase class
        /// </summary>
        protected ComandoTransMemoria()
            : base(-1)
        {
        }

        /// <summary>
        /// Gets or sets the memory bank to access
        /// </summary>
        public BancoMemoria? Banco
        {
            get
            {
                return this.banco;
            }

            set
            {
                this.banco = value;
            }
        }

        /// <summary>
        /// Gets or sets the word address into the memory bank to start
        /// </summary>
        public int StartAddress
        {
            get
            {
                return this.startAddress;
            }

            set 
            {
                this.startAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the access password
        /// </summary>
        public int? AccessPassword
        {
            get
            {
                return this.accessPassword;
            }

            set
            {
                this.accessPassword = value;
            }
        }

        /// <summary>
        /// Gets or sets the SelectMask to determine the transponder to operate on
        /// </summary>
        public SelMask? SelectMask
        {
            get
            {
                return this.mask;
            }

            set
            {
                this.mask = value;
            }
        }        

        /// <summary>
        /// Appends the memory bank value to the command
        /// </summary>
        /// <param name="command">The command to append to</param>
        /// <param name="value">The memory bank value</param>
        protected static void MemoryBankToAscii(StringBuilder command, BancoMemoria value)
        {
            char result;

            switch (value)
            {
                case BancoMemoria.Reserved:
                    // not yet supported but expected
                    result = 'r';
                    break;

                case BancoMemoria.ElectronicProductCode:
                    result = 'e';
                    break;

                case BancoMemoria.TransponderIdentifier:
                    result = 't';
                    break;

                case BancoMemoria.User:
                    result = 'u';
                    break;

                default:
                    throw new ArgumentOutOfRangeException("value");
            }

            command.Append(result);
        }

        /// <summary>
        /// Appends the select mask value to the command
        /// </summary>
        /// <param name="command">The command to append to</param>
        /// <param name="value">The select mask value</param>
        protected static void SelectMaskToAscii(StringBuilder command, SelMask value)
        {
            command.Append("m");
            MemoryBankToAscii(command, value.bancoMemoria);
            command.AppendFormat(CultureInfo.InvariantCulture, "s{0:x4}", value.StartAddress);
            command.AppendFormat(CultureInfo.InvariantCulture, "l{0:x2}", value.Length);
            command.Append("d");
            AppendAsBase16(command, value.GetMask());
        }

        /// <summary>
        /// Appends the access password to the command
        /// </summary>
        /// <param name="command">The command to append to</param>
        /// <param name="value">The access password value</param>
        protected static void AccessPasswordToAscii(StringBuilder command, int value)
        {
            command.AppendFormat(CultureInfo.InvariantCulture, "a{0:x8}", value);
        }

        /// <summary>
        /// Appends the binary data to the command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="data"></param>
        protected static void AppendAsBase16(StringBuilder command, byte[] data)
        {
            if (data != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    command.AppendFormat(CultureInfo.InvariantCulture, "{0:x2}", data[i]);
                }
            }
        }

        /// <summary>
        /// If <see cref="Bank"/> has been specicied appends the memory bank to the command
        /// </summary>
        /// <param name="command">The command to append the value to </param>
        protected void AppendMemoryBankIfDefined(StringBuilder command)
        {
            if (this.Banco.HasValue)
            {
                MemoryBankToAscii(command, this.Banco.Value);
            }
        }

        /// <summary>
        /// If <see cref="AccessPassword"/> has been specified appends the access password to the command
        /// </summary>
        /// <param name="command">The command to append the value to</param>
        protected void AppendAccessPasswordIfHasValue(StringBuilder command)
        {
            if (this.AccessPassword.HasValue)
            {
                AccessPasswordToAscii(command, this.AccessPassword.Value);
            }
        }

        /// <summary>
        /// If <see cref="SelectMask"/> has been specified appends the select mask to the command
        /// </summary>
        /// <param name="command">The command to append the value to</param>
        protected void AppendSelectMaskIfHasValue(StringBuilder command)
        {
            if (this.SelectMask.HasValue)
            {
                SelectMaskToAscii(command, this.SelectMask.Value);
            }
        }
    }
}
