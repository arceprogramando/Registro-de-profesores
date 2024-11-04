using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_GN.Models;
using MySql.Data.MySqlClient;
using TP2_GN.Utilities;

namespace TP2_GN.DataBase
{
    internal class DB
    {

        private readonly string _connection;
        public string Connection => _connection;

        public DB()
        {
            _connection = "Server=localhost;Database=registro_profesores;Uid=root;Pwd=root;";

        }

        internal ObservableCollection<ProfesorModel> Get()
        {
            ObservableCollection<ProfesorModel> lastResult = new ObservableCollection<ProfesorModel>();

            string query = "SELECT * FROM profesores";

                using (MySqlConnection connect = new MySqlConnection(Connection))
                {
                    connect.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connect);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                    lastResult.Add(new ProfesorModel()
                    {
                        Id = reader["ID"] != DBNull.Value ? (int)reader["ID"] : 0,
                        Nombre = reader["NOMBRE"] != DBNull.Value ? (string)reader["NOMBRE"] : string.Empty,
                        Apellido = reader["APELLIDO"] != DBNull.Value ? (string)reader["APELLIDO"] : string.Empty,
                        Domicilio = reader["DOMICILIO"] != DBNull.Value ? (string)reader["DOMICILIO"] : string.Empty,
                        Localidad = reader["LOCALIDAD"] != DBNull.Value ? (string)reader["LOCALIDAD"] : string.Empty,
                        Provincia = reader["PROVINCIA"] != DBNull.Value ? (string)reader["PROVINCIA"] : string.Empty,
                        NroCelular = reader["NRO_CONTACTO"] != DBNull.Value ? (string)reader["NRO_CONTACTO"] : string.Empty,
                        Email = reader["EMAIL"] != DBNull.Value ? (string)reader["EMAIL"] : string.Empty,
                        Categoria = reader["CATEGORIA"] != DBNull.Value ? (string)reader["CATEGORIA"] : string.Empty,
                        NivelEnsenanza = reader["NIVEL_ENSENANZA"] != DBNull.Value ? (string)reader["NIVEL_ENSENANZA"] : string.Empty,
                        Materia = reader["MATERIA"] != DBNull.Value ? (string)reader["MATERIA"] : string.Empty,

                        // Parsear y convertir DiasClase a una lista de enums
                        DiasClase = reader["DIAS_CLASES"] != DBNull.Value
                        ? ((string)reader["DIAS_CLASES"]).Split(',') // Dividir por comas
                            .Select(dia =>
                            {
                                // Intentar parsear cada día
                                if (Enum.TryParse(dia.Trim(), out DiasSemanaEnum resultado))
                                {
                                    return resultado;
                                }
                                else
                                {
                                    // Manejar errores si el valor no es válido
                                    return (DiasSemanaEnum?)null;
                                }
                            })
                            .Where(dia => dia.HasValue) // Filtrar valores nulos
                            .Select(dia => dia.Value) // Seleccionar sólo valores válidos
                            .ToList()
                        : new List<DiasSemanaEnum>(),

                        // Parsear y convertir Turnos a una lista de enums
                        Turnos = reader["TURNOS"] != DBNull.Value
                        ? ((string)reader["TURNOS"]).Split(',')
                            .Select(turno =>
                            {
                                if (Enum.TryParse(turno.Trim(), out TurnosEnum resultado))
                                {
                                    return resultado;
                                }
                                else
                                {
                                    return (TurnosEnum?)null;
                                }
                            })
                            .Where(turno => turno.HasValue)
                            .Select(turno => turno.Value)
                            .ToList()
                        : new List<TurnosEnum>()


                    });
                    }
                    reader.Close();
                    connect.Close();
                }

             return lastResult;
        }


        internal void Add(ProfesorModel model)
        {
            string query = "INSERT INTO profesores (nombre, apellido, domicilio, localidad, provincia, nro_contacto, email," +
                    "categoria, nivel_ensenanza, materia, dias_clases, turnos) VALUES(@Nombre, @Apellido, @Domicilio," +
                    "@Localidad, @Provincia, @Nro_contacto, @Email, @Categoria, @Nivel_ensenanza, @Materia, " +
                    "@Dias_clases, @Turnos)";

            try
            {
                using (MySqlConnection connect = new MySqlConnection(Connection))
                {

                    using (MySqlCommand cmd = new MySqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", model.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", model.Apellido);
                        cmd.Parameters.AddWithValue("@Domicilio", model.Domicilio ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Localidad", model.Localidad ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Provincia", model.Provincia ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Nro_contacto", model.NroCelular ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", model.Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Categoria", model.Categoria ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Nivel_ensenanza", model.NivelEnsenanza ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Materia", model.Materia ?? (object)DBNull.Value);

                        string diasClasesString = string.Join(",", model.DiasClase
                                           .OrderBy(d => d) // Ordena la lista de enums
                                           .Select(d => d.ToString())); // Convierte a string

                        cmd.Parameters.AddWithValue("@Dias_clases", diasClasesString);

                        string turnosString = string.Join(",", model.Turnos
                                              .OrderBy(t => t)
                                              .Select(t => t.ToString()));
                        cmd.Parameters.AddWithValue("@Turnos", turnosString);

                        connect.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejar la excepción, por ejemplo, loguear el error o mostrar un mensaje
                Console.WriteLine($"Error al insertar el profesor: {ex.Message}");
            }
        }

        internal void Delete(ProfesorModel model)
        {
            string query = "DELETE FROM profesores WHERE id=@Id";

            using (MySqlConnection connect = new MySqlConnection(Connection))
            {
                connect.Open();

                MySqlCommand cmd = new MySqlCommand(query, connect);

                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.ExecuteNonQuery();
                connect.Close();
            }

        }

        internal void Edit(ProfesorModel model)
        {

            string query = "UPDATE profesores SET nombre=@Nombre, apellido=@Apellido, materia=@Materia WHERE id=@Id";

            using (MySqlConnection connect = new MySqlConnection(Connection))
            {
                connect.Open();

                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Nombre", model.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", model.Apellido);
                cmd.Parameters.AddWithValue("@Materia", model.Materia);

                cmd.ExecuteNonQuery();
                connect.Close();
            }

        }


    }

}

    