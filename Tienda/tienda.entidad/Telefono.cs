using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tienda.entidad
{
    [Serializable]
    public class Telefono
    {
        public int idCliente { set; get; }
        public string numero { get; set; }
    }
}