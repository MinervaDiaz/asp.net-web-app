using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace LibrosWeb.Utilidades
{
    public class Util
    {
        //este sweet box abrirá una alertita
        public static void SweetBox(String ex, String sub, String type, Page pg, Object obj)
        {
            //libreria JS con la propiedad SWAL
            string s = "<SCRIPT languaje='javascript'> swal('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "','" + sub.Replace("\r\n", " \n").Replace("'", "") + "','" + type + "'); </SCRIPT>";

            //a partir de aqui es puro C#
            //recuperar el tipo de objeto que estamos trabajando, alerta, popup...
            Type cstype = obj.GetType();

            //.net framework, propiedad MCLIENTSCRIPTMANAGER se le inyecta el script de JS
            ClientScriptManager cs = pg.ClientScript;
            //vamos a usa elemento de ADO NET en la sig linea
            //registra un bloque de js. SE PASA DE JS a C#
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}