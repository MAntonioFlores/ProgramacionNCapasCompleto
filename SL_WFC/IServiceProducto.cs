using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceProducto" in both code and config file together.
    [ServiceContract]
    public interface IServiceProducto
    {
        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        (bool, string, List<ML.Producto>, Exception) GetAll();

        [OperationContract]
        (bool, string, Exception) Add(ML.Producto producto);

        [OperationContract]
        (bool, string, Exception) Update(ML.Producto producto);

        [OperationContract]
        (bool, string, ML.Producto, Exception) Delete(int IdProducto);

        [OperationContract]
        (bool, string, ML.Producto, Exception) GetById(int IdProducto);
    }
}
