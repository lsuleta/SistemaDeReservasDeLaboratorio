namespace SistemaDeReservasDeLaboratorio.View
{
    partial class FormNuevoLaboratorio
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
            label2 = new Label();
            label3 = new Label();
            txtUbicacion = new TextBox();
            btnAceptar = new Button();
            btnSalir = new Button();
            nudNumeroAsignado = new NumericUpDown();
            nudCapacidad = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudNumeroAsignado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(250, 121);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Numero asignado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 171);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 1;
            label2.Text = "Ubicacion/Piso";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(250, 219);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "Capacidad";
            // 
            // txtUbicacion
            // 
            txtUbicacion.Location = new Point(377, 168);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.Size = new Size(100, 23);
            txtUbicacion.TabIndex = 5;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(292, 287);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(444, 287);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // nudNumeroAsignado
            // 
            nudNumeroAsignado.Location = new Point(377, 119);
            nudNumeroAsignado.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudNumeroAsignado.Name = "nudNumeroAsignado";
            nudNumeroAsignado.Size = new Size(120, 23);
            nudNumeroAsignado.TabIndex = 8;
            // 
            // nudCapacidad
            // 
            nudCapacidad.Location = new Point(377, 217);
            nudCapacidad.Name = "nudCapacidad";
            nudCapacidad.Size = new Size(120, 23);
            nudCapacidad.TabIndex = 9;
            // 
            // FormNuevoLaboratorio
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
            Name = "FormNuevoLaboratorio";
            Text = "FormNuevoLaboratorio";
            ((System.ComponentModel.ISupportInitialize)nudNumeroAsignado).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUbicacion;
        private Button btnAceptar;
        private Button btnSalir;
        private NumericUpDown nudNumeroAsignado;
        private NumericUpDown nudCapacidad;
    }
}