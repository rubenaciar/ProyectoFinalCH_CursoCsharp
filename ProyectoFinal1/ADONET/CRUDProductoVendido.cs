using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProyectoFinal1.Modelos;

namespace ProyectoFinal1
{
    public class CRUDProductoVendido
    {

        static string connectionString = @"Server=P533750\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";


        // Método para insertar un nuevo ProductoVendido en la Base de Datos
        // Recibe un objeto ProductoVendido con la información del ProductoVendido a crear
        // Devuelve el Id asignado al nuevo registro
        public int CrearProductoVendido(ProductoVendido productoVendido)
        {
            // Creamos una nueva conexión a la base de datos utilizando el string de conexión que se recibió en el constructor
            using (var connection = new SqlConnection(connectionString))
            {
                // Abrimos la conexión
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta) 
                                   VALUES (@Stock,@IdProducto,,@IdVenta);
                                   SELECT SCOPE_IDENTITY();";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto ProductoVendido recibido como parámetro
                    command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                    command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                    command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);

                    // Ejecutamos la consulta SQL utilizando ExecuteScalar() que retorna el id generado para nuevo registro insertado
                    return (int)(decimal)command.ExecuteScalar();
                }
            }
        }

        // Método para eliminar un producto de la Base de Datos según su Id
        // Recibe el Id del producto que se desea eliminar
        // Devuelve true si la eliminación fue exitosa, false si no
        public bool EliminarProducto(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"DELETE FROM ProductoVendido WHERE Id = @Id";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos el parámetro correspondiente a la consulta SQL utilizando el Id recibido como parámetro
                    command.Parameters.AddWithValue("@Id", id);

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se eliminó el ProductoVendido correctamente, o 0 si no se encontró el ProductoVendido con el Id correspondiente
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para modificar un ProductoVendido existente en la Base de Datos
        // Recibe un objeto ProductoVendido con la información actualizada del ProductoVendido a modificar
        // Devuelve true si la modificación fue exitosa, false si no

        public bool ModificarProductoVendido(ProductoVendido productoVendido)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"UPDATE ProductoVendido SET Stock = @Stock,IdProducto = @IdProducto, IdVenta = @IdVenta
                                   WHERE Id = @Id";

                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto ProductoVendido recibido como parámetro
                    command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                    command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                    command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);
                    command.Parameters.AddWithValue("@Id", productoVendido.Id);


                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se modificó el ProductoVendido correctamente, o 0 si no se encontró el ProductoVendido con el Id correspondiente
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para obtener la información de un ProductoVendido según su Id
        // Recibe el Id del ProductoVendido que se desea obtener
        // Devuelve un objeto ProductoVendido con la información correspondiente, o null si no se encontró
        public static ProductoVendido TraerProductoVendidoPorId(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"SELECT Id,Stock,IdProducto,IdVenta FROM ProductoVendido WHERE Id = @Id";
                /*const string query = @"SELECT ProdVend.IdProducto,Prod.Descripcion,Prod.Costo,Prod.PrecioVenta,ProdVend.Stock as 'Cantidad'
                                       FROM [ProductoVendido] ProdVend INNER JOIN [Producto] Prod ON ProdVend.[IdProducto] = Prod.[Id]
                                       WHERE Id = @Id";*/
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos el parámetro correspondiente a la consulta SQL utilizando el Id recibido como parámetro
                    command.Parameters.AddWithValue("@Id", id);

                    // Ejecutamos la consulta SQL utilizando ExecuteReader() que retorna un objeto SqlDataReader que podemos utilizar para leer los datos devueltos por la consulta SQL
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Creamos un nuevo objeto ProductoVendido con la información obtenida del objeto SqlDataReader
                            return new ProductoVendido
                            {
                                Id = (int)reader.GetInt64(0),
                                Stock = reader.GetInt32(1),
                                IdProducto = (int)reader.GetInt64(2),
                                IdVenta = (int)reader.GetInt64(3)
                        };
                        }
                        else
                        {
                            // Si no se encontró ningún registro, devolvemos null
                            return null;
                        }
                    }
                }
            }
        }

        public static List<ProductoVendido> TraerListaProductoVendidos()
        {

            //string connectionString = @"Server=P533750\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id,Stock,IdProducto,IdVenta FROM ProductoVendido";
            var listaProductoVendidos = new List<ProductoVendido>();

            //Creamos una instancia de conexión utilizando el string a nuestra BD, usando using para limpiar los recursos

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                // Abrimos nuestra conexion a la BD
                conect.Open();
                // Enviamos el comando que necesitamos ejecutar en nuestra BD para la conexión creada
                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    // La BD devuelve la información a través de un objeto datareader
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        // Verifico que el la consulta trajo datos
                        if (dr.HasRows)
                        {

                            // Mientras la conexión está abierta, el datareader se puede leer, almacenar el ProductoVendido y agregarlo a lista
                            while (dr.Read())
                            {
                                var productoVendido = new ProductoVendido();
                                productoVendido.Id = (int)dr.GetInt64("Id");
                                productoVendido.Stock = dr.GetInt32("Stock");
                                productoVendido.IdProducto = (int)dr.GetInt64("IdProducto");
                                productoVendido.IdVenta = (int)dr.GetInt64("IdVenta");
                                listaProductoVendidos.Add(productoVendido);
                            }
                        }
                        else
                        {
                            // Cerramos nuestra conexion a la BD
                            conect.Close();
                            return null;
                        }

                    }
                }
                // Cerramos nuestra conexion a la BD
                conect.Close();
            }
            return listaProductoVendidos;

        }
    }
}
