using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RfidZOperador;

namespace RfidZControl
{
    public class Ajustes
    {
        private byte barcodeTimeout = 2;
        private string portName = "COM2";
        private int accessPassword = 0;
        private IEnumerable<string> transponders;
        private BancoMemoria banco = BancoMemoria.ElectronicProductCode;
        private int address;
        private int count = 4;
        

        public byte BarcodeTimeout
        {
            get
            {
                return this.barcodeTimeout;
            }

            set
            {
                if ((value < 0) || (value > 9))
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                this.barcodeTimeout = value;
            }
        }

        public string PortName
        {
            get
            {
                return this.portName;
            }

            set
            {
                this.portName = value;
            }
        }

        public int AccessPassword
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

        public IEnumerable<string> Transponders
        {
            get
            {
                if (this.transponders == null)
                {
                    this.transponders = new string[] { };
                }

                return this.transponders;
            }

            set
            {
                this.transponders = value;
            }
        }

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
    }
}
