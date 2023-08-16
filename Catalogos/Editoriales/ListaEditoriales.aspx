<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaEditoriales.aspx.cs" Inherits="LibrosWeb.Catalogos.Editoriales.ListaEditoriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            
            <h3>Lista de editoriales</h3>
            <asp:Button ID="Insert" runat="server" Text="Agregar editorial" ControlStyle-CssClass="btn btn-warning m-2 btn-xs col-2" ItemStyle-Width="10px" OnClick="Insert_Click"/>
            <asp:GridView ID="GVEditoriales"
                runat="server"
                CssClass = "table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="id_editorial"
                OnRowDeleting="GVEditoriales_RowDeleting"
                OnRowCommand =" GVEditoriales_RowCommand"
                OnRowEditing =" GVEditoriales_RowEditing"
                OnRowUpdating ="GVEditoriales_RowUpdating"
                OnRowCancelingEdit ="GVEditoriales_RowCancelingEdit"
                >
                <Columns>
                    
                    <asp:BoundField DataField="id_editorial" HeaderText="Código editorial" ItemStyle-Width="50px" ReadOnly="true"/>
                    <asp:ImageField HeaderText="Foto" ReadOnly="true" ItemStyle-Width="120px" ControlStyle-Height="120px" ControlStyle-Width="120px" DataImageUrlField="url_foto">
                    </asp:ImageField>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre Editorial" ItemStyle-Width="15%"/>
                    <asp:BoundField DataField="ciudad" HeaderText="Ciudad" ItemStyle-Width="15%"/>
                    <asp:BoundField DataField="telefono" HeaderText="Telefono" ItemStyle-Width="15%"/>
                    <asp:BoundField DataField="email" HeaderText="Email" ItemStyle-Width="15%"/>
                    <asp:BoundField DataField="url_foto" HeaderText="url_foto" ItemStyle-Width="15%"/>

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" ShowHeader="true" Text="Más info" ControlStyle-CssClass="btn btn-primary btn-xs"/>
                    <%--<asp:CommandField ButtonType="Button" HeaderText="3" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass=" btn btn-success btn-xs" />--%>
                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass=" btn btn-danger btn-xs" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
