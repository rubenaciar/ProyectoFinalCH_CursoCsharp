using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProyectoFinal1.Modelos;

namespace ProyectoFinal1.ADONET
{
    public class CRUDVenta
    {
        static string connectionString = @"Server=P533750\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";



        // Método para insertar un nuevo Venta en la Base de Datos
        // Recibe un objeto Venta con la información del Venta a crear
        // Devuelve el Id asignado al nuevo registro
        public int CrearVenta(Venta venta)
        {
            // Creamos una nueva conexión a la base de datos utilizando el string de conexión que se recibió en el constructor
            using (var connection = new SqlConnection(connectionString))
            {
                // Abrimos la conexión
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"INSERT INTO Venta (Comentarios,IdUsuario) 
                                   VALUES (@Comentarios,@IdUsuario);
                                   SELECT SCOPE_IDENTITY();";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto Venta recibido como parámetro
                    command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                    command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

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
                const string query = @"DELETE FROM Venta WHERE Id = @Id";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos el parámetro correspondiente a la consulta SQL utilizando el Id recibido como parámetro
                    command.Parameters.AddWithValue("@Id", id);

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se eliminó el Venta correctamente, o 0 si no se encontró el Venta con el Id correspondiente
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para modificar una Venta existente en la Base de Datos
        // Recibe un objeto Venta con la información actualizada del Venta a modificar
        // Devuelve true si la modificación fue exitosa, false si no

        public bool ModificarVenta(Venta venta)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"UPDATE Venta SET Comentarios = @Comentarios, IdUsuario = @IdUsuario
                                   WHERE Id = @Id";

                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto Venta recibido como parámetro
 
                    command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                    command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se modificó el Venta correctamente, o 0 si no se encontró el Venta con el Id correspondiente
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para obtener la información de un Venta según su Id
        // Recibe el Id del Venta que se desea obtener
        // Devuelve un objeto Venta con la información correspondiente, o null si no se encontró
        public static Venta TraerVentaPorId(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"SELECT Id,Comentarios, IdUsuario FROM Venta WHERE Id = @Id";

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
                            // Creamos un nuevo objeto Venta con la información obtenida del objeto SqlDataReader
                            return new Venta
                            {
                                Id = (int)reader.GetInt64(0),
                                Comentarios = reader.GetString(1),
                                IdUsuario = (int)reader.GetInt64(2)
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

        public static List<Venta> TraerListaVentas()
        {

            var query = "SELECT Id, Comentarios, IdUsuario FROM Venta";
            var listaVentas = new List<Venta>();

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

                            // Mientras la conexión está abierta, el datareader se puede leer, almacenar el venta y agregarlo a lista
                            while (dr.Read())
                            {
                                var venta = new Venta();
                                venta.Id = (int)dr.GetInt64("Id");
                                venta.Comentarios = dr.GetString("Comentarios");
                                venta.IdUsuario= (int)dr.GetInt64("IdUsuario");

                                listaVentas.Add(venta);
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
            return listaVentas;

        }
    }
}
