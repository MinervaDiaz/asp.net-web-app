using CapaBLL;
using LibrosWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrosWeb.Catalogos.Idiomas
{
    public partial class EditarIdiomas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Titulo.Text = "Registrar Idioma";
                    Subtitulo.Text = "-";
                }
            }
            else { }
        }
        protected void btnGuardarClick(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtnombre.Text;

                BLLIdiomas.InsertarIdioma(nombre);
                Util.SweetBox("Correcto", "Editorial creada con éxito", "success", this.Page, this.GetType());
                Response.Redirect("ListaIdiomas.aspx");
            }
            catch (Exception ex)
            {
                Util.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
            }
        }
    }
}