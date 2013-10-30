using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfidZ
{
   public class AsyncParameters
    {
        /// <summary>
        /// The collection of paramters
        /// </summary>
        private Dictionary<string, object> parameters;

        /// <summary>
        /// Gets the colletion of parameters
        /// </summary>
        private IDictionary<string, object> Parameters
        {
            get
            {
                if (this.parameters == null)
                {
                    this.parameters = new Dictionary<string, object>();
                }

                return this.parameters;
            }
        }

        /// <summary>
        /// Gets or sets the parameter at the specified index
        /// </summary>
        /// <param name="index">The index of the required parameter</param>
        /// <returns>The parameter value</returns>
        public object this[int index]
        {
            get
            {
                return this.Parameters[ArgumentName(index)];
            }

            set
            {
                this.Parameters[ArgumentName(index)] = value;
            }
        }

        /// <summary>
        /// Returns the parameter value at the specified index cast to TParam
        /// </summary>
        /// <typeparam name="TParam">The expected type of the requested parameter</typeparam>
        /// <param name="index">The index of the parameter required</param>
        /// <returns>The value of the parameter requested</returns>
        public TParam Value<TParam>(int index)
        {
            return (TParam)this[index];
        }

        /// <summary>
        /// Returns a key used to retrive a parameter from the internal dictionary
        /// </summary>
        /// <param name="index">The index to generate the key from</param>
        /// <returns>The key for the parameter</returns>
        private static string ArgumentName(int index)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "Arg{0}", index);
        }
    }
}
