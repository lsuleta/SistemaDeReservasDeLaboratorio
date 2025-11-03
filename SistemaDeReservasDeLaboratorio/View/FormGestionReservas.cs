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
using SistemaDeReservasDeLaboratorio.Repository;
namespace SistemaDeReservasDeLaboratorio.View
{
    public partial class FormGestionReservas : Form
    {
        private readonly ReservaController _controller;
        public FormGestionReservas()
        {
            InitializeComponent();
            string miConnectionString = ConfigurationManager.ConnectionStrings["MiConexionDB"].ConnectionString;
            ReservaRepository reservaRepository = new ReservaRepository(miConnectionString);
            _controller = new ReservaController(reservaRepository);

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
                var reservas = _controller.ObtenerTodasLasReservas();

                var listaReservas = reservas.ToList();

                dgvReserva.DataSource = listaReservas;
                       
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
        }
    }
}
