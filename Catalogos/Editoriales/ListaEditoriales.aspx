<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaEditoriales.aspx.cs" Inherits="LibrosWeb.Catalogos.Editoriales.ListaEditoriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            
            <h4 class="mt-2 mb-2 text-center">Editoriales</h4>
            <asp:Button ID="Insert" runat="server" Text="Agregar" ControlStyle-CssClass="btn btn-secondary mb-4 btn-xs col-2 ms-auto me-auto" ItemStyle-Width="10px" OnClick="Insert_Click"/>
            <asp:GridView ID="GVEditoriales"
                runat="server"
                CssClass = "table table-bordered table-striped table-condensed table-hover"
                AutoGenerateColumns="false"
                DataKeyNames="id_editorial"
                OnRowDeleting="GVEditoriales_RowDeleting"
                OnRowCommand =" GVEditoriales_RowCommand"
                OnRowEditing =" GVEditoriales_RowEditing"
                OnRowUpdating ="GVEditoriales_RowUpdating"
                OnRowCancelingEdit ="GVEditoriales_RowCancelingEdit"
                >
                <Columns>
                    
                    <asp:BoundField DataField="id_editorial" HeaderText="Código" ItemStyle-Width="10px" ReadOnly="true" ControlStyle-CssClass=""/>
                    <asp:ImageField HeaderText="Foto" ReadOnly="true" ControlStyle-Width="160px" DataImageUrlField="url_foto">
                    </asp:ImageField>
                    <asp:BoundField DataField="nombre" HeaderText="Editorial" ItemStyle-Width="15%"/>
                    <asp:BoundField DataField="ciudad" HeaderText="Ciudad" ItemStyle-Width="15%"/>
                    <asp:BoundField DataField="telefono" HeaderText="Teléfono" ItemStyle-Width="15%"/>
                    <asp:BoundField DataField="email" HeaderText="Email" ItemStyle-Width="15%"/>
                    <%--<asp:BoundField DataField="url_foto" HeaderText="url_foto" ItemStyle-Width="10%"/>--%>

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="" ShowHeader="true" Text="Editar" ControlStyle-CssClass="btn btn-info btn-xs"/>
                    <%--<asp:CommandField ButtonType="Button" HeaderText="3" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass=" btn btn-success btn-xs" />--%>
                    <asp:CommandField ButtonType="Button" HeaderText="" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass=" btn btn-danger btn-xs" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
