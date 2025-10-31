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
        public void Agregar(Reserva entidad)
        {
            //string sql = "INSERT INTO Reserva (Carrera, Asignatura, Anio, Comision, Profesor) VALUES (@Carrera, @Asignatura, @anio, @comision, @Profesor)";
            string sql = @"
                INSERT INTO Reserva 
                (TipoReserva, Carrera, Asignatura, Anio, Comision, Profesor, 
                 FechaHoraComienzo, FechaHoraFinalizacion, Frecuencia, 
                 FechaComienzoReserva, CantidadSemanas)
                VALUES 
                (@Tipo, @Carrera, @Asignatura, @Anio, @Comision, @Profesor,
                 @F_H_Inicio, @F_H_Fin, @Frecuencia,
                 @F_Inicio_Ev, @CantSemanas)";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
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

                            // Columnas de 'Eventual' van como NULL
                            command.Parameters.AddWithValue("@F_Inicio_Ev", DBNull.Value);
                            command.Parameters.AddWithValue("@CantSemanas", DBNull.Value);
                        }
                        else if (entidad is ReservaEventual re)
                        {
                            command.Parameters.AddWithValue("@Tipo", "Eventual");
                            command.Parameters.AddWithValue("@F_Inicio_Ev", re.FechaComienzoReserva);
                            command.Parameters.AddWithValue("@CantSemanas", re.CantidadDeSemanas);

                            // Columnas de 'Cuatrimestral' van como NULL
                            command.Parameters.AddWithValue("@F_H_Inicio", DBNull.Value);
                            command.Parameters.AddWithValue("@F_H_Fin", DBNull.Value);
                            command.Parameters.AddWithValue("@Frecuencia", DBNull.Value);
                        }
                        else
                        {
                            throw new ArgumentException("El tipo de reserva no es soportado.");
                        }
                        connection.Open();
                        command.ExecuteNonQuery();
                        entidad.ID = (int)command.ExecuteScalar();
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
                        LaboratorioID = @LabID, TipoReserva = @Tipo, Carrera = @Carr, ,
                        Asignatura = @Asignatura, Anio = @Anio   Comision = @Comision, 
                        Profesor = @Profesor, FechaHoraComienzo = @F_H_Inicio, FechaHoraFinalizacion = @F_H_Fin,
                        Frecuencia = @Frecuencia, FechaComienzoReserva = @F_Inicio_Ev, CantidadSemanas = @CantSemanas
                        WHERE ReservaID = @ReservaID";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
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
                throw new Exception("Error al actualiza la reserva.", ex);
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
                                string tipoReserva = reader["TipoReserva"].ToString();
                                if (tipoReserva == "Cuatrimestral")
                                {
                                    ReservaCuatrimestral rc = new ReservaCuatrimestral
                                    {
                                        ID = Convert.ToInt32(reader["ReservaID"]),
                                        Carrera = reader["Carrera"].ToString(),
                                        Asignatura = reader["Asignatura"].ToString(),
                                        Anio = Convert.ToInt32(reader["Anio"]),
                                        Comision = reader["Comision"].ToString(),
                                        Profesor = reader["Profesor"].ToString(),
                                        HoraInicio = Convert.ToDateTime(reader["FechaHoraComienzo"]),
                                        HoraFin = Convert.ToDateTime(reader["FechaHoraFinalizacion"]),
                                        Frecuencia = (FrecuenciaReserva)Enum.Parse(typeof(FrecuenciaReserva), reader["Frecuencia"].ToString())
                                    };
                                    return rc;
                                }
                                else if (tipoReserva == "Eventual")
                                {
                                    ReservaEventual re = new ReservaEventual
                                    {
                                        ID = Convert.ToInt32(reader["ReservaID"]),
                                        Carrera = reader["Carrera"].ToString(),
                                        Asignatura = reader["Asignatura"].ToString(),
                                        Anio = Convert.ToInt32(reader["Anio"]),
                                        Comision = reader["Comision"].ToString(),
                                        Profesor = reader["Profesor"].ToString(),
                                        FechaComienzoReserva = Convert.ToDateTime(reader["FechaComienzoReserva"]),
                                        CantidadDeSemanas = Convert.ToInt32(reader["CantidadSemanas"])
                                    };
                                    return re;
                                }
                                else
                                {
                                    throw new Exception("Tipo de reserva desconocido.");
                                }
                            }
                            else
                            {
                                return null; // O lanzar una excepción si se prefiere
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
        public List<Reserva> ObtenerTodos()
        {
            string sql = "SELECT * From Reserva";
            List<Reserva> reservas = new List<Reserva>();
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
                                string tipoReserva = reader["TipoReserva"].ToString();
                                if (tipoReserva == "Cuatrimestral")
                                {
                                    ReservaCuatrimestral rc = new ReservaCuatrimestral
                                    {
                                        ID = Convert.ToInt32(reader["ReservaID"]),
                                        Carrera = reader["Carrera"].ToString(),
                                        Asignatura = reader["Asignatura"].ToString(),
                                        Anio = Convert.ToInt32(reader["Anio"]),
                                        Comision = reader["Comision"].ToString(),
                                        Profesor = reader["Profesor"].ToString(),
                                        HoraInicio = Convert.ToDateTime(reader["FechaHoraComienzo"]),
                                        HoraFin = Convert.ToDateTime(reader["FechaHoraFinalizacion"]),
                                        Frecuencia = (FrecuenciaReserva)Enum.Parse(typeof(FrecuenciaReserva), reader["Frecuencia"].ToString())
                                    };
                                    reservas.Add(rc);
                                }
                                else if (tipoReserva == "Eventual")
                                {
                                    ReservaEventual re = new ReservaEventual
                                    {
                                        ID = Convert.ToInt32(reader["ReservaID"]),
                                        Carrera = reader["Carrera"].ToString(),
                                        Asignatura = reader["Asignatura"].ToString(),
                                        Anio = Convert.ToInt32(reader["Anio"]),
                                        Comision = reader["Comision"].ToString(),
                                        Profesor = reader["Profesor"].ToString(),
                                        FechaComienzoReserva = Convert.ToDateTime(reader["FechaComienzoReserva"]),
                                        CantidadDeSemanas = Convert.ToInt32(reader["CantidadSemanas"])
                                    };
                                    reservas.Add(re);
                                }
                                else
                                {
                                    throw new Exception("Tipo de reserva desconocido.");
                                }
                            }
                        }
                    }
                }
                return reservas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las reservas.", ex);
            }

        }

        public List<Reserva> ObtenerPorFecha(DateTime fecha)
        {
            List<Reserva> reservas = new List<Reserva>();

            string sql = @"
                SELECT 
                    -- Comunes
                    ReservaID, TipoReserva, Carrera, Asignatura, Anio, Comision, Profesor,
            
                    -- Específicas (para la fábrica)
                    FechaHoraComienzo, FechaHoraFinalizacion, Frecuencia,
                    FechaComienzoReserva, CantidadSemanas
            
                FROM Reserva
        
                -- El WHERE que ya tenías (está perfecto)
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

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tipoReserva = reader["TipoReserva"].ToString();

                                if (tipoReserva == "Cuatrimestral")
                                {
                                    ReservaCuatrimestral rc = new ReservaCuatrimestral
                                    {
                                        ID = Convert.ToInt32(reader["ReservaID"]),
                                        Carrera = reader["Carrera"].ToString(),
                                        Asignatura = reader["Asignatura"].ToString(),
                                        Anio = Convert.ToInt32(reader["Anio"]),
                                        Comision = reader["Comision"].ToString(),
                                        Profesor = reader["Profesor"].ToString(),
                                        HoraInicio = Convert.ToDateTime(reader["FechaHoraComienzo"]),
                                        HoraFin = Convert.ToDateTime(reader["FechaHoraFinalizacion"]),
                                        Frecuencia = (FrecuenciaReserva)Enum.Parse(typeof(FrecuenciaReserva), reader["Frecuencia"].ToString())
                                    };
                                    reservas.Add(rc);
                                }
                                else if (tipoReserva == "Eventual")
                                {
                                    ReservaEventual re = new ReservaEventual
                                    {
                                        ID = Convert.ToInt32(reader["ReservaID"]),
                                        Carrera = reader["Carrera"].ToString(),
                                        Asignatura = reader["Asignatura"].ToString(),
                                        Anio = Convert.ToInt32(reader["Anio"]),
                                        Comision = reader["Comision"].ToString(),
                                        Profesor = reader["Profesor"].ToString(),
                                        FechaComienzoReserva = Convert.ToDateTime(reader["FechaComienzoReserva"]),
                                        CantidadDeSemanas = Convert.ToInt32(reader["CantidadSemanas"])
                                    };
                                    reservas.Add(re);
                                }
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
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            string tipoReserva = reader["TipoReserva"].ToString();

                            if (tipoReserva == "Cuatrimestral")
                            {
                                ReservaCuatrimestral rc = new ReservaCuatrimestral
                                {
                                    ID = Convert.ToInt32(reader["ReservaID"]),
                                    Carrera = reader["Carrera"].ToString(),
                                    Asignatura = reader["Asignatura"].ToString(),
                                    Anio = Convert.ToInt32(reader["Anio"]),
                                    Comision = reader["Comision"].ToString(),
                                    Profesor = reader["Profesor"].ToString(),
                                    HoraInicio = Convert.ToDateTime(reader["FechaHoraComienzo"]),
                                    HoraFin = Convert.ToDateTime(reader["FechaHoraFinalizacion"]),
                                    Frecuencia = (FrecuenciaReserva)Enum.Parse(typeof(FrecuenciaReserva), reader["Frecuencia"].ToString())
                                };
                                reservas.Add(rc);
                            }
                            else if (tipoReserva == "Eventual")
                            {
                                ReservaEventual re = new ReservaEventual
                                {
                                    ID = Convert.ToInt32(reader["ReservaID"]),
                                    Carrera = reader["Carrera"].ToString(),
                                    Asignatura = reader["Asignatura"].ToString(),
                                    Anio = Convert.ToInt32(reader["Anio"]),
                                    Comision = reader["Comision"].ToString(),
                                    Profesor = reader["Profesor"].ToString(),
                                    FechaComienzoReserva = Convert.ToDateTime(reader["FechaComienzoReserva"]),
                                    CantidadDeSemanas = Convert.ToInt32(reader["CantidadSemanas"])
                                };
                                reservas.Add(re);
                            }
                        }
                    }
                }
                return reservas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los profesores", ex);
            }
        }
        public List<Reserva> ObtenerPorAsignatura(string asignatura)
        {
            string sql = "Select * From Reserva WHERE Asignatura = @Asignatura";
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            string tipoReserva = reader["TipoReserva"].ToString();

                            if (tipoReserva == "Cuatrimestral")
                            {
                                ReservaCuatrimestral rc = new ReservaCuatrimestral
                                {
                                    ID = Convert.ToInt32(reader["ReservaID"]),
                                    Carrera = reader["Carrera"].ToString(),
                                    Asignatura = reader["Asignatura"].ToString(),
                                    Anio = Convert.ToInt32(reader["Anio"]),
                                    Comision = reader["Comision"].ToString(),
                                    Profesor = reader["Profesor"].ToString(),
                                    HoraInicio = Convert.ToDateTime(reader["FechaHoraComienzo"]),
                                    HoraFin = Convert.ToDateTime(reader["FechaHoraFinalizacion"]),
                                    Frecuencia = (FrecuenciaReserva)Enum.Parse(typeof(FrecuenciaReserva), reader["Frecuencia"].ToString())
                                };
                                reservas.Add(rc);
                            }
                            else if (tipoReserva == "Eventual")
                            {
                                ReservaEventual re = new ReservaEventual
                                {
                                    ID = Convert.ToInt32(reader["ReservaID"]),
                                    Carrera = reader["Carrera"].ToString(),
                                    Asignatura = reader["Asignatura"].ToString(),
                                    Anio = Convert.ToInt32(reader["Anio"]),
                                    Comision = reader["Comision"].ToString(),
                                    Profesor = reader["Profesor"].ToString(),
                                    FechaComienzoReserva = Convert.ToDateTime(reader["FechaComienzoReserva"]),
                                    CantidadDeSemanas = Convert.ToInt32(reader["CantidadSemanas"])
                                };
                                reservas.Add(re);
                            }
                        }
                    }
                }
                return reservas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los profesores", ex);
            }
        }
    }
}
