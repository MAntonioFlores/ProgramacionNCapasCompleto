using DL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsuarioDireccion
    {
        public static (bool, string, Exception) AddUsuarioDireccion(ML.Usuario usuario)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new MFloresProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDLEF = new DL_EF.Usuario();

                    int rowsAffected = context.UsuarioDireccionAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UserName, usuario.Email, usuario.Password,
                        usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen, usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

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
                return (false, ex.Message, ex);
            }
        }
        public static (bool, string, Exception) UpdateUsuarioDireccion(ML.Usuario usuario)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new MFloresProgramacionNCapasEntities())
                {
                    int rowsAffected = context.UsuarioUpdateDire(usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                            usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen,
                             usuario.Rol.IdRol, usuario.Direccion.IdDireccion, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior,
                            usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

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
                return (false, ex.Message, ex);

            }
        }
        public static (bool, string, Exception) DeleteUsuarioDireccion(int IdUsuario, int IdDireccion)
        {
            bool resultado = false;
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new MFloresProgramacionNCapasEntities())
                {
                    int rowsAffected = context.UsuarioDeleteDire(IdUsuario, IdDireccion);
                    if (rowsAffected > 0)
                    {
                        resultado = true;
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
                return (false, ex.Message, ex);
            }
        }
        public static (bool, string, ML.Usuario, Exception) GetAllUsuarioDireccion(ML.Usuario usuarioBusqueda)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new MFloresProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetAllUsuarioDireccionLike(usuarioBusqueda.Nombre, usuarioBusqueda.ApellidoPaterno, usuarioBusqueda.ApellidoMaterno).ToList();

                    if (query.Count > 0)
                    {
                        if (usuarioBusqueda.Usuarios == null)
                        {
                            usuarioBusqueda.Usuarios = new List<object>();
                        }

                        foreach (var registro in query)
                        {
                            ML.Usuario usuarioObj = new ML.Usuario();

                            usuarioObj.IdUsuario = registro.IdUsuario;
                            usuarioObj.Nombre = registro.NombreUsuario;
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
                            usuarioObj.Imagen = registro.Imagen;

                            usuarioObj.Rol = new ML.Rol();
                            usuarioObj.Rol.IdRol = registro.IdRol.Value;
                            usuarioObj.Rol.Nombre = registro.NombreRol;

                            usuarioObj.Direccion = new ML.Direccion();
                            usuarioObj.Direccion.IdDireccion = registro.IdDireccion;
                            usuarioObj.Direccion.Calle = registro.Calle;
                            usuarioObj.Direccion.NumeroInterior = registro.NumeroInterior;
                            usuarioObj.Direccion.NumeroExterior = registro.NumeroExterior;

                            usuarioObj.Direccion.Colonia = new ML.Colonia();
                            usuarioObj.Direccion.Colonia.IdColonia = registro.IdColonia.Value;
                            usuarioObj.Direccion.Colonia.NombreColonia = registro.NombreColonia;
                            usuarioObj.Direccion.Colonia.CodigoPostal = registro.CodigoPostal;

                            usuarioObj.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuarioObj.Direccion.Colonia.Municipio.IdMunicipio = registro.IdMunicipio.Value;
                            usuarioObj.Direccion.Colonia.Municipio.NombreMunicipio = registro.NombreMunicipio;

                            usuarioObj.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuarioObj.Direccion.Colonia.Municipio.Estado.IdEstado = registro.IdEstado.Value;
                            usuarioObj.Direccion.Colonia.Municipio.Estado.NombreEstado = registro.NombreEstado;

                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais.IdPais = registro.IdPais.Value;
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais.NombrePais = registro.NombrePais;


                            usuarioBusqueda.Usuarios.Add(usuarioObj);


                        }
                        return (true, null, usuarioBusqueda, null);
                    }
                    else
                    {
                        return (false, null, usuarioBusqueda, null);
                    }

                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
        public static (bool, string, ML.Usuario, Exception) GetByIdUsuarioDireccion(int idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new MFloresProgramacionNCapasEntities())
                {
                    var objUsuario = context.UsuarioGetByIdDireccion(idUsuario).SingleOrDefault();

                    if (objUsuario != null)
                    {
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Nombre = objUsuario.NombreUsuario;
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
                        usuario.Imagen = objUsuario.Imagen;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.IdRol.Value;
                        usuario.Rol.Nombre = objUsuario.NombreRol;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objUsuario.IdDireccion;
                        usuario.Direccion.Calle = objUsuario.Calle;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExterior = objUsuario.NumeroExterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia;
                        usuario.Direccion.Colonia.NombreColonia = objUsuario.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = objUsuario.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.NombreMunicipio = objUsuario.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.NombreEstado = objUsuario.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.NombrePais = objUsuario.NombrePais;

                        return (true, null, usuario, null);
                    }
                    else
                    {

                        return (false, "No data", null, null);
                    }

                }
            }
            catch (Exception e)
            {
                return (false, e.Message, null, e);
            }
        }
        public static (bool, string, Exception) CambiarStatus(int idUsuario, bool status)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var result = context.CambioEstatus(idUsuario, status);
                    if (result > 0)
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
                return (false, ex.Message, ex);
            }
        }
    }
}
