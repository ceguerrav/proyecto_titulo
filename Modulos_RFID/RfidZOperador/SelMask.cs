using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfidZOperador
{
    public struct SelMask
    {
        /// <summary>
        /// The target memory bank
        /// </summary>
        private BancoMemoria banco;

        /// <summary>
        /// The bit offset into the memory bank at which to apply the mask
        /// </summary>
        private int startAddress;

        /// <summary>
        /// The length in bits of the mask
        /// </summary>
        private int length;

        /// <summary>
        /// The mask bits to match to
        /// </summary>
        private byte[] mask;

        /// <summary>
        /// Initializes a new instance of the SelectMask struct
        /// </summary>
        /// <param name="bank">The memory bank to target</param>
        /// <param name="mask">A byte array containing mask to match to </param>
        /// <param name="startAddress">The bit offset into the target memory to match the mask from</param>
        /// <param name="length">The number of btits of the mask to match against the target memory</param>
        public SelMask(BancoMemoria banco, byte[] mask, int startAddress, int length)
        {
            if ((banco != BancoMemoria.ElectronicProductCode) &&
                (banco != BancoMemoria.Reserved) &&
                (banco != BancoMemoria.TransponderIdentifier) &&
                (banco != BancoMemoria.User))
            {
                throw new ArgumentOutOfRangeException("bank");
            }

            if (mask == null)
            {
                throw new ArgumentNullException("mask");
            }

            if (startAddress < 0)
            {
                throw new ArgumentOutOfRangeException("startAddress");
            }

            if ((length < 0) || (length > mask.Length * 8))
            {
                throw new ArgumentOutOfRangeException("length");
            }

            this.banco = banco;
            this.startAddress = startAddress;
            this.length = length;
            this.mask = mask;
        }

        /// <summary>
        /// Gets the target memory bank
        /// </summary>
        public BancoMemoria bancoMemoria
        {
            get
            {
                return this.banco;
            }
        }

        /// <summary>
        /// Gets the bit offset into the <see cref="MemoryBank"/> to start matching the mask
        /// </summary>
        public int StartAddress
        {
            get
            {
                return this.startAddress;
            }
        }

        /// <summary>
        /// Gets the length of the mask in bits
        /// </summary>
        public int Length
        {
            get
            {
                return this.length;
            }
        }

        /// <summary>
        /// Gets the mask data
        /// </summary>
        /// <returns>The mask data</returns>
        public byte[] GetMask()
        {
            return this.mask;
        }
    }
}
