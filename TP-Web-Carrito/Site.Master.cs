using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Web_Carrito
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                ActualizarCantidadCarrito();
            
        }

        private void ActualizarCantidadCarrito()
        {
            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;
            int cantidad = carrito != null ? carrito.Count : 0;

            ScriptManager.RegisterStartupScript(this, GetType(), "ActualizarCantidadCarrito", "document.getElementById('CantidadCarrito').textContent = " + cantidad + ";", true);
        }
        /*
        public int GetCantidadArticulosEnCarrito()
        {
            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;
            if (carrito != null)
            {
                return carrito.Count;
            }
            return 0;
        }*/
    }
}