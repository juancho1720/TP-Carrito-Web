using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Web_Carrito
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Articulo> carrito = Session["Carrito"] as List<Articulo>;
                ImagenNegocio _negocio = new ImagenNegocio();

                if (carrito != null)
                {
                    _negocio.CargarListas(carrito);
                    repCarrito.DataSource = carrito;
                    repCarrito.DataBind();

                    

                    if (carrito.Count > 0)
                    {
                        decimal precioTotal = carrito.Sum(articulo => articulo.Precio);
                        lblPrecioTotal.Text = "Precio Total: $" + precioTotal.ToString("N2");
                    }
                    else
                    {
                        lblPrecioTotal.Text = "No hay elementos en el carrito";
                    }
                }
                else
                {
                    lblPrecioTotal.Text = "No hay elementos en el carrito";
                }
            }
            
        }

        protected void btnSeguir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnEliminarDelCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string articuloIdStr = btn.CommandArgument;

            if (int.TryParse(articuloIdStr, out int articuloId))
            {
                List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

                if (carrito != null)
                {
                    Articulo articuloAEliminar = carrito.FirstOrDefault(a => a.Id == articuloId);

                    if (articuloAEliminar != null)
                    {
                        carrito.Remove(articuloAEliminar);
                    }

                    Session["Carrito"] = carrito;
                }
                
                Response.Redirect("Carrito.aspx");
            }
        }
    }
}