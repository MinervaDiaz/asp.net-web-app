<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarAutores.aspx.cs" Inherits="LibrosWeb.Catalogos.Autores.EditarAutores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </div>
        <div class="row">
            <asp:Label ID="Titulo" CssClass="text-center modal-title" Text="" runat="server"></asp:Label>
            <asp:Label ID="Subtitulo" CssClass="text-center modal-title" Text="" runat="server"></asp:Label>
        </div>
    </div>
    <div class="container">
        <div class="row">
            
            <asp:Label runat="server" ID="lblnombre"  Text="">Nombre</asp:Label>
            <asp:TextBox runat="server" ID="txtnombre"  CssClass="form-control mb-4"></asp:TextBox>

            <asp:Label runat="server" ID="lblapellido_paterno"  Text="">Apellido paterno</asp:Label>
            <asp:TextBox runat="server" ID="txtapellido_paterno"  CssClass="form-control mb-4"></asp:TextBox>

            <asp:Label ID="lblapellido_materno" runat="server" Text="">Apellido Materno</asp:Label>
            <asp:TextBox runat="server"  ID="txtapellido_materno" CssClass="form-control mb-4" ></asp:TextBox>

            <asp:Label ID="lblpais" runat="server" Text="">Pais</asp:Label>
            <asp:DropDownList runat="server" ID="DDLPais" CssClass="mb-5"></asp:DropDownList>

            <asp:Label ID="lblimagen" runat="server"></asp:Label>
                <input type="file" id="SubeImagen" runat="server" class="btn btn-file"/>
                <asp:Button ID="btnSubeImagen" runat="server" CssClass="btn btn-primary" Text="subir imagen" OnClick="btnSubeImagen_Click" />

                <asp:Label ID="lblFoto" runat="server" CssClass="btn btn_primary" Text="Subir Imagen">Imagen</asp:Label>
                <asp:Image ID="imgfoto" Width="100" Height="100" runat="server" />
                <asp:Image ID="imgfotoautor" Width="100" Height="100" runat="server" />
                <asp:Label ID="urlFoto" runat="server"></asp:Label>

            <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarClick"/>
        </div>
    </div>
</asp:Content>
