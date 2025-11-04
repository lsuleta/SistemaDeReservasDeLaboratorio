using SistemaDeReservasDeLaboratorio.Controller;
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
    private readonly ReservaController _controllerReserva;
    private readonly LaboratorioController _controllerLaboratorio;
    public partial class FormDetalleReserva : Form
    {
        public FormDetalleReserva()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
