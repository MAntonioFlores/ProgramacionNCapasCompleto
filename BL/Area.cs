using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Area
    {
        public static (bool, string, ML.Area, Exception) GetAllArea()
        {
            ML.Area area = new ML.Area();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var registros = context.GetAllArea().ToList();
                    area.Areas = new List<ML.Area>();

                    if (registros != null)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Area area1 = new ML.Area();

                            area1.IdArea = registro.IdArea;
                            area1.NombreArea = registro.Nombre;

                            area.Areas.Add(area1);
                        }
                        return (true, null, area, null);
                    }
                    else
                    {
                        return (false, null, area, null);
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
