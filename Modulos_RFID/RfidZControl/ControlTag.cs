using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RfidZOperador;
using RfidZOperadorCommandos;
using System.Globalization;

namespace RfidZControl
{
    public class ControlTag : ControlBase
    {
        private string transponderIdentifierHex;

        private BancoMemoria banco;
        private int address;
        private int count;
        private byte[] data;
        private List<string> transponderIdentifierBanks;
        private String lectura;

        public String Lectura
        {
            get { return lectura; }
            set { lectura = value; }
        }
        
        public ControlTag()
        {
            // restore the cached values
            this.Banco = Service.Ajustes.Banco;
            this.WordAddress = Service.Ajustes.WordAddress;
            this.WordCount = Service.Ajustes.WordCount;
        }

        /// <summary>
        /// Gets the list of transponders discovered in the last inventory
        /// </summary>
        public IList<string> TransponderIdentifiers
        {
            get
            {
                //return Service.Settings.Transponders as IList<string> ?? new List<string>(Service.Settings.Transponders);
                return this.transponderIdentifierBanks ?? new List<string>();
            }
        }

        /// <summary>
        /// Gets or sets the transponder identifier to select as a hex string
        /// </summary>
        public string TransponderIdentifierHex
        {
            get
            {
                return this.transponderIdentifierHex;
            }

            set
            {
                this.transponderIdentifierHex = value;
            }
        }

        /// <summary>
        /// Gets or sets the transponder data to write to or read from the transponder as a hex string
        /// </summary>
        public string TransponderDataHex
        {
            get
            {
                return BinaryEncoding.ToBase16StringSafe(this.GetTransponderData());
            }

            set
            {
                this.SetTransponderData(BinaryEncoding.FromBase16String(value));
            }
        }

        /// <summary>
        /// Gets or sets the transponder memory bank to access
        /// </summary>

        public BancoMemoria Banco
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
        /// Gets or sets the word address (offset) into the memory bank to start from
        /// </summary>
        public int WordAddress
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of words to read or write from the memory bank
        /// </summary>
        public int WordCount
        {
            get
            {
                return this.count;
            }

            set 
            {
                this.count = value;
            }
        }

        /// <summary>
        /// Gets the unique identifier of the selected transponder
        /// </summary>
        private byte[] TransponderIdentifierBank
        {
            get
            {
                int i = this.TransponderIdentifierHex.IndexOf("TID:", StringComparison.OrdinalIgnoreCase);
                if (i >= 0)
                {
                    return BinaryEncoding.FromBase16String(this.transponderIdentifierHex.Substring(i + 4).Trim());
                }
                else
                {
                    throw new InvalidOperationException("transponders are selected based on transponder identifier memory");
                }
            }
        }

        /// <summary>
        /// Gets the transponder data to read or write
        /// </summary>
        /// <returns>The transponder data</returns>
        private byte[] GetTransponderData()
        {
            return this.data;
        }

        /// <summary>
        /// Sets the transponder data to write
        /// </summary>
        /// <param name="value">The data to write</param>
        private void SetTransponderData(byte[] value)
        {
            this.data = value;
        }

        /// <summary>
        /// Perform a task to list the transponders within range
        /// </summary>
        public bool ActionGetTags()
        {
            bool verificador = false;
            this.PerformTask("Inventory", delegate()
            {
                ComandoTransLectura command;
                //InventoryCommand command;

                command = new ComandoTransLectura();
                
                command.Banco = BancoMemoria.TransponderIdentifier;
                command.SelectMask = new SelMask(BancoMemoria.ElectronicProductCode, new byte[] { 0 }, 0, 0);
                command.StartAddress = 0;
                command.Length = 4;

                //command = new InventoryCommand();

                Service.Connect.Execute(command);

                List<string> transponders = new List<string>();
                foreach (KeyValuePair<string, byte[]> transponder in command.TranspondersRead)
                {
                    transponders.Add(
                        string.Format(
                        System.Globalization.CultureInfo.CurrentUICulture,
                        "EPC: {0} TID: {1}",
                        transponder.Key,
                        BinaryEncoding.ToBase16StringSafe(transponder.Value)));
                }

                this.transponderIdentifierBanks = transponders;
                verificador = true;
            });
            return verificador;
        }

