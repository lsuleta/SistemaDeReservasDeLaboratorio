using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservasDeLaboratorio.Model
{
    public class Laboratorio
    {
        // 1. ¡AGREGAR EL ID! (Es vital)
        public int LaboratorioID { get; set; }

        public int NumeroAsignado { get; set; }
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }

        // 2. AGREGAR UN CONSTRUCTOR VACÍO
        //    Esto permite al repositorio crear un objeto
        //    y llenar las propiedades una por una (más seguro)
        public Laboratorio()
        {
        }

        // Tu constructor viejo (opcional, pero no lo usaremos en el repo)
        public Laboratorio(int numeroAsignado, string ubicacion, int capacidad)
        {
            NumeroAsignado = numeroAsignado;
            Ubicacion = ubicacion;
            Capacidad = capacidad;
        }

        public override string ToString()
        {
            return $"Laboratorio {NumeroAsignado} - Ubicación: {Ubicacion}, Capacidad: {Capacidad}";
        }
    }
}
