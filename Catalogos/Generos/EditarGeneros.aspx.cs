using CapaBLL;
using LibrosWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace LibrosWeb.Catalogos.Generos
{
    public partial class EditarGeneros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Titulo.Text = "Registrar Genero";
                    Subtitulo.Text = "";
                }
            }
            else { }
        }
        protected void btnGuardarClick(object sender, EventArgs e)
        {
                try
                {
                    string nombre = txtnombre.Text;

                    BLLGeneros.InsertarGenero(nombre);
                    Util.SweetBox("Correcto", "Genero creado con éxito", "success", this.Page, this.GetType());
                    Response.Redirect("ListaGeneros.aspx");
                }
                catch (Exception ex)
                {
                    Util.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
                }
         }
    }
}