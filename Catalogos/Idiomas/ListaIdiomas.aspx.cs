﻿using CapaBLL;
using LibrosWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace LibrosWeb.Catalogos.Idiomas
{
    public partial class ListaIdiomas : System.Web.UI.Page
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

            GVIdiomas.DataSource = BLLIdiomas.GetlistIdioma();
            GVIdiomas.DataBind();
        }

        protected void GVIdiomas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string IdIdioma = GVIdiomas.DataKeys[e.RowIndex].Values["id_idioma"].ToString();
                BLLIdiomas.DeleteIdioma(int.Parse(IdIdioma));
                Util.SweetBox("Idioma eliminado con éxito", "", "success", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                Util.SweetBox("Idioma no puede ser eliminado", "", "warning", this.Page, this.GetType());
            }
            RefrescarGrid();
        }
        protected void GVIdiomas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //aqui vamos a redireccionar al formulario de editar
            if (e.CommandName == "Select")

            {
                int varIndex = int.Parse(e.CommandArgument.ToString()); //recuperando el indice que lo detonó
                string VarIdiomaIDparaenviar = GVIdiomas.DataKeys[varIndex].Values["id_idioma"].ToString();
                Response.Redirect("EditarIdiomas.aspx?Id=" + VarIdiomaIDparaenviar);
            }

        }

        protected void GVIdiomas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVIdiomas.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVIdiomas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id_idioma = GVIdiomas.DataKeys[e.RowIndex].Values["id_idioma"].ToString();
            string nombre = e.NewValues["nombre"].ToString();

            IdiomaVO idiomaVO = BLLIdiomas.GetIdiomaById(int.Parse(id_idioma));
            BLLIdiomas.UpdateIdioma(int.Parse(id_idioma), nombre);

            GVIdiomas.EditIndex = -1;
            RefrescarGrid();
            Util.SweetBox("correcto", "Editorial actualizada con éxito", "success", this.Page, this.GetType());
        }

        protected void GVIdiomas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVIdiomas.EditIndex = -1;
            RefrescarGrid();

        }

        public void Insert_Click(object sender, EventArgs e)
        {

            Response.Redirect("EditarIdiomas.aspx");
        }
    }
}