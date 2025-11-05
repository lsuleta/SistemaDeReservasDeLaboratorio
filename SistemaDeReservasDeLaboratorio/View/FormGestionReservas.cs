using SistemaDeReservasDeLaboratorio.Controller;
using SistemaDeReservasDeLaboratorio.Controller;
using SistemaDeReservasDeLaboratorio.Model;
using SistemaDeReservasDeLaboratorio.Repository;
using SistemaDeReservasDeLaboratorio.Repository;
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
    public partial class FormGestionReservas : Form
    {
        private readonly ReservaController _controllerReserva;
        private readonly ReservaRepository _repoReserva;
        private readonly LaboratorioRepository _repoLab;
        public FormGestionReservas()
        {
            InitializeComponent();
            string miConnectionString = ConfigurationManager.ConnectionStrings["MiConexionDB"].ConnectionString;
            _repoReserva = new ReservaRepository(miConnectionString);
            _repoLab = new LaboratorioRepository(miConnectionString);
            _controllerReserva = new ReservaController(_repoReserva);

        }

        private void FormGestionReservas_Load(object sender, EventArgs e)
        {
            CargarReservas();
            CargarFiltros();
        }
        private void CargarReservas()
        {
            dgvReserva.DataSource = null;
            var reservas = _controllerReserva.ObtenerTodasLasReservas();

            var listaReservas = reservas.ToList();

            dgvReserva.DataSource = listaReservas;

            if (dgvReserva.Columns["ID"] != null)
                dgvReserva.Columns["ID"].Visible = false;

            if (dgvReserva.Columns["LaboratorioID"] != null)
                dgvReserva.Columns["LaboratorioID"].Visible = false;

            if (dgvReserva.Columns["Fecha"] != null)
                dgvReserva.Columns["Fecha"].Visible = false;

            if (dgvReserva.Columns["HoraInicio"] != null)
            {
                dgvReserva.Columns["HoraInicio"].DefaultCellStyle.Format = "HH:mm";
                dgvReserva.Columns["HoraInicio"].HeaderText = "Hora inicio"; 
            }

            if (dgvReserva.Columns["HoraFin"] != null)
            {
                dgvReserva.Columns["HoraFin"].DefaultCellStyle.Format = "HH:mm";
                dgvReserva.Columns["HoraFin"].HeaderText = "Hora fin";
            }

            if (dgvReserva.Columns["Laboratorio"] != null)
            {
                dgvReserva.Columns["Laboratorio"].Visible = false;
            }

        }

        private void CargarFiltros()
        {
            try
            {
                cmbProfesor.DataSource = null;
                cmbProfesor.DataSource = _repoReserva.ObtenerProfesoresDistintos().ToList();
                cmbProfesor.SelectedItem = null;
                cmbProfesor.Text = "Seleccione un profesor";

                cmbAsignatura.DataSource = null;
                cmbAsignatura.DataSource = _repoReserva.ObtenerAsignaturasDistintas().ToList();
                cmbAsignatura.SelectedItem = null;
                cmbAsignatura.Text = "Seleccione una asignatura";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los filtros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDetalleReserva formDetalleReserva = new FormDetalleReserva(
                _controllerReserva,
                _repoLab);

            var resultado = formDetalleReserva.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CargarReservas();
                MessageBox.Show("Reserva agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvReserva.CurrentRow == null)
            {
                MessageBox.Show("Seleccione la reserva a modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idReserva = (int)dgvReserva.CurrentRow.Cells["ID"].Value;

                Model.Reserva reservaSeleccionada = _repoReserva.ObtenerPorId(idReserva);

                FormDetalleReserva formDetalleReserva = new FormDetalleReserva(
                    _controllerReserva,
                    _repoLab,
                    reservaSeleccionada);

                var resultado = formDetalleReserva.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    CargarReservas();
                    MessageBox.Show("Reserva modificada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvReserva_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvReserva.Columns[e.ColumnIndex].Name == "colLaboratorioNum")
            {
                if (e.RowIndex >= 0 && this.dgvReserva.Rows[e.RowIndex].DataBoundItem != null)
                {
                    try
                    {
                        Reserva reserva = this.dgvReserva.Rows[e.RowIndex].DataBoundItem as Reserva;

                        if (reserva != null && reserva.Laboratorio != null)
                        {
                            e.Value = reserva.Laboratorio.NumeroAsignado.ToString();
                            e.FormattingApplied = true;
                        }
                        else
                        {
                            e.Value = string.Empty;
                            e.FormattingApplied = true;
                        }
                    }
                    catch (Exception)
                    {
                        e.Value = "ERR";
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            try
            {
                
                List<Reserva> reservasFiltradas = _controllerReserva.ObtenerTodasLasReservas().ToList();
                IEnumerable<Reserva> resultado = reservasFiltradas;

                string profesor = cmbProfesor.SelectedItem as string;
                if (!string.IsNullOrEmpty(profesor))
                {
                    resultado = resultado.Where(r => r.Profesor == profesor);
                }
                string asignatura = cmbAsignatura.SelectedItem as string;
                if (!string.IsNullOrEmpty(asignatura))
                {
                    resultado = resultado.Where(r => r.Asignatura == asignatura);
                }
                if (chkUsarFecha.Checked)
                {
                    DateTime fecha = dtpFechaReserva.Value;
                    resultado = resultado.Where(r => r.Fecha.Date == fecha.Date);
                }

                dgvReserva.DataSource = null;
                dgvReserva.DataSource = resultado.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar las reservas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            cmbProfesor.SelectedItem = null;
            cmbProfesor.Text = "Seleccione un profesor";

            cmbAsignatura.SelectedItem = null;
            cmbAsignatura.Text = "Seleccione una asignatura";

            chkUsarFecha.Checked = false;

            CargarReservas();
        }
    }
}
