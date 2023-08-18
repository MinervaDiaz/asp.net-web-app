<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaGeneros.aspx.cs" Inherits="LibrosWeb.Catalogos.Generos.ListaGeneros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            
            <h4 class="mt-2 mb-2 text-center">Géneros</h4>
            <asp:Button ID="Insert" runat="server" Text="Agregar" ControlStyle-CssClass="btn btn-secondary mb-4 btn-xs col-2 ms-auto me-auto" ItemStyle-Width="10px" OnClick="Insert_Click"/>
            <asp:GridView ID="GVGeneros"
                runat="server"
                CssClass = "table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="id_genero"
                OnRowDeleting="GVGeneros_RowDeleting"
                OnRowCommand =" GVGeneros_RowCommand"
                OnRowEditing =" GVGeneros_RowEditing"
                OnRowUpdating ="GVGeneros_RowUpdating"
                OnRowCancelingEdit ="GVGeneros_RowCancelingEdit"
                >
                <Columns>
                    
                    <asp:BoundField DataField="id_genero" HeaderText="Código" ItemStyle-Width="10%" ReadOnly="true"/>
                    <asp:BoundField DataField="nombre" HeaderText="Genero" ItemStyle-Width="30%"/>

                    <%--<asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" ShowHeader="true" Text="Más info" ControlStyle-CssClass="btn btn-primary btn-xs"/>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="" ShowEditButton="true" ShowHeader="true" ItemStyle-Width="10%" ControlStyle-CssClass="btn btn-info btn-xs" />
                    <asp:CommandField ButtonType="Button" HeaderText="" ShowDeleteButton="true" ShowHeader="true" ItemStyle-Width="10%" ControlStyle-CssClass=" btn btn-danger btn-xs" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
