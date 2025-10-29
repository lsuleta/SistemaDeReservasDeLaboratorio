using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservasDeLaboratorio.Repository
{
    internal interface IReservaRepository : IRepository<Model.Reserva>
    {
        IEnumerable<Model.Reserva> ObtenerPorFecha(DateTime fecha);
        IEnumerable<Model.Reserva> ObtenerPorProfesor(string profesor);
        IEnumerable<Model.Reserva> ObtenerPorAsignatura(string asignatura);
    }
}
