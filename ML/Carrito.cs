using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Carrito
    {
        public List<object> Productos { get; set; }
        public decimal CostoTotal { get; set; }
        public int TotalProductos { get; set; }
    }
}
