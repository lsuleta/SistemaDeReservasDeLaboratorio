using SistemaDeReservasDeLaboratorio.Controller;
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
using SistemaDeReservasDeLaboratorio.Controller;
namespace SistemaDeReservasDeLaboratorio.View
{
    public partial class FormGestionReservas : Form
    {
        private readonly Controller.ReservaController _controller;
        public FormGestionReservas()
        {
            InitializeComponent();
            string miConnectionString = ConfigurationManager.ConnectionStrings["MiConexionDB"].ConnectionString;
            ReservaRepository resevaRepository = new ReservaRepository(miConnectionString);
            //_controller = new ReservaRepository(resevaRepository);

        }

        private void FormGestionReservas_Load(object sender, EventArgs e)
        {

        }
        private void CargarReservas()
        {
            try
            {
                dgvReserva.DataSource = null;
                var reservas = _controller.ObtenerTodasLasReservas();

                var listaReservas = reservas.ToList();

                dgvReserva.DataSource = listaReservas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"¡ERROR en CargarGrilla!:\n\n{ex.Message}",
                                "Error de Base de Datos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
        }
    }
}
