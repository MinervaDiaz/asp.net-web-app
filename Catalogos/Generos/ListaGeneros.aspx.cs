using CapaBLL;
using LibrosWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace LibrosWeb.Catalogos.Generos
{
    public partial class ListaGeneros : System.Web.UI.Page
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

            GVGeneros.DataSource = BLLGeneros.GetlistGenero();
            GVGeneros.DataBind();
        }

        protected void GVGeneros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string IdGenero = GVGeneros.DataKeys[e.RowIndex].Values["id_genero"].ToString();
                BLLGeneros.DeleteGenero(int.Parse(IdGenero));
                Util.SweetBox("Editorial eliminada con éxito", "", "success", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                Util.SweetBox("Editorial no puede ser eliminada", "", "warning", this.Page, this.GetType());
            }
            RefrescarGrid();
        }
        protected void GVGeneros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //aqui vamos a redireccionar al formulario de editar
            if (e.CommandName == "Select")

            {
                int varIndex = int.Parse(e.CommandArgument.ToString()); //recuperando el indice que lo detonó
                string VarGeneroIDparaenviar = GVGeneros.DataKeys[varIndex].Values["id_genero"].ToString();
                Response.Redirect("EditarGeneros.aspx?Id=" + VarGeneroIDparaenviar);
            }

        }

        protected void GVGeneros_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVGeneros.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVGeneros_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id_genero = GVGeneros.DataKeys[e.RowIndex].Values["id_genero"].ToString();
            string nombre = e.NewValues["nombre"].ToString();

            GeneroVO generoVO = BLLGeneros.GetGeneroById(int.Parse(id_genero));
            BLLGeneros.UpdateGenero(int.Parse(id_genero), nombre);

            GVGeneros.EditIndex = -1;
            RefrescarGrid();
            Util.SweetBox("correcto", "Editorial actualizada con éxito", "success", this.Page, this.GetType());
        }

        protected void GVGeneros_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVGeneros.EditIndex = -1;
            RefrescarGrid();

        }

        public void Insert_Click(object sender, EventArgs e)
        {

            Response.Redirect("EditarGeneros.aspx");
        }
    }
}