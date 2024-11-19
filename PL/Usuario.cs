using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void AddSQLClient()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Escriba el Nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Escriba el Apellido Paterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Escriba el Apellido Materno");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Escriba un Username");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Escriba su Email");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Escriba su Contrasena\n Debe contener al Menos: \n Una Mayuscula\n Una Minuscula\n Y un Caracter");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Escriba su Fecha de Nacimiento");
            usuario.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Escriba su Sexo (M o F)");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Escriba su Telefono");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Escriba su Celular");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Escriba su CURP");
            usuario.CURP = Console.ReadLine();

            var resultado = BL.Usuario.Add(usuario);

            if (resultado == true)
            {
                Console.WriteLine("se inserto correctamente\n");
                Console.WriteLine("----------------------------------------");
            }
            else
            {
                Console.WriteLine("No Se Pudo Insertar\n" + resultado);
                Console.WriteLine("----------------------------------------");
            }
        }
        public static void UpdateSQLClient()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Escriba el Nombre al que Actualizara");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Escriba el Apellido Paterno al que Actualizara");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Escriba el Apellido Materno al que Actualizara");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Escriba un Username al que Actualizara");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Escriba su Email al que Actualizara");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Escriba su Contrasena al que Actualizara");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Escriba su Fecha de Nacimiento al que Actualizara (Año a 4 digitos, Mes, Día");
            usuario.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Escriba su Sexo (M o F) al que Actualizara");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Escriba su Telefono al que Actualizara");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Escriba su Celular al que Actualizara");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Escriba su CURP al que Actualizara");
            usuario.CURP = Console.ReadLine();
            Console.WriteLine("Escriba sel ID al que Se Aplicaran los Cambios");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            var resultado = BL.Usuario.Update(usuario);

            if (resultado == true)
            {
                Console.WriteLine("Se Actualizo Correctamente\n");
                Console.WriteLine("----------------------------------------");
            }
            else
            {
                Console.WriteLine("No Se Pudo Actualizar\n" + resultado);
                Console.WriteLine("----------------------------------------");
            }
        }
        public static void DeleteSQLClient()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Escriba el ID que se va a Eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            var resultado = BL.Usuario.Delete(usuario);

            if (resultado == true)
            {
                Console.WriteLine("se elimino correctamente\n");
                Console.WriteLine("----------------------------------------");
            }
            else
            {
                Console.WriteLine("no se pudo eliminar\n" + resultado);
                Console.WriteLine("----------------------------------------");
            }
        }
        public static void GetAllSQLClient()
        {
            ML.Usuario usuario = BL.Usuario.GetAll();
            foreach (ML.Usuario usuarioRegistro in usuario.Usuarios)
            {
                Console.WriteLine("ID Usuario: " + usuarioRegistro.IdUsuario);
                Console.WriteLine("Nombre: " + usuarioRegistro.Nombre);
                Console.WriteLine("Apellido Paterno: " + usuarioRegistro.ApellidoPaterno);
                Console.WriteLine("Apellido Materno: " + usuarioRegistro.ApellidoMaterno);
                Console.WriteLine("UserName: " + usuarioRegistro.UserName);
                Console.WriteLine("Email: " + usuarioRegistro.Email);
                Console.WriteLine("Password: " + usuarioRegistro.Password);
                Console.WriteLine("FechaNacimiento: " + usuarioRegistro.FechaNacimiento);
                Console.WriteLine("Sexo: " + usuarioRegistro.Sexo);
                Console.WriteLine("Telefono: " + usuarioRegistro.Telefono);
                Console.WriteLine("Celular:" + usuarioRegistro.Celular);
                Console.WriteLine("CURP: " + usuarioRegistro.CURP);
                Console.WriteLine("----------------------------------------");
            }
        }
        public static void GetByIdSQLClient()
        {
            Console.WriteLine("Escriba el ID Donde se va a Consultar");
            int idUsuario = Convert.ToInt32(Console.ReadLine());
            ML.Usuario usuario = BL.Usuario.GetById(idUsuario);

            Console.WriteLine("IdUsuario: " + usuario.IdUsuario);
            Console.WriteLine("Nombre: " + usuario.Nombre);
            Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
            Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
            Console.WriteLine("UserName: " + usuario.UserName);
            Console.WriteLine("Email: " + usuario.Email);
            Console.WriteLine("Password: " + usuario.Password);
            Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
            Console.WriteLine("Sexo: " + usuario.Sexo);
            Console.WriteLine("Telefono: " + usuario.Telefono);
            Console.WriteLine("Celular: " + usuario.Celular);
            Console.WriteLine("CURP: " + usuario.CURP);
            Console.WriteLine("----------------------------------------");

        }
    }
}

