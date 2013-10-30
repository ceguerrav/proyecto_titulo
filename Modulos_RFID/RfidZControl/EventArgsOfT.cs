using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfidZControl
{
    using System;

    /// <summary>
    /// <see cref="EventArgs"/> providing access to a single event data member
    /// </summary>
    /// <typeparam name="T">The data member</typeparam>
    public class EventArgs<T>
        : EventArgs
    {
        /// <summary>
        /// The data provided for the event
        /// </summary>
        private T value;

        /// <summary>
        /// Initializes a new instance of the EventArgs class
        /// </summary>
        /// <param name="value">The data for the event</param>
        public EventArgs(T value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the data provided for the event
        /// </summary>
        public T Value
        {
            get
            {
                return this.value;
            }
        }
    }
}
