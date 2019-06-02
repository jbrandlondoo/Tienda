using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using EN = tienda.entidad;
using CT = tienda.controlador;
namespace Tienda
{
    public partial class carrito : System.Web.UI.Page
    {
        private Cache cache;
        private List<EN.Producto> productos;
        protected void Page_Load(object sender, EventArgs e)
        {
            cache = new Cache();
            if (!IsPostBack)
            {
                cargar();
            }
        }
        private void cargar() {
            productos = (List<EN.Producto>)cache.Get("carrito");
            viewProducts.DataSource = productos;
            viewProducts.DataBind();
        }

        protected void sacar(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = viewProducts.Rows[e.RowIndex];
            productos = (List<EN.Producto>)cache.Get("carrito");
            var idProducto = (Label)((GridViewRow)viewProducts.Rows[e.RowIndex]).FindControl("idProduct");
            int id = Convert.ToInt16(idProducto.Text);
            foreach (var item in productos)
            {
                if (item.id == id)
                {
                    productos.Remove(item);
                    cache["carrito"] = productos;
                    cargar();
                    return;
                }
            }
        }
        protected void compra_Click(object sender, EventArgs e)
        {
            //llamado a seccion de comentarios mongo db
            String Comentario = txtComentarios.Text;
            CT.Producto producto = new CT.Producto();
            //------------------------------------------
            producto.comProductAsync(Comentario);
            CT.Factura facturaCt = new CT.Factura();
            productos = (List<EN.Producto>)cache.Get("carrito");
            EN.Factura facturaEn = new EN.Factura();
            var date = DateTime.Now;
            facturaEn.date = date;
            facturaEn.cliente = 1038;
            facturaEn.productos = productos;
            
            foreach (var item in productos)
            {
                facturaEn.total += item.total;
            }
            facturaCt.insertFactura(facturaEn);
            
        }
    }
}