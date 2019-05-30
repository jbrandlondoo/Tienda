using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN = tienda.entidad;
using BR = tienda.broker;

namespace tienda.controlador
{
    public class Producto
    {
        private BR.BDDatoEntities db = new BR.BDDatoEntities();

        public List<EN.Producto> listProductos(){
            List<EN.Producto> productos = new List<EN.Producto>();
            try
            {
                var consulta = (from p in db.productos
                                join ca in db.categorias on p.idCategoria equals ca.idCategoria
                                orderby p.nombreProducto descending
                                select new {p.nombreProducto,p.idProductos,p.precioActual,p.stock,p.descuento,ca.nombreCategoria });

                foreach (var item in consulta)
                {
                    EN.Producto producto = new EN.Producto();
                    producto.categoria = item.nombreCategoria;
                    producto.nombre = item.nombreProducto;
                    producto.precioActual = item.precioActual;
                    producto.descuento = item.descuento;
                    producto.id = item.idProductos;
                    producto.stock = item.stock;
                    productos.Add(producto);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return productos;
        }

        public bool updateProducto(EN.Producto producto) {
            try
            {
                var oldProducto = db.productos.Find(producto.id);
                db.Entry(oldProducto).CurrentValues.SetValues(producto);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
    }
}
