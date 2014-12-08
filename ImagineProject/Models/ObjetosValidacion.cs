using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImagineProject.Models
{
    public class ObjetosValidacion
    {
        static TagBuilder mensaje = null;

        public static TagBuilder Mensaje(string texto)
        {
            mensaje = new TagBuilder("span");
            mensaje.Attributes.Add("class", "field-validation-error");
            if (!string.IsNullOrEmpty(texto))
            {
                mensaje.SetInnerText(texto);
            }
            return mensaje;
        }
    }
}