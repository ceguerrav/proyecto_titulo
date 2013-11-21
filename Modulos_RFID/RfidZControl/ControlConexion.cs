using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RfidZOperadorCommandos;
namespace RfidZControl
{
    public class ControlConexion : ControlBase
    {
        private string[] devices;
        private string selected;
        private ControlComando conCom; 
        public ControlConexion()
        {

            this.selected = Service.Ajustes.PortName;
            this.conCom = new ControlComando();
        }

        public string[] Devices
        {
            get
            {
                return this.devices;
            }
        }

        public bool IsConnected
        {
            get
            {
                return Service.Connect.IsConnected;
                //conCom.Execute(new ComandoInfoVersion());
               
                // this.conCom.Execute(new ComandoAlerta());
            }
        }

        public string Selected
        {
            get
            {
                return this.selected;
            }

            set
            {
                this.selected = value;
            }
        }

        public void Refresh()
        {
            this.PerformTask("Refresh list", delegate()
            {
                this.devices = Service.Connect.AvailableDevices();
            });
            
        }

        public void Connect()
        {
            this.PerformTask("Connect", delegate()
            {
                Service.Connect.Connect(this.Selected);
            });

        }

        public void Disconnect()
        {
            this.PerformTask("Disconnect", delegate()
            {
                Service.Connect.Disconnect();
            });
        }
    }
}
