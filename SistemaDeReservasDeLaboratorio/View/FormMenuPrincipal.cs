using SistemaDeReservasDeLaboratorio.View;

namespace SistemaDeReservasDeLaboratorio
{
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void laboratoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionLaboratorios formLaboratorios = new FormGestionLaboratorios();

            //formLaboratorios.MdiParent = this;
            formLaboratorios.Show();
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionReservas formReservas = new FormGestionReservas();
            formReservas.MdiParent = this;
            formReservas.Show();
        }

        private void integrantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIntegrantes formIntegrantes = new FormIntegrantes();
            formIntegrantes.MdiParent = this;
            formIntegrantes.Show();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
