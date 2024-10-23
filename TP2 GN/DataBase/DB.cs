using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_GN.Models;

namespace TP2_GN.DataBase
{
    internal class DB
    {

        private readonly string _connection;
        public string Connection => _connection;

        public DB()
        {
            _connection = @"Server=DESKTOP-PRJRN6F\DBSERVER; Database=Registro_Profesores;";
        }

        internal ObservableCollection<Profesor> Get()
        {
            ObservableCollection<Profesor> lastResult = new ObservableCollection<Profesor>();

            string query = "SELECT * FROM profesores";

            using (SqlConnection connect = new SqlConnection(Connection))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lastResult.Add(new Profesor()
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

        internal void Add(Profesor model)
        {
            string query = "INSERT INTO profesores VALUES(@id, @nombre, @apellido, @materia)";

            using (SqlConnection connect = new SqlConnection(Connection))
            {
                connect.Open();

                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@id", model.Id);
                cmd.Parameters.AddWithValue("@nombre", model.Nombre);
                cmd.Parameters.AddWithValue("@apellido", model.Apellido);
                cmd.Parameters.AddWithValue("@materia", model.Materia);

                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        internal void Delete(Profesor model)
        {
            string query = "DELETE FROM profesores WHERE id=@id";

            using (SqlConnection connect = new SqlConnection(Connection))
            {
                connect.Open();

                SqlCommand cmd = new SqlCommand(query, connect);

                cmd.Parameters.AddWithValue("@id", model.Id);
                cmd.ExecuteNonQuery();
                connect.Close();
            }

        }

        internal void Edit(Profesor model)
        {

            string query = "UPDATE profesores SET nombre=@nombre, apellido=@apellido, materia=@materia WHERE id=@id";

            using (SqlConnection connect = new SqlConnection(Connection))
            {
                connect.Open();

                SqlCommand cmd = new SqlCommand(query, connect);
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

    