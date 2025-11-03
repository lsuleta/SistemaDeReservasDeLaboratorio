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
            string sql = "INSERT INTO Laboratorio (NumeroAsignado, UbicacionPiso, CapacidadPuestos) VALUES (@NumeroAsignado, @Ubicacion, @Capacidad)";
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
            // 1. CORRECCIÓN: 
            //    - Agregamos 'NumeroAsignado' al SET.
            //    - Usamos 'LaboratorioID' en el WHERE.
            string sql = @"
        UPDATE Laboratorio 
        SET 
            NumeroAsignado = @NumeroAsignado, 
            UbicacionPiso = @Ubicacion, 
            CapacidadPuestos = @Capacidad 
        WHERE 
            LaboratorioID = @ID"; // ¡Usar la Primary Key!

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // 2. Agregamos TODOS los parámetros
                        command.Parameters.AddWithValue("@NumeroAsignado", entidad.NumeroAsignado);
                        command.Parameters.AddWithValue("@Ubicacion", entidad.Ubicacion);
                        command.Parameters.AddWithValue("@Capacidad", entidad.Capacidad);

                        // 3. ¡Agregamos el parámetro del ID para el WHERE!
                        command.Parameters.AddWithValue("@ID", entidad.LaboratorioID);

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
            // 1. CORRECCIÓN: Usar la clave primaria en el WHERE
            string sql = "DELETE FROM Laboratorio WHERE LaboratorioID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // 2. CORRECCIÓN: Pasar el LaboratorioID de la entidad
                        command.Parameters.AddWithValue("@ID", entidad.LaboratorioID);

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
            Model.Laboratorio lab = null; // Empezamos en null

            // 1. SQL CORREGIDO:
            //    - Tabla en SINGULAR: "Laboratorio"
            //    - Columnas de la BD: "UbicacionPiso", "CapacidadPuestos"
            string sql = @"
        SELECT LaboratorioID, NumeroAsignado, UbicacionPiso, CapacidadPuestos 
        FROM Laboratorio 
        WHERE LaboratorioID = @IDBuscado";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Agregamos el parámetro
                        command.Parameters.AddWithValue("@IDBuscado", id);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Usamos 'if' porque solo esperamos una fila
                            if (reader.Read())
                            {
                                // 2. Llenamos el modelo con los nombres correctos
                                lab = new Model.Laboratorio
                                {
                                    LaboratorioID = (int)reader["LaboratorioID"],
                                    NumeroAsignado = (int)reader["NumeroAsignado"],
                                    Ubicacion = reader["UbicacionPiso"].ToString(),
                                    Capacidad = (int)reader["CapacidadPuestos"]
                                };
                            }
                        }
                    }
                }
                // Devolvemos 'lab'
                // (Será 'null' si el 'if (reader.Read())' falló, 
                // lo que hará que el controlador lance el error que viste)
                return lab;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el repositorio al obtener por ID: " + ex.Message, ex);
            }
        }

        public IEnumerable<Model.Laboratorio> ObtenerTodos()
        {
            List<Model.Laboratorio> laboratorios = new List<Model.Laboratorio>();

            // 1. SQL CORREGIDO:
            //    - Tabla en SINGULAR: "Laboratorio"
            //    - Columnas de la BD: "UbicacionPiso", "CapacidadPuestos"
            //    - Seleccionamos el ID: "LaboratorioID"
            string sql = @"
        SELECT LaboratorioID, NumeroAsignado, UbicacionPiso, CapacidadPuestos 
        FROM Laboratorio";

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
                                // 2. Llenamos el modelo usando el constructor vacío
                                //    y los nombres de las columnas (más seguro)
                                Model.Laboratorio lab = new Model.Laboratorio();

                                // Columna "LaboratorioID" -> Propiedad "LaboratorioID"
                                lab.LaboratorioID = (int)reader["LaboratorioID"];

                                // Columna "NumeroAsignado" -> Propiedad "NumeroAsignado"
                                lab.NumeroAsignado = (int)reader["NumeroAsignado"];

                                // Columna "UbicacionPiso" -> Propiedad "Ubicacion"
                                lab.Ubicacion = reader["UbicacionPiso"].ToString();

                                // Columna "CapacidadPuestos" -> Propiedad "Capacidad"
                                lab.Capacidad = (int)reader["CapacidadPuestos"];

                                laboratorios.Add(lab);
                            }
                        }
                    }
                }
                return laboratorios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el repositorio al obtener todos: " + ex.Message, ex);
            }
        }



    }
}
