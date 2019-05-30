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
        private List<EN.Producto> productos;
        protected void Page_Load(object sender, EventArgs e)
        {
            cache = new Cache();
            producto = new CT.Producto();
            productos = new List<EN.Producto>();
            if (!IsPostBack)
            {
                cache["carrito"] = productos;
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

        protected void viewProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "add")
            {
                List<EN.Producto> productos = (List<EN.Producto>)cache.Get("carrito");
                EN.Producto producto = new EN.Producto();
                
                //GridViewRow row = viewProducts.Rows[e.RowIndex]; 
            }
        }

        protected void Guardar(object sender, GridViewUpdateEventArgs e)
        {
            //Update the values.
            GridViewRow row = viewProducts.Rows[e.RowIndex];
            var idProducto = (Label)((GridViewRow)viewProducts.Rows[e.RowIndex]).FindControl("idProduct");
            var TextBox1 = (TextBox)((GridViewRow)viewProducts.Rows[e.RowIndex]).FindControl("TextBox2");
            var ButtonGuardar = (ImageButton)((GridViewRow)viewProducts.Rows[e.RowIndex]).FindControl("ButtonGuardar");
            int id = Convert.ToInt16(idProducto.Text);
            EN.Producto producto = this.producto.listProductos(id);
            productos = (List<EN.Producto>)cache.Get("carrito");
            try
            {
                producto.cantidad = Convert.ToInt16(TextBox1.Text);

            }
            catch (Exception)
            {
                producto.cantidad = 1;
            }
            producto.total = getTotal(producto.cantidad,producto.precioActual,producto.descuento);
            productos.Add(producto);
            cache["carrito"] = productos;
            ButtonGuardar.Enabled = false;
        }

        private double getTotal(int cantidad,double precio,double descuento) {
            return (cantidad * precio) * (1 - (descuento/100));
        }

        protected void viewProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}