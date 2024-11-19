using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static (bool, string, ML.Rol, Exception) GetAll()
        {
            ML.Rol rol = new ML.Rol();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var registros = context.GetAllRolDropList().ToList();

                    rol.Roles = new List<ML.Rol>();

                    if (registros != null)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Rol rol1 = new ML.Rol();

                            rol1.IdRol = registro.IdRol;
                            rol1.Nombre = registro.Nombre;

                            rol.Roles.Add(rol1);
                        }
                        return (true, null, rol, null);
                    }
                    else
                    {
                        return (false, "Ocurrio un error", rol, null);
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
