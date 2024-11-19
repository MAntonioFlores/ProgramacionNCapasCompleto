
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {
        public static (bool, string, ML.Direccion, Exception) GetByIdDireccion(int IdDireccion)
        {
            ML.Direccion direccion = new ML.Direccion();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var registros = context.DireccionGetByIdColonia(IdDireccion).ToList();

                    direccion.Direcciones = new List<ML.Direccion>();

                    if (registros != null)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Direccion direccion1 = new ML.Direccion();

                            direccion1.IdDireccion = registro.IdDireccion;
                            direccion1.Calle = registro.Calle;
                            direccion1.NumeroInterior = registro.NumeroInterior;
                            direccion1.NumeroExterior = registro.NumeroExterior;

                            direccion.Direcciones.Add(direccion1);

                        }
                        return (true, null, direccion, null);
                    }
                    else
                    {
                        return (false, "Ocurrio un error", direccion, null);
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
