namespace SistemaDeReservasDeLaboratorio.View
{
    partial class FormGestionLaboratorios
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
            dgvLaboratorios = new DataGridView();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLaboratorios).BeginInit();
            SuspendLayout();
            // 
            // dgvLaboratorios
            // 
            dgvLaboratorios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLaboratorios.Location = new Point(2, 1);
            dgvLaboratorios.Name = "dgvLaboratorios";
            dgvLaboratorios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLaboratorios.Size = new Size(605, 449);
            dgvLaboratorios.TabIndex = 0;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(672, 78);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(672, 107);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(672, 136);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(672, 165);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FormGestionLaboratorios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvLaboratorios);
            Name = "FormGestionLaboratorios";
            Text = "FormGestionLaboratorios";
            Load += FormGestionLaboratorios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLaboratorios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvLaboratorios;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnSalir;
    }
}