<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TP_Web_Carrito.Carrito" %>

<asp:Content ID="Carrito" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col">
            <h1>Mi Carrito</h1>
            <table class="table">
                <thead>
                    <tr>
                        <th>Imagen</th>
                        <th>Descripción</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repCarrito" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROGVlwDhbC-6RixbdgEwDrABJ6BD3hhM2eJA&usqp=CAU" ID="imgCarrito" runat="server" Width="60%" />
                                <td><%# Eval("Descripcion") %></td>
                                <td>
                                    <asp:Button Text="Seguir Comprando" ID="btnSeguir" OnClick="btnSeguir_Click" CssClass="btn btn-primary" runat="server" />
                                    <asp:Button runat="server" OnClick="btnEliminarDelCarrito_Click" CommandArgument='<%#Eval("Id") %>' Text="Eliminar del Carrito" ID="btnEliminarDelCarrito" CssClass="btn btn-danger" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>

    <asp:Label ID="lblPrecioTotal" runat="server" Text="Precio Total: $" CssClass="precio-total"></asp:Label>
</asp:Content>
