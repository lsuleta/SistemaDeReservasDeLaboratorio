using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservasDeLaboratorio.Model
{
    internal class Reserva
    {
        public string Carrera { get; set; }
        public string Asignatura { get; set; }
        public int Anio { get; set; }
        public string Comision { get; set; }
        public string Profesor { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public enum Frecuencia
        { 
            Semanal,
            Quincenal
        }
        public DateTime FechaComienzoReserva { get; set; }
        public int CantidadDeSemanas { get; set; }

        public Reserva() { }

        public override string ToString()
        {
            return $"Reserva de {Asignatura} ({Carrera}) por {Profesor} el {Fecha.ToShortDateString()} de {HoraInicio}:00 a {HoraFin}:00";
        }

    }
}
