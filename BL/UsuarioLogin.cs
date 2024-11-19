using DL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsuarioLogin
    {
        public static (bool, string, ML.Usuario, Exception) LoginEmail(string email)
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new MFloresProgramacionNCapasEntities())
                {
                    var result = context.UsuarioLogin(email).SingleOrDefault();

                    if (result != null)
                    {
                        usuario.IdUsuario = result.IdUsuario;
                        usuario.Email = result.Email;
                        usuario.Password = result.Password;

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
    }
}
