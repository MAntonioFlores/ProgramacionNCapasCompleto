using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static (bool, string, Exception) AddEF(ML.Producto producto)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    int rowsAffected = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento,
                        producto.Descripcion, producto.Imagen);

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
        public static (bool, string, Exception) UpdateEF(ML.Producto producto)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    int rowsAffected = context.ProductoUpdate(producto.IdProducto, producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento,
                        producto.Descripcion, producto.Imagen);
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
        public static (bool, string, ML.Producto, Exception) DeleteLINQ(int IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = (from Producto in context.Producto
                                 where IdProducto == Producto.IdProducto
                                 select Producto).FirstOrDefault();
                    context.Producto.Remove(query);
                    context.SaveChanges();
                    return (true, null, producto, null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
        public static (bool, string, ML.Producto, Exception) GetByIdLINQ(int IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = (from Producto in context.Producto
                                 where IdProducto == Producto.IdProducto
                                 select Producto).SingleOrDefault();
                    if (query != null)
                    {
                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.Nombre;
                        producto.PrecioUnitario = query.PrecioUnitario;
                        producto.Stock = query.Stock;
                        producto.Descripcion = query.Descripcion;
                        producto.Imagen = query.Imagen;

                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.IdProveedor = query.IdProveedor.Value;
                        producto.Proveedor.Nombre = query.Nombre;

                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.IdDepartamento = query.IdDepartamento.Value;
                        producto.Departamento.NombreDepartamento = query.Nombre;

                        producto.Departamento.Area = new ML.Area();
                        producto.Departamento.Area.IdArea = query.Departamento.IdArea.Value;
                        producto.Departamento.Area.NombreArea = query.Departamento.Area.Nombre;

                        return (true, null, producto, null);
                    }
                    else
                    {
                        return (false, null, producto, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }

        public static (bool, string, ML.Producto) GetAllEF(ML.Producto busqueda)
        {
            ML.Producto producto = new ML.Producto();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var registros = context.ProductoGetAll(busqueda.Nombre).ToList();

                    if (registros.Count > 0)
                    {
                        producto.Productos = new List<ML.Producto>();

                        foreach (var registro in registros)
                        {
                            ML.Producto productoObj = new ML.Producto();

                            productoObj.IdProducto = registro.IdProducto;
                            productoObj.Nombre = registro.NombreProducto;
                            productoObj.PrecioUnitario = registro.PrecioUnitario;
                            productoObj.Stock = registro.Stock;
                            productoObj.Descripcion = registro.Descripcion;
                            productoObj.Imagen = registro.Imagen;

                            productoObj.Proveedor = new ML.Proveedor();
                            productoObj.Proveedor.IdProveedor = registro.IdProveedor.Value;
                            productoObj.Proveedor.Nombre = registro.NombreProveedor;

                            productoObj.Departamento = new ML.Departamento();
                            productoObj.Departamento.IdDepartamento = registro.IdDepartamento.Value;
                            productoObj.Departamento.NombreDepartamento = registro.NombreDepartamento;

                            productoObj.Departamento.Area = new ML.Area();
                            productoObj.Departamento.Area.IdArea = registro.IdArea.Value;
                            productoObj.Departamento.Area.NombreArea = registro.NombreArea;

                            producto.Productos.Add(productoObj);
                        }
                        return (true, null, producto);
                    }
                    else
                    {
                        return (false, null, producto);
                    }
                }
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null);
            }
        }

        public static (bool, string, ML.Producto, Exception) GetAllEFSB()
        {
            ML.Producto producto = new ML.Producto();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var registros = context.ProductoGetAllSinBusqueda().ToList();

                    if (registros.Count > 0)
                    {
                        producto.Productos = new List<ML.Producto>();

                        foreach (var registro in registros)
                        {
                            var productoObj = new ML.Producto
                            {

                                IdProducto = registro.IdProducto,
                                Nombre = registro.NombreProducto,
                                PrecioUnitario = registro.PrecioUnitario,
                                Stock = registro.Stock,
                                Descripcion = registro.Descripcion,
                                Imagen = registro.Imagen,

                                Proveedor = new ML.Proveedor
                                {
                                    IdProveedor = registro.IdProveedor.Value,
                                    Nombre = registro.NombreProveedor
                                },

                                Departamento = new ML.Departamento
                                {
                                    IdDepartamento = registro.IdDepartamento.Value,
                                    NombreDepartamento = registro.NombreDepartamento,
                                    Area = new ML.Area
                                    {
                                        IdArea = registro.IdArea.Value,
                                        NombreArea = registro.NombreArea
                                    }
                                }
                            };
                            producto.Productos.Add(productoObj);
                        }
                        return (true, null, producto, null);
                    }
                    else
                    {
                        return (false, null, producto, null);
                    }
                }
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null, ex);
            }
        }

        public static (bool, string, List<ML.Producto>, Exception) CargaMasivaExcel(string connectionString)
        {
            try
            {
                using (OleDbConnection context = new OleDbConnection(connectionString))
                {
                    var query = "SELECT * FROM [Sheet1$]";//de donde va a jalar los datos que son las hojas, si viene en ingles tu excel es sheet si es en español es hoja.
                    using (OleDbCommand cmd = new OleDbCommand())
                    {

                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.Connection.Open();

                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);

                        DataTable dataTable = new DataTable();

                        dataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            List<ML.Producto> productos = new List<ML.Producto>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                ML.Producto producto = new ML.Producto();
                                producto.Nombre = row[0].ToString();
                                producto.PrecioUnitario = decimal.Parse(row[1].ToString());
                                producto.Stock = int.Parse(row[2].ToString());
                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse(row[3].ToString());
                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[4].ToString());
                                producto.Descripcion = row[5].ToString();
                                producto.Imagen = row[6].ToString();

                                productos.Add(producto);

                            }
                            return (true, null, productos, null);
                        }
                        else
                        {
                            return (true, "", null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null, ex);
            }
        }
        public static (bool, string, Exception) CargaMasivaTxt(string connectionString)
        {
            try
            {
                string path = connectionString;
                if (File.Exists(path))
                {
                    StreamReader reader = new StreamReader(path);
                    string linea;
                    //Console.ReadLine();
                    reader.ReadLine();
                    while ((linea = reader.ReadLine()) != null)
                    {

                        string[] datos = linea.Split('|');


                        ML.Producto producto = new ML.Producto();
                        producto.Nombre = datos[0];
                        producto.PrecioUnitario = decimal.Parse(datos[1]);
                        producto.Stock = int.Parse(datos[2]);
                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.IdDepartamento = int.Parse(datos[3]);
                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.IdProveedor = int.Parse(datos[4]);
                        producto.Descripcion = datos[5];

                        BL.Producto.AddEF(producto);
                    }
                    return (true, null, null);
                }
                else
                {
                    return (false, null, null);
                }

            }
            catch (Exception ex)
            {

                return (false, ex.Message, ex);
            }
        }

        public static (bool, ML.ResultExcel, Exception) ValidarDatos(List<ML.Producto> Object)
        {
            try
            {
                ML.ResultExcel resultExcel = new ML.ResultExcel();

                resultExcel.Errores = new List<ML.ResultExcel>();
                string MensajeError;
                int contador = 2;

                foreach (ML.Producto producto in Object)
                {
                    MensajeError = "";
                    MensajeError += (producto.Nombre == "") ? "No Contiene Nombre" : "";
                    MensajeError += (producto.PrecioUnitario == 0) ? "No Tiene Precio" : "";
                    MensajeError += (producto.Stock == 0) ? "No Tiene Stock" : "";
                    MensajeError += (producto.Departamento.IdDepartamento == 0) ? "No Tiene Departamento" : "";
                    MensajeError += (producto.Proveedor.IdProveedor == 0) ? "No Tiene Proveedor" : "";
                    MensajeError += (producto.Descripcion == "") ? "No Contiene Descripcion" : "";

                    if (MensajeError != "") // si hay errores
                    {
                        ML.ResultExcel errorFila = new ML.ResultExcel();
                        errorFila.IdRegistro = contador;
                        errorFila.Mensaje = MensajeError;
                        resultExcel.Errores.Add(errorFila);
                    }
                    contador++;
                }
                return (true, resultExcel, null);
            }
            catch (Exception ex)
            {
                return (false, null, ex);
            }
        }
    }
}
