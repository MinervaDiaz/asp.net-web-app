<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarPaises.aspx.cs" Inherits="LibrosWeb.Catalogos.Paises.EditarPaises" %>
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
                <asp:Label ID="lblpais" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblnombre" runat="server" Text="" >Nombre</asp:Label>
                <asp:TextBox ID="txtnombre" runat="server" placeholder=""  CssClass="form-control" required="true"></asp:TextBox>

                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarClick"/>
            </div>
        </div>
    </div>
</asp:Content>
