namespace SistemaDeReservasDeLaboratorio
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuPrincipal));
            menuStrip1 = new MenuStrip();
            reservasToolStripMenuItem = new ToolStripMenuItem();
            altaModificarBajaReservaToolStripMenuItem = new ToolStripMenuItem();
            consultaDeReservasToolStripMenuItem = new ToolStripMenuItem();
            laboratoriosToolStripMenuItem = new ToolStripMenuItem();
            altaModificarEliminarLaboratorioToolStripMenuItem = new ToolStripMenuItem();
            consultToolStripMenuItem = new ToolStripMenuItem();
            integrantesToolStripMenuItem = new ToolStripMenuItem();
            lucasSuletaToolStripMenuItem = new ToolStripMenuItem();
            emanuelHamuiToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { reservasToolStripMenuItem, laboratoriosToolStripMenuItem, integrantesToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // reservasToolStripMenuItem
            // 
            reservasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { altaModificarBajaReservaToolStripMenuItem, consultaDeReservasToolStripMenuItem });
            reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            reservasToolStripMenuItem.Size = new Size(64, 20);
            reservasToolStripMenuItem.Text = "Reservas";
            reservasToolStripMenuItem.Click += reservasToolStripMenuItem_Click;
            // 
            // altaModificarBajaReservaToolStripMenuItem
            // 
            altaModificarBajaReservaToolStripMenuItem.Name = "altaModificarBajaReservaToolStripMenuItem";
            altaModificarBajaReservaToolStripMenuItem.Size = new Size(218, 22);
            altaModificarBajaReservaToolStripMenuItem.Text = "Alta/Modificar/Baja reserva";
            altaModificarBajaReservaToolStripMenuItem.Click += altaModificarBajaReservaToolStripMenuItem_Click;
            // 
            // consultaDeReservasToolStripMenuItem
            // 
            consultaDeReservasToolStripMenuItem.Name = "consultaDeReservasToolStripMenuItem";
            consultaDeReservasToolStripMenuItem.Size = new Size(218, 22);
            consultaDeReservasToolStripMenuItem.Text = "Consulta de reservas";
            // 
            // laboratoriosToolStripMenuItem
            // 
            laboratoriosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { altaModificarEliminarLaboratorioToolStripMenuItem, consultToolStripMenuItem });
            laboratoriosToolStripMenuItem.Name = "laboratoriosToolStripMenuItem";
            laboratoriosToolStripMenuItem.Size = new Size(85, 20);
            laboratoriosToolStripMenuItem.Text = "Laboratorios";
            laboratoriosToolStripMenuItem.Click += laboratoriosToolStripMenuItem_Click;
            // 
            // altaModificarEliminarLaboratorioToolStripMenuItem
            // 
            altaModificarEliminarLaboratorioToolStripMenuItem.Name = "altaModificarEliminarLaboratorioToolStripMenuItem";
            altaModificarEliminarLaboratorioToolStripMenuItem.Size = new Size(260, 22);
            altaModificarEliminarLaboratorioToolStripMenuItem.Text = "Alta/Modificar/Eliminar laboratorio";
            altaModificarEliminarLaboratorioToolStripMenuItem.Click += altaModificarEliminarLaboratorioToolStripMenuItem_Click;
            // 
            // consultToolStripMenuItem
            // 
            consultToolStripMenuItem.Name = "consultToolStripMenuItem";
            consultToolStripMenuItem.Size = new Size(260, 22);
            consultToolStripMenuItem.Text = "Consulta de laboratorios";
            // 
            // integrantesToolStripMenuItem
            // 
            integrantesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lucasSuletaToolStripMenuItem, emanuelHamuiToolStripMenuItem });
            integrantesToolStripMenuItem.Name = "integrantesToolStripMenuItem";
            integrantesToolStripMenuItem.Size = new Size(78, 20);
            integrantesToolStripMenuItem.Text = "Integrantes";
            integrantesToolStripMenuItem.Click += integrantesToolStripMenuItem_Click;
            // 
            // lucasSuletaToolStripMenuItem
            // 
            lucasSuletaToolStripMenuItem.Name = "lucasSuletaToolStripMenuItem";
            lucasSuletaToolStripMenuItem.Size = new Size(159, 22);
            lucasSuletaToolStripMenuItem.Text = "Lucas Suleta";
            // 
            // emanuelHamuiToolStripMenuItem
            // 
            emanuelHamuiToolStripMenuItem.Name = "emanuelHamuiToolStripMenuItem";
            emanuelHamuiToolStripMenuItem.Size = new Size(159, 22);
            emanuelHamuiToolStripMenuItem.Text = "Emanuel Hamui";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(41, 20);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 426);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMenuPrincipal";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem laboratoriosToolStripMenuItem;
        private ToolStripMenuItem reservasToolStripMenuItem;
        private ToolStripMenuItem integrantesToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem altaModificarEliminarLaboratorioToolStripMenuItem;
        private ToolStripMenuItem consultToolStripMenuItem;
        private ToolStripMenuItem altaModificarBajaReservaToolStripMenuItem;
        private ToolStripMenuItem consultaDeReservasToolStripMenuItem;
        private ToolStripMenuItem lucasSuletaToolStripMenuItem;
        private ToolStripMenuItem emanuelHamuiToolStripMenuItem;
    }
}
