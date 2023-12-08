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
    public partial class AltaArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    List<Marca> marcas = marcaNegocio.Listar();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Categoria> categorias = categoriaNegocio.Listar();

                    ddlMarcas.DataSource = marcas;
                    ddlMarcas.DataValueField = "Id";
                    ddlMarcas.DataTextField = "Descripcion";
                    ddlMarcas.DataBind();
                    ddlMarcas.Items.Insert(0, new ListItem("-- Seleccione Marca --", string.Empty));

                    ddlCategorias.DataSource = categorias;
                    ddlCategorias.DataValueField= "Id";
                    ddlCategorias.DataTextField = "Descripcion";
                    ddlCategorias.DataBind();
                    ddlCategorias.Items.Insert(0, new ListItem("-- Seleccione Categoria --", string.Empty));

                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

                    if(id != "")
                    {
                        ArticuloNegocio _negocio = new ArticuloNegocio();
                        ImagenNegocio imagenNegocio = new ImagenNegocio();

                        Articulo aux = _negocio.FiltraPorId(int.Parse(id));
                        aux.Imagenes = new List<Imagen>();
                        imagenNegocio.CargarLista(aux);

                        txtNombre.Text = aux.Nombre;
                        txtDescripcion.Text = aux.Descripcion;
                        txtCodigo.Text = aux.Codigo;
                        txtPrecio.Text = aux.Precio.ToString();
                        txtUrlImagen.Text = aux.Imagenes.Count() > 0 ? aux.Imagenes[0].ImagenUrl.ToString() : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROGVlwDhbC-6RixbdgEwDrABJ6BD3hhM2eJA&usqp=CAU";
                        imgArticulo.ImageUrl = aux.Imagenes.Count() > 0 ? aux.Imagenes[0].ImagenUrl.ToString() : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROGVlwDhbC-6RixbdgEwDrABJ6BD3hhM2eJA&usqp=CAU";

                        ddlCategorias.SelectedValue = aux.Categoria.Id.ToString();
                        ddlMarcas.SelectedValue = aux.Marca.Id.ToString();
                    }

                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                        btnAceptar.Text = "Editar";
                    else
                        btnAceptar.Text = "Agregar";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";
            ArticuloNegocio _negocio = new ArticuloNegocio();
            ImagenNegocio _imgNegocio = new ImagenNegocio();
            Articulo aux = new Articulo();

                aux.Nombre = txtNombre.Text;
                aux.Codigo = txtCodigo.Text;
                aux.Descripcion = txtDescripcion.Text;
                aux.Precio = decimal.Parse(txtPrecio.Text);

                Marca marca = new Marca();
                marca.Id = ddlMarcas.SelectedIndex;
                aux.Marca = marca;

                Categoria categoria = new Categoria();
                categoria.Id = ddlCategorias.SelectedIndex;
                aux.Categoria = categoria;

            
            if (id != "")
            {
                aux.Id = int.Parse(id);
                _negocio.Modificar(aux);
            }
            else
                _negocio.Agregar(aux);

            int idArticulo = _negocio.CapturarId(aux.Codigo);

            Imagen img = new Imagen();
            img.IdArticulo = idArticulo;
            img.ImagenUrl = txtUrlImagen.Text;

            _imgNegocio.Agregar(img);


            Response.Redirect("Default.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

            if(id != "")
            {
                ArticuloNegocio _negocio = new ArticuloNegocio();
                _negocio.Eliminar(int.Parse(id));
            }

            Response.Redirect("Default.aspx");
        }
    }
}