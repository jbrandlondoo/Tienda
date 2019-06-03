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
                cache["userid"] = 1038;
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

        protected void Guardar(object sender, GridViewUpdateEventArgs e)
        {
            //Update the values.
            GridViewRow row = viewProducts.Rows[e.RowIndex];
            var idProducto = (Label)((GridViewRow)viewProducts.Rows[e.RowIndex]).FindControl("idProduct");
            var stock = (Label)((GridViewRow)viewProducts.Rows[e.RowIndex]).FindControl("stock");
            var TextBox1 = (TextBox)((GridViewRow)viewProducts.Rows[e.RowIndex]).FindControl("TextBox2");
            var ButtonGuardar = (ImageButton)((GridViewRow)viewProducts.Rows[e.RowIndex]).FindControl("ButtonGuardar");
            int id = Convert.ToInt16(idProducto.Text);
            EN.Producto producto = this.producto.listProductos(id);
            productos = (List<EN.Producto>)cache.Get("carrito");
            try
            {
                producto.cantidad = Convert.ToInt16(TextBox1.Text);
                if (!(Convert.ToInt16(stock.Text) > producto.cantidad))
                {
                    producto.cantidad = Convert.ToInt16(stock.Text);
                }
                

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


        protected void commentar(object sender, GridViewUpdateEventArgs e) {
           
        }

        protected void viewProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var TextBox4 = (TextBox)((GridViewRow)viewProducts.Rows[e.NewEditIndex]).FindControl("TextBox4");
            var idProducto = (Label)((GridViewRow)viewProducts.Rows[e.NewEditIndex]).FindControl("idProduct");
            int id = Convert.ToInt16(idProducto.Text);
            var idcliente = (int)cache.Get("userid");
            var comment = TextBox4.Text;
            producto.comProductAsync(comment, id, idcliente);
        }
    }
}