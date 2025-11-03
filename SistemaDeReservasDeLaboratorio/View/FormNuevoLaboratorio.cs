using SistemaDeReservasDeLaboratorio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeReservasDeLaboratorio.View
{
    public partial class FormNuevoLaboratorio : Form
    {
        private readonly Controller.LaboratorioController _controller;
        public FormNuevoLaboratorio(Controller.LaboratorioController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUbicacion.Text))
                {
                    MessageBox.Show("Por favor, complete la ubicacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Agregado para evitar continuar si falta la ubicación
                }

                int numeroAsignado = (int)nudNumeroAsignado.Value;
                int capacidad = (int)nudCapacidad.Value;

                Laboratorio nuevoLab = new Laboratorio
                {
                    NumeroAsignado = (int)nudNumeroAsignado.Value,
                    Capacidad = (int)nudCapacidad.Value,
                    Ubicacion = txtUbicacion.Text
                };

                _controller.AgregarLaboratorio(nuevoLab);

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el laboratorio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.InnerException?.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
