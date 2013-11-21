using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace RfidZ
{
    /// <summary>
    /// Basic class that implements <see cref="IAsyncResult"/>
    /// </summary>
    /// <remarks>
    /// Used to implement the AsyncPattern
    /// void XXX()
    /// IAsyncResult BeginXXX(AsyncCallback callback, object state) and 
    /// void EndXXX(IAsyncResult asyncResult)
    /// </remarks>
    public class AsyncResult : IDisposable, IAsyncResult
    {
        /// <summary>
        /// True once disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Delegate to call on completion of the operation
        /// </summary>
        private AsyncCallback callback;

        /// <summary>
        /// State passed to the Beginxxx method and returned to the Endxxx method
        /// </summary>
        private object state;

        /// <summary>
        /// Async Wait Handle
        /// </summary>
        private ManualResetEvent waitHandle;

        /// <summary>
        /// Exception caught during execution and thrown from Endxxx
        /// </summary>
        private Exception caughtError;

        /// <summary>
        /// True if the method completes synchronously
        /// </summary>
        private bool isSynchronous;

        /// <summary>
        /// Initializes a new instance of the AsyncResult class
        /// </summary>
        /// <param name="callback">Async call back to call as operation completes</param>
        /// <param name="state">Object to pass to the call back</param>
        public AsyncResult(AsyncCallback callback, object state)
            : this(callback, state, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the AsyncResult class
        /// </summary>
        /// <param name="callback">Async call back to call as operation completes</param>
        /// <param name="state">Object to pass to the call back</param>
        /// <param name="complete">True if the operate completed synchronously</param>
        public AsyncResult(AsyncCallback callback, object state, bool complete)
        {
            this.callback = callback;
            this.state = state;
            this.waitHandle = new ManualResetEvent(false);
            this.isSynchronous = complete; // if already complete then we were synchronous
        }

        /// <summary>
        /// Gets or sets an exception caught from the asynchronous operation
        /// </summary>
        public Exception CaughtException
        {
            get
            {
                return this.caughtError;
            }

            set
            {
                this.caughtError = value;
            }
        }

        /// <summary>
        /// Gets the state value passed to the constructor
        /// </summary>
        public object AsyncState
        {
            get
            {
                return this.state;
            }
        }

        /// <summary>
        /// Gets a wait handle that is signalled when the operation is complete
        /// </summary>
        public WaitHandle AsyncWaitHandle
        {
            get
            {
                return this.waitHandle;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the operation completed synchronously
        /// </summary>
        public bool CompletedSynchronously
        {
            get
            {
                return this.isSynchronous;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the operation is complete
        /// </summary>
        public bool IsCompleted
        {
            get
            {
                return this.waitHandle.WaitOne(0, false);
            }
        }

        /// <summary>
        /// Completes the operation by setting the wait handle and calling the callback function
        /// </summary>
        public void Complete()
        {
            try
            {
                this.waitHandle.Set();
                if (this.callback != null)
                {
                    this.callback(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Validates the result after completion.
        /// </summary>
        /// <exception cref="Exception">An exception caught during the operation if thrown</exception>
        public void Validate()
        {
            try
            {
                if (this.disposed)
                {
                    throw new ObjectDisposedException(this.GetType().Name);
                }
                else if (this.waitHandle == null)
                {
                    throw new InvalidOperationException("wait handle is null in AsyncResult");
                }
                else if (this.caughtError != null)
                {
                    throw this.caughtError;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Disposes an instance of the AsyncResult class
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes an instance of the AsyncResult class
        /// </summary>
        /// <param name="disposing">True to dispose managed and native objects, false to dispose native only</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                if (disposing)
                {
                    if (this.waitHandle != null)
                    {
                        this.waitHandle.Close();
                        this.waitHandle = null;

                        this.state = null;
                        this.callback = null;
                    }
                }

                this.disposed = true;
            }
        }
    }
}
