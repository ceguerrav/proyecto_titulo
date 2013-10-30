using System;
using System.Collections.Generic;
using System.Text;

namespace RfidZOperador
{
    /// <summary>
    /// Provides methods to convert to and from a Base16 text representation
    /// </summary>
    public static class BinaryEncoding
    {
        /// <summary>
        /// Converts a Base16 string into a byte array
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <returns>A byte array containing the data from the Base16 string</returns>
        public static byte[] FromBase16String(string value)
        {
            System.IO.MemoryStream result;
            List<char> hexDigits;
            bool convert;
            int hexDigit;
            int byteValue;

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            result = new System.IO.MemoryStream(value.Length / 2);
            hexDigits = new List<char>(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' });
            convert = false;
            byteValue = 0;

            foreach (char c in value)
            {
                if (char.IsWhiteSpace(c))
                {
                    // ignore whitespace
                    continue;
                }

                if (char.IsNumber(c))
                {
                    // must be '0' to '9'
                    hexDigit = hexDigits.IndexOf(c);
                }
                else if (char.IsLetter(c))
                {
                    // verify 'a' to 'f'
                    hexDigit = hexDigits.IndexOf(char.ToLower(c, System.Globalization.CultureInfo.InvariantCulture));
                }
                else
                {
                    // any other character is invalid
                    hexDigit = -1;
                }

                if (hexDigit < 0)
                {
                    throw new FormatException(string.Format(
                        System.Globalization.CultureInfo.InvariantCulture,
                        "Invalid hex character: {0}",
                        c));
                }

                if (convert)
                {
                    byteValue *= 16;
                    byteValue += hexDigit;
                    result.WriteByte((byte)byteValue);

                    byteValue = 0;
                    convert = false;
                }
                else
                {
                    byteValue = hexDigit;
                    convert = true;
                }
            }

            return result.ToArray();
        }
    }
}
