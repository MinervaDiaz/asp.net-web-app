<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaAutores.aspx.cs" Inherits="LibrosWeb.Catalogos.Autores.ListaAutores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">

            <h3>Lista de Autores</h3>
            <asp:Button ID="Insert" runat="server" Text="Agregar autor" ControlStyle-CssClass="btn btn-warning m-2 btn-xs col-2" ItemStyle-Width="10px" OnClick="Insert_Click" />
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

                    <asp:BoundField DataField="id_autor" HeaderText="Código autor" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:ImageField HeaderText="Foto" ReadOnly="true" ItemStyle-Width="120px" ControlStyle-Height="120px" ControlStyle-Width="120px" DataImageUrlField="url_foto">
                    </asp:ImageField>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre Autor" ItemStyle-Width="15%" />
                    <asp:BoundField DataField="apellido_paterno" HeaderText="Ap Paterno" ItemStyle-Width="15%" />
                    <asp:BoundField DataField="apellido_materno" HeaderText="Ap Materno" ItemStyle-Width="15%" />
                    <asp:BoundField DataField="pais_id" HeaderText="Código Pais" ItemStyle-Width="15%" />
                    <asp:BoundField DataField="url_foto" HeaderText="url_foto" ItemStyle-Width="15%" />

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="" ShowHeader="true" Text="Más info" ControlStyle-CssClass="btn btn-primary btn-xs"/>
                    <%--<asp:CommandField ButtonType="Button" HeaderText="3" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass=" btn btn-success btn-xs" />--%>
                    <asp:CommandField ButtonType="Button" HeaderText="" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass=" btn btn-danger btn-xs" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
