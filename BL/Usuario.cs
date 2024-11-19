using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ML;
using DL;
using System.Data;

namespace BL
{
    public class Usuario
    {
        public static bool Add(ML.Usuario usuario)
        {
            try
            {
                SqlConnection context = new SqlConnection(Conexion.Get());
                //string query = "INSERT INTO [Usuario] ([Nombre] ,[ApellidoPaterno] ,[ApellidoMaterno]) VALUES (@Nombre ,@ApellidoPaterno,@ApellidoMaterno)";
                string query = "UsuarioAddSQLClient";//procedimiento almacenado

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = context;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters = new SqlParameter[11];
                parameters[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                parameters[0].Value = usuario.Nombre;
                parameters[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                parameters[1].Value = usuario.ApellidoPaterno;
                parameters[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                parameters[2].Value = usuario.ApellidoMaterno;
                parameters[3] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                parameters[3].Value = usuario.UserName;
                parameters[4] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                parameters[4].Value = usuario.Email;
                parameters[5] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                parameters[5].Value = usuario.Password;
                parameters[6] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.DateTime);
                parameters[6].Value = usuario.FechaNacimiento;
                parameters[7] = new SqlParameter("@Sexo", System.Data.SqlDbType.VarChar);
                parameters[7].Value = usuario.Sexo;
                parameters[8] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                parameters[8].Value = usuario.Telefono;
                parameters[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                parameters[9].Value = usuario.Celular;
                parameters[10] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                parameters[10].Value = usuario.CURP;

                cmd.Parameters.AddRange(parameters);

                cmd.Connection.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (rowAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool Update(ML.Usuario usuario)
        {
            try
            {
                SqlConnection context = new SqlConnection(Conexion.Get());
                //string queryUpdate = "UPDATE [Usuario] SET [Nombre] = @Nombre, [ApellidoPaterno] = @ApellidoPaterno, [ApellidoMaterno] = @ApellidoMaterno WHERE IdUsuario = @IdUsuario";
                string query = "UsuarioUpdateSQLClient";// esto es con un Procedimiento almacenado
                SqlCommand cmd = new SqlCommand(query, context);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parametersUpdate = new SqlParameter[12];
                parametersUpdate[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                parametersUpdate[0].Value = usuario.Nombre;
                parametersUpdate[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                parametersUpdate[1].Value = usuario.ApellidoPaterno;
                parametersUpdate[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                parametersUpdate[2].Value = usuario.ApellidoMaterno;
                parametersUpdate[3] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                parametersUpdate[3].Value = usuario.UserName;
                parametersUpdate[4] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                parametersUpdate[4].Value = usuario.Email;
                parametersUpdate[5] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                parametersUpdate[5].Value = usuario.Password;
                parametersUpdate[6] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.DateTime);
                parametersUpdate[6].Value = usuario.FechaNacimiento;
                parametersUpdate[7] = new SqlParameter("@Sexo", System.Data.SqlDbType.VarChar);
                parametersUpdate[7].Value = usuario.Sexo;
                parametersUpdate[8] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                parametersUpdate[8].Value = usuario.Telefono;
                parametersUpdate[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                parametersUpdate[9].Value = usuario.Celular;
                parametersUpdate[10] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                parametersUpdate[10].Value = usuario.CURP;
                parametersUpdate[11] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.VarChar);
                parametersUpdate[11].Value = usuario.IdUsuario;

                cmd.Parameters.AddRange(parametersUpdate);

                cmd.Connection.Open();
                int rowAffectedUpdate = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (rowAffectedUpdate > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool Delete(ML.Usuario usuario)
        {
            try
            {
                SqlConnection context = new SqlConnection(Conexion.Get());
                //string query = "DELETE FROM [Usuario] WHERE IdUsuario = @IdUsuario";
                string query = "UsuarioDeleteSQLClient";
                SqlCommand cmd = new SqlCommand(query, context);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parametersDelete = new SqlParameter[1];
                parametersDelete[0] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                parametersDelete[0].Value = usuario.IdUsuario;

                cmd.Parameters.AddRange(parametersDelete);

                cmd.Connection.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (rowAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static ML.Usuario GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    //string query = "SELECT [IdUsuario], [Nombre] ,[ApellidoPaterno],[ApellidoMaterno] FROM [Usuario]";
                    string query = "UsuarioGetAllSQLClient";
                    SqlCommand command = new SqlCommand(query, context);
                    command.CommandType = CommandType.StoredProcedure;

                    DataTable tablaUsuario = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(tablaUsuario);

                    if (tablaUsuario.Rows.Count > 0)
                    {
                        usuario.Usuarios = new List<object>();
                        foreach (DataRow fila in tablaUsuario.Rows)
                        {
                            ML.Usuario usuarioObj = new ML.Usuario();
                            usuarioObj.IdUsuario = int.Parse(fila[0].ToString());
                            usuarioObj.Nombre = fila[1].ToString();
                            usuarioObj.ApellidoPaterno = fila[2].ToString();
                            usuarioObj.ApellidoMaterno = fila[3].ToString();
                            usuarioObj.UserName = fila[4].ToString();
                            usuarioObj.Email = fila[5].ToString();
                            usuarioObj.Password = fila[6].ToString();
                            usuarioObj.FechaNacimiento = Convert.ToDateTime(fila[7].ToString());
                            usuarioObj.Sexo = fila[8].ToString();
                            usuarioObj.Telefono = fila[9].ToString();
                            usuarioObj.Celular = fila[10].ToString();
                            usuarioObj.CURP = fila[11].ToString();

                            usuario.Usuarios.Add(usuarioObj);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se pudieron obtener los registros");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return usuario;
        }

        public static ML.Usuario GetById(int idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    //string query = "SELECT [IdUsuario], [Nombre] ,[ApellidoPaterno],[ApellidoMaterno] FROM [Usuario] WHERE [IdUsuario] = @IdUsuario";
                    string query = "UsuarioGetByIdSQLClient";
                    SqlCommand command = new SqlCommand(query, context);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] parametersGetById = new SqlParameter[1];

                    parametersGetById[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                    parametersGetById[0].Value = idUsuario;

                    command.Parameters.AddRange(parametersGetById);

                    DataTable tablaUsuario = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(tablaUsuario);

                    if (tablaUsuario.Rows.Count > 0)
                    {
                        usuario.IdUsuario = int.Parse(tablaUsuario.Rows[0][0].ToString());
                        usuario.Nombre = tablaUsuario.Rows[0][1].ToString();
                        usuario.ApellidoPaterno = tablaUsuario.Rows[0][2].ToString();
                        usuario.ApellidoMaterno = tablaUsuario.Rows[0][3].ToString();
                        usuario.UserName = tablaUsuario.Rows[0][4].ToString();
                        usuario.Email = tablaUsuario.Rows[0][5].ToString();
                        usuario.Password = tablaUsuario.Rows[0][6].ToString();
                        usuario.FechaNacimiento = Convert.ToDateTime(tablaUsuario.Rows[0][7].ToString());
                        usuario.Sexo = tablaUsuario.Rows[0][8].ToString();
                        usuario.Telefono = tablaUsuario.Rows[0][9].ToString();
                        usuario.Celular = tablaUsuario.Rows[0][10].ToString();
                        usuario.CURP = tablaUsuario.Rows[0][11].ToString();
                    }
                    else
                    {
                        Console.WriteLine("No se pudo obtener el registro deseado");
                    }

                }
            }
            catch (Exception e)
            {

            }
            return usuario;
        }
    }
}
