using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static (bool, string, ML.Municipio, Exception) GetByIdMunicipio(int IdEstado)
        {
            ML.Municipio municipio = new ML.Municipio();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var registros = context.MunicipioGetByIdEstado(IdEstado).ToList();

                    municipio.Municipios = new List<ML.Municipio>();

                    if (registros != null)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Municipio municipio1 = new ML.Municipio();

                            municipio1.IdMunicipio = registro.IdMunicipio;
                            municipio1.NombreMunicipio = registro.Nombre;

                            municipio.Municipios.Add(municipio1);

                        }
                        return (true, null, municipio, null);
                    }
                    else
                    {
                        return (false, "Ocurrio un error", municipio, null);
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
