using System;
using System.Collections.Generic;
using System.Text;

namespace RfidZControl
{
    public class BinaryEncoding
    {
        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent System.String representation encoded with base 16 digits.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers</param>
        /// <returns>The System.String representation, in base 64, of the contents of inArray</returns>
        /// <exception cref="ArgumentNullException">inArray is null</exception>
        [System.Runtime.InteropServices.ComVisible(false)]
        public static string ToBase16String(byte[] inArray)
        {
            if (inArray == null)
            {
                throw new ArgumentNullException("inArray");
            }

            return ToBase16String(inArray, 0, inArray.Length);
        }

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent System.String representation encoded with base 16 digits.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers</param>
        /// <returns>The System.String representation, in base 64, of the contents of inArray</returns>
        /// <remarks>
        /// Differs form <see cref="ToBase16String(byte[])"/> in that a null array is returned as an empty string
        /// rather than throwing a <see cref="ArgumentNullException"/>
        /// </remarks>
        [System.Runtime.InteropServices.ComVisible(false)]
        public static string ToBase16StringSafe(byte[] inArray)
        {
            if ((inArray == null) || (inArray.Length == 0))
            {
                return string.Empty;
            }

            return ToBase16String(inArray, 0, inArray.Length);
        }

        /// <summary>
        /// Converts a subset of an array of 8-bit unsigned integers to its equivalent System.String representation encoded with base 16 digits. 
        /// Parameters specify the subset as an offset in the input array and the number of elements in the array to convert.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers</param>
        /// <param name="offset">An offset in inArray</param>
        /// <param name="length">The number of elements of inArray to convert</param>
        /// <returns>The System.String representation in base 16 of length elements of inArray starting at position offset</returns>
        /// <exception cref="ArgumentNullException">inArray is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">offset or length is negative.-or- offset plus length is greater than the length of inArray</exception>
        [System.Runtime.InteropServices.ComVisible(false)]
        public static string ToBase16String(byte[] inArray, int offset, int length)
        {
            if (inArray == null)
            {
                throw new ArgumentNullException("inArray");
            }

            if ((offset < 0) || (offset >= inArray.Length))
            {
                throw new ArgumentOutOfRangeException("offset");
            }

            if ((length < 1) || ((offset + length) > inArray.Length))
            {
                throw new ArgumentOutOfRangeException("length");
            }

            System.Text.StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(inArray[offset++].ToString("X2", System.Globalization.CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts the specified System.String, which encodes binary data as base 16 digits, to an equivalent 8-bit unsigned integer array
        /// </summary>
        /// <param name="encoded">a base16 encoded System.String</param>
        /// <returns>An array of 8-bit unsigned integers equivalent to s</returns>
        /// <exception cref="ArgumentNullException">s is null</exception>
        /// <exception cref="FormatException">The length of s, ignoring white space characters, is not zero or a multiple of 2. -or-The format of s is invalid. s contains a non-base 16 character</exception>
        [System.Runtime.InteropServices.ComVisible(false)]
        public static byte[] FromBase16String(string encoded)
        {
            System.IO.MemoryStream ms;
            bool convert;
            int value;

            if (encoded == null)
            {
                throw new ArgumentNullException("encoded");
            }

            ms = new System.IO.MemoryStream(encoded.Length / 2);
            convert = false;
            value = 0;

            foreach (char c in encoded)
            {
                if (char.IsDigit(c) | (char.IsLetter(c) & (char.ToUpper(c, System.Globalization.CultureInfo.InvariantCulture) < 'G')))
                {
                    if (convert)
                    {
                        value *= 16;
                        value += FromBase16Char(c);
                        ms.WriteByte((byte)value);

                        value = 0;
                        convert = false;
                    }
                    else
                    {
                        value = FromBase16Char(c);
                        convert = true;
                    }
                }
                else if (char.IsWhiteSpace(c))
                {
                    // ignore
                }
                else
                {
                    throw new FormatException();
                }
            }

            return ms.ToArray();
        }

        /// <summary>
        /// Converts a value to a Binary Coded Decimal Byte
        /// </summary>
        /// <param name="value">the value to encode</param>
        /// <returns>the equivalent BCD byte</returns>
        /// <exception cref="ArgumentOutOfRangeException">only values from 0 to 99 are valid</exception>
        public static byte ToBinaryCodedDecimal(int value)
        {
            if ((value < 0) || (value > 99))
            {
                throw new ArgumentOutOfRangeException("value", "maximum value of BCD byte is 99");
            }

            return System.Convert.ToByte(((value / 10) * 16) + (value % 10));
        }

        /// <summary>
        /// Converts a binary coded decimal byte to a binary value
        /// </summary>
        /// <param name="value">the BCD byte to decode</param>
        /// <returns>the equivalent binary value</returns>
        public static byte FromBinaryCodedDecimal(int value)
        {
            if ((value > 0x99) || (value < 0))
            {
                throw new ArgumentOutOfRangeException("value", "BCD represents 0..99 per byte");
            }

            return (byte)(((value >> 4) * 10) + (value & 0x0F));
        }

        /////// <summary>
        /////// takes an array of BCD bytes and returns an array of bytes with decoded values at match indexes
        /////// </summary>
        /////// <param name="source"></param>
        /////// <param name="index"></param>
        /////// <param name="count"></param>
        /////// <returns></returns>
        ////public static byte[] FromBinaryCodedDecimal(byte[] source, int index, int count)
        ////{
        ////    if (source == null)
        ////    {
        ////        throw new ArgumentNullException("source");
        ////    }

        ////    if ((index < 0) || (index > source.Length - 1))
        ////    {
        ////        throw new ArgumentOutOfRangeException("index");
        ////    }

        ////    if ((count < 1) || (index + count > source.Length))
        ////    {
        ////        throw new ArgumentOutOfRangeException("count");
        ////    }

        ////    byte[] ret = new byte[count];

        ////    for (int i = 0; i < count; i++)
        ////    {
        ////        ret[i] = Decode(source[index + i]);
        ////    }

        ////    return ret;
        ////}         

        /// <summary>
        /// Converts a parameters response received as bytes into ASCII text
        /// </summary>
        /// <param name="data">A text response from the reader</param>
        /// <returns>The text in the response</returns>
        public static string ToAsciiText(byte[] data)
        {
            if (data == null)
            {
                return string.Empty;
            }
            else
            {
                return ToAsciiText(data, 0, data.Length);
            }
        }

        /// <summary>
        /// Converts a parameters response received as bytes into ASCII text
        /// </summary>
        /// <param name="data">A text response from the reader</param>
        /// <param name="offset">the offset into the data where the text starts</param>
        /// <param name="count">the length of the text in bytes</param>
        /// <returns>The text in the response</returns>
        public static string ToAsciiText(byte[] data, int offset, int count)
        {
            string result;

            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            if ((offset < 0) | (offset >= data.Length))
            {
                throw new ArgumentOutOfRangeException("offset");
            }

            if ((count < 1) | ((offset + count) > data.Length))
            {
                throw new ArgumentOutOfRangeException("count");
            }

            result = System.Text.Encoding.ASCII.GetString(data, offset, count).Replace("\0", " ").Trim();

            return result;
        }

        /// <summary>
        /// Converts '0'..'9', 'A'..'F' to value equalivaleng
        /// </summary>
        /// <param name="digit">the hex digit to convert</param>
        /// <returns>the numeric equivalent of the hex character</returns>
        /// <exception cref="ArgumentOutOfRangeException">if the character does not have a hex number equivalent</exception>
        private static byte FromBase16Char(char digit)
        {
            byte value;

            // TODO: surely we can improve on this
            switch (digit)
            {
                case '0':
                    value = 0;
                    break;

                case '1':
                    value = 1;
                    break;

                case '2':
                    value = 2;
                    break;

                case '3':
                    value = 3;
                    break;

                case '4':
                    value = 4;
                    break;

                case '5':
                    value = 5;
                    break;

                case '6':
                    value = 6;
                    break;

                case '7':
                    value = 7;
                    break;

                case '8':
                    value = 8;
                    break;

                case '9':
                    value = 9;
                    break;

                case 'A':
                    value = 10;
                    break;

                case 'B':
                    value = 11;
                    break;

                case 'C':
                    value = 12;
                    break;

                case 'D':
                    value = 13;
                    break;

                case 'E':
                    value = 14;
                    break;

                case 'F':
                    value = 15;
                    break;

                case 'a':
                    value = 10;
                    break;

                case 'b':
                    value = 11;
                    break;

                case 'c':
                    value = 12;
                    break;

                case 'd':
                    value = 13;
                    break;

                case 'e':
                    value = 14;
                    break;

                case 'f':
                    value = 15;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("digit");
            }

            return value;
        }
    }
}
