using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RfidZControl;
using RfidZOperador;

namespace ImagineProject.Models
{
    public class RfidModel
    {
        private bool IsCursorBusy;

        private ControlConexion conn;
        private ControlComando conCom;
        private ControlTag conTag;
        public int cont = 0;
        public int auxSleep = 1000;

        private String codigoRFID;
        private String puertoCOM;

        public String PuertoCOM
        {
            get { return puertoCOM; }
            set { puertoCOM = value; }
        }

        public String CodigoRFID
        {
            get { return codigoRFID; }
            set { codigoRFID = value; }
        }


        private ControlConexion contrCon
        {
            get
            {
                if (this.conn == null)
                {

                    this.conn = new ControlConexion();
                    this.conn.BusyChanged += this.Control_BusyChanged;

                }
                return this.conn;

            }
        }


        public RfidModel()
        {
            this.conCom = new ControlComando();
            this.conTag = new ControlTag();
            this.conCom.BusyChanged += this.Control_BusyChanged;
            this.conCom.PostMessage += this.Control_PostMessage;
            this.conTag.BusyChanged += this.Control_BusyChanged;
            this.PuertoCOM = "COM10";
        }



         
        private void ActualizaDatos(String tagInicial, String newTag)
        {
            try
            {
                //ejecuta lectura automatica 
                this.conTag.TransponderIdentifierHex = tagInicial;
                this.conTag.Banco = BancoMemoria.ElectronicProductCode;
                this.conTag.WordAddress = (int)2;
                this.conTag.WordCount = (int)6;
                this.conTag.TransponderDataHex = newTag;

            }
            catch
            {
                throw;
            }
            
        }

        private String obtenerPuertoCom()
        {
            return "COM10";
        }




        public String retornaTag()
        {
            
            conTag = new ControlTag();
            conn = new ControlConexion();
            this.contrCon.Selected = this.obtenerPuertoCom();
            this.contrCon.Connect();
            gotoVolver:
            this.conTag.ActionGetTags();
            IsCursorBusy = this.conn.IsBusy;
            if (!this.conTag.IsBusy)
            {
                //DataTable dt = new DataTable();
                //dt.Merge((DataTable)this.conTag.TransponderIdentifiers);
                if (!string.IsNullOrEmpty(this.conTag.TransponderIdentifierHex))
                {
                    //desde aca obtengo los parametros para grabar 
                    return this.conTag.TransponderIdentifierHex;
                    //this.comboPropiedad.SelectedItem = this.conTag.TransponderIdentifierHex;
                    //this.txtTagId.Text = this.conTag.TransponderIdentifierHex.Substring(4, 29).ToString().Trim();

                }

            }
            else
            {
                goto gotoVolver;
            }
            return "";
        }


        private void Control_BusyChanged(object sender, EventArgs e)
        {

                IsCursorBusy = this.conn.IsBusy;
                if (!this.conn.IsBusy)
                {

                    if (!this.conTag.IsBusy)
                    {
                        if (!string.IsNullOrEmpty(this.conTag.TransponderIdentifierHex))
                        {

                        }


                        this.HacerPost(this.conTag.Message);
                    }



                }

                this.EnableUserInterface(this.conn.IsBusy, this.conn.IsConnected);


            
        }
        private void EnableUserInterface(bool busy, bool connected)
        {

            //this.connectButton.Enabled = !connected & !busy;
            //this.disconnectButton.Enabled = connected & !busy;
            //this.btnCon.Enabled = !connected & !busy;
            if (!connected  /*&!busy*/)
            {
                cont = 0;
            }

            if (connected /*& !busy*/)
            {
                cont++;

            }
            if (cont == 1)
            {

            }
        }



        private void Control_PostMessage(object sender, EventArgs<string> e)
        {
            //metodo agrega el mensaje a una lista
                //escribe el mensaje 
                this.HacerPost(e.Value);
            
        }


        private void HacerPost(String post)
        {
            if (!string.IsNullOrEmpty(post))
            {
                if (this.conTag.Error != null)
                {

                }
                else
                {

                }

            }
        }



        //metodo que agrega ceros a la izquierda del codigoRFID
        // para completar 24 caracteres


        public void completaRFID()
        {
            while (this.CodigoRFID.Length < 24)
                this.CodigoRFID = "0" + this.CodigoRFID;
        }

