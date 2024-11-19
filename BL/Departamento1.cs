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
    public class Departamento1
    {
        public static (bool, string, Exception) AddSqlClient(ML.Departamento departamento)
        {
            try
            {
                SqlConnection context = new SqlConnection(Conexion.Get());
                string query = "INSERT INTO Departamento (Nombre, IdArea) VALUES (@Nombre, @IdArea)";

                SqlCommand cmd = new SqlCommand(query, context);

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                parameters[0].Value = departamento.NombreDepartamento;
                parameters[1] = new SqlParameter("@IdArea", System.Data.SqlDbType.Int);
                parameters[1].Value = departamento.Area.IdArea;

                cmd.Parameters.AddRange(parameters);

                cmd.Connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (rowsAffected > 0)
                {
                    return (true, null, null);
                }
                else
                {
                    return (false, null, null);
                }
            }
            catch (Exception ex)
            {

                return (false, "Ocrruio un error", ex);
            }
        }
        public static (bool, string, Exception) UpdateEF(ML.Departamento departamento)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new MFloresProgramacionNCapasEntities())
                {
                    int rowsAffected = context.DepartamentoUpdate(departamento.IdDepartamento, departamento.NombreDepartamento, departamento.Area.IdArea);
                    if (rowsAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (false, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error" + ex, ex);
            }
        }
        public static (bool, string, Exception) DeleteSqlClient(int IdDepartamento)
        {
            try
            {
                SqlConnection context = new SqlConnection(Conexion.Get());
                string queryDelete = "DELETE FROM Departamento WHERE IdDepartamento = @IdDepartamento";
                SqlCommand cmd = new SqlCommand(queryDelete, context);

                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdDepartamento", System.Data.SqlDbType.Int);
                parameters[0].Value = @IdDepartamento;

                cmd.Parameters.AddRange(parameters);

                cmd.Connection.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (rowAffected > 0)
                {
                    return (true, null, null);
                }
                else
                {
                    return (false, null, null);
                }
            }
            catch (Exception ex)
            {
                return (false, "ocurrio un error:" + ex, ex);
            }
        }
        public static (bool, string, ML.Departamento, Exception) GetAllLINQ()
        {
            ML.Departamento departamento = new ML.Departamento();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new MFloresProgramacionNCapasEntities())
                {
                    var queryGetAll = (from Departamento in context.Departamento
                                       select new
                                       {
                                           IdDepartamento = Departamento.IdDepartamento,
                                           Nombre = Departamento.Nombre,
                                           IdArea = Departamento.Area.IdArea,
                                           NombreArea = Departamento.Area.Nombre
                                       }).ToList();
                    if (queryGetAll.Count > 0)
                    {
                        departamento.Departamentos = new List<ML.Departamento>();
                        foreach (var registro in queryGetAll)
                        {
                            ML.Departamento departamentoObj = new ML.Departamento();

                            departamentoObj.IdDepartamento = registro.IdDepartamento;
                            departamentoObj.NombreDepartamento = registro.Nombre;
                            departamentoObj.Area = new ML.Area();
                            departamentoObj.Area.IdArea = registro.IdArea;
                            departamentoObj.Area.NombreArea = registro.NombreArea;

                            departamento.Departamentos.Add(departamentoObj);
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

                return (false, "Ocurrio un error" + ex, null, ex);
            }
        }

        public static (bool, string, ML.Departamento, Exception) GetByIdEF(int IdDepartamento)
        {
            ML.Departamento departamento = new ML.Departamento();
            try
            {

                using (DL_EF.MFloresProgramacionNCapasEntities context = new MFloresProgramacionNCapasEntities())
                {
                    var objDepartamento = context.DepartamentosGetbyIdArea(IdDepartamento).SingleOrDefault();

                    if (objDepartamento != null)
                    {
                        departamento.IdDepartamento = objDepartamento.IdDepartamento;
                        departamento.NombreDepartamento = objDepartamento.NombreDepartamento;
                        departamento.Area = new ML.Area();
                        departamento.Area.IdArea = objDepartamento.IdArea;
                        departamento.Area.NombreArea = objDepartamento.NombreArea;

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
                return (false, "error" + ex, null, ex);
            }
        }
    }
}
