using CapaBLL;
using LibrosWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace LibrosWeb.Catalogos.Paises
{
    public partial class ListaPaises : System.Web.UI.Page
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

            GVPaises.DataSource = BLLPaises.GetlistPais();
            GVPaises.DataBind();
        }

        protected void GVPaises_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string IdPais = GVPaises.DataKeys[e.RowIndex].Values["id_pais"].ToString();
                BLLPaises.DeletePais(int.Parse(IdPais));
                Util.SweetBox("País eliminado con éxito", " ", "success", this.Page, this.GetType());
            }
            catch (Exception ex)
            {
                Util.SweetBox("Este país no puede ser eliminado", "", "warning", this.Page, this.GetType());
            }
            RefrescarGrid();
        }
        protected void GVPaises_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //aqui vamos a redireccionar al formulario de editar
            if (e.CommandName == "Select")

            {
                int varIndex = int.Parse(e.CommandArgument.ToString()); //recuperando el indice que lo detonó
                string VarPaisIDparaenviar = GVPaises.DataKeys[varIndex].Values["id_pais"].ToString();
                Response.Redirect("EditarPaises.aspx?Id=" + VarPaisIDparaenviar);
            }

        }

        protected void GVPaises_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVPaises.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVPaises_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id_pais = GVPaises.DataKeys[e.RowIndex].Values["id_pais"].ToString();
            string nombre = e.NewValues["nombre"].ToString();

            PaisVO paisVO = BLLPaises.GetPaisById(int.Parse(id_pais));
            BLLPaises.UpdatePais(int.Parse(id_pais), nombre);

            GVPaises.EditIndex = -1;
            RefrescarGrid();
            Util.SweetBox("correcto", "Pais actualizado con éxito", "success", this.Page, this.GetType());
        }

        protected void GVIdiomas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVPaises.EditIndex = -1;
            RefrescarGrid();

        }

        public void Insert_Click(object sender, EventArgs e)
        {

            Response.Redirect("EditarPaises.aspx");
        }
    }
}