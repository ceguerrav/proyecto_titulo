using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RfidZOperador;
using RfidZOperadorCommandos;
using System.Globalization;
namespace RfidZControl
{
   public class ControlTagB : ControlBase
    {
      private string transponderIdentifierHex;
        private BancoMemoria banco;
        private int address;
        private int count;
        private byte[] data;

        public ControlTagB()
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
                return Service.Ajustes.Transponders as IList<string> ?? new List<string>(Service.Ajustes.Transponders);
                
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
        private byte[] TransponderIdentifier
        {
            get
            {
                return BinaryEncoding.FromBase16String(this.TransponderIdentifierHex);
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
        //public void ActionGetTags()
        //{
        //    this.PerformTask("Inventory", delegate()
        //    {
        //        InventoryCommand command;

        //        command = new InventoryCommand();

        //        Service.Connection.Execute(command);

        //        Service.Settings.Transponders = command.Transponders;
        //    });
        //}

        /// <summary>
        /// Perform a task to read data from the selected transponder with the selected parameters
        /// </summary>
        public void ActionRead()
        {
            this.PerformTask("Read Transponder", delegate()
            {
                ComandoTransLectura command;

                command = new ComandoTransLectura();
                command.SelectMask = CreateSelectMaskForTransponder(this.TransponderIdentifier);
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
                            this.ShowMessage(
                                string.Format(
                                    System.Globalization.CultureInfo.CurrentUICulture,
                                    "Read: {0}",
                                    BinaryEncoding.ToBase16String(data.Value)));

                        }
                        break;

                    default:
                        throw new ApplicationException("more than one transponder read");
                }
            });
         
        }

        /// <summary>
        /// Perform a task to write data to the selected transponder with the selected parameters
        /// </summary>
        public void ActionWrite()
        {
            this.PerformTask("Write Transponder", delegate()
            {

                ComandoTransEscritura command;

                command = new ComandoTransEscritura();
                command.SelectMask = CreateSelectMaskForTransponder(this.TransponderIdentifier);
                command.StartAddress = this.WordAddress;
                command.SetData(this.GetTransponderData());

                command.AccessPassword = Service.Ajustes.AccessPassword;
                command.Banco = this.Banco;

                Service.Connect.Execute(command);

                // cache the values for later use
                Service.Ajustes.Banco = this.Banco;
                Service.Ajustes.WordAddress = this.WordAddress;
                Service.Ajustes.WordCount = this.WordCount;

                if (command.IsSuccess)
                {
                    this.ShowMessage("Transponder written successfully");
                }
                else if (!command.IsTransponderFound)
                {
                    // TODO: custom exception
                    throw new ApplicationException("No transponder found");
                }
                else
                {
                    throw new ApplicationException("Write failed");
                }
            });
        }
       
        /// <summary>
        /// Creates a SelectMask to select a transponder from its TransponderIdentifier
        /// </summary>
        /// <param name="identifier">The identifier of the transponder</param>
        /// <returns>A SelectMask to select the transponder</returns>
        private static SelMask CreateSelectMaskForTransponder(byte[] identifier)
        {
            //TechnologySolutions.Rfid.ElectronicProductCodeMemory memory;
            // The ElectronicProductCodeMemory class creates a mimic of the EPC memory contents of the transponder based on the transponder identifier
            //memory = new TechnologySolutions.Rfid.ElectronicProductCodeMemory(identifier);
            //return new SelectMask(MemoryBank.ElectronicProductCode, memory.ToArray(), 0, memory.ProtocolControl.ElectronicProductCodeLength * 16 + 32);
            return new SelMask(BancoMemoria.ElectronicProductCode, identifier, 32, identifier.Length * 8);
           
        }
    }
}
