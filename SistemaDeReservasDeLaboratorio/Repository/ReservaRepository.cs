using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservasDeLaboratorio.Repository
{
    internal class ReservaRepository : IRepository<Model.Reserva>
    {
        void IRepository<Model.Reserva>.Agregar(Model.Reserva entidad)
        {
            throw new NotImplementedException();
        }
        void IRepository<Model.Reserva>.Actualizar(Model.Reserva entidad)
        {
            throw new NotImplementedException();
        }
        void IRepository<Model.Reserva>.Eliminar(Model.Reserva entidad)
        {
            throw new NotImplementedException();
        }
        Model.Reserva IRepository<Model.Reserva>.ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Model.Reserva> IRepository<Model.Reserva>.ObtenerTodos()
        {
            throw new NotImplementedException();
        }
        IEnumerable<Model.Reserva> ObtenerPorFecha(DateTime fecha)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Model.Reserva> ObtenerPorProfesor(string profesor)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Model.Reserva> ObtenerPorAsignatura(string asignatura)
        {
            throw new NotImplementedException();
        }
    }
}
