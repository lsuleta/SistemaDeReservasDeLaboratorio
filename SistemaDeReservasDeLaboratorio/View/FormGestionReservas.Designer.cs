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
            colLaboratorioNum = new DataGridViewTextBoxColumn();
            dtpFechaReserva = new DateTimePicker();
            cmbAsignatura = new ComboBox();
            cmbProfesor = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnFiltrar = new Button();
            btnLimpiarFiltros = new Button();
            chkUsarFecha = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvReserva).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(224, 441);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(224, 412);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(143, 441);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(143, 412);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dgvReserva
            // 
            dgvReserva.AllowUserToOrderColumns = true;
            dgvReserva.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReserva.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvReserva.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReserva.Columns.AddRange(new DataGridViewColumn[] { colLaboratorioNum });
            dgvReserva.Location = new Point(0, -1);
            dgvReserva.Name = "dgvReserva";
            dgvReserva.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReserva.Size = new Size(1026, 377);
            dgvReserva.TabIndex = 5;
            dgvReserva.CellFormatting += dgvReserva_CellFormatting;
            // 
            // colLaboratorioNum
            // 
            colLaboratorioNum.HeaderText = "Laboratorio";
            colLaboratorioNum.Name = "colLaboratorioNum";
            // 
            // dtpFechaReserva
            // 
            dtpFechaReserva.Format = DateTimePickerFormat.Short;
            dtpFechaReserva.Location = new Point(645, 412);
            dtpFechaReserva.Name = "dtpFechaReserva";
            dtpFechaReserva.Size = new Size(121, 23);
            dtpFechaReserva.TabIndex = 10;
            // 
            // cmbAsignatura
            // 
            cmbAsignatura.FormattingEnabled = true;
            cmbAsignatura.Location = new Point(645, 469);
            cmbAsignatura.Name = "cmbAsignatura";
            cmbAsignatura.Size = new Size(121, 23);
            cmbAsignatura.TabIndex = 11;
            // 
            // cmbProfesor
            // 
            cmbProfesor.FormattingEnabled = true;
            cmbProfesor.Location = new Point(645, 440);
            cmbProfesor.Name = "cmbProfesor";
            cmbProfesor.Size = new Size(121, 23);
            cmbProfesor.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(553, 390);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 13;
            label1.Text = "Filtros";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(554, 417);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 14;
            label2.Text = "Fecha";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(554, 444);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 15;
            label3.Text = "Profesor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(554, 472);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 16;
            label4.Text = "Asignatura";
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(800, 468);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(75, 23);
            btnFiltrar.TabIndex = 17;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(893, 445);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(75, 47);
            btnLimpiarFiltros.TabIndex = 18;
            btnLimpiarFiltros.Text = "Limpiar filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // chkUsarFecha
            // 
            chkUsarFecha.AutoSize = true;
            chkUsarFecha.Location = new Point(800, 415);
            chkUsarFecha.Name = "chkUsarFecha";
            chkUsarFecha.Size = new Size(80, 19);
            chkUsarFecha.TabIndex = 19;
            chkUsarFecha.Text = "UsarFecha";
            chkUsarFecha.UseVisualStyleBackColor = true;
            // 
            // FormGestionReservas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1027, 508);
            Controls.Add(chkUsarFecha);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(btnFiltrar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
            PerformLayout();
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridViewTextBoxColumn colLaboratorioNum;
        private Button btnFiltrar;
        private Button btnLimpiarFiltros;
        private CheckBox chkUsarFecha;
    }
}