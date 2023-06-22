using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoFinal1.Modelos;

namespace ProyectoFinal1.ADONET
{
    public class ADO_Sesion
    {

        //static string connectionString = "Server=localhost;Database=SistemaGestion;Trusted_Connection=True;";
        static string connectionString = @"Server=P533750\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        

        public static Usuario IniciarSesion(string nombreUsuario, string contrasena)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                const string query = @"SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contrasena";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@contrasena", contrasena);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
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
                            return null;
                        }
                    }
                }
            }

        }
    }
}
