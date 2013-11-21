//-----------------------------------------------------------------------
// <copyright file="AsciiCommander.cs" company="Technology Solutions UK Ltd"> 
//     Copyright (c) 2012 Technology Solutions UK Ltd. All rights reserved. 
// </copyright> 
// <author>Robin Stone</author>
//-----------------------------------------------------------------------
namespace RfidZOperador
{
    using System;
    using System.Collections.Generic;
    using System.IO;    
    using System.Text;
    using System.Threading;    

    /// <summary>
    /// Provides a object to send commands to an ASCII device on a serial port and receive the responses
    /// </summary>
    public class AsciiCommander
        : IDisposable 
    {
        /// <summary>
        /// True once an instance is disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The port to communicate with the ASCII device
        /// </summary>
        private IAsciiSerialPort port;

        /// <summary>
        /// Signalled when new data is available from the ASCII device
        /// </summary>
        private AutoResetEvent dataReceived;

        /// <summary>
        /// The background thread used to read responses
        /// </summary>
        private Thread readThread;

        /// <summary>
        /// Cache of the responses since the last <see cref="Received"/> event
        /// </summary>
        private List<string> lines;        

        /// <summary>
        /// Initializes a new instance of the AsciiCommander class
        /// </summary>
        /// <param name="portName">The name of the serial port to use</param>
        public AsciiCommander(string portName)
            : this(new SerialPortWrapper(portName))
        {
        }

        public AsciiCommander (IAsciiSerialPort port)
        {
            if (port == null )
            {
                throw new ArgumentNullException ("port");
            }

            this.dataReceived = new AutoResetEvent(false);

            this.port = port;
            this.port.Received += this.SerialPort_Received;

            this.readThread = new Thread(this.ReadThread);
            this.readThread.Name = "ASCII Read Thread";
            this.readThread.Start();
        }

        /// <summary>
        /// Raised when data is received that is not a response to a command
        /// </summary>
        public event EventHandler<ResponseEventArgs> Received;

        /// <summary>
        /// Gets the collection of responses since the last <see cref="Received"/> event
        /// </summary>
        protected ICollection<string> Lines
        {
            get
            {
                if (this.lines == null)
                {
                    this.lines = new List<string>();
                }

                return this.lines;
            }
        }

        /// <summary>
        /// Sends a ASCII command to the ASCII device
        /// </summary>
        /// <param name="line">The command to send to the reader</param>
        public void Send(string line)
        {
            System.Diagnostics.Debug.WriteLine("SEND :> " + line);
            this.port.WriteLine(line);
        }

        /// <summary>
        /// Disposes an instance of the AsciiCommander class
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes an instance of the AsciiCommander class
        /// </summary>
        /// <param name="disposing">True to dispose managed as well as the native resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    IDisposable dispose = this.port as IDisposable;
                    this.port = null;                    
                    this.dataReceived.Set();
                    this.dataReceived.Close();

                    if (dispose != null)
                    {
                        // perform this after signalling the close of read thread as can throw IOException on failed port
                        dispose.Dispose();
                    }
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Override this method to act as a single line is received from the ASCII device. 
        /// The default implementation appends the received line to the <see cref="Lines"/> collection and returns false
        /// </summary>
        /// <param name="value">The line received</param>
        /// <returns>True if no more data is expected, false otherwise</returns>
        /// <remarks>
        /// Responses are a collection of one or more lines from the reader. 
        /// By default lines are grouped into collections of lines denoted by a break in communication (<see cref="OnReceivedLineGap"/>). 
        /// At which point the <see cref="Received"/> is raised and a new response started.
        /// To speed up the response to commands where the number of lines are known this method can return true to force a 'line gap'
        /// </remarks>
        protected virtual bool OnReceivedLine(string value)
        {
            System.Diagnostics.Debug.WriteLine("RECV :< " + value);
            this.Lines.Add(value);
            return false;
        }

        /// <summary>
        /// Override this method to supress the <see cref="Received"/> event.
        /// The default implementation calls the <see cref="OnReceived"/> method to raise the <see cref="Received"/> event if <see cref="Lines"/> is not empty.
        /// </summary>
        /// <remarks>
        /// This method is called from the read thread when a gap in incoming data is detected, denoting a response is complete, or if
        /// an overridden implementation of <see cref="OnReceivedLine"/> returned true.
        /// </remarks>
        protected virtual void OnReceivedLineGap()
        {
            if (this.Lines.Count > 0)
            {
                this.OnReceived(this.Lines);               
            }
        }

        /// <summary>
        /// Raises the <see cref="Received"/> event
        /// </summary>
        /// <param name="lines">The received lines</param>
        protected virtual void OnReceived(IEnumerable<string> lines)
        {
            EventHandler<ResponseEventArgs> handler;

            handler = this.Received;
            if (handler != null)
            {
                handler(this, new ResponseEventArgs(lines));
            }
        }

        /// <summary>
        /// Handles the arrival of data from the serial port by signalling the read thread to read data
        /// </summary>
        /// <param name="sender">The event source</param>
        /// <param name="e">Data provided for the event</param>
        private void SerialPort_Received(object sender, EventArgs e)
        {
            this.dataReceived.Set();
        }        

        /// <summary>
        /// The background thread that consumes data from the serial port
        /// </summary>
        private void ReadThread()
        {
            while (this.port != null)
            {
                this.dataReceived.WaitOne();

                if (this.port != null)
                {
                    try
                    {
                        string line;

                        while (!string.IsNullOrEmpty(line = this.port.ReadLine()))
                        {
                            if (this.OnReceivedLine(line))
                            {
                                break;
                            }
                        }
                    }
                    catch (TimeoutException)
                    {
                        // TODO: port set to null exception. object disposed exception?
                        // no more lines                        
                    }
                    catch (IOException)
                    {
                        // TODO: convey exceptions to listener / caller?
                    }

                    this.OnReceivedLineGap();
                    this.lines = null;
                }
            }
        }      
    }
}
