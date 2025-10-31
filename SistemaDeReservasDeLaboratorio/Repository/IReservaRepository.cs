using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservasDeLaboratorio.Repository
{
    internal interface IReservaRepository : IRepository<Model.Reserva>
    {
        IEnumerable<Model.Reserva> ObtenerPorFecha(DateTime fecha)
        {
            throw new NotImplementedException("Error al obtener por fecha");
        }
        IEnumerable<Model.Reserva> ObtenerPorProfesor(string profesor)
        {
            throw new NotImplementedException("Error al obtener por Profesor");
        }
        IEnumerable<Model.Reserva> ObtenerPorAsignatura(string asignatura)
        {
            throw new NotImplementedException("Error al obtener por Asignatura");
        }
    }
}
