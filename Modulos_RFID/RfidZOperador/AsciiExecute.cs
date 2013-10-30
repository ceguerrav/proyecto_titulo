//-----------------------------------------------------------------------
// <copyright file="AsciiExecute.cs" company="Technology Solutions UK Ltd"> 
//     Copyright (c) 2012 Technology Solutions UK Ltd. All rights reserved. 
// </copyright> 
// <author>Robin Stone</author>
//-----------------------------------------------------------------------
namespace RfidZOperador
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using RfidZOperadorAscii;
   

    /// <summary>
    /// Extends the <see cref="AsciiCommander"/> class to implement <see cref="IAsciiExecute"/>
    /// </summary>
    public class AsciiExecute
        : AsciiCommander, IAsciiExec
    {
        /// <summary>
        /// True once this instance is disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The number of lines expected in the response to the current command or less than 0 for unknown or no command
        /// </summary>
        private int expectedLines;

        /// <summary>
        /// Cache of the last response
        /// </summary>
        private IEnumerable<string> response;

        /// <summary>
        /// Signalled while a command is being executed
        /// </summary>
        private ManualResetEvent commandPending;

        /// <summary>
        /// Signalled when a response is available for a command
        /// </summary>
        private ManualResetEvent commandWait;        

        /// <summary>
        /// Initializes a new instance of the AsciiExecute class
        /// </summary>
        /// <param name="portName">The name of the serial port the ASCII device is connected to</param>
        public AsciiExecute(string portName)
            : base(portName)
        {
            this.expectedLines = int.MaxValue;
            this.commandPending = new ManualResetEvent(false);
            this.commandWait = new ManualResetEvent(false);
        }

        /// <summary>
        /// Executes an ASCII command
        /// </summary>
        /// <param name="command">The ASCII command to send</param>
        /// <param name="expectedLines">The number of lines expected in the response (-1 if unknown)</param>
        /// <returns>The lines received in response to the command</returns>
        /// <remarks>
        /// Send the command to the reader and waits up to five seconds for a response.
        /// If expected lines is less than 1 then the method will return once a response has be received followed by a 'line gap' 
        /// (break in communication <see cref="OnReceivedLineGap"/>. If expected lines is one or more the command may return earlier
        /// as soon as the specified number of lines is received
        /// </remarks>
        public IEnumerable<string> Execute(string command, int expectedLines)
        {
            return this.Execute(command, 5000, expectedLines);
        }

        /// <summary>
        /// Executes an ASCII command
        /// </summary>
        /// <param name="command">The ASCII command to send</param>
        /// <param name="timeout">The timeout in milliseconds to wait for a response</param>
        /// <param name="expectedLines">The number of lines expected in the response (-1 if unknown)</param>
        /// <returns>The lines received in response to the command</returns>
        /// <remarks>
        /// Send the command to the reader and waits up to timeout milliseconds for a response.
        /// If expected lines is less than 1 then the method will return once a response has be received followed by a 'line gap' 
        /// (break in communication <see cref="OnReceivedLineGap"/>. If expected lines is one or more the command may return earlier
        /// as soon as the specified number of lines is received
        /// </remarks>
        public IEnumerable<string> Execute(string command, int timeout, int expectedLines)
        {
            if (expectedLines < 1)
            {
                expectedLines = int.MaxValue;
            }

            if (timeout < 1)
            {
                throw new ArgumentOutOfRangeException("timeout");
            }

            if (this.commandPending.WaitOne(0, false))
            {
                throw new InvalidOperationException("already executing a command");
            }

            this.expectedLines = expectedLines; // number of lines expected in the response
            this.response = new string[] { }; // clear response
            this.commandWait.Reset(); // clear any responses we've had
            this.commandPending.Set(); // signal we want the next response

            try
            {
                // send command
                this.Send(command);

                // wait for a response
                this.commandWait.WaitOne(timeout, false);

                // return response if any received
                return this.response;
            }
            finally
            {
                this.commandPending.Reset();
                this.expectedLines = int.MaxValue;
            }
        }

        /// <summary>
        /// Disposes an instance of the AsciiExecute class
        /// </summary>
        /// <param name="disposing">True to dispose the managed as well as native resources</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!this.disposed)
            {
                if (disposing)
                {
                    this.commandPending.Close();
                    this.commandWait.Close();
                }

                this.disposed = true;
            }
        }        

        /// <summary>
        /// Overrides the default method and returns true if the number of expected lines has beed received. 
        /// Calls the base method to append the received line to the response
        /// </summary>
        /// <param name="value">The line received</param>
        /// <returns>True if the expected number of lines has been received, false otherwise</returns>
        protected override bool OnReceivedLine(string value)
        {
            // add line to cache as before
            base.OnReceivedLine(value);

            // if we have enough lines to satisfy a response and we're waiting for a response
            return (this.Lines.Count >= this.expectedLines) && this.commandPending.WaitOne(0, false);
        }

        /// <summary>
        /// Overrides the default method to handle a response from the reader.
        /// If a command has been sent the received lines is consumed as the response to the command.
        /// If no command is pending then the base method is called to signal the incoming lines
        /// </summary>
        protected override void OnReceivedLineGap()
        {
            if (this.commandPending.WaitOne(0, false))
            {
                // waiting for a response
                // capture the response and signal available
                this.response = this.Lines;
                this.commandWait.Set();
            }
            else
            {
                base.OnReceivedLineGap();
            }
        }     
    }
}
