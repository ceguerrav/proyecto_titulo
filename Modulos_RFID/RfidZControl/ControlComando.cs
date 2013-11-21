using System;
using System.Collections.Generic;
using System.Text;
using RfidZ;
using RfidZControl;
using RfidZOperadorCommandos;
using RfidZOperadorAscii;
namespace RfidZControl
{
    public class ControlComando : ControlBase
    {
        // private string selectedCommand;
        private IDictionary<string, Task> tasks;

        public ControlComando()
        {
            
            //this.selectedCommand = string.Empty;
            this.tasks = new Dictionary<string, Task>();
            ////this.tasks.Add("Alert", delegate { this.Execute(new ComandoAlerta()); });
            //this.tasks.Add("Version", delegate { this.Execute(new ComandoInfoVersion()); });
            
        }

        public event EventHandler<EventArgs<string>> PostMessage;

        /// <summary>
        /// Gets a list of available commands
        /// </summary>
        /// <remarks>
        /// List or ListSource as required for databinding
        /// </remarks>
        //public IList<string> Commands
        //{
        //    get
        //    {
        //        return new List<string>(this.tasks.Keys);
        //    }
        //}

        public void Execute(string selectedCommand)
        {
            Task task;

            task = this.tasks[selectedCommand];
            this.PerformTask(selectedCommand, task);
        }

        protected virtual void OnPostMessage(string format, params object[] args)
        {
            this.OnPostMessage(
                string.Format(
                    System.Globalization.CultureInfo.CurrentUICulture,
                    format,
                    args));
        }

        protected virtual void OnPostMessage(string value)
        {
            EventHandler<EventArgs<string>> handler;

            handler = this.PostMessage;

            if (handler != null)
            {
                handler(this, new EventArgs<string>(value));
            }
        }
        
        public void Execute(IAsciiComando command)
        {
           
            StringBuilder strbl = new StringBuilder();
            int cont_caracter = 0;
            this.ShowMessage(string.Empty);
            Service.Connect.Execute(command);
            if (!command.IsSuccess)
            {
               this.OnPostMessage("Error");
               this.ShowError("Command failed", null);
            }

            foreach (string line in command.Response)
            {
                
                //el numero de caracter de cada de linea  
                if (line.Length > 2)
                {
                    strbl = strbl.AppendLine(line);
                     cont_caracter ++;
                    if (cont_caracter == 3)
                    {
                        this.OnPostMessage("-- Version del Dispositivo --");
                        this.OnPostMessage(strbl.ToString());
                    }
                }
            }
             
        }
    }
}
