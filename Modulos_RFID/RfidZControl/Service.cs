using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RfidZOperadorAscii;
using RfidZOperador;

namespace RfidZControl
{
    public static class Service
    {
        private static AsciiExecute reader;
        private static ConnexionBase conn;
        private static Ajustes ajustes;
        
        public static AsciiExecute Reader
        {
            get
            {
                return reader;
            }

            set
            {
                reader = value;
            }
        }

        public static ConnexionBase Connect
        {
            get
            {
                return conn;
            }

            set
            {
                conn = value;
            }
        }

        public static Ajustes Ajustes
        {
            get
            {
                if (ajustes == null)
                {
                    ajustes = new Ajustes();
                }

                return ajustes;
            }

            set
            {
                ajustes = value;
            }
        }
    }
}
