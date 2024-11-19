using DL;
using DL_EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        public static (bool, string, ML.Departamento, Exception) GetByIdArea(int IdArea)
        {
            ML.Departamento departamento = new ML.Departamento();

            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var registros = context.DepartamentoGetById(IdArea).ToList();

                    departamento.Departamentos = new List<ML.Departamento>();

                    if (registros != null)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Departamento departamento1 = new ML.Departamento();

                            departamento1.IdDepartamento = registro.IdDepartamento;
                            departamento1.NombreDepartamento = registro.NombreDepartamento;

                            departamento.Departamentos.Add(departamento1);
                        }
                        return (true, null, departamento, null);
                    }
                    else
                    {
                        return (false, null, departamento, null);
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
