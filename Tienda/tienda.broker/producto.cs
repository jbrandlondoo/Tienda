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
    
    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            this.detalleFacturas = new HashSet<detalleFactura>();
        }
    
        public int idProductos { get; set; }
        public string nombreProducto { get; set; }
        public int stock { get; set; }
        public double precioActual { get; set; }
        public string nombreProveedor { get; set; }
        public Nullable<int> idCategoria { get; set; }
        public double descuento { get; set; }
    
        public virtual categoria categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleFactura> detalleFacturas { get; set; }
    }
}
