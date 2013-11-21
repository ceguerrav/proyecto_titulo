using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfidZ
{
    /// <summary>
    /// Delegate to perform a method on a separate thread providing the parameters to the method
    /// </summary>
    /// <param name="parameters">The input and output parameters required for the method</param>
    public delegate void AsyncMethodDelegate(AsyncParameters parameters);

    /// <summary>
    /// Wraps the functionality of <see cref="AsyncResult"/> to execute a method asyhronously.
    /// </summary>
    public class AsyncMethodExecutor : AsyncResult
    {
        /// <summary>
        /// The method to execute
        /// </summary>
        private AsyncMethodDelegate method;

        /// <summary>
        /// The parameters for the method
        /// </summary>
        private AsyncParameters parameters;

        /// <summary>
        /// Initializes a new instance of the AsyncMethodExecutor class
        /// </summary>
        /// <param name="callback">Async call back to call as operation completes</param>
        /// <param name="state">Object to pass to the call back</param>
        /// <param name="method">The method to perform on the remote thead</param>
        /// <param name="parameters">The parameters required for the remote delegate</param>
        private AsyncMethodExecutor(AsyncCallback callback, object state, AsyncMethodDelegate method, AsyncParameters parameters)
            : base(callback, state)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }

            this.method = method;
            this.parameters = parameters;
        }

        /// <summary>
        /// Begins an operation that will execute on a separate thread
        /// </summary>
        /// <param name="callback">Async call back to call as operation completes</param>
        /// <param name="state">Object to pass to the call back</param>
        /// <param name="parameters">The parameters required for the delegate</param>
        /// <param name="asyncMethod">The delegate to run on the remote thread</param>
        /// <returns>An IAsyncResult to track the progress of the execution</returns>
        public static IAsyncResult BeginAsync(AsyncCallback callback, object state, AsyncParameters parameters, AsyncMethodDelegate asyncMethod)
        {
            IAsyncResult asyncResult;

            asyncResult = new AsyncMethodExecutor(callback, state, asyncMethod, parameters);

            System.Threading.ThreadPool.QueueUserWorkItem(Run, asyncResult);

            return asyncResult;
        }

        /// <summary>
        /// Completes an <see cref="AsyncResult"/>
        /// </summary>
        /// <param name="asyncResult">The IAsyncResult returned from a Begin method</param>
        /// <returns>The parameters returned from the method executed</returns>
        public static AsyncParameters EndAsync(IAsyncResult asyncResult)
        {
            AsyncMethodExecutor localAsyncResult;

            if (asyncResult == null)
            {
                throw new ArgumentNullException("asyncResult");
            }

            localAsyncResult = asyncResult as AsyncMethodExecutor;

            if (localAsyncResult == null)
            {
                throw new ArgumentException("asyncResult is not of the expected type", "asyncResult");
            }

            localAsyncResult.Validate();
            localAsyncResult.AsyncWaitHandle.WaitOne();
            localAsyncResult.Dispose();

            return localAsyncResult.parameters;
        }

        /// <summary>
        /// Performs the <see cref="method"/> providing <see cref="parameters"/>.
        /// Captures any exceptions thrown to be thrown by the callback method
        /// </summary>
        /// <param name="state">Conatins an AsyncMethodExecutor instance to perfom on the calling thread</param>
        private static void Run(object state)
        {
            AsyncMethodExecutor asyncResult;

            asyncResult = state as AsyncMethodExecutor;

            if (asyncResult == null)
            {
                throw new InvalidOperationException();
            }

            try
            {
                asyncResult.method(asyncResult.parameters);
            }
            catch (Exception ex)
            {
                asyncResult.CaughtException = ex;
            }
            finally
            {
                asyncResult.Complete();
            }
        }
    }
}
