using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("Elige una de las opciones");
                Console.WriteLine("1. Insertar");
                Console.WriteLine("2. Actualizar");
                Console.WriteLine("3. Borrar");
                Console.WriteLine("4. Mostrar todos los registros");
                Console.WriteLine("5. Mostrar un Registro");
                Console.WriteLine("6. Salir");


                int opcion = Convert.ToInt16(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        //PL.Usuario.AddSQLClient();
                        //PL.UsuarioLINQ.AddLINQ();
                        //PL.UsuarioEF.AddEF();
                        PL.UsuarioRol.AddRol();
                        break;

                    case 2:

                        //PL.Usuario.UpdateSQLClient();
                        //PL.UsuarioLINQ.UpdateLINQ();
                        //PL.UsuarioEF.UpdateEF();
                        PL.UsuarioRol.UpdateRol();
                        break;

                    case 3:

                        //PL.Usuario.DeleteSQLClient();
                        //PL.UsuarioLINQ.DeleteLINQ();
                        //PL.UsuarioEF.DeleteEF();
                        PL.UsuarioRol.DeleteRol();
                        break;

                    case 4:

                        //PL.Usuario.GetAllSQLClient();
                        //PL.UsuarioLINQ.GetAllLINQ();
                        //PL.UsuarioEF.GetAllEF();
                        //PL.UsuarioRol.GetAllRol();
                        PL.UsuarioRol.GetAllUsuarioRol();
                        break;

                    case 5:

                        //PL.Usuario.GetByIdSQLClient();
                        //PL.UsuarioLINQ.GetByIdLINQ();
                        //PL.UsuarioEF.GetByIdEF();
                        //PL.UsuarioRol.GetByIdRol();
                        PL.UsuarioRol.GetByIdUsuarioRol();
                        break;

                    case 6:

                        salir = true;
                        break;
                }
            }
        }
    }
}
