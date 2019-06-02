using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tienda.entidad
{
    [Serializable]
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int stock { get; set; }
        public double precioActual { get; set; }
        public string nombreProveedor { get; set; }
        public string categoria { get; set; }
        public int cantidad { get; set; }
        public double descuento { get; set; }
        public double total { set; get; }

    }
}