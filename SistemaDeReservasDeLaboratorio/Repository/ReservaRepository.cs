using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using SistemaDeReservasDeLaboratorio.Model;
namespace SistemaDeReservasDeLaboratorio.Repository
{
    internal class ReservaRepository : IReservaRepository
    {

        private string _connectionString;
        public ReservaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // --- MÉTODO AYUDANTE "FÁBRICA" ---
        // (Lo usamos en todos los 'Obtener...' para no repetir código)
        private Reserva GenerarReserva(SqlDataReader reader)
        {
            string tipoReserva = reader["TipoReserva"].ToString();
            Reserva reserva;

            if (tipoReserva == "Cuatrimestral")
            {
                var rc = new ReservaCuatrimestral
                {
                    // Llenamos propiedades de la clase hija
                    HoraInicio = Convert.ToDateTime(reader["FechaHoraComienzo"]),
                    HoraFin = Convert.ToDateTime(reader["FechaHoraFinalizacion"]),
                    Frecuencia = (FrecuenciaReserva)Enum.Parse(typeof(FrecuenciaReserva), reader["Frecuencia"].ToString())
                };
                // Llenamos la fecha "virtual"
                rc.Fecha = rc.HoraInicio;
                reserva = rc;
            }
            else if (tipoReserva == "Eventual")
            {
                var re = new ReservaEventual
                {
                    // Llenamos propiedades de la clase hija
                    FechaComienzoReserva = Convert.ToDateTime(reader["FechaComienzoReserva"]),
                    CantidadDeSemanas = Convert.ToInt32(reader["CantidadSemanas"])
                };
                // Llenamos la fecha "virtual"
                re.Fecha = re.FechaComienzoReserva;
                reserva = re;
            }
            else
            {
                throw new Exception("Tipo de reserva desconocido.");
            }

            // Llenamos las propiedades de la clase base (comunes)
            reserva.ID = Convert.ToInt32(reader["ReservaID"]);
            reserva.LaboratorioID = Convert.ToInt32(reader["LaboratorioID"]);
            reserva.Carrera = reader["Carrera"].ToString();
            reserva.Asignatura = reader["Asignatura"].ToString();
            reserva.Anio = reader["Anio"].ToString(); // ¡Corregido a String!
            reserva.Comision = reader["Comision"].ToString();
            reserva.Profesor = reader["Profesor"].ToString();

            return reserva;
        }
        public void Agregar(Reserva entidad)
        {
            string sql = @"
                INSERT INTO Reserva 
                (LaboratorioID, TipoReserva, Carrera, Asignatura, Anio, Comision, Profesor, 
                 FechaHoraComienzo, FechaHoraFinalizacion, Frecuencia, 
                 FechaComienzoReserva, CantidadSemanas)
                VALUES 
                (@LabID, @Tipo, @Carrera, @Asignatura, @Anio, @Comision, @Profesor,
                 @F_H_Inicio, @F_H_Fin, @Frecuencia,
                 @F_Inicio_Ev, @CantSemanas);
                SELECT SCOPE_IDENTITY();"; // Para obtener el nuevo ID
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Parámetros comunes (¡con los tipos corregidos!)
                        command.Parameters.AddWithValue("@LabID", entidad.LaboratorioID);
                        command.Parameters.AddWithValue("@Carrera", entidad.Carrera);
                        command.Parameters.AddWithValue("@Asignatura", entidad.Asignatura);
                        command.Parameters.AddWithValue("@Anio", entidad.Anio); // Ahora es string
                        command.Parameters.AddWithValue("@Comision", entidad.Comision);
                        command.Parameters.AddWithValue("@Profesor", entidad.Profesor);

                        // Lógica de tipo (esta estaba bien)
                        if (entidad is ReservaCuatrimestral rc)
                        {
                            command.Parameters.AddWithValue("@Tipo", "Cuatrimestral");
                            command.Parameters.AddWithValue("@F_H_Inicio", rc.HoraInicio);
                            command.Parameters.AddWithValue("@F_H_Fin", rc.HoraFin);
                            command.Parameters.AddWithValue("@Frecuencia", rc.Frecuencia.ToString());
                            command.Parameters.AddWithValue("@F_Inicio_Ev", DBNull.Value);
                            command.Parameters.AddWithValue("@CantSemanas", DBNull.Value);
                        }
                        else if (entidad is ReservaEventual re)
                        {
                            command.Parameters.AddWithValue("@Tipo", "Eventual");
                            command.Parameters.AddWithValue("@F_Inicio_Ev", re.FechaComienzoReserva);
                            command.Parameters.AddWithValue("@CantSemanas", re.CantidadDeSemanas);
                            command.Parameters.AddWithValue("@F_H_Inicio", DBNull.Value);
                            command.Parameters.AddWithValue("@F_H_Fin", DBNull.Value);
                            command.Parameters.AddWithValue("@Frecuencia", DBNull.Value);
                        }
                        else { throw new ArgumentException("El tipo de reserva no es soportado."); }

                        connection.Open();

                        // 2. EJECUCIÓN CORREGIDA: Usamos ExecuteScalar
                        object result = command.ExecuteScalar();
                        entidad.ID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la reserva.", ex);
            }
        }
        public void Actualizar(Reserva entidad)
        {
            string sql = @"
                UPDATE Reserva SET
                    LaboratorioID = @LabID, TipoReserva = @Tipo, Carrera = @Carrera,
                    Asignatura = @Asignatura, Anio = @Anio, Comision = @Comision, 
                    Profesor = @Profesor, FechaHoraComienzo = @F_H_Inicio, 
                    FechaHoraFinalizacion = @F_H_Fin,
                    Frecuencia = @Frecuencia, FechaComienzoReserva = @F_Inicio_Ev, 
                    CantidadSemanas = @CantSemanas
                WHERE ReservaID = @ReservaID";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ReservaID", entidad.ID);
                        command.Parameters.AddWithValue("@LabID", entidad.LaboratorioID);
                        command.Parameters.AddWithValue("@Carrera", entidad.Carrera);
                        command.Parameters.AddWithValue("@Asignatura", entidad.Asignatura);
                        command.Parameters.AddWithValue("@Anio", entidad.Anio);
                        command.Parameters.AddWithValue("@Comision", entidad.Comision);
                        command.Parameters.AddWithValue("@Profesor", entidad.Profesor);

