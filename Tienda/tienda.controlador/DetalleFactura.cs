using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN = tienda.entidad;
using BR = tienda.broker;

namespace tienda.controlador
{
    public class DetalleFactura
    {
        private BR.BDDatoEntities db = new BR.BDDatoEntities();
        public bool crearDetalle(EN.Producto producto,int idFactura) {
            try
            {
                BR.detalleFactura detalle = new BR.detalleFactura();
                detalle.idProducto = producto.id;
                detalle.idFactura = idFactura;
                detalle.cantidad = producto.cantidad;
                db.detalleFacturas.Add(detalle);
                db.SaveChanges();
                Producto productoAcualizar = new Producto();
                productoAcualizar.updateProducto(producto);
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
    }
}
