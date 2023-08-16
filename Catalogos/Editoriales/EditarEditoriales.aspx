<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarEditoriales.aspx.cs" Inherits="LibrosWeb.Catalogos.Editoriales.EditarEditoriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" CssClass="text-center modal-title" Text="" runat="server"></asp:Label>
            <asp:Label ID="Subtitulo" CssClass="text-center modal-title" Text="" runat="server"></asp:Label>
        </div>
    </div>
    <%-- FORMULARIO--%>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="lblideditorial" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblnombre" runat="server" Text="" >Nombre</asp:Label>
                <asp:TextBox ID="txtnombre" runat="server" placeholder=""  CssClass="form-control" required="true"></asp:TextBox>
                <asp:Label ID="lblciudad" runat="server" Text="" >Ciudad</asp:Label>
                <asp:TextBox ID="txtciudad" runat="server" placeholder=""  CssClass="form-control" ></asp:TextBox>
                <asp:Label ID="lcltelefono" runat="server" Text="" >Telefono</asp:Label>
                <asp:TextBox ID="txttelefono" runat="server" placeholder=""  CssClass="form-control" ></asp:TextBox>

                <%--//AJAX SERVER se corre en el servidor y se e¿usa parapeticiones vacias--%>
                <asp:Label ID="lblemail" runat="server" Text="">Correo electrónico</asp:Label>
                <asp:TextBox ID="txtemail" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblimagen" runat="server"></asp:Label>
                <input type="file" id="SubeImagen" runat="server" class="btn btn-file"/>
                <asp:Button ID="btnSubeImagen" runat="server" CssClass="btn btn-primary" Text="subir imagen" OnClick="btnSubeImagen_Click" />

                <asp:Label ID="lblFoto" runat="server" CssClass="btn btn_primary" Text="Subir Imagen">Imagen</asp:Label>
                <asp:Image ID="imgfoto" Width="100" Height="100" runat="server" />
                <asp:Image ID="imgfotoeditorial" Width="100" Height="100" runat="server" />
                <asp:Label ID="urlFoto" runat="server"></asp:Label>

                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarClick"/>
            </div>
        </div>
    </div>
</asp:Content>
