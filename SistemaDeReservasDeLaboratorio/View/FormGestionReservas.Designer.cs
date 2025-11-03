namespace SistemaDeReservasDeLaboratorio.View
{
    partial class FormGestionReservas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSalir = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnNuevo = new Button();
            dgvReserva = new DataGridView();
            dtpFechaReserva = new DateTimePicker();
            cmbAsignatura = new ComboBox();
            cmbProfesor = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvReserva).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(966, 24);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(864, 24);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(756, 24);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(645, 24);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dgvReserva
            // 
            dgvReserva.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReserva.Location = new Point(0, -1);
            dgvReserva.Name = "dgvReserva";
            dgvReserva.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReserva.Size = new Size(628, 508);
            dgvReserva.TabIndex = 5;
            // 
            // dtpFechaReserva
            // 
            dtpFechaReserva.Location = new Point(645, 73);
            dtpFechaReserva.Name = "dtpFechaReserva";
            dtpFechaReserva.Size = new Size(280, 23);
            dtpFechaReserva.TabIndex = 10;
            // 
            // cmbAsignatura
            // 
            cmbAsignatura.FormattingEnabled = true;
            cmbAsignatura.Location = new Point(790, 119);
            cmbAsignatura.Name = "cmbAsignatura";
            cmbAsignatura.Size = new Size(121, 23);
            cmbAsignatura.TabIndex = 11;
            // 
            // cmbProfesor
            // 
            cmbProfesor.FormattingEnabled = true;
            cmbProfesor.Location = new Point(645, 119);
            cmbProfesor.Name = "cmbProfesor";
            cmbProfesor.Size = new Size(121, 23);
            cmbProfesor.TabIndex = 12;
            // 
            // FormGestionReservas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 508);
            Controls.Add(cmbProfesor);
            Controls.Add(cmbAsignatura);
            Controls.Add(dtpFechaReserva);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvReserva);
            Name = "FormGestionReservas";
            Text = "FormGestionReservas";
            Load += FormGestionReservas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReserva).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnNuevo;
        private DataGridView dgvReserva;
        private DateTimePicker dtpFechaReserva;
        private ComboBox cmbAsignatura;
        private ComboBox cmbProfesor;
    }
}