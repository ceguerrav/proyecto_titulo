using System;
using System.Collections.Generic;
using System.Text;

namespace RfidZOperador
{
    using System.IO.Ports;

    public interface IAsciiSerialPort
        : IDisposable 
    {
        event EventHandler Received;

        void WriteLine(string value);

        string ReadLine();
    }

    public class SerialPortWrapper
        : IAsciiSerialPort
    {
        private bool disposed;
        private SerialPort port;
        
        public SerialPortWrapper(string portName)
        {
            this.port = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
            this.port.DtrEnable = true;
            this.port.RtsEnable = true;
            this.port.Handshake = Handshake.RequestToSend;
            this.port.DataReceived += this.SerialPort_Received;
            this.port.ErrorReceived += this.SerialPort_ErrorReceived;
            this.port.ReadTimeout = 100;
            this.port.WriteTimeout = 500; // should allow plenty of time to send a command
            this.port.NewLine = "\r\n";
            this.port.Open();
        }

        public event EventHandler Received;

        public void WriteLine(string value)
        {
            this.port.WriteLine(value);
        }

        public string ReadLine()
        {
            return this.port.ReadLine();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.port.Dispose();
                }

                this.disposed = true;
            }
        }

        protected virtual void OnReceived()
        {
            EventHandler handler;

            handler = this.Received;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Handles the arrival of data from the serial port by signalling the read thread to read data
        /// </summary>
        /// <param name="sender">The event source</param>
        /// <param name="e">Data provided for the event</param>
        private void SerialPort_Received(object sender, SerialDataReceivedEventArgs e)
        {
            this.OnReceived();
        }

        /// <summary>
        /// Handles errors from the serial port
        /// </summary>
        /// <param name="sender">The event source</param>
        /// <param name="e">Data provided for the event</param>
        private void SerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            // throw new IOException(e.EventType.ToString());
            System.Diagnostics.Debug.WriteLine(e.EventType.ToString());
        }
    }
}
