using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsuarioRol
    {
        public static (bool, string, Exception) AddRol(ML.Usuario usuario)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDLEF = new DL_EF.Usuario();

                    int rowsAffected = context.UsuarioAddRol(
                        usuarioDLEF.Nombre = usuario.Nombre,
                        usuarioDLEF.ApellidoPaterno = usuario.ApellidoPaterno,
                        usuarioDLEF.ApellidoMaterno = usuario.ApellidoMaterno,
                        usuarioDLEF.UserName = usuario.UserName,
                        usuarioDLEF.Email = usuario.Email,
                        usuarioDLEF.Password = usuario.Password,
                        usuarioDLEF.FechaNacimiento = usuario.FechaNacimiento,
                        usuarioDLEF.Sexo = usuario.Sexo,
                        usuarioDLEF.Telefono = usuario.Telefono,
                        usuarioDLEF.Celular = usuario.Celular,
                        usuarioDLEF.CURP = usuario.CURP,
                        usuarioDLEF.Imagen = usuario.Imagen,
                        usuarioDLEF.IdRol = usuario.Rol.IdRol);

                    if (rowsAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (true, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }
        public static (bool, string, ML.Usuario, Exception) UpdateRol(ML.Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    int rowsAffected = context.UsuarioUpdateRol(
                        usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno,
                        usuario.UserName,
                        usuario.Email,
                        usuario.Password,
                        usuario.FechaNacimiento,
                        usuario.Sexo,
                        usuario.Telefono,
                        usuario.Celular,
                        usuario.CURP,
                        usuario.Imagen,
                        usuario.Rol.IdRol,
                        usuario.IdUsuario);
                    if (rowsAffected > 0)
                    {
                        resultado = true;
                    }
                    return (true, null, usuario, null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
        //Se ocupo el mismo Metodo con el mismo SP ya que la llave primaria de Rol esta en usuario por lo que es la foranea, por lo tanto si borras el is Uduario borras el rol que tenia asignado
        public static (bool, string, ML.Usuario, Exception) DeleteRol(ML.Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    int rowsAffected = context.UsuarioDeleteEF(usuario.IdUsuario);
                    if (rowsAffected > 0)
                    {
                        resultado = true;
                        return (true, null, usuario, null);
                    }
                    else
                    {
                        return (false, null, usuario, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
        public static (bool, string, ML.Usuario, Exception) GetAllRol()
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetAllRol().ToList();

                    if (query.Count > 0)
                    {
                        usuario.Usuarios = new List<object>();
                        foreach (var registro in query)
                        {
                            ML.Usuario usuarioObj = new ML.Usuario();

                            usuarioObj.IdUsuario = registro.IdUsuario;
                            usuarioObj.Nombre = registro.Nombre;
                            usuarioObj.ApellidoPaterno = registro.ApellidoPaterno;
                            usuarioObj.ApellidoMaterno = registro.ApellidoMaterno;
                            usuarioObj.UserName = registro.UserName;
                            usuarioObj.Email = registro.Email;
                            usuarioObj.Password = registro.Password;
                            usuarioObj.FechaNacimiento = registro.FechaNacimiento;
                            usuarioObj.Sexo = registro.Sexo;
                            usuarioObj.Telefono = registro.Telefono;
                            usuarioObj.Celular = registro.Celular;
                            usuarioObj.CURP = registro.CURP;
                            usuarioObj.Rol = new ML.Rol();
                            usuarioObj.Rol.IdRol = registro.IdRol.Value;

                            usuario.Usuarios.Add(usuarioObj);
                        }
                        return (true, null, usuario, null);
                    }
                    else
                    {
                        return (false, null, usuario, null);
                    }

                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
        public static (bool, string, ML.Usuario, Exception) GetAllUsuarioRol()
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetAllInnerJoin().ToList();

                    if (query.Count > 0)
                    {
                        usuario.Usuarios = new List<object>();
                        foreach (var registro in query)
                        {
                            ML.Usuario usuarioObj = new ML.Usuario();

                            usuarioObj.IdUsuario = registro.IdUsuario;
                            usuarioObj.Nombre = registro.Nombre;
                            usuarioObj.ApellidoPaterno = registro.ApellidoPaterno;
                            usuarioObj.ApellidoMaterno = registro.ApellidoMaterno;
                            usuarioObj.UserName = registro.UserName;
                            usuarioObj.Email = registro.Email;
                            usuarioObj.Password = registro.Password;
                            usuarioObj.FechaNacimiento = registro.FechaNacimiento;
                            usuarioObj.Sexo = registro.Sexo;
                            usuarioObj.Telefono = registro.Telefono;
                            usuarioObj.Celular = registro.Celular;
                            usuarioObj.CURP = registro.CURP;
                            usuarioObj.Rol = new ML.Rol();
                            usuarioObj.Rol.IdRol = registro.IdRol.Value;
                            usuarioObj.Rol.Nombre = registro.NombreRol;


                            usuario.Usuarios.Add(usuarioObj);
                        }
                        return (true, null, usuario, null);
                    }
                    else
                    {
                        return (false, null, usuario, null);
                    }

                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
        public static (bool, string, ML.Usuario, Exception) GetByIdRol(int idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var objUsuario = context.UsuarioGetByIdRol(idUsuario).SingleOrDefault();

                    if (objUsuario != null)
                    {

                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Email = objUsuario.Email;
                        usuario.Password = objUsuario.Password;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento;
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Celular = objUsuario.Celular;
                        usuario.CURP = objUsuario.CURP;
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.IdRol.Value;
                        //usuario.Rol.Nombre = objUsuario.Nombre;
                    };

                    return (true, null, usuario, null);

                }
            }
            catch (Exception e)
            {
                return (false, e.Message, null, e);
            }
        }
        public static (bool, string, ML.Usuario, Exception) GetByIdUsuarioRol(int idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var objUsuario = context.UsuarioGetByIdInnerJoin(idUsuario).SingleOrDefault();

                    if (objUsuario != null)
                    {

                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Email = objUsuario.Email;
                        usuario.Password = objUsuario.Password;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento;
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Celular = objUsuario.Celular;
                        usuario.CURP = objUsuario.CURP;
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.IdRol.Value;
                        usuario.Rol.Nombre = objUsuario.NombreRol;
                    };

                    return (true, null, usuario, null);

                }
            }
            catch (Exception e)
            {
                return (false, e.Message, null, e);
            }
        }
    }
}
