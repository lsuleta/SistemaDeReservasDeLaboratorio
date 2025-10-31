using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservasDeLaboratorio.Repository
{
    internal interface IRepository<T> where T : class
    {
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(T entidad);
        T ObtenerPorId(int id);
        //List<T> ObtenerTodos();
        IEnumerable<T> ObtenerTodos()
        {
            throw new NotImplementedException("Error al obtener todos ");
        }
    }
}
