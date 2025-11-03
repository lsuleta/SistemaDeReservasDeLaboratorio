using SistemaDeReservasDeLaboratorio.Controller;
using SistemaDeReservasDeLaboratorio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeReservasDeLaboratorio.View
{
    public partial class FormGestionLaboratorios : Form
    {
        private readonly LaboratorioController _controller;
        public FormGestionLaboratorios()
        {
            InitializeComponent();
            string miConnectionString = ConfigurationManager.ConnectionStrings["MiConexionDB"].ConnectionString;
            Repository.LaboratorioRepository laboratorioRepository = new Repository.LaboratorioRepository(miConnectionString);
            _controller = new LaboratorioController(laboratorioRepository);
            //CargarLaboratorios();
        }

        public void CargarLaboratorios()
        {
            try
            {
                dgvLaboratorios.DataSource = null;
                var laboratorios = _controller.ObtenerTodosLosLaboratorios();

                var listaLaboratorios = laboratorios.ToList();

                dgvLaboratorios.DataSource = listaLaboratorios;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"¡ERROR en CargarGrilla!:\n\n{ex.Message}",
                                "Error de Base de Datos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void FormGestionLaboratorios_Load(object sender, EventArgs e)
        {
            CargarLaboratorios();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormNuevoLaboratorio formNuevoLaboratorio = new FormNuevoLaboratorio(_controller);
            var result = formNuevoLaboratorio.ShowDialog();
            if (result == DialogResult.OK)
            {
                CargarLaboratorios();
                MessageBox.Show("Laboratorio agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // 1. Verificar si hay una fila seleccionada
            if (dgvLaboratorios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione el laboratorio que desea modificar.",
                                "Selección requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Obtener el ID de la fila seleccionada
                //    (Usa la propiedad 'LaboratorioID' que arreglamos en el modelo)
                int idSeleccionado = (int)dgvLaboratorios.CurrentRow.Cells["LaboratorioID"].Value;

                // 3. Pedirle al controlador el objeto completo
                Laboratorio labParaModificar = _controller.ObtenerLaboratorioPorId(idSeleccionado);

                // (Verificación por si acaso)
                if (labParaModificar == null)
                {
                    MessageBox.Show("No se pudo encontrar el laboratorio seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargarLaboratorios(); // Refrescamos por si fue eliminado por otro usuario
                    return;
                }

                // 4. Abrir el formulario de Modificar, pasándole el objeto
                FormModificarLaboratorio formModificar = new FormModificarLaboratorio(_controller, labParaModificar);
                var resultado = formModificar.ShowDialog();

                // 5. Si el usuario guardó (presionó "Aceptar")
                if (resultado == DialogResult.OK)
                {
                    CargarLaboratorios(); // Refrescamos la grilla
                    MessageBox.Show("Laboratorio modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (KeyNotFoundException knfEx) // Si el ID no se encontró
            {
                MessageBox.Show(knfEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Otros errores
            {
                MessageBox.Show($"Error al intentar modificar el laboratorio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLaboratorios.CurrentRow == null)
            {
                // 1. (Corrección cosmética) Mensaje correcto
                MessageBox.Show("Por favor, seleccione un laboratorio para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. ¡ERROR CRÍTICO CORREGIDO!
                //    La celda se llama 'LaboratorioID', igual que la propiedad del modelo.
                int idSeleccionado = (int)dgvLaboratorios.CurrentRow.Cells["LaboratorioID"].Value;

                // (Recomendado) Obtenemos el nombre para un mensaje más claro
                string numAsignado = dgvLaboratorios.CurrentRow.Cells["NumeroAsignado"].Value.ToString();

                var confirmResult = MessageBox.Show($"¿Está seguro de que desea eliminar el laboratorio {numAsignado}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    _controller.EliminarLaboratorio(idSeleccionado);

                    // 3. ¡ERROR DE NOMBRE CORREGIDO!
                    //    Llamamos al método que sí existe.
                    CargarLaboratorios();

                    MessageBox.Show("Laboratorio eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // (Opcional pero recomendado) Capturar errores específicos
            catch (KeyNotFoundException knfEx)
            {
                MessageBox.Show(knfEx.Message, "Error: No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ioEx) // Ej. El error de "tiene reservas"
            {
                MessageBox.Show(ioEx.Message, "Operación denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el laboratorio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
