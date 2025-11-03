namespace SistemaDeReservasDeLaboratorio.View
{
    partial class FormModificarLaboratorio
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
            nudCapacidad = new NumericUpDown();
            nudNumeroAsignado = new NumericUpDown();
            btnSalir = new Button();
            btnAceptar = new Button();
            txtUbicacion = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNumeroAsignado).BeginInit();
            SuspendLayout();
            // 
            // nudCapacidad
            // 
            nudCapacidad.Location = new Point(393, 228);
            nudCapacidad.Name = "nudCapacidad";
            nudCapacidad.Size = new Size(120, 23);
            nudCapacidad.TabIndex = 17;
            // 
            // nudNumeroAsignado
            // 
            nudNumeroAsignado.Location = new Point(393, 130);
            nudNumeroAsignado.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudNumeroAsignado.Name = "nudNumeroAsignado";
            nudNumeroAsignado.Size = new Size(120, 23);
            nudNumeroAsignado.TabIndex = 16;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(460, 298);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 15;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(308, 298);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 14;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtUbicacion
            // 
            txtUbicacion.Location = new Point(393, 179);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.Size = new Size(100, 23);
            txtUbicacion.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(266, 230);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 12;
            label3.Text = "Capacidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 182);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 11;
            label2.Text = "Ubicacion/Piso";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(266, 132);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 10;
            label1.Text = "Numero asignado";
            // 
            // FormModificarLaboratorio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(nudCapacidad);
            Controls.Add(nudNumeroAsignado);
            Controls.Add(btnSalir);
            Controls.Add(btnAceptar);
            Controls.Add(txtUbicacion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormModificarLaboratorio";
            Text = "FormModificarLaboratorio";
            Load += FormModificarLaboratorio_Load;
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNumeroAsignado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown nudCapacidad;
        private NumericUpDown nudNumeroAsignado;
        private Button btnSalir;
        private Button btnAceptar;
        private TextBox txtUbicacion;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}