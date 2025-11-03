using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeReservasDeLaboratorio.Model;
namespace SistemaDeReservasDeLaboratorio.Controller
{
    public class LaboratorioController
    {
        private readonly Repository.ILaboratorioRepository _laboratorioRepository;
        public LaboratorioController(Repository.ILaboratorioRepository laboratorioRepository)
        {
            _laboratorioRepository = laboratorioRepository;
        }
        public void AgregarLaboratorio(Laboratorio laboratorio)
        {
            if (laboratorio == null)
            {
                throw new ArgumentNullException(nameof(laboratorio), "El laboratorio no puede ser nulo");
            }

            if (string.IsNullOrEmpty(laboratorio.NumeroAsignado.ToString()))
            {
                throw new Exception("EL numero de laboratorio no puede estar vacio.");
            }

            var existente = _laboratorioRepository.ObtenerTodos()
                .FirstOrDefault(l => l.NumeroAsignado == laboratorio.NumeroAsignado);
            
            if (existente != null)
                throw new Exception($"Ya existe un laboratorio con el número asignado {laboratorio.NumeroAsignado}.");

            _laboratorioRepository.Agregar(laboratorio);
        }
        public Laboratorio ObtenerLaboratorioPorId(int id)
        {
            var Laboratorio = _laboratorioRepository.ObtenerPorId(id);
            if (Laboratorio == null)
            {
                throw new KeyNotFoundException($"No se encontró un laboratorio con el ID {id}.");
            }
            return Laboratorio;
        }

        public void ActualizarLaboratorio(Laboratorio laboratorio)
        {
            if (laboratorio == null)
            {
                throw new ArgumentNullException(nameof(laboratorio), "El laboratorio no puede ser nulo");
            }
            _laboratorioRepository.Actualizar(laboratorio);
        }
        public IEnumerable<Laboratorio> ObtenerTodosLosLaboratorios()
        {
            return _laboratorioRepository.ObtenerTodos();
        }

        public void EliminarLaboratorio(int id)
        {
            var Laboratorio = _laboratorioRepository.ObtenerPorId(id);
            if (Laboratorio == null)
            {
                throw new KeyNotFoundException($"No se encontró un laboratorio con el ID {id}.");
            }
            _laboratorioRepository.Eliminar(Laboratorio);
        }
    }
}