        /// <summary>
        /// Perform a task to read data from the selected transponder with the selected parameters
        /// </summary>
        public String ActionRead()
        {
            this.PerformTask("Read Transponder", delegate()
            {

                ComandoTransLectura command;

                command = new ComandoTransLectura();
                command.SelectMask = CreateSelectMaskForTransponderIdentifierBank(this.TransponderIdentifierBank);
                command.StartAddress = this.WordAddress;
                command.Length = this.WordCount;
                command.AccessPassword = 0;
                command.Banco = this.Banco;
                
                Service.Connect.Execute(command);

                Service.Ajustes.Banco = this.Banco;
                Service.Ajustes.WordAddress = this.WordAddress;
                Service.Ajustes.WordCount = this.WordCount;

                // TODO: custom exceptions
                switch (command.TranspondersRead.Count)
                {
                    case 0:
                        throw new ApplicationException("no transponders");

                    case 1:
                        foreach (KeyValuePair<string, byte[]> data in command.TranspondersRead)
                        {
                            //this.Lectura=
                            this.ShowMessage(
                                string.Format(
                                    System.Globalization.CultureInfo.CurrentUICulture,
                                    "Lectura: {0}",
                                    BinaryEncoding.ToBase16String(data.Value)));
                            //this.ShowMessage(Lectura);

                        }
                        break;

                    default:
                        throw new ApplicationException("more than one transponder read");
                }
            });
            return Lectura;
        }

        /// <summary>
        /// Perform a task to write data to the selected transponder with the selected parameters
        /// </summary>
        public void ActionWrite()
        {
            this.PerformTask("Write Transponder", delegate()
            {
                this.MultiWriteTransponder();
            });
        }

        /// <summary>
        /// Creates a SelectMask to select a transponder from its TransponderIdentifier memory bank
        /// </summary>
        /// <param name="transponderIdentifier">The contents of the transponder identifier memory bank</param>
        /// <returns>A SelectMask to select the transponder</returns>
        private static SelMask CreateSelectMaskForTransponderIdentifierBank(byte[] transponderIdentifier)
        {
            return new SelMask(BancoMemoria.TransponderIdentifier, transponderIdentifier, 0, 64);
        }
        
        /// <summary>
        /// Attempts multiple write commands to the transponder to write data longer than 16 words to a transponder memory bank
        /// </summary>
        /// <remarks>
        /// Selects are done based on the transponder identifier memory bank
        /// </remarks>
        private void MultiWriteTransponder()
        {
            byte[] data;
            int countWritten;
            ComandoTransEscritura command;
            
            data = this.GetTransponderData();
            if (data == null)
            {
                throw new InvalidOperationException("data cannot be nothing");
            }

            if ((data.Length % 2) != 0)
            {
                throw new InvalidOperationException("data must be an even number of bytes, integer number of words");
            }
            
            command = new ComandoTransEscritura();
            command.SelectMask = CreateSelectMaskForTransponderIdentifierBank(this.TransponderIdentifierBank);
            command.AccessPassword = Service.Ajustes.AccessPassword;
            command.Banco = this.Banco;

            countWritten = 0;
            while (countWritten < data.Length)
            {
                byte[] block;

                if ((data.Length - countWritten) > 32)
                {
                    block = new byte[32];
                }
                else
                {
                    block = new byte[data.Length - countWritten];
                }

                Buffer.BlockCopy(data, countWritten, block, 0, block.Length);
                command.StartAddress = this.WordAddress + countWritten / 2;
                command.SetData(block);
                               
                Service.Connect.Execute(command);
                if (!command.IsSuccess)
                {
                    // cheaky repeat of command if temporary failure
                    System.Threading.Thread.Sleep(200);
                    Service.Connect.Execute(command);
                }
                
                if (command.IsSuccess)
                {
                    countWritten += block.Length;
                }
                else if (!command.IsTransponderFound)
                {
                    // TODO: custom exception
                    throw new ApplicationException(FailureMessage("No transponder found", countWritten / 2, data.Length / 2));
                }
                else
                {
                    throw new ApplicationException(FailureMessage("Write failed", countWritten / 2, data.Length / 2));
                }
            }

            this.ShowMessage("Escritura Completa");

            // cache the values for later use
            Service.Ajustes.Banco = this.Banco;
            Service.Ajustes.WordAddress = this.WordAddress;
            Service.Ajustes.WordCount = this.WordCount;
        }

        private static string FailureMessage(string error, int countWritten, int countTotal)
        {
            return string.Format(
                System.Globalization.CultureInfo.CurrentUICulture,
                "{0} after writing {1}/{2} words",
                error,
                countWritten,
                countTotal);
        }
    }
}
