<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaPaises.aspx.cs" Inherits="LibrosWeb.Catalogos.Paises.ListaPaises" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            
            <h3>Lista de Paises</h3>
            <asp:Button ID="Insert" runat="server" Text="Agregar pais" ControlStyle-CssClass="btn btn-warning m-2 btn-xs col-2" ItemStyle-Width="10px" OnClick="Insert_Click"/>
            <asp:GridView ID="GVPaises"
                runat="server"
                CssClass = "table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="id_pais"
                OnRowDeleting="GVPaises_RowDeleting"
                OnRowCommand =" GVPaises_RowCommand"
                OnRowEditing =" GVPaises_RowEditing"
                OnRowUpdating ="GVPaises_RowUpdating"
                
                >
                <Columns>
                    
                    <asp:BoundField DataField="id_pais" HeaderText="Código pais" ItemStyle-Width="50px" ReadOnly="true"/>
                    <asp:BoundField DataField="nombre" HeaderText="Pais" ItemStyle-Width="15%"/>

                    <%--<asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" ShowHeader="true" Text="Más info" ControlStyle-CssClass="btn btn-primary btn-xs"/>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="3" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass=" btn btn-success btn-xs" />
                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass=" btn btn-danger btn-xs" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
