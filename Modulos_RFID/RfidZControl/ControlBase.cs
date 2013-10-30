using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfidZControl
{
     public delegate void Task();

     public abstract class ControlBase
     {
         private bool busy;
         private Exception error;
         private string message;

         public event EventHandler BusyChanged;


         public bool IsBusy
         {
             get
             {
                 return this.busy;
             }

             protected set
             {
                 if (this.busy != value)
                 {
                     this.busy = value;
                     this.OnBusyChanged();
                 }
             }
         }

         public Exception Error
         {
             get
             {
                 return this.error;
             }
         }

         public string Message
         {
             get
             {
                 return this.message;
             }
         }

         protected void ShowError(string message, Exception ex)
         {
             if (ex == null)
             {
                 this.error = new ApplicationException();
                 this.message = message;
             }
             else
             {
                 this.error = ex;
                 this.message = string.Format(
                     System.Globalization.CultureInfo.CurrentUICulture,
                     "{0}: {1}",
                     message,
                     ex.Message);
             }
         }

         protected void ShowMessage(string message)
         {
             this.message = message;
             this.error = null;
         }

         protected virtual void OnBusyChanged()
         {
             EventHandler handler;

             handler = this.BusyChanged;
             if (handler != null)
             {
                 handler(this, EventArgs.Empty);
             }
         }

         protected void PerformTask(string name, Task task)
         {
             System.Threading.ThreadPool.QueueUserWorkItem(delegate(object state)
             {
                 try
                 {
                     this.IsBusy = true;
                     this.error = null;
                     this.message = string.Empty;

                     task();
                 }
                 catch (Exception ex)
                 {
                     this.ShowError(
                         string.Format(
                             System.Globalization.CultureInfo.CurrentUICulture,
                             "Failed to complete {0}",
                             name),
                         ex);
                 }
                 finally
                 {
                     this.IsBusy = false;
                 }
             });
         }
     }
}