                        if (entidad is ReservaCuatrimestral rc)
                        {
                            command.Parameters.AddWithValue("@Tipo", "Cuatrimestral");
                            command.Parameters.AddWithValue("@F_H_Inicio", rc.HoraInicio);
                            command.Parameters.AddWithValue("@F_H_Fin", rc.HoraFin);
                            command.Parameters.AddWithValue("@Frecuencia", rc.Frecuencia.ToString());
                            command.Parameters.AddWithValue("@F_Inicio_Ev", DBNull.Value);
                            command.Parameters.AddWithValue("@CantSemanas", DBNull.Value);

                        }
                        else if (entidad is ReservaEventual re)
                        {
                            command.Parameters.AddWithValue("@Tipo", "Eventual");
                            command.Parameters.AddWithValue("@F_Inicio_Ev", re.FechaComienzoReserva);
                            command.Parameters.AddWithValue("@CantSemanas", re.CantidadDeSemanas);
                            command.Parameters.AddWithValue("@F_H_Inicio", DBNull.Value);
                            command.Parameters.AddWithValue("@F_H_Fin", DBNull.Value);
                            command.Parameters.AddWithValue("@Frecuencia", DBNull.Value);
                        }
                        else
                        {
                            throw new ArgumentException("El tipo de reserva no es soportado.");
                        }


                        command.Parameters.AddWithValue("@ReservaID", entidad.ID);
                        connection.Open();
                        command.ExecuteNonQuery();

                    }                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la reserva.", ex);
            }
        }
        public void Eliminar(Reserva entidad)
        {
            string sql = "DELETE FROM Reserva WHERE ReservaID = @ReservaID";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ReservaID", entidad.ID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la reserva.", ex);
            }
        }
        public Reserva ObtenerPorId(int id)
        {
            string sql = "SELECT * From Reserva WHERE ReservaID = @ReservaID";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ReservaID", id);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Usamos el método ayudante
                                return GenerarReserva(reader);
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
                throw new Exception("Error al obtener la reserva por ID.", ex);
            }
        }
        public IEnumerable<Reserva> ObtenerTodos()
        {
            // Dejá solo la lógica, sin 'try-catch'
            string sql = "SELECT * From Reserva";
            List<Reserva> reservas = new List<Reserva>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Usamos el método ayudante
                            reservas.Add(GenerarReserva(reader));
                        }
                    }
                }
            }
            return reservas;
        }
        public List<Reserva> ObtenerPorFecha(DateTime fecha)
        {
            List<Reserva> reservas = new List<Reserva>();
            string sql = @"
                SELECT * FROM Reserva
                WHERE CAST(
                    (CASE 
                        WHEN TipoReserva = 'Eventual' 
                        THEN FechaComienzoReserva 
                        ELSE FechaHoraComienzo 
                    END)
                AS DATE) = CAST(@FechaBuscada AS DATE)";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // 1. CORREGIDO: Faltaba el parámetro
                        command.Parameters.AddWithValue("@FechaBuscada", fecha);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reservas.Add(GenerarReserva(reader));
                            }
                        }
                    }
                }
                return reservas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las reservas por fecha.", ex);
            }
        }
        public List<Reserva> ObtenerPorProfesor(string profesor)
        {
            string sql = "SELECT * From Reserva WHERE Profesor = @Profesor";
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // 1. CORREGIDO: Faltaba el parámetro
                        command.Parameters.AddWithValue("@Profesor", profesor);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 2. CORREGIDO: La lógica de fábrica va DENTRO del while
                            while (reader.Read())
                            {
                                reservas.Add(GenerarReserva(reader));
                            }
                        }
                    }
                }
                return reservas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener por profesor", ex);
            }
        }
        public List<Reserva> ObtenerPorAsignatura(string asignatura)
        {
            string sql = "SELECT * From Reserva WHERE Asignatura = @Asignatura";
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // 1. CORREGIDO: Faltaba el parámetro
                        command.Parameters.AddWithValue("@Asignatura", asignatura);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 2. CORREGIDO: La lógica de fábrica va DENTRO del while
                            while (reader.Read())
                            {
                                reservas.Add(GenerarReserva(reader));
                            }
                        }
                    }
                }
                return reservas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener por asignatura", ex);
            }
        }
        public List<string> ObtenerProfesoresDistintos()
        {
            List<string> profesores = new List<string>();
            string sql = "SELECT DISTINCT Profesor FROM Reserva ORDER BY Profesor";

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
                                profesores.Add(reader["Profesor"].ToString());
                            }
                        }
                    }
                }
                return profesores;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener lista de profesores.", ex);
            }
        }
        public List<string> ObtenerAsignaturasDistintas()
        {
            List<string> asignaturas = new List<string>();
            string sql = "SELECT DISTINCT Asignatura FROM Reserva ORDER BY Asignatura";
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
                                asignaturas.Add(reader["Asignatura"].ToString());
                            }
                        }
                    }
                }
                return asignaturas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener lista de asignaturas.", ex);
            }
        }
    }
}
