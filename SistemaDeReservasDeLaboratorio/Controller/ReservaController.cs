using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeReservasDeLaboratorio.Model;
namespace SistemaDeReservasDeLaboratorio.Controller
{
    public class ReservaController
    {
        private readonly Repository.IReservaRepository _reservaRepository;

        public ReservaController(Repository.IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public void AgregarReserva(Reserva reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva), "la reserva no puede ser nula");
            }
            _reservaRepository.Agregar(reserva);
        }
        public IEnumerable<Reserva> ObtenerReservasPorFecha(DateTime fecha)
        {
            return _reservaRepository.ObtenerPorFecha(fecha);
        }

        public IEnumerable<Reserva> ObtenerReservasPorProfesor(string profesor)
        {
            if (string.IsNullOrWhiteSpace(profesor))
                throw new ArgumentException("El nombre del profesor no puede estar vacío.", nameof(profesor));

            return _reservaRepository.ObtenerPorProfesor(profesor);
        }
        public IEnumerable<Reserva> ObtenerReservasPorAsignatura(string asignatura)
        {
            if (string.IsNullOrWhiteSpace(asignatura))
                throw new ArgumentException("La asignatura no puede estar vacía.", nameof(asignatura));

            return _reservaRepository.ObtenerPorAsignatura(asignatura);
        }
        public IEnumerable<Reserva> ObtenerTodasLasReservas()
        {
            return _reservaRepository.ObtenerTodos();
        }
        public void EliminarReserva(int id)
        {
            var reserva = _reservaRepository.ObtenerPorId(id);
            if (reserva == null)
                throw new KeyNotFoundException($"No se encontró una reserva con el ID {id}.");

            _reservaRepository.Eliminar(reserva);
        }

        // Método para actualizar una reserva
        public void ActualizarReserva(Reserva reserva)
        {
            if (reserva == null)
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser nula.");

            _reservaRepository.Actualizar(reserva);
        }
    }
}
