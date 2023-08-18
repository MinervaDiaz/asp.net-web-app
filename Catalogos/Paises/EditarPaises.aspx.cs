using CapaBLL;
using LibrosWeb.Utilidades;
using System;

namespace LibrosWeb.Catalogos.Paises
{
    public partial class EditarPaises : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Titulo.Text = "Registrar Pais";
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

                BLLPaises.InsertarPais(nombre);
                Util.SweetBox("Correcto", "Pais creado con éxito", "success", this.Page, this.GetType());
                Response.Redirect("ListaPaises.aspx");
            }
            catch (Exception ex)
            {
                Util.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
            }
        }
    }
}