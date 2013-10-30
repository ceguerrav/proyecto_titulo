using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfidZ
{
    /// <summary>
    /// Encapsulates the information contained in the Protocol Control word of an Electronic Protuct Code
    /// </summary>
   public class ProtocolControl
    {
        /// <summary>
        /// The word value
        /// </summary>
        private ushort value;

        /// <summary>
        /// Initializes a new instance of the ProtocolControl class
        /// </summary>
        /// <param name="value">A byte array starting with the PC value</param>
        public ProtocolControl(byte[] value)
            : this(BigEndianBitConverter.ToUInt16(value, 0))
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProtocolControl class
        /// </summary>
        /// <param name="value">The value of the protocol control word</param>
        public ProtocolControl(int value)
        {
            this.value = (ushort)value;
        }

        /// <summary>
        /// Gets the value of the Protocol Control word
        /// </summary>
        public int Value
        {
            get
            {
                return this.value;
            }
        }

        /// <summary>
        /// Gets the EPC length field. The length of the EPC in words
        /// </summary>
        public int ElectronicProductCodeLength
        {
            get
            {
                return this.value >> 11;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the User Memory Indicator is asserted in the PC word
        /// </summary>
        /// <remarks>
        /// If not asserted the tag either does not implement User memory or User memory contains no information.
        /// If asserted then User memory contains information (and is therefore implemented)
        /// </remarks>
        public bool IsUserMemoryIndicatorAsserted
        {
            get
            {
                return (this.value & 0x40) > 0;
            }
        }

        /// <summary>
        /// Gets the numbering system identifier
        /// </summary>
        public int NumberingSystemIdentifier
        {
            get
            {
                return this.value & 0x1ff;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="NumeringSystemIdentifier"/> indicates the PC is in EPC format
        /// </summary>
        public bool IsElectronicProductCode
        {
            get
            {
                return this.NumberingSystemIdentifier == 0;
            }
        }

        /// <summary>
        /// Creates a Procotol Control word from the information provided
        /// </summary>
        /// <param name="length">The length of the identifier in words</param>
        /// <param name="userMemoryIdentifier">Sets the state of the user memory identifier bit</param>
        /// <param name="extendedProtocolControlIdentifier">Sets the state of the XI bit</param>
        /// <param name="numberingSystemIdentifier">Sets the numbering system identifier</param>
        /// <returns>The ProtocolControl word containing the encoded values</returns>
        public static ProtocolControl ElectronicProductCode(
            int length,
            bool userMemoryIdentifier,
            bool extendedProtocolControlIdentifier,
            int numberingSystemIdentifier)
        {
            int result;

            if ((length < 0) || (length > 31))
            {
                throw new ArgumentOutOfRangeException("length");
            }

            if ((numberingSystemIdentifier < 0) || (numberingSystemIdentifier > 0x1fff))
            {
                throw new ArgumentOutOfRangeException("numberingSystemIdentifier");
            }

            result = length << 11;
            if (userMemoryIdentifier)
            {
                result |= 0x400;
            }

            if (extendedProtocolControlIdentifier)
            {
                result |= 0x200;
            }

            result |= numberingSystemIdentifier;

            return new ProtocolControl(result);
        }

        /// <summary>
        /// Returns the Procotol Control Word as a byte array MSB first
        /// </summary>
        /// <returns>The PC as a byte array</returns>
        public byte[] ToArray()
        {
            return BigEndianBitConverter.GetBytes(this.value);
        }
    }
}
