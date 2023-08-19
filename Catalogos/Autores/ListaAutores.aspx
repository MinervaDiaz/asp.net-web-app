<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaAutores.aspx.cs" Inherits="LibrosWeb.Catalogos.Autores.ListaAutores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">

            <h4 class="mt-2 mb-2 text-center">Autores</h4>
            <asp:Button ID="Insert" runat="server" Text="Agregar" ControlStyle-CssClass="btn btn-secondary mb-4 btn-xs col-2 ms-auto me-auto" ItemStyle-Width="10px" OnClick="Insert_Click"/>
            <asp:GridView ID="GVAutores"
                runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="id_autor"
                OnRowDeleting="GVAutores_RowDeleting"
                OnRowCommand =" GVAutores_RowCommand"
                OnRowEditing =" GVAutores_RowEditing"
                OnRowUpdating ="GVAutores_RowUpdating"
                OnRowCancelingEdit ="GVAutores_RowCancelingEdit"
            >
                <Columns>

                    <asp:BoundField DataField="id_autor" HeaderText="Código" ItemStyle-Width="10%" ReadOnly="true" />
                    <asp:ImageField HeaderText="Foto" ReadOnly="true" ItemStyle-Width="15%" ControlStyle-Height="120px" ControlStyle-Width="120px" DataImageUrlField="url_foto">
                    </asp:ImageField>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" ItemStyle-Width="15%" />
                    <asp:BoundField DataField="apellido_paterno" HeaderText="Ap Paterno" ItemStyle-Width="15%" />
                    <asp:BoundField DataField="apellido_materno" HeaderText="Ap Materno" ItemStyle-Width="15%" />
                    <asp:BoundField DataField="pais_id" HeaderText="Código de país" ItemStyle-Width="15%" />



                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="" ShowHeader="true" Text="Editar" ControlStyle-CssClass="btn btn-primary btn-xs"/>
                    <%--<asp:CommandField ButtonType="Button" HeaderText="3" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass=" btn btn-success btn-xs" />--%>
                    <asp:CommandField ButtonType="Button" HeaderText="" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass=" btn btn-danger btn-xs" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
