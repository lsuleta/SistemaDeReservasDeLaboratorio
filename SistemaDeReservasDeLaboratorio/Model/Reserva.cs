using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservasDeLaboratorio.Model
{
    public abstract class Reserva
    {
        public int ID { get; set; }
        public string Carrera { get; set; }
        public string Asignatura { get; set; }
        public int Anio { get; set; }
        public string Comision { get; set; }
        public string Profesor { get; set; }
        public DateTime Fecha { get; set; }
    }
        public enum FrecuenciaReserva
        {
            Semanal,
            Quincenal
        }

    public class TipoReserva
    {
        public const string Cuatrimestral = "Cuatrimestral";
        public const string Eventual = "Eventual";
    }

    public class ReservaEventual : Reserva
    {
        public DateTime FechaComienzoReserva { get; set; }
        public int CantidadDeSemanas { get; set; }

        public ReservaEventual() { }
    }

    public class ReservaCuatrimestral : Reserva
    {       
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public FrecuenciaReserva Frecuencia {  get; set; }
       

        public ReservaCuatrimestral () { }
    }
}
