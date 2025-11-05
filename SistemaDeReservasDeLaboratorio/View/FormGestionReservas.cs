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
        }
        private void CargarReservas()
        {
            //List<Model.Reserva> listaReserva = _controller.ObtenerTodasLasReservas();
            dgvReserva.DataSource = null;
            //dgvReserva.DataSource = listaReserva;
            var reservas = _controllerReserva.ObtenerTodasLasReservas();

            var listaReservas = reservas.ToList();

            dgvReserva.DataSource = listaReservas;

            if (dgvReserva.Columns["ID"] != null)
                dgvReserva.Columns["ID"].Visible = false;
            if (dgvReserva.Columns["LaboratorioID"] != null)
                dgvReserva.Columns["LaboratorioID"].Visible = false;

            if (dgvReserva.Columns["Fecha"] != null)
            {
                dgvReserva.Columns["Fecha"].DefaultCellStyle.Format = "HH:mm";
                dgvReserva.Columns["Fecha"].HeaderText = "Hora"; // (Opcional) Cambia el título
            }

            if (dgvReserva.Columns["Laboratorio"] != null)
            {
                dgvReserva.Columns["Laboratorio"].Visible = false;
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
            //formDetalleReserva.ShowDialog();
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
                // 2. Nos aseguramos de que la fila tenga un objeto
                if (e.RowIndex >= 0 && this.dgvReserva.Rows[e.RowIndex].DataBoundItem != null)
                {
                    try
                    {
                        // 3. Obtenemos el objeto 'Reserva' completo de esa fila
                        Reserva reserva = this.dgvReserva.Rows[e.RowIndex].DataBoundItem as Reserva;

                        if (reserva != null && reserva.Laboratorio != null)
                        {
                            // 4. ¡LA CORRECCIÓN!
                            //    Convertimos el número a un string
                            e.Value = reserva.Laboratorio.NumeroAsignado.ToString();
                            e.FormattingApplied = true;
                        }
                        else
                        {
                            // Si el laboratorio es null, ponemos un string vacío
                            e.Value = string.Empty;
                            e.FormattingApplied = true;
                        }
                    }
                    catch (Exception)
                    {
                        // Si algo falla, ponemos un texto de error
                        e.Value = "ERR";
                        e.FormattingApplied = true;
                    }
                }
            }
        }
    }
}
