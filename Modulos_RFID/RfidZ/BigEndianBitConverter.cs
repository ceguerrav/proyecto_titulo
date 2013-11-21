using System;
using System.Collections.Generic;
using System.Text;

namespace RfidZ
{
    /// <summary>
    /// Covnerts values to and from a byte array assuming the big endian format
    /// </summary>
    public static class BigEndianBitConverter
    {
        /// <summary>
        /// Gets the bytes that represent value
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <returns>The byte array that represents value</returns>
        [CLSCompliant(false)]
        public static byte[] GetBytes(ushort value)
        {
            byte[] result;

            result = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(result);
            }

            return result;
        }

        /// <summary>
        /// Converts the byte array to the required value
        /// </summary>
        /// <param name="value">The byte array to convert from</param>
        /// <param name="offset">The offset into the array to start the conversion</param>
        /// <returns>The value converted from the array</returns>
        [CLSCompliant(false)]
        public static ushort ToUInt16(byte[] value, int offset)
        {
            // enforce overflow exception for offset+1
            checked
            {
                return (ushort)((value[offset] << 8) + value[offset + 1]);
            }
        }
    }
}
