using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_GN.Models;
using MySql.Data.MySqlClient;

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
                            Id = (int)reader["ID"],
                            Nombre = (string)reader["NOMBRE"],
                            Apellido = (string)reader["APELLIDO"],
                            Materia = (string)reader["MATERIA"]
                        });
                    }
                    reader.Close();
                    connect.Close();
                }

                return lastResult;
            }

        internal void Add(ProfesorModel model)
        {
            string query = "INSERT INTO profesores (id, nombre, apellido, materia) VALUES(@id, @nombre, @apellido, @materia)";

            try
            {
                using (MySqlConnection connect = new MySqlConnection(Connection))
                {
                    connect.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@id", model.Id);
                        cmd.Parameters.AddWithValue("@nombre", model.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", model.Apellido);
                        cmd.Parameters.AddWithValue("@materia", model.Materia);

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
            string query = "DELETE FROM profesores WHERE id=@id";

            using (MySqlConnection connect = new MySqlConnection(Connection))
            {
                connect.Open();

                MySqlCommand cmd = new MySqlCommand(query, connect);

                cmd.Parameters.AddWithValue("@id", model.Id);
                cmd.ExecuteNonQuery();
                connect.Close();
            }

        }

        internal void Edit(ProfesorModel model)
        {

            string query = "UPDATE profesores SET nombre=@nombre, apellido=@apellido, materia=@materia WHERE id=@id";

            using (MySqlConnection connect = new MySqlConnection(Connection))
            {
                connect.Open();

                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@id", model.Id);
                cmd.Parameters.AddWithValue("@nombre", model.Nombre);
                cmd.Parameters.AddWithValue("@apellido", model.Apellido);
                cmd.Parameters.AddWithValue("@materia", model.Materia);

                cmd.ExecuteNonQuery();
                connect.Close();
            }

        }


    }

}

    