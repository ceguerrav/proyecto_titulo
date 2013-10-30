using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfidZ
{
    /// <summary>
    /// Represents the CRC+PC+EPC stored at the start of the EPC memory bank for EPC Global Class 1 Generation 2 transponers
    /// </summary>
    public class ElectronicProductCodeMemory
    {
        /// <summary>
        /// The CRC as determined from the identifier
        /// </summary>
        private int storedChecksum;

        /// <summary>
        /// The Protocol Control (PC) word as determined from the identifier
        /// </summary>
        private ProtocolControl protocolControl;

        /// <summary>
        /// The Electronic Product Code (EPC) as determined from the identifier
        /// </summary>
        private byte[] electronicProductCode;

        /// <summary>
        /// Initializes a new instance of the ElectronicProductCodeMemory class
        /// </summary>
        /// <param name="identifier">Either an EPC only or a valid PC+EPC+CRC combination</param>
        /// <remarks>
        /// Checks idenfifier for a valid PC and CRC. If correct the value is interpreted as a PC+EPC+CRC.
        /// If the identifier does not have a valid PC or CRC then it is treated as an EPC only and the PC and CRC are generated.
        /// </remarks>
        public ElectronicProductCodeMemory(byte[] identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }

            if (ProtocolControlValid(identifier, out this.protocolControl) && ChecksumValid(identifier, out this.storedChecksum))
            {
                this.electronicProductCode = new byte[identifier.Length - 4];
                Buffer.BlockCopy(identifier, 2, this.electronicProductCode, 0, this.electronicProductCode.Length);
            }
            else
            {
                this.protocolControl = ProtocolControl.ElectronicProductCode(identifier.Length / 2, false, false, 0);
                this.electronicProductCode = new byte[identifier.Length];
                Buffer.BlockCopy(identifier, 0, this.electronicProductCode, 0, this.electronicProductCode.Length);
                this.storedChecksum = new ElectronicProductCodeChecksum()
                    .Compute(this.protocolControl.ToArray(), 0, 2)
                    .Compute(identifier, 0, identifier.Length).Checksum;
            }
        }

        /// <summary>
        /// Gets the procotol control word from the identifier
        /// </summary>
        public ProtocolControl ProtocolControl
        {
            get
            {
                return this.protocolControl;
            }
        }

        /// <summary>
        /// Parses the protocol control word from the first two bytes of the identifier
        /// </summary>
        /// <param name="identifier">The identifier to parse</param>
        /// <param name="value">Returns the parsed value</param>
        /// <returns>True if the protocol control word is valid for the length of identifier</returns>
        public static bool ProtocolControlValid(byte[] identifier, out ProtocolControl value)
        {
            value = new ProtocolControl(identifier);
            return value.IsElectronicProductCode && ((value.ElectronicProductCodeLength * 2) == (identifier.Length - 4));
        }

        /// <summary>
        /// Assumes identifier (PC+EPC+CRC) is terminated with a CRC. Determines if the CRC is correct
        /// </summary>
        /// <param name="identifier">The identifier to parse</param>
        /// <param name="checksum">Returns the parsed checksum</param>
        /// <returns>True if the checksum is valid, false otherwise</returns>
        public static bool ChecksumValid(byte[] identifier, out int checksum)
        {
            ElectronicProductCodeChecksum crc;

            crc = new ElectronicProductCodeChecksum();
            checksum = crc.Compute(identifier, 0, identifier.Length - 2).Checksum;
            crc.Compute(identifier, identifier.Length - 2, 2);
            return crc.IsVerified;
        }

        /// <summary>
        /// Returns the identifier as it would appear be returned from inventory (StoredPC + EPC + CRC)
        /// </summary>
        /// <returns>The identifier as returned from an inventory</returns>
        public byte[] IdentifierToArray()
        {
            byte[] result;

            result = new byte[this.electronicProductCode.Length + 4];
            Buffer.BlockCopy(this.ProtocolControl.ToArray(), 0, result, 0, 2);
            Buffer.BlockCopy(this.electronicProductCode, 0, result, 2, this.electronicProductCode.Length);
            Buffer.BlockCopy(BigEndianBitConverter.GetBytes((ushort)this.storedChecksum), 0, result, this.electronicProductCode.Length + 2, 2);

            return result;
        }

        /// <summary>
        /// Returns the identifier as it would appear in the EPC memory bank (StoredCRC + StoredPC + EPC)
        /// </summary>
        /// <returns>The identifier as stored in the EPC memory bank</returns>
        public byte[] ToArray()
        {
            byte[] result;

            result = new byte[this.electronicProductCode.Length + 4];
            Buffer.BlockCopy(BigEndianBitConverter.GetBytes((ushort)this.storedChecksum), 0, result, 0, 2);
            Buffer.BlockCopy(this.ProtocolControl.ToArray(), 0, result, 2, 2);
            Buffer.BlockCopy(this.electronicProductCode, 0, result, 4, this.electronicProductCode.Length);

            return result;
        }

        /// <summary>
        /// Returns the EPC as determined from the Identifier
        /// </summary>
        /// <returns>The EPC from the identifier</returns>
        public byte[] ElectronicProductCode()
        {
            return this.electronicProductCode;
        }
    }
}
