using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proveedor
    {
        public static (bool, string, ML.Proveedor, Exception) GetAllProveedor()
        {
            ML.Proveedor proveedor = new ML.Proveedor();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var registros = context.ProveedorGetAll().ToList();
                    proveedor.Proveedores = new List<ML.Proveedor>();

                    if (registros != null)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Proveedor proveedor1 = new ML.Proveedor();

                            proveedor1.IdProveedor = registro.IdProveedor;
                            proveedor1.Nombre = registro.Nombre;

                            proveedor.Proveedores.Add(proveedor1);
                        }
                        return (true, null, proveedor, null);
                    }
                    else
                    {
                        return (false, null, proveedor, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
    }
}
