using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservasDeLaboratorio.Model
{
    public class Laboratorio
    {
        public int LaboratorioID { get; set; }

        public int NumeroAsignado { get; set; }
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }

        public Laboratorio()
        {
        }

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