        public String completaRFIDCod(string rut)
        {
            while (rut.Length < 24)
            {
                rut = "0" + rut;
            }
            return rut;
        }



        public String graba()
        {

            // "001" : Proceso Realizado
            // "002" : Error de Comunicacion
            // "003" : Error de lectura etiqueta
            // "005" : Error inesperado

            try
            {
                //Se conecta grabador al puerto com que correspode 
                //ojo hay que parametrizar el COM
               
                
                Service.Connect  = new ConnexionBase();


                this.contrCon.Refresh();

                // ControlConexion conex = new ControlConexion();

                String[] auxpuertos = null;
                int auxContPuertos = 0;

                while (auxContPuertos < 3 && auxpuertos == null)
                {
                    IsCursorBusy = this.conn.IsBusy;
                    this.contrCon.Selected = this.PuertoCOM;
                    this.contrCon.Connect();
                    // se rescatan todos los comm ocupados
                    this.contrCon.BusyChanged += this.Control_BusyChanged;
                    System.Threading.Thread.Sleep(auxSleep);
                    auxpuertos = this.contrCon.Devices;
                    auxContPuertos++;
                } 

                if (this.contrCon.Devices == null)
                    return "002";


                int auxConPuertos = 0;
                bool auxConectado = false;

                //SE trata de conectar com tras com para ver a puerto se conecta
                while (auxConPuertos < auxpuertos.Length && auxConectado == false)
                {
                    int auxCont = 0;
                    while (auxCont < 3 && !this.contrCon.IsConnected)
                    {
                        this.contrCon.Refresh();

                        // ControlConexion conex = new ControlConexion();


                        IsCursorBusy = this.conn.IsBusy;
                        this.contrCon.Selected = auxpuertos[auxConPuertos];
                        this.contrCon.Connect();
                        this.contrCon.BusyChanged += this.Control_BusyChanged;
                        System.Threading.Thread.Sleep(auxSleep);
                        auxCont++;
                    }

                    if (this.contrCon.IsConnected == true)
                    {
                        auxConectado = true;
                        this.PuertoCOM = auxpuertos[auxConPuertos];
                    }
                    else
                    {
                        auxConPuertos++;

                    }
                } //fin while de los puertos

                //Problemas de coneccion

                if (this.contrCon.IsConnected==false)
                    return "002";



                //Se Captura el ID del tag o etiqueta

                this.conTag.ActionGetTags();
                //RfidZAux.IsCursorBusy = this.conn.IsBusy;

                String auxID = "";

                int auxCon2 = 0;
                while (auxCon2 < 4 && this.conTag.TransponderIdentifiers.Count == 0)
                {
                    bool a = this.conTag.IsBusy;
                  //  if (this.conTag.IsBusy)
                   // {
                        this.conTag.ActionGetTags();
                        IsCursorBusy = this.conn.IsBusy;
                        this.contrCon.BusyChanged += this.Control_BusyChanged;
                        this.conTag.BusyChanged += this.Control_BusyChanged;
                        System.Threading.Thread.Sleep(auxSleep);
                   // }
                   // else
                    if (this.conTag.TransponderIdentifiers.Count > 0)
                    {
                        auxID = this.conTag.TransponderIdentifiers[0];
                    }
                    auxCon2++;
                }


                
                // se graba el tag
                if (auxID.Length > 0 )
                {
                    this.conTag.TransponderIdentifierHex = auxID; //Se define el tag que se va a grabar
                    this.conTag.Banco = BancoMemoria.ElectronicProductCode;
                    this.conTag.WordAddress = (int)2;
                    this.conTag.WordCount = (int)6;
                    this.completaRFID();
                    this.conTag.TransponderDataHex = this.CodigoRFID; //Se envia el valor a grabar
                    this.conTag.ActionWrite();
                    this.contrCon.BusyChanged += this.Control_BusyChanged;
                    this.conTag.BusyChanged += this.Control_BusyChanged;
                    System.Threading.Thread.Sleep(auxSleep);
                 }
                else
                {
                    return "003";
                }

                //Se desconecta el grabador
                this.contrCon.Disconnect();
                return "001";
            }
            catch (Exception ex)
            {
                return "005";
            }
        
        }
    }
}