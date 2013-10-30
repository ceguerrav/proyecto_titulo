//-----------------------------------------------------------------------
// <copyright file="ResponseEventArgs.cs" company="Technology Solutions UK Ltd"> 
//     Copyright (c) 2012 Technology Solutions UK Ltd. All rights reserved. 
// </copyright> 
// <author>Robin Stone</author>
//-----------------------------------------------------------------------
namespace RfidZOperador
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// EventArgs for an ASCII response
    /// </summary>
    public class ResponseEventArgs
        : EventArgs 
    {
        /// <summary>
        /// The response data
        /// </summary>
        private IEnumerable<string> response;

        /// <summary>
        /// Initializes a new instance of the ResponseEventArgs class
        /// </summary>
        /// <param name="response">The response from an ASCII protocol reader</param>
        public ResponseEventArgs(IEnumerable<string> response)
        {
            if (response == null)
            {
                // do not want enumeration to throw NullReferenceException
                throw new ArgumentNullException("response");
            }

            this.response = response;
        }

        /// <summary>
        /// Gets the respons data
        /// </summary>
        public IEnumerable<string> Response
        {
            get
            {
                return this.response;
            }
        }
    }
}
