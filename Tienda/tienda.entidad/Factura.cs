using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda.entidad
{
    [Serializable]
    public class Factura
    {
        public int id { get; set; }
        public DateTime date { set; get; }
        public int cliente { set; get; }
        public List<Producto> productos { set; get; }
        public double total { get; set; }
    }
}
