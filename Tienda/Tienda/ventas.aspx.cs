using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using CT = tienda.controlador;
using EN = tienda.entidad;

namespace Tienda
{
    public partial class ventas : System.Web.UI.Page
    {
        private CT.Producto producto;
        private Cache cache;
        protected void Page_Load(object sender, EventArgs e)
        {
            cache = new Cache();
            producto = new CT.Producto();
            List<EN.Producto> productos = new List<EN.Producto>();
            cache["carrito"] = productos;
            if (!IsPostBack)
            {
                cargar();
            }
        }

        private void cargar()
        {
            List<EN.Producto> productos = producto.listProductos();
            viewProducts.DataSource = productos;
            viewProducts.DataBind();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void viewProducts_RowCommand(object sender, GridViewUpdateEventArgs e)
        {
            List<EN.Producto> productos = (List<EN.Producto>)cache.Get("carrito");
            EN.Producto producto = new EN.Producto();
            GridViewRow row = viewProducts.Rows[e.RowIndex]; 
        }
    }
}