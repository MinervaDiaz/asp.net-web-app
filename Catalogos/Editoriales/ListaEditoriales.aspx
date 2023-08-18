<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaEditoriales.aspx.cs" Inherits="LibrosWeb.Catalogos.Editoriales.ListaEditoriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            
            <h3 class="text-secondary text-center">Lista de editoriales</h3>
            <asp:Button ID="Insert" runat="server" Text="Agregar editorial" ControlStyle-CssClass="btn btn-warning m-2 btn-xs col-2" ItemStyle-Width="10px" OnClick="Insert_Click"/>
            <asp:GridView ID="GVEditoriales"
                runat="server"
                CssClass = "table table-bordered table-striped table-condensed table-hover text-center"
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
                    <asp:BoundField DataField="nombre" HeaderText="Nombre Editorial" ItemStyle-Width="15%"/>
                    <asp:BoundField DataField="ciudad" HeaderText="Ciudad" ItemStyle-Width="15%"/>
                    <asp:BoundField DataField="telefono" HeaderText="Telefono" ItemStyle-Width="15%"/>
                    <asp:BoundField DataField="email" HeaderText="Email" ItemStyle-Width="15%"/>
                    <%--<asp:BoundField DataField="url_foto" HeaderText="url_foto" ItemStyle-Width="10%"/>--%>

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="" ShowHeader="true" Text="Más info" ControlStyle-CssClass="btn btn-primary btn-xs"/>
                    <%--<asp:CommandField ButtonType="Button" HeaderText="3" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass=" btn btn-success btn-xs" />--%>
                    <asp:CommandField ButtonType="Button" HeaderText="" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass=" btn btn-danger btn-xs" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
