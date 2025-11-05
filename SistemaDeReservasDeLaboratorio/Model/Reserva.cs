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

        public int LaboratorioID { get; set; }
        public string Carrera { get; set; }
        public string Asignatura { get; set; }
        public string Anio { get; set; }
        public string Comision { get; set; }
        public string Profesor { get; set; }
        public DateTime Fecha { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public virtual DateTime? HoraInicio { get; set; }
        public virtual DateTime? HoraFin { get; set; }
        public virtual FrecuenciaReserva? Frecuencia { get; set; }
        public virtual DateTime? FechaComienzoReserva { get; set; }
        public virtual int? CantidadDeSemanas { get; set; }
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
        public override DateTime? FechaComienzoReserva { get; set; }
        public override int? CantidadDeSemanas { get; set; }

        public ReservaEventual() { }
    }

    public class ReservaCuatrimestral : Reserva
    {       
        public override DateTime? HoraInicio { get; set; }
        public override DateTime? HoraFin { get; set; }
        public override FrecuenciaReserva? Frecuencia {  get; set; }
       

        public ReservaCuatrimestral () { }
    }
}
