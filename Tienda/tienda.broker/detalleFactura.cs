//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tienda.broker
{
    using System;
    using System.Collections.Generic;
    
    public partial class detalleFactura
    {
        public int cantidad { get; set; }
        public int idFactura { get; set; }
        public int idProducto { get; set; }
    
        public virtual factura factura { get; set; }
        public virtual producto producto { get; set; }
    }
}
