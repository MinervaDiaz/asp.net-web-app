using CapaBLL;
using LibrosWeb.Utilidades;
using System;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using VO;

namespace LibrosWeb.Catalogos.Editoriales
{
    public partial class ListaEditoriales : System.Web.UI.Page
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
            
            GVEditoriales.DataSource = BLLEditoriales.GetlistEditorial();
            GVEditoriales.DataBind();
        }
        protected void GVEditoriales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IdEditorial = GVEditoriales.DataKeys[e.RowIndex].Values["id_editorial"].ToString();
            string resultado = BLLEditoriales.DeleteEditorial(int.Parse(IdEditorial));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (resultado)
            {
                case "1":
                    mensaje = "Editorial eliminada con éxito";
                    sub = "";
                    clase = "success";
                    break;
                case "0":
                    mensaje = "Esta editorial no se puede eliminar";
                    sub = "";
                    clase = "warning";
                    break;
            }
                Util.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
                RefrescarGrid();

        }
        protected void GVEditoriales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //aqui vamos a redireccionar al formulario de editar
            if (e.CommandName == "Select")

            {
                int varIndex = int.Parse(e.CommandArgument.ToString()); //recuperando el indice que lo detonó
                string VareditorialIDparaenviar = GVEditoriales.DataKeys[varIndex].Values["id_editorial"].ToString();
                Response.Redirect("EditarEditoriales.aspx?Id=" + VareditorialIDparaenviar);
            }

        }

        protected void GVEditoriales_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVEditoriales.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVEditoriales_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id_editorial = GVEditoriales.DataKeys[e.RowIndex].Values["id_editorial"].ToString();
            string nombre = e.NewValues["nombre"].ToString();
            string ciudad = e.NewValues["ciudad"].ToString();
            string telefono = e.NewValues["telefono"].ToString();
            string email = e.NewValues["email"].ToString();
            string url_foto = e.NewValues["url_foto"].ToString();


            EditorialVO editorialVO = BLLEditoriales.GetEditorialById(int.Parse(id_editorial));
            BLLEditoriales.UpdateEditorial(int.Parse(id_editorial), nombre, ciudad, telefono, email, url_foto);

            GVEditoriales.EditIndex = -1;
            RefrescarGrid();
            Util.SweetBox("correcto", "Editorial actualizada con éxito", "success", this.Page, this.GetType());
        }

        protected void GVEditoriales_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVEditoriales.EditIndex = -1;
            RefrescarGrid();

        }

        public void Insert_Click(object sender, EventArgs e) { 
        
            Response.Redirect("EditarEditoriales.aspx");
        }
    }
}