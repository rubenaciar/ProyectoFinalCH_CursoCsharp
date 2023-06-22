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
    public class CRUDProducto
    {
        static string connectionString = @"Server=P533750\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";

        // Método para insertar un nuevo Producto en la Base de Datos
        // Recibe un objeto Producto con la información del Producto a crear
        // Devuelve el Id asignado al nuevo registro
        public int CrearProducto(Producto producto)
        {
            // Creamos una nueva conexión a la base de datos utilizando el string de conexión que se recibió en el constructor
            using (var connection = new SqlConnection(connectionString))
            {
                // Abrimos la conexión
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"INSERT INTO Producto (Descripcion,Costo,PrecioVenta,Stock,IdUsuario) 
                                   VALUES (@Descripcion,@Costo,@PrecioVenta,@Stock,@IdUsuario);
                                   SELECT SCOPE_IDENTITY();";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto Producto recibido como parámetro
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Costo", producto.Costo);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

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
                const string query = @"DELETE FROM Producto WHERE Id = @Id";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos el parámetro correspondiente a la consulta SQL utilizando el Id recibido como parámetro
                    command.Parameters.AddWithValue("@Id", id);

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se eliminó el producto correctamente, o 0 si no se encontró el producto con el Id correspondiente
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para modificar un producto existente en la Base de Datos
        // Recibe un objeto producto con la información actualizada del producto a modificar
        // Devuelve true si la modificación fue exitosa, false si no

        public bool ModificarProducto(Producto producto)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"UPDATE Producto SET Descripcion = @Descripcion,Costo = @Costo, PrecioVenta = @PrecioVenta,
                                   Stock = @Stock, IDUsuario = @IdUsuario
                                   WHERE Id = @Id";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto Producto recibido como parámetro
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Costo", producto.Costo);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                    command.Parameters.AddWithValue("@Id", producto.Id);


                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se modificó el producto correctamente, o 0 si no se encontró el producto con el Id correspondiente
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para obtener la información de un producto según su Id
        // Recibe el Id del producto que se desea obtener
        // Devuelve un objeto producto con la información correspondiente, o null si no se encontró
        public static Producto TraerProductoPorId(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"SELECT Id,Descripcion,Costo,PrecioVenta,Stock,IdUsuario
                                   FROM Producto WHERE Id = @Id";
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
                            // Creamos un nuevo objeto Producto con la información obtenida del objeto SqlDataReader
                            return new Producto
                            {
                                Id = (int)reader.GetInt64(0),
                                Descripcion = reader.GetString(1),
                                Costo = reader.GetDecimal(2),
                                PrecioVenta = reader.GetDecimal(3),
                                Stock = reader.GetInt32(4),
                                IdUsuario = (int)reader.GetInt64(5)
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

        public static List<Producto> TraerListaProductos()
        {

            //string connectionString = @"Server=P533750\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id,Descripcion,Costo,PrecioVenta,Stock,IdUsuario FROM Producto";
            List<Producto> listaProductos = new List<Producto>();

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

                            // Mientras la conexión está abierta, el datareader se puede leer, almacenar el producto y agregarlo a lista
                            while (dr.Read())
                            {
                                var producto = new Producto();
                                producto.Id = (int)dr.GetInt64("Id");
                                producto.Descripcion = dr.GetString("Descripcion");
                                producto.Costo = dr.GetDecimal("Costo");
                                producto.PrecioVenta = dr.GetDecimal("PrecioVenta");
                                producto.Stock = dr.GetInt32("Stock");
                                producto.IdUsuario = (int)dr.GetInt64("IdUsuario");
                                listaProductos.Add(producto);
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
            return listaProductos;

        }
    }
}
