using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda.entidad
{

    [Serializable]
    public class Cliente
    {
        public int id { set; get; }
        public string nombre { set; get; }
        public  List<Telefono> telefonos { set; get; }
        public string ciudad { set; get; }
        public string direccion { get; set; }

    }
}
