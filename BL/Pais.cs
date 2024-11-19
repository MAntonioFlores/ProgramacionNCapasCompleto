using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static (bool, string, ML.Pais, Exception) GetAll()
        {
            ML.Pais pais = new ML.Pais();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var registros = context.PaisGetAll().ToList();

                    pais.Paises = new List<ML.Pais>();

                    if (registros != null)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Pais pais1 = new ML.Pais();

                            pais1.IdPais = registro.IdPais;
                            pais1.NombrePais = registro.Nombre;

                            pais.Paises.Add(pais1);
                        }
                        return (true, null, pais, null);
                    }
                    else
                    {
                        return (false, "Ocurrio un error", pais, null);
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
