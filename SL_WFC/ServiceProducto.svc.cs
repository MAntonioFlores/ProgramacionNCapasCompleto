using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceProducto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceProducto.svc or ServiceProducto.svc.cs at the Solution Explorer and start debugging.
    public class ServiceProducto : IServiceProducto
    {
        public (bool, string, List<ML.Producto>, Exception) GetAll()
        {
            var result = BL.Producto.GetAllEFSB();
            List<ML.Producto> productoWCF = new List<ML.Producto>();//se inicializa la lista del ML

            foreach (ML.Producto p in result.Item3.Productos)//se guarda el resultado del modelo
            {
                productoWCF.Add(p);//todo lo que entre del modelo lo pasamos a p
            }

            return (result.Item1, result.Item2, productoWCF, result.Item4);//regresamos la lista y se la pasamos al modelo lista
        }

        public (bool, string, Exception) Add(ML.Producto producto)
        {
            var result = BL.Producto.AddEF(producto);

            return (result.Item1, result.Item2, result.Item3);
        }

        public (bool, string, Exception) Update(ML.Producto producto)
        {
            var result = BL.Producto.UpdateEF(producto);

            return (result.Item1, result.Item2, result.Item3);
        }

        public (bool, string, ML.Producto, Exception) Delete(int IdProducto)
        {
            var result = BL.Producto.DeleteLINQ(IdProducto);

            return (result.Item1, result.Item2, result.Item3, result.Item4);
        }
        public (bool, string, ML.Producto, Exception) GetById(int IdProducto)
        {
            var result = BL.Producto.GetByIdLINQ(IdProducto);

            return (result.Item1, result.Item2, result.Item3, result.Item4);
        }
    }
}
