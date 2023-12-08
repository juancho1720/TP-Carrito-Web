<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="TP_Web_Carrito.AltaArticulo" %>

<asp:Content ID="conAltaArticulo" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtMarca" class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarcas" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtCategoria" class="form-label">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategorias" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary"  runat="server" />
                <asp:Button Text="Eliminar" ID="btnEliminar" Onclick="btnEliminar_Click" CssClass="btn btn-primary"  runat="server" />
                <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-primary"  runat="server" />
            </div>
        </div>
        <div class="col-6">
            <asp:UpdatePanel runat="server" ID="UpdateImage">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtUrlImagen" class="form-label">Url Imagen</label>
                        <asp:TextBox ID="txtUrlImagen" OnTextChanged="txtUrlImagen_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROGVlwDhbC-6RixbdgEwDrABJ6BD3hhM2eJA&usqp=CAU" ID="imgArticulo" runat="server" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
