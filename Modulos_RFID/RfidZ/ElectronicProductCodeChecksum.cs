using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Implements the Crc16Ccitt algorithm for calculating the checksum of an EPC
/// </summary>
namespace RfidZ
{
    public class ElectronicProductCodeChecksum
    {
        /// <summary>
        /// The initial seed value for the checksum
        /// </summary>
        private const ushort InitialValue = 0xffff;

        /// <summary>
        /// The value used to verify a checksum is correct
        /// </summary>
        private const ushort CheckValue = 0x1d0f;

        /// <summary>
        /// The polynomial for the algorithm
        /// </summary>
        private const ushort Polynomial = 4129;

        /// <summary>
        /// Holds a cache of values used to calculate the CRC
        /// </summary>
        private static ushort[] table = new ushort[256];

        /// <summary>
        /// The current value of the checksum
        /// </summary>
        private ushort checksum;

        /// <summary>
        /// Initializes static members of the ElectronicProductCodeChecksum class
        /// </summary>
        static ElectronicProductCodeChecksum()
        {
            ushort temp, a;

            for (int i = 0; i < table.Length; ++i)
            {
                temp = 0;
                a = (ushort)(i << 8);
                for (int j = 0; j < 8; ++j)
                {
                    if (((temp ^ a) & 0x8000) != 0)
                    {
                        temp = (ushort)((temp << 1) ^ Polynomial);
                    }
                    else
                    {
                        temp <<= 1;
                    }

                    a <<= 1;
                }

                table[i] = temp;
            }
        }

        /// <summary>
        /// Initializes a new instance of the ElectronicProductCodeChecksum class
        /// </summary>
        public ElectronicProductCodeChecksum()
        {
            this.checksum = InitialValue;
        }

        /// <summary>
        /// Gets the current value of the checksum
        /// </summary>
        /// <remarks>
        /// The checksum output is the one's compliment of the running value
        /// </remarks>
        public int Checksum
        {
            get
            {
                return (int)(this.checksum ^ 0xffff);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the bytes passed through indicate a verified checksum
        /// </summary>
        /// <remarks>
        /// To verify a checksum is valid: 
        /// First call <see cref="Reset"/>
        /// Then pass all the bytes including the checksum through the aplgorithm with <see cref="Compute"/>
        /// Finally check the result with the <see cref="IsVerified"/> property
        /// </remarks>
        public bool IsVerified
        {
            get
            {
                return this.checksum == CheckValue;
            }
        }

        /// <summary>
        /// Passes the bytes specified through the checksum algorithm
        /// </summary>
        /// <param name="value">The source of values to pass through</param>
        /// <param name="offset">The offset into the array to start processing from</param>
        /// <param name="count">The number of bytes to process</param>
        /// <returns>The value of <see cref="Checksum"/> once the bytes are processed</returns>
        public ElectronicProductCodeChecksum Compute(byte[] value, int offset, int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.checksum = (ushort)((this.checksum << 8) ^ table[((this.checksum >> 8) ^ (0xff & value[i + offset]))]);
            }

            return this;
        }

        /// <summary>
        /// Passes the bytes specified through the checksum algorithm
        /// </summary>
        /// <param name="value">The source of values to pass through</param>
        /// <returns>The value of <see cref="Checksum"/> once the bytes are processed</returns>
        public ElectronicProductCodeChecksum Compute(byte[] value)
        {
            return this.Compute(value, 0, value.Length);
        }

        /// <summary>
        /// Passes the bytes specified through the checksum algorithm
        /// </summary>
        /// <param name="value">The source of values to pass through</param>
        /// <param name="offset">The offset into the array to start processing from</param>
        /// <param name="count">The number of bytes to process</param>
        /// <returns>The value of <see cref="Checksum"/> once the bytes are processed</returns>
        public int ComputeChecksum(byte[] value, int offset, int count)
        {
            return this.Compute(value, offset, count).Checksum;
        }

        /// <summary>
        /// Passes the bytes specified through the checksum algorithm
        /// </summary>
        /// <param name="value">The source of values to pass through</param>
        /// <returns>The value of <see cref="Checksum"/> once the bytes are processed</returns>
        public int ComputeChecksum(byte[] value)
        {
            return this.Compute(value).Checksum;
        }

        /// <summary>
        /// Passes the bytes specified through the checksum algorithm and returns <see cref="IsVerified"/>
        /// </summary>
        /// <param name="value">The source of values to pass through</param>
        /// <returns>True if the checksum verifies successfully</returns>
        public bool VerifyChecksum(byte[] value)
        {
            return this.Compute(value, 0, value.Length).IsVerified;
        }        
    }
}
