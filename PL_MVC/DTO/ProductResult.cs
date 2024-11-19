using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL_MVC.DTO
{
    public class ProductResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<ML.Producto> Productos { get; set; }
        public Exception Error { get; set; }
    }
}
