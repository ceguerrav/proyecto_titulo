using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RfidZOperadorAscii;
using RfidZOperador;
using RfidZ;
namespace RfidZControl
{
    public class ConnexionBase 
    {

        private bool disposed;
        private object commandSync = new object();
       /*
        public string[] ListPuertos()
        {
            string[] puertos;
            try { puertos = System.IO.Ports.SerialPort.GetPortNames(); }
            catch (Exception e) { throw new Exception("Error: "+e.ToString()); }
            return puertos;
        }
        */
        public string[] AvailableDevices()
        {
            return System.IO.Ports.SerialPort.GetPortNames();
        }
        public bool IsConnected
        {
            get
            {
                
                return Service.Reader != null;
                
            }
        }

        public void Connect(string connection)
        {
            this.CheckDisposed();

            if (string.IsNullOrEmpty(connection))
            {
                throw new ApplicationException("please select a port to connect to");
            }

            if (this.IsConnected)
            {
                throw new InvalidOperationException("already connected");
            }

           // Service.Reader = new TechnologySolutions.Rfid.Agouti.AsciiExecute(connection);
            Service.Reader = new AsciiExecute(connection);
        }

        public void Disconnect()
        {
            IDisposable dispose;

            dispose = Service.Reader as IDisposable;
            Service.Reader = null;

            if (dispose != null)
            {
                dispose.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public TCommand ExecuteCommand<TCommand>(TCommand value) where TCommand : IAsciiComando
        {
            this.Execute(value);
            return value;
        }

        public void Execute(IAsciiComando value)
        {
            this.CheckDisposed();

            if (!this.IsConnected)
            {
                throw new ApplicationException("reader not connected");
            }

            if (!Monitor.TryEnter(this.commandSync))
            {
                throw new ApplicationException("read busy with command");
            }

            try
            {
                value.Execute(Service.Reader);
            }
            finally
            {
                Monitor.Exit(this.commandSync);
            }
        }

        public IAsyncResult BeginExecute(IAsciiComando value, AsyncCallback callback, object state)
        {
            AsyncParameters param = new AsyncParameters();

            param[0] = value;

            return AsyncMethodExecutor.BeginAsync(callback, state, param, delegate(AsyncParameters parameters)
            {
                this.Execute(parameters.Value<IAsciiComando>(0));
            });
        }

        public IAsciiComando EndExecute(IAsyncResult result)
        {
            return AsyncMethodExecutor.EndAsync(result).Value<IAsciiComando>(0);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Disconnect();
                }

                this.disposed = true;
            }
        }

        private void CheckDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }
        

       
    }
}
