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
    public partial class FormModificarLaboratorio : Form
    {
        private readonly Controller.LaboratorioController _controller;
        private readonly Laboratorio _laboratorioActual;
        public FormModificarLaboratorio(Controller.LaboratorioController controller, Laboratorio laboratorioActual)
        {
            InitializeComponent();
            _controller = controller;
            _laboratorioActual = laboratorioActual;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones (igual que en "Agregar")
                if (string.IsNullOrWhiteSpace(txtUbicacion.Text))
                {
                    MessageBox.Show("Complete la ubicación.", "Datos incompletos", (MessageBoxButtons)MessageBoxIcon.Warning);
                    return;
                }

                // --- ¡AQUÍ ESTÁ EL CAMBIO! ---

                // 2. Modificamos el objeto EXISTENTE (_laboratorioActual)
                //    que recibimos en el constructor.
                //    (Asumo que tu modelo ya tiene el ID y todo)
                _laboratorioActual.NumeroAsignado = (int)nudNumeroAsignado.Value;
                _laboratorioActual.Ubicacion = txtUbicacion.Text;
                _laboratorioActual.Capacidad = (int)nudCapacidad.Value;

                // 3. Llamamos al método "Actualizar" del controlador
                _controller.ActualizarLaboratorio(_laboratorioActual);

                // --- FIN DEL CAMBIO ---

                // 4. Cerramos el formulario con éxito
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la modificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormModificarLaboratorio_Load(object sender, EventArgs e)
        {
            nudNumeroAsignado.Value = _laboratorioActual.NumeroAsignado;
            nudCapacidad.Value = _laboratorioActual.Capacidad;
            txtUbicacion.Text = _laboratorioActual.Ubicacion;
        }
    }
}
