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

            cmbReserva.Items.Add(TipoReserva.Eventual);
            cmbReserva.Items.Add(TipoReserva.Cuatrimestral);
            cmbFrecuencia.DataSource = Enum.GetNames(typeof(FrecuenciaReserva));


        }

        private void CargarLaboratoriosComboBox()
        {
            try
            {
                var laboratorios = _repositoryLaboratorio.ObtenerTodos();
                cmbLaboratorio.DataSource = laboratorios;
                cmbLaboratorio.DisplayMember = "NumeroAsignado";
                cmbLaboratorio.ValueMember = "Value";
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error crítico al cargar laboratorios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
