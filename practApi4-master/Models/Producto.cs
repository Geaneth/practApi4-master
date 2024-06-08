using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practApi4.Models
{
    public class Producto
    {
         public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public bool liked;
    }
}