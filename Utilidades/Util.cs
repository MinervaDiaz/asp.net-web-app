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
            string s  = "<SCRIPT languaje='javascript'> swal('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "','" + sub.Replace("\r\n", " \\n").Replace("'", "") + "','" + type + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}