using CapaBLL;
using LibrosWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace LibrosWeb.Catalogos.Autores
{
    public partial class ListaAutores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    RefrescarGrid();
                }
                catch (Exception)
                {

                }
            }
        }
        public void RefrescarGrid()
        {

            GVAutores.DataSource = BLLAutores.GetlistAutores();
            GVAutores.DataBind();
        }
        protected void GVAutores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string IdAutor = GVAutores.DataKeys[e.RowIndex].Values["id_autor"].ToString();
                BLLAutores.DeleteAutor(int.Parse(IdAutor));
                Util.SweetBox("Autor eliminado con éxito", "", "success", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                Util.SweetBox("Autor no puede ser eliminado", "", "warning", this.Page, this.GetType());
            }
            RefrescarGrid();
        }
        protected void GVAutores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //aqui vamos a redireccionar al formulario de editar
            if (e.CommandName == "Select")

            {
                int varIndex = int.Parse(e.CommandArgument.ToString()); //recuperando el indice que lo detonó
                string VarAutorIDparaenviar = GVAutores.DataKeys[varIndex].Values["id_autor"].ToString();
                Response.Redirect("EditarAutores.aspx?Id=" + VarAutorIDparaenviar);
            }

        }

        protected void GVAutores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVAutores.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVAutores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id_autor = GVAutores.DataKeys[e.RowIndex].Values["id_autor"].ToString();
            string nombre = e.NewValues["nombre"].ToString();
            string apellido_paterno = e.NewValues["apellido_paterno"].ToString();
            string apellido_materno = e.NewValues["apellido_materno"].ToString();
            string pais_id = e.NewValues["pais_id"].ToString();
            string url_foto = e.NewValues["url_foto"].ToString();


            AutorVO AutorVO = BLLAutores.GetAutorById(int.Parse(id_autor));
            BLLAutores.UpdateAutor(int.Parse(id_autor), nombre, apellido_paterno, apellido_materno, int.Parse(pais_id), url_foto);

            GVAutores.EditIndex = -1;
            RefrescarGrid();
            Util.SweetBox("correcto", "Autor actualizado con éxito", "success", this.Page, this.GetType());
        }

        protected void GVAutores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVAutores.EditIndex = -1;
            RefrescarGrid();

        }

        public void Insert_Click(object sender, EventArgs e)
        {

            Response.Redirect("EditarAutores.aspx");
        }
    }
}