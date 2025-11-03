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
            cmbProfesor = new ComboBox();
            cmbAsignatura = new ComboBox();
            gbCuatrimestral = new GroupBox();
            gbEventual = new GroupBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            comboBox1 = new ComboBox();
            label12 = new Label();
            dateTimePicker3 = new DateTimePicker();
            numericUpDown1 = new NumericUpDown();
            btnGuardar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            gbCuatrimestral.SuspendLayout();
            gbEventual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            // cmbProfesor
            // 
            cmbProfesor.FormattingEnabled = true;
            cmbProfesor.Location = new Point(366, 145);
            cmbProfesor.Name = "cmbProfesor";
            cmbProfesor.Size = new Size(121, 23);
            cmbProfesor.TabIndex = 13;
            // 
            // cmbAsignatura
            // 
            cmbAsignatura.FormattingEnabled = true;
            cmbAsignatura.Location = new Point(366, 91);
            cmbAsignatura.Name = "cmbAsignatura";
            cmbAsignatura.Size = new Size(121, 23);
            cmbAsignatura.TabIndex = 14;
            // 
            // gbCuatrimestral
            // 
            gbCuatrimestral.Controls.Add(comboBox1);
            gbCuatrimestral.Controls.Add(dateTimePicker2);
            gbCuatrimestral.Controls.Add(dateTimePicker1);
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
            // gbEventual
            // 
            gbEventual.Controls.Add(numericUpDown1);
            gbEventual.Controls.Add(dateTimePicker3);
            gbEventual.Controls.Add(label12);
            gbEventual.Controls.Add(label10);
            gbEventual.Location = new Point(410, 220);
            gbEventual.Name = "gbEventual";
            gbEventual.Size = new Size(378, 169);
            gbEventual.TabIndex = 16;
            gbEventual.TabStop = false;
            gbEventual.Text = "Eventual";
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
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 75);
            label9.Name = "label9";
            label9.Size = new Size(50, 15);
            label9.TabIndex = 17;
            label9.Text = "Hora fin";
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
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(17, 111);
            label11.Name = "label11";
            label11.Size = new Size(64, 15);
            label11.TabIndex = 18;
            label11.Text = "Frecuencia";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(102, 36);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 19;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(102, 69);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 20;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(102, 108);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 23);
            comboBox1.TabIndex = 21;
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
            // dateTimePicker3
            // 
            dateTimePicker3.Location = new Point(154, 38);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(200, 23);
            dateTimePicker3.TabIndex = 19;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(154, 73);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(200, 23);
            numericUpDown1.TabIndex = 17;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(303, 415);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 17;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(412, 415);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // FormDetalleReserva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Controls.Add(gbEventual);
            Controls.Add(gbCuatrimestral);
            Controls.Add(cmbAsignatura);
            Controls.Add(cmbProfesor);
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
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            gbCuatrimestral.ResumeLayout(false);
            gbCuatrimestral.PerformLayout();
            gbEventual.ResumeLayout(false);
            gbEventual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
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
        private ComboBox cmbProfesor;
        private ComboBox cmbAsignatura;
        private GroupBox gbCuatrimestral;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label label11;
        private Label label9;
        private Label label8;
        private GroupBox gbEventual;
        private NumericUpDown numericUpDown1;
        private DateTimePicker dateTimePicker3;
        private Label label12;
        private Label label10;
        private Button btnGuardar;
        private Button btnSalir;
    }
}