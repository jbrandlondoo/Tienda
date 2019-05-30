using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN = tienda.entidad;
using BR = tienda.broker;

namespace tienda.controlador
{
    public class Factura
    {
        private BR.BDDatoEntities db = new BR.BDDatoEntities();

        public EN.Factura listFactura(int idFactura)
        {
            EN.Factura factura = new EN.Factura();
            try
            {
                var consulta = (from f in db.facturas
                                join d in db.detalleFacturas on f.idFactura equals d.idFactura
                                join c in db.clientes on f.idCliente equals c.idCliente
                                join p in db.productos on d.idProducto equals p.idProductos
                                join ca in db.categorias on p.idCategoria equals ca.idCategoria
                                where f.idFactura == idFactura
                                orderby f.idFactura descending
                                select new { f.fecha,c.idCliente,c.nombreCliente, ca.nombreCategoria, p.nombreProducto, p.precioActual, d.cantidad, p.descuento, f.total });

                factura.id = idFactura;
                List<EN.Producto> productos = new List<EN.Producto>();
                EN.Cliente cliente = new EN.Cliente();
                int i = 0;
                foreach (var item in consulta)
                {
                    if (i == 0) {
                        factura.total = item.total;
                        factura.date = item.fecha;
                        cliente.nombre = item.nombreCliente;
                        cliente.id = item.idCliente;
                        i++;
                    }
                    EN.Producto producto = new EN.Producto();
                    producto.categoria = item.nombreCategoria;
                    producto.nombre = item.nombreProducto;
                    producto.precioActual = item.precioActual;
                    producto.cantidad = item.cantidad;
                    producto.descuento = item.descuento;
                    productos.Add(producto);
                }
                factura.productos = productos;
                factura.cliente = cliente;
            }
            catch (Exception)
            {

                throw;
            }
            return factura;
        }
        public List<EN.Factura> listFactura(EN.Cliente cliente)
        {
            List<EN.Factura> facturas = new List<EN.Factura>();
            try
            {
                var consulta = (from f in db.facturas
                                join d in db.detalleFacturas on f.idFactura equals d.idFactura
                                join p in db.productos on d.idProducto equals p.idProductos
                                join ca in db.categorias on p.idCategoria equals ca.idCategoria
                                where f.idCliente == cliente.id
                                orderby f.idFactura descending
                                select new { f.fecha,f.idFactura, ca.nombreCategoria, p.nombreProducto, p.precioActual, d.cantidad, p.descuento, f.total });
                int i = 0,index = 0;
                EN.Factura factura = new EN.Factura();
                List<EN.Producto> productos = new List<EN.Producto>();
                foreach (var item in consulta)
                {
                        if (i == index)
                        { 
                            factura.id = item.idFactura;
                            factura.total = item.total;
                            factura.date = item.fecha;
                            i++;
                        }
                        if (factura.id != item.idFactura)
                        {
                            index++;
                            facturas.Add(factura);
                            factura = new EN.Factura();
                        }
                        EN.Producto producto = new EN.Producto();
                        producto.categoria = item.nombreCategoria;
                        producto.nombre = item.nombreProducto;
                        producto.precioActual = item.precioActual;
                        producto.cantidad = item.cantidad;
                        producto.descuento = item.descuento;
                        productos.Add(producto);
                        factura.productos = productos;
                        factura.cliente = cliente;
                }
               
            }
            catch (Exception)
            {

                throw;
            }
            return facturas;
        }
        public List<EN.Factura> listFactura()
        {
            List<EN.Factura> facturas = new List<EN.Factura>();

            return facturas;
        }

        public bool insertFactura(EN.Factura factura)
        {
            return false;
        }
        public bool updateFactura(EN.Factura factura)
        {
            return false;
        }
        public bool deleteFactura(EN.Factura factura)
        {
            return false;
        }
    }
}
