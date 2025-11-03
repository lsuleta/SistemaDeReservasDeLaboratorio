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

        private void altaModificarEliminarLaboratorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_open = Application.OpenForms["FormGestionLaboratorios"];
            foreach (Form child in this.MdiChildren)
                child.Close();
            if (form_open == null)
            {
                FormGestionLaboratorios formGestionLaboratorios = new FormGestionLaboratorios();
                formGestionLaboratorios.MdiParent = this;
                formGestionLaboratorios.Dock = DockStyle.Fill;
                formGestionLaboratorios.FormBorderStyle = FormBorderStyle.None;
                formGestionLaboratorios.Show();
            }
        }

        private void altaModificarBajaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_open = Application.OpenForms["FormGestionReservas"];
            foreach (Form child in this.MdiChildren)
                child.Close();
            if (form_open == null)
            {
                FormGestionReservas formGestionReservas = new FormGestionReservas();
                formGestionReservas.MdiParent = this;
                formGestionReservas.Dock = DockStyle.Fill;
                formGestionReservas.FormBorderStyle = FormBorderStyle.None;
                formGestionReservas.Show();
            }
        }
    }
}
