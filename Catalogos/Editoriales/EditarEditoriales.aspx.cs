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

namespace LibrosWeb.Catalogos.Editoriales
{
    public partial class EditarEditoriales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Titulo.Text = "Registrar Editorial";
                    Subtitulo.Text = "";
                }
                else
                {
                    int varIdEditorial = int.Parse(Request.QueryString["Id"]);
                    EditorialVO editorialVO = BLLEditoriales.GetEditorialById(varIdEditorial);

                    Titulo.Text = "Editar Editorial";
                    Subtitulo.Text = "Editorial con código: " + varIdEditorial.ToString(); ;
                    
                    if (editorialVO.id_editorial != 0)
                    {
                        
                        this.txtnombre.Text = editorialVO.nombre;
                        this.txtciudad.Text = editorialVO.ciudad;
                        this.txttelefono.Text = editorialVO.telefono;
                        this.txtemail.Text = editorialVO.email;
                        this.imgfotoeditorial.ImageUrl = editorialVO.url_foto;
                        this.urlFoto.Text = editorialVO.url_foto;
                    }
                    else
                    {
                        Util.SweetBox("Ops...", "No se encontró la editorial", "Danger", this.Page, this.GetType());
                        Response.Redirect("ListaEditoriales.aspx");
                    }
                }
            }
            else{}
        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {

            if (SubeImagen.Value != "")
            {
                string FileName = Path.GetFileName(SubeImagen.PostedFile.FileName);
                //vamos a validar la extension del archivo
                string FileExt = Path.GetExtension(FileName).ToLower();
                if ((FileExt != ".jpg") && (FileExt != ".png"))
                {
                    //con este manipulamos los errores, o la explicacion de los errores
                    Util.SweetBox("error", "Seleccione un archivo válido ('.jpg/.png')", "error", this.Page, this.GetType());
                }
                else
                {
                    string pathdir = Server.MapPath("~/Imagenes/Editoriales/");
                    if (!Directory.Exists(pathdir))
                    {
                        Directory.CreateDirectory(pathdir);
                    }
                    SubeImagen.PostedFile.SaveAs(pathdir + FileName);

                    string urlfoto = "/Imagenes/Editoriales/" + FileName;
                    urlFoto.Text = urlfoto;

                    imgfoto.ImageUrl = urlfoto;
                    btnGuardar.Visible = true;
                }
            }
            else
            {
                Util.SweetBox("error", "Seleccione un archivo", "error", this.Page, this.GetType());
            }
        }

        protected void btnGuardarClick(object sender, EventArgs e)
        {

            if (Request.QueryString["Id"] == null)
            {
                try // usar el try catch para controlar las variables de ños mensajitos de salida
                {
                    string nombre = txtnombre.Text;
                    string ciudad = txtciudad.Text;
                    string telefono = txttelefono.Text;
                    string email = txtemail.Text;
                    string url_foto = urlFoto.Text;

                    BLLEditoriales.InsertarEditorial(nombre, ciudad, telefono, email, url_foto);
                    Util.SweetBox("Correcto", "Editorial creada con éxito", "success", this.Page, this.GetType());

//                    Response.Redirect("ListaEditoriales.aspx");
                }
                catch (Exception ex)
                {
                    Util.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
                }
            }
            else
            {
                try
                {
                    string nombre = txtnombre.Text;
                    string telefono = txttelefono.Text;
                    string ciudad = txtciudad.Text;
                    string email = txtemail.Text;
                    string urlfoto = urlFoto.Text;
                    //genero mi objeto editorialVO
                    EditorialVO editorialVO = BLLEditoriales.GetEditorialById(int.Parse(Request.QueryString["Id"].Trim()));
                    BLLEditoriales.UpdateEditorial(editorialVO.id_editorial, nombre, telefono, ciudad, email, urlfoto);

                    //succes: marcar palomitas
                    Util.SweetBox("Correcto", "Editorial actualizada con éxito", "success", this.Page, this.GetType());
                }
                catch (Exception ex)
                {
                    Util.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
                }
            }

        }


    }
}