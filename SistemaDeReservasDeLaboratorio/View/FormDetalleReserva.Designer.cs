namespace SistemaDeReservasDeLaboratorio.View
{
    partial class FormDetalleReserva
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
            label1 = new Label();
            cmbLaboratorio = new ComboBox();
            label2 = new Label();
            cmbReserva = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtCarrera = new TextBox();
            txtComision = new TextBox();
            nudAnio = new NumericUpDown();
            gbCuatrimestral = new GroupBox();
            cmbFrecuencia = new ComboBox();
            dtpHoraFin = new DateTimePicker();
            dtpHoraInicio = new DateTimePicker();
            label11 = new Label();
            label9 = new Label();
            label8 = new Label();
            gbEventual = new GroupBox();
            nudCantidadSemanas = new NumericUpDown();
            dtpFecha = new DateTimePicker();
            label12 = new Label();
            label10 = new Label();
            btnGuardar = new Button();
            btnSalir = new Button();
            txtAsignatura = new TextBox();
            txtProfesor = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            gbCuatrimestral.SuspendLayout();
            gbEventual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadSemanas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 44);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 0;
            label1.Text = "Laboratorio";
            // 
            // cmbLaboratorio
            // 
            cmbLaboratorio.FormattingEnabled = true;
            cmbLaboratorio.Location = new Point(147, 41);
            cmbLaboratorio.Name = "cmbLaboratorio";
            cmbLaboratorio.Size = new Size(121, 23);
            cmbLaboratorio.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 94);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 2;
            label2.Text = "Tipo de reserva";
            // 
            // cmbReserva
            // 
            cmbReserva.FormattingEnabled = true;
            cmbReserva.Location = new Point(147, 91);
            cmbReserva.Name = "cmbReserva";
            cmbReserva.Size = new Size(121, 23);
            cmbReserva.TabIndex = 3;
            cmbReserva.SelectedIndexChanged += cmbReserva_selectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(291, 44);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 4;
            label3.Text = "Carrera";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(291, 94);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 5;
            label4.Text = "Asignatura";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(525, 44);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 6;
            label5.Text = "Anio";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(525, 94);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 7;
            label6.Text = "Comision";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(291, 148);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 8;
            label7.Text = "Profesor";
            // 
            // txtCarrera
            // 
            txtCarrera.Location = new Point(366, 41);
            txtCarrera.Name = "txtCarrera";
            txtCarrera.Size = new Size(121, 23);
            txtCarrera.TabIndex = 9;
            // 
            // txtComision
            // 
            txtComision.Location = new Point(600, 91);
            txtComision.Name = "txtComision";
            txtComision.Size = new Size(120, 23);
            txtComision.TabIndex = 11;
            // 
            // nudAnio
            // 
            nudAnio.Location = new Point(600, 42);
            nudAnio.Name = "nudAnio";
            nudAnio.Size = new Size(120, 23);
            nudAnio.TabIndex = 12;
            // 
            // gbCuatrimestral
            // 
            gbCuatrimestral.Controls.Add(cmbFrecuencia);
            gbCuatrimestral.Controls.Add(dtpHoraFin);
            gbCuatrimestral.Controls.Add(dtpHoraInicio);
            gbCuatrimestral.Controls.Add(label11);
            gbCuatrimestral.Controls.Add(label9);
            gbCuatrimestral.Controls.Add(label8);
            gbCuatrimestral.Location = new Point(12, 220);
            gbCuatrimestral.Name = "gbCuatrimestral";
            gbCuatrimestral.Size = new Size(392, 169);
            gbCuatrimestral.TabIndex = 15;
            gbCuatrimestral.TabStop = false;
            gbCuatrimestral.Text = "Cuatrimestral";
            // 
            // cmbFrecuencia
            // 
            cmbFrecuencia.FormattingEnabled = true;
            cmbFrecuencia.Location = new Point(102, 108);
            cmbFrecuencia.Name = "cmbFrecuencia";
            cmbFrecuencia.Size = new Size(200, 23);
            cmbFrecuencia.TabIndex = 21;
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(102, 69);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.Size = new Size(200, 23);
            dtpHoraFin.TabIndex = 20;
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(102, 36);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.Size = new Size(200, 23);
            dtpHoraInicio.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(17, 111);
            label11.Name = "label11";
            label11.Size = new Size(64, 15);
            label11.TabIndex = 18;
            label11.Text = "Frecuencia";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 75);
            label9.Name = "label9";
            label9.Size = new Size(50, 15);
            label9.TabIndex = 17;
            label9.Text = "Hora fin";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 42);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 0;
            label8.Text = "Hora inicio";
            // 
            // gbEventual
            // 
            gbEventual.Controls.Add(nudCantidadSemanas);
            gbEventual.Controls.Add(dtpFecha);
            gbEventual.Controls.Add(label12);
            gbEventual.Controls.Add(label10);
            gbEventual.Location = new Point(410, 220);
            gbEventual.Name = "gbEventual";
            gbEventual.Size = new Size(378, 169);
            gbEventual.TabIndex = 16;
            gbEventual.TabStop = false;
            gbEventual.Text = "Eventual";
            // 
            // nudCantidadSemanas
            // 
            nudCantidadSemanas.Location = new Point(154, 73);
            nudCantidadSemanas.Name = "nudCantidadSemanas";
            nudCantidadSemanas.Size = new Size(200, 23);
            nudCantidadSemanas.TabIndex = 17;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(154, 38);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 19;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(29, 77);
            label12.Name = "label12";
            label12.Size = new Size(104, 15);
            label12.TabIndex = 18;
            label12.Text = "Cantidad semanas";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(29, 44);
            label10.Name = "label10";
            label10.Size = new Size(93, 15);
            label10.TabIndex = 17;
            label10.Text = "Fecha comienzo";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(303, 415);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 17;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(412, 415);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // txtAsignatura
            // 
            txtAsignatura.Location = new Point(366, 91);
            txtAsignatura.Name = "txtAsignatura";
            txtAsignatura.Size = new Size(121, 23);
            txtAsignatura.TabIndex = 19;
            // 
            // txtProfesor
            // 
            txtProfesor.Location = new Point(366, 145);
            txtProfesor.Name = "txtProfesor";
            txtProfesor.Size = new Size(121, 23);
            txtProfesor.TabIndex = 20;
            // 
            // FormDetalleReserva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtProfesor);
            Controls.Add(txtAsignatura);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Controls.Add(gbEventual);
            Controls.Add(gbCuatrimestral);
            Controls.Add(nudAnio);
            Controls.Add(txtComision);
            Controls.Add(txtCarrera);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbReserva);
            Controls.Add(label2);
            Controls.Add(cmbLaboratorio);
            Controls.Add(label1);
            Name = "FormDetalleReserva";
            Text = "FormDetalleReserva";
            Load += FormDetalleReserva_Load;
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            gbCuatrimestral.ResumeLayout(false);
            gbCuatrimestral.PerformLayout();
            gbEventual.ResumeLayout(false);
            gbEventual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadSemanas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbLaboratorio;
        private Label label2;
        private ComboBox cmbReserva;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtCarrera;
        private TextBox txtComision;
        private NumericUpDown nudAnio;
        private GroupBox gbCuatrimestral;
        private ComboBox cmbFrecuencia;
        private DateTimePicker dtpHoraFin;
        private DateTimePicker dtpHoraInicio;
        private Label label11;
        private Label label9;
        private Label label8;
        private GroupBox gbEventual;
        private NumericUpDown nudCantidadSemanas;
        private DateTimePicker dtpFecha;
        private Label label12;
        private Label label10;
        private Button btnGuardar;
        private Button btnSalir;
        private TextBox txtAsignatura;
        private TextBox txtProfesor;
    }
}