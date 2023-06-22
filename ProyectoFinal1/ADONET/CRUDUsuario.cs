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
    public class CRUDUsuario
    {

        static string connectionString = @"Server=P533750\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";



        // Método para insertar un nuevo usuario en la Base de Datos
        // Recibe un objeto Usuario con la información del usuario a crear
        // Devuelve el Id asignado al nuevo registro
        public int CrearUsuario(Usuario usuario)
        {
            // Creamos una nueva conexión a la base de datos utilizando el string de conexión que se recibió en el constructor
            using (var connection = new SqlConnection(connectionString))
            {
                // Abrimos la conexión
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) 
                                   VALUES (@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail);
                                   SELECT SCOPE_IDENTITY();";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto Usuario recibido como parámetro
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    command.Parameters.AddWithValue("@Mail", usuario.Mail);

                    // Ejecutamos la consulta SQL utilizando ExecuteScalar() que retorna el id generado para nuevo registro insertado
                    return (int)(decimal)command.ExecuteScalar();
                }

            }
        }

        // Método para eliminar un usuario de la Base de Datos según su Id
        // Recibe el Id del usuario que se desea eliminar
        // Devuelve true si la eliminación fue exitosa, false si no
        public bool EliminarUsuario(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"DELETE FROM Usuario WHERE Id = @Id";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos el parámetro correspondiente a la consulta SQL utilizando el Id recibido como parámetro
                    command.Parameters.AddWithValue("@Id", id);

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se eliminó el usuario correctamente, o 0 si no se encontró el usuario con el Id correspondiente
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para modificar un usuario existente en la Base de Datos
        // Recibe un objeto Usuario con la información actualizada del usuario a modificar
        // Devuelve true si la modificación fue exitosa, false si no
        public bool ModificarUsuario(Usuario usuario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, 
                                   NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Mail = @Mail 
                                   WHERE Id = @Id";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto Usuario recibido como parámetro
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    command.Parameters.AddWithValue("@Mail", usuario.Mail);
                    command.Parameters.AddWithValue("@Id", usuario.Id);

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se modificó el usuario correctamente, o 0 si no se encontró el usuario con el Id correspondiente
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para obtener la información de un usuario según su Id
        // Recibe el Id del usuario que se desea obtener
        // Devuelve un objeto Usuario con la información correspondiente, o null si no se encontró
        public static Usuario TraerUsuarioPorId(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail 
                                   FROM Usuario WHERE Id = @Id";
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
                            // Creamos un nuevo objeto Usuario con la información obtenida del objeto SqlDataReader
                            return new Usuario
                            {
                                Id = (int)reader.GetInt64(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                NombreUsuario = reader.GetString(3),
                                Contraseña = reader.GetString(4),
                                Mail = reader.GetString(5)
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

        public static List<Usuario> TraerListaUsuarios()
        {
    
                //string connectionString = @"Server=P533750\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
                var query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario";
                List<Usuario> listaUsuarios = new List<Usuario>();

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
                                    var usuario = new Usuario();
                                    usuario.Id = (int)dr.GetInt64(0);
                                    usuario.Nombre = dr.GetString(1);
                                    usuario.Apellido = dr.GetString(2);
                                    usuario.NombreUsuario = dr.GetString(3);
                                    usuario.Contraseña = dr.GetString(4);
                                    usuario.Mail = dr.GetString(5);
                                    listaUsuarios.Add(usuario);
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
                return listaUsuarios;
            
        }
    }
}
