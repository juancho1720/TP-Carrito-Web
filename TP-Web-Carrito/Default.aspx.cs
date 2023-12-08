using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Web_Carrito
{
    public partial class _Default : Page
    {
        private List<Articulo> _articulos {  get; set; }
        private AccesoDatos _datos = new AccesoDatos();
        private ArticuloNegocio _negocio = new ArticuloNegocio();
        private ImagenNegocio _imgNegocio = new ImagenNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                _articulos = _negocio.Listar();
                repArticulos.DataSource = _articulos;
                _imgNegocio.CargarListas(_articulos);
                repArticulos.DataBind();
            }
        }

        protected void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string articuloId = btn.CommandArgument;

            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = negocio.FiltraPorId(int.Parse(articuloId));

            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

            if (carrito == null)
            {
                carrito = new List<Articulo>();
            }

            carrito.Add(articulo);

            Session["Carrito"] = carrito;

            int cantidadCarrito = carrito.Count;
            ScriptManager.RegisterStartupScript(this, GetType(), "ActualizarCantidadCarrito", "document.getElementById('CantidadCarrito').textContent = " + cantidadCarrito + ";", true);
        }
    }
}