using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservasDeLaboratorio.Repository
{
    internal class LaboratorioRepository : ILaboratorioRepository
    {
        private string _connectionString;

        public LaboratorioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Agregar(Model.Laboratorio entidad)
        {
            string sql = "INSERT INTO Laboratorios (NumeroAsignado, Ubicacion, Capacidad) VALUES (@NumeroAsignado, @Ubicacion, @Capacidad)";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@NumeroAsignado", entidad.NumeroAsignado);
                        command.Parameters.AddWithValue("@Ubicacion", entidad.Ubicacion);
                        command.Parameters.AddWithValue("@Capacidad", entidad.Capacidad);

                        connection.Open();

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al agregar el laboratorio.", ex);
            }
        }

        public void Actualizar(Model.Laboratorio entidad)
        {
            string sql = "UPDATE Laboratorios SET Ubicacion = @Ubicacion, Capacidad = @Capacidad WHERE NumeroAsignado = @NumeroAsignado";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@NumeroAsignado", entidad.NumeroAsignado);
                        command.Parameters.AddWithValue("@Ubicacion", entidad.Ubicacion);
                        command.Parameters.AddWithValue("@Capacidad", entidad.Capacidad);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al actualizar el laboratorio.", ex);
            }

        }

        public void Eliminar(Model.Laboratorio entidad)
        {
            string sql = "DELETE FROM Laboratorios WHERE NumeroAsignado = @NumeroAsignado";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@NumeroAsignado", entidad.NumeroAsignado);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al eliminar el laboratorio.", ex);
            }
        }

        public Model.Laboratorio ObtenerPorId(int id)
        {
            string sql = "SELECT NumeroAsignado, Ubicacion, Capacidad FROM Laboratorios WHERE NumeroAsignado = @NumeroAsignado";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@NumeroAsignado", id);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Model.Laboratorio(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetInt32(2)
                                );
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener el laboratorio por ID.", ex);
            }
        }

        public IEnumerable<Model.Laboratorio> ObtenerTodos()
        {
            List<Model.Laboratorio> laboratorios = new List<Model.Laboratorio>();
            string sql = "SELECT NumeroAsignado, Ubicacion, Capacidad FROM Laboratorios";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                laboratorios.Add(new Model.Laboratorio(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetInt32(2)
                                ));
                            }
                        }
                    }
                }
                return laboratorios;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener todos los laboratorios.", ex);
            }
        }
    }
}
