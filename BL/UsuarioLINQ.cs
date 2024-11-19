using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsuarioLINQ
    {
        public static (bool, string, Exception) AddLINQ(ML.Usuario usuario)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDLEF = new DL_EF.Usuario();

                    usuarioDLEF.Nombre = usuario.Nombre;
                    usuarioDLEF.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDLEF.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDLEF.UserName = usuario.UserName;
                    usuarioDLEF.Email = usuario.Email;
                    usuarioDLEF.Password = usuario.Password;
                    usuarioDLEF.FechaNacimiento = usuario.FechaNacimiento;
                    usuarioDLEF.Sexo = usuario.Sexo;
                    usuarioDLEF.Telefono = usuario.Telefono;
                    usuarioDLEF.Celular = usuario.Celular;
                    usuarioDLEF.CURP = usuario.CURP;
                    //usuarioDLEF.Imagen = usuario.Imagen;

                    context.Usuario.Add(usuarioDLEF);
                    context.SaveChanges();

                    return (true, null, null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }
        public static (bool, string, Exception) UpdateLINQ(ML.Usuario usuario)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = (from Usuario in context.Usuario
                                 where Usuario.IdUsuario == usuario.IdUsuario
                                 select Usuario).SingleOrDefault();
                    if (query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.UserName = usuario.UserName;
                        query.Email = usuario.Email;
                        query.Password = usuario.Password;
                        query.FechaNacimiento = usuario.FechaNacimiento;
                        query.Sexo = usuario.Sexo;
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        query.CURP = usuario.CURP;
                        query.IdUsuario = usuario.IdUsuario;

                        context.SaveChanges();

                        return (true, "Se actualizo correctamente", null);
                    }
                    else
                    {
                        return (false, "Ocurrio un error", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error" + ex.Message, ex);
            }

        }
        public static (bool, string, ML.Usuario, Exception) DeleteLINQ(ML.Usuario usuario)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = (from Usuario in context.Usuario
                                 where Usuario.IdUsuario == usuario.IdUsuario
                                 select Usuario).FirstOrDefault();
                    context.Usuario.Remove(query);

                    context.SaveChanges();

                    return (true, null, usuario, null);
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error" + ex.Message, null, ex);
            }
        }
        public static (bool, string, ML.Usuario, Exception) GetAllLINQ()
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = (from Usuario in context.Usuario
                                 select new
                                 {
                                     IdUsuario = Usuario.IdUsuario,
                                     Nombre = Usuario.Nombre,
                                     ApellidoPaterno = Usuario.ApellidoPaterno,
                                     ApellidoMaterno = Usuario.ApellidoMaterno,
                                     UserName = Usuario.UserName,
                                     Email = Usuario.Email,
                                     Password = Usuario.Password,
                                     FechaNacimiento = Usuario.FechaNacimiento,
                                     Sexo = Usuario.Sexo,
                                     Telefono = Usuario.Telefono,
                                     Celular = Usuario.Celular,
                                     CURP = Usuario.CURP
                                 }).ToList();

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
                return (false, "Ocurrio un error: " + ex.Message, null, ex);
            }
        }
        public static (bool, string, ML.Usuario, Exception) GetByIdLINQ(int idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = (from Usuario in context.Usuario
                                 where Usuario.IdUsuario == idUsuario
                                 select Usuario).SingleOrDefault();

                    if (query != null)
                    {
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.UserName = query.UserName;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.FechaNacimiento = query.FechaNacimiento;
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.CURP = query.CURP;

                    };

                    return (true, null, usuario, null);

                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error: " + ex.Message, null, ex);
            }
        }
    }
}
