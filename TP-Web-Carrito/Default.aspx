<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Web_Carrito._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="display-4 text-center">Listado de artículos</h1>
    <main>
        <div class="container">
            <div class="row row-cols-1 row-cols-md-4 g-4">
                <asp:Repeater ID="repArticulos" runat="server">
                    <ItemTemplate>
                        <div class="card" style="width: 18rem;">
                            <asp:Repeater ID="repImagenes" runat="server" DataSource='<%# Eval("Imagenes") %>'>
                                <ItemTemplate>
                                    <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
                                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="Error al cargar imagen">
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <div>
                                    <p class="card-price m-0">$<%# string.Format("{0:N2}", Eval("Precio")) %></p>
                                </div>
                                <p class="card-text"><%#Eval("Descripcion") %></p>
                                <div class="text-center">
                                    <a href='<%# "AltaArticulo.aspx?id=" + Eval("Id") %>' class="btn btn-primary">Ver Detalle</a>
                                    <asp:Button Text="Agregar" ID="btnAgregarAlCarrito" OnClick="btnAgregarAlCarrito_Click" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-success" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </main>

</asp:Content>
