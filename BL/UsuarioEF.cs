using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsuarioEF
    {
        public static (bool, string, ML.Usuario, Exception) AddEF(ML.Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {

                    int rowsAffected = context.UsuarioAddEF(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UserName,
                        usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular,
                        usuario.CURP, usuario.Imagen);

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
        public static (bool, string, ML.Usuario, Exception) UpdateEF(ML.Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    int rowsAffected = context.UsuarioUpdateEF(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UserName,
                        usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen, usuario.IdUsuario);
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
        public static (bool, string, ML.Usuario, Exception) DeleteEF(ML.Usuario usuario)
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
        public static (bool, string, ML.Usuario, Exception) GetAllEF()
        {
            bool resultado = false;
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var registros = context.UsuarioGetAllEF().ToList();

                    if (registros.Count > 0)
                    {
                        usuario.Usuarios = new List<object>();
                        foreach (var registro in registros)
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
        public static (bool, string, ML.Usuario, Exception) GetByIdEF(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var objUsuario = context.UsuarioGetByIdEF(IdUsuario).SingleOrDefault();


                    if (objUsuario != null)
                    {
                        usuario.IdUsuario = objUsuario.IdUsuario;
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
                    }
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
