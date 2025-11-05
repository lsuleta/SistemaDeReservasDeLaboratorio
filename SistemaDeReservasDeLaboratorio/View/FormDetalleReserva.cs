using SistemaDeReservasDeLaboratorio.Controller;
using SistemaDeReservasDeLaboratorio.Model;
using SistemaDeReservasDeLaboratorio.Repository;
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

    public partial class FormDetalleReserva : Form
    {
        private readonly ReservaController _controllerReserva;
        private readonly LaboratorioRepository _repositoryLaboratorio;
        private Reserva _reservaActual;
        private FormDetalleReserva()
        {
            InitializeComponent();
        }

        public FormDetalleReserva(ReservaController controller, LaboratorioRepository labRepo)
        {
            InitializeComponent();
            _controllerReserva = controller;
            _repositoryLaboratorio = labRepo;
            _reservaActual = null;
        }

        public FormDetalleReserva(ReservaController controller, LaboratorioRepository labRepo, Reserva reserva)
        {
            InitializeComponent();
            _controllerReserva = controller;
            _repositoryLaboratorio = labRepo;
            _reservaActual = reserva;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormDetalleReserva_Load(object sender, EventArgs e)
        {
            CargarLaboratoriosComboBox();
            CargarCombosEstaticos();

            if (_reservaActual == null)
            {
                this.Text = "Nueva Reserva";

                cmbReserva.SelectedItem = TipoReserva.Eventual; // Cambiado de SelectedIndex a SelectedItem
            }
            else
            {
                this.Text = "Modificar Reserva";

                cmbReserva.Enabled = false;

                cmbLaboratorio.SelectedValue = _reservaActual.LaboratorioID;
                txtCarrera.Text = _reservaActual.Carrera;
                txtAsignatura.Text = _reservaActual.Asignatura;
                nudAnio.Text = _reservaActual.Anio;
                txtComision.Text = _reservaActual.Comision;
                txtProfesor.Text = _reservaActual.Profesor;

                if (_reservaActual is ReservaEventual re)
                {
                    cmbReserva.SelectedItem = TipoReserva.Eventual;
                    dtpFecha.Value = re.FechaComienzoReserva.GetValueOrDefault();
                    nudCantidadSemanas.Value = (decimal)re.CantidadDeSemanas;
                }
                else if (_reservaActual is ReservaCuatrimestral rc)
                {
                    cmbReserva.SelectedItem = TipoReserva.Cuatrimestral;
                    dtpHoraInicio.Value = rc.HoraInicio.GetValueOrDefault(DateTime.Today);
                    dtpHoraFin.Value = rc.HoraFin.GetValueOrDefault(DateTime.Today);
                    cmbFrecuencia.SelectedItem = rc.Frecuencia.ToString();
                }

                cmbReserva_selectedIndexChanged(null, null);
            }
        }

        private void CargarLaboratoriosComboBox()
        {
            try
            {
                var laboratorios = _repositoryLaboratorio.ObtenerTodos();
                cmbLaboratorio.DataSource = laboratorios;
                cmbLaboratorio.DisplayMember = "NumeroAsignado";
                cmbLaboratorio.ValueMember = "LaboratorioID";
                cmbLaboratorio.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al cargar laboratorios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombosEstaticos()
        {
            cmbReserva.Items.Clear();
            cmbReserva.Items.Add(TipoReserva.Eventual);
            cmbReserva.Items.Add(TipoReserva.Cuatrimestral);

            cmbFrecuencia.Items.Clear();
            cmbFrecuencia.Items.AddRange(Enum.GetNames(typeof(FrecuenciaReserva)));
        }

        private void cmbReserva_selectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReserva.SelectedItem == null) return;

            string tipoReservaSeleccionada = cmbReserva.SelectedItem.ToString();

            if (tipoReservaSeleccionada == TipoReserva.Eventual)
            {
                gbEventual.Visible = true;
                gbCuatrimestral.Visible = false;
            }
            else if (tipoReservaSeleccionada == TipoReserva.Cuatrimestral)
            {
                gbEventual.Visible = false;
                gbCuatrimestral.Visible = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLaboratorio.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un laboratorio", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCarrera.Text))
                {
                    MessageBox.Show("Debe completar la Carrera.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtAsignatura.Text))
                {
                    MessageBox.Show("Debe completar la Asignatura.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipoReservaSeleccionada = cmbReserva.SelectedItem.ToString();

                if (_reservaActual != null)
                {
                    LLenarDatosReserva(_reservaActual, tipoReservaSeleccionada);

                    _controllerReserva.ActualizarReserva(_reservaActual);
                }
                else
                {
                    Reserva nuevaReserva;
                    if (tipoReservaSeleccionada == TipoReserva.Eventual)
                    {
                        nuevaReserva = new ReservaEventual();
                    }
                    else // Cuatrimestral
                    {
                        nuevaReserva = new ReservaCuatrimestral();
                    }
                    LLenarDatosReserva(nuevaReserva, tipoReservaSeleccionada);
                    _controllerReserva.AgregarReserva(nuevaReserva);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                string mensajeError = $"Error al guardar la reserva:\n\n";

                mensajeError += $"Mensaje: {ex.Message}\n\n";

                if (ex.InnerException != null)
                {
                    mensajeError += $"Detalle (BD): {ex.InnerException.Message}";
                }

                MessageBox.Show(mensajeError,
                                "Error al Guardar",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        public void LLenarDatosReserva(Reserva reserva, string tipo)
        {
            reserva.LaboratorioID = (int)cmbLaboratorio.SelectedValue;
            reserva.Carrera = txtCarrera.Text.Trim();
            reserva.Asignatura = txtAsignatura.Text.Trim();
            reserva.Anio = nudAnio.Text;
            reserva.Comision = txtComision.Text.Trim();
            reserva.Profesor = txtProfesor.Text.Trim();

            if (tipo == TipoReserva.Eventual && reserva is ReservaEventual re)
            {
                re.FechaComienzoReserva = dtpFecha.Value;
                re.CantidadDeSemanas = (int)nudCantidadSemanas.Value;
            }
            else if (tipo == TipoReserva.Cuatrimestral && reserva is ReservaCuatrimestral rc)
            {
                rc.HoraInicio = dtpHoraInicio.Value;
                rc.HoraFin = dtpHoraFin.Value;
                rc.Frecuencia = (FrecuenciaReserva)Enum.Parse(typeof(FrecuenciaReserva), cmbFrecuencia.SelectedItem.ToString());
            }
        }
    }
}
