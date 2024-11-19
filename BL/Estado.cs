using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static (bool, string, ML.Estado, Exception) GetByIdPais(int IdPais)
        {
            ML.Estado estado = new ML.Estado();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var registros = context.EstadoGetByIdPais(IdPais).ToList();

                    estado.Estados = new List<ML.Estado>();

                    if (registros != null)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Estado estado1 = new ML.Estado();

                            estado1.IdEstado = registro.IdEstado;
                            estado1.NombreEstado = registro.Nombre;

                            estado.Estados.Add(estado1);

                        }
                        return (true, null, estado, null);
                    }
                    else
                    {
                        return (false, "Ocurrio un error", estado, null);
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
