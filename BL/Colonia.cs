using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static (bool, string, ML.Colonia, Exception) GetByIdColonia(int IdMunicipio)
        {
            ML.Colonia colonia = new ML.Colonia();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var registros = context.ColoniaGetByIdMunicipio(IdMunicipio).ToList();

                    colonia.Colonias = new List<ML.Colonia>();

                    if (registros != null)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Colonia colonia1 = new ML.Colonia();

                            colonia1.IdColonia = registro.IdColonia;
                            colonia1.NombreColonia = registro.Nombre;
                            colonia1.CodigoPostal = registro.CodigoPostal;

                            colonia.Colonias.Add(colonia1);

                        }
                        return (true, null, colonia, null);
                    }
                    else
                    {
                        return (false, "Ocurrio un error", colonia, null);
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
