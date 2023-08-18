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

namespace LibrosWeb.Catalogos.Autores
{
    public partial class EditarAutores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDDL();
                if (Request.QueryString["Id"] == null)
                {
                    Titulo.Text = "Registrar Autor";
                    Subtitulo.Text = "";
                }
                else
                {
                    int varIdAutor = int.Parse(Request.QueryString["Id"]);
                    AutorVO autorVO = BLLAutores.GetAutorById(varIdAutor);

                    Titulo.Text = "Editar Autor";
                    Subtitulo.Text = "Código del autor: " + varIdAutor.ToString(); ;

                    if (autorVO.id_autor != 0)
                    {
                        this.txtnombre.Text = autorVO.nombre;
                        this.txtapellido_paterno.Text = autorVO.apellido_paterno;
                        this.txtapellido_materno.Text = autorVO.apellido_materno;
                        this.imgfotoautor.ImageUrl = autorVO.url_foto;
                        this.urlFoto.Text = autorVO.url_foto;
                        DDLPais.SelectedValue = autorVO.pais_id.ToString();

                    }
                    else
                    {
                        Util.SweetBox("Ops...", "No se encontró el autor", "Danger", this.Page, this.GetType());
                        Response.Redirect("ListaEditoriales.aspx");
                    }
                }
            }
            else { }
        }

        private void CargarDDL()
        {
            ListItem DDL = new ListItem("Selecciona un pais", "0");
            DDLPais.Items.Add(DDL);
            //recupero la informacion con que voy a llenar mi DDL (una lista de N objetos)
            List<PaisVO> list_paises = BLLPaises.GetlistPais();
            //Valido si mi lista tiene objetos
            if (list_paises.Count > 0)
            {
                foreach (PaisVO aut in list_paises)
                {
                    //por cada iteracion cree un nuevo ListItem con el camión de la lista
                    ListItem i1 = new ListItem(aut.nombre, aut.id_pais.ToString());
                    //Por cada iteración añado dicho elemento al DDL
                    DDLPais.Items.Add(i1);
                }
            }
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
                    string pathdir = Server.MapPath("~/Imagenes/Autores/");
                    if (!Directory.Exists(pathdir))
                    {
                        Directory.CreateDirectory(pathdir);
                    }
                    SubeImagen.PostedFile.SaveAs(pathdir + FileName);

                    string urlfoto = "/Imagenes/Autores/" + FileName;
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
                    string apellido_paterno = txtapellido_paterno.Text;
                    string apellido_materno = txtapellido_materno.Text; ;
                    int pais_id = int.Parse(DDLPais.SelectedValue); ;
                    string url_foto = urlFoto.Text;

                    BLLAutores.InsertarAutores(nombre, apellido_paterno, apellido_materno, pais_id, url_foto);
                    Util.SweetBox("Correcto", "Autor creado con éxito", "success", this.Page, this.GetType());

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
                    string apellido_paterno = txtapellido_paterno.Text;
                    string apellido_materno = txtapellido_materno.Text;
                    int pais_id = int.Parse(DDLPais.SelectedValue); ;
                    string urlfoto = urlFoto.Text;
                    //genero mi objeto editorialVO
                    AutorVO autorVO = BLLAutores.GetAutorById(int.Parse(Request.QueryString["Id"].Trim()));
                    BLLAutores.UpdateAutor(autorVO.id_autor, nombre, apellido_paterno, apellido_materno, pais_id, urlfoto);

                    //succes: marcar palomitas
                    Util.SweetBox("Correcto", "Editorial agregada con éxito", "success", this.Page, this.GetType());
                }
                catch (Exception ex)
                {
                    Util.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
                }
            }

        }
    }
}