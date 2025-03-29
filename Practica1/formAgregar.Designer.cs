namespace Practica1
{
    partial class formAgregar
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
            lblTitulo = new Label();
            txtNombre = new TextBox();
            txtCorreoElectronico = new TextBox();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            lblCorreo = new Label();
            lblNombre = new Label();
            btnAgregar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(481, 45);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Introduce los datos del contacto";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 117);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(363, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtCorreoElectronico
            // 
            txtCorreoElectronico.Location = new Point(12, 275);
            txtCorreoElectronico.Name = "txtCorreoElectronico";
            txtCorreoElectronico.Size = new Size(363, 23);
            txtCorreoElectronico.TabIndex = 3;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(12, 192);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(363, 23);
            txtTelefono.TabIndex = 4;
            txtTelefono.KeyPress += txtTelefono_KeyPress_1;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 15F);
            lblTelefono.Location = new Point(12, 161);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(301, 28);
            lblTelefono.TabIndex = 5;
            lblTelefono.Text = "Introduce un número de teléfono";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI", 15F);
            lblCorreo.Location = new Point(12, 244);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(287, 28);
            lblCorreo.TabIndex = 6;
            lblCorreo.Text = "Introduce un correo electrónico";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 15F);
            lblNombre.Location = new Point(12, 86);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(197, 28);
            lblNombre.TabIndex = 7;
            lblNombre.Text = "Introduce un nombre";
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 15F);
            btnAgregar.Location = new Point(504, 102);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(196, 38);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar contacto";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // formAgregar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAgregar);
            Controls.Add(lblNombre);
            Controls.Add(lblCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(txtCorreoElectronico);
            Controls.Add(txtNombre);
            Controls.Add(lblTitulo);
            Name = "formAgregar";
            Text = "formAgregar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private TextBox txtNombre;
        private TextBox txtCorreoElectronico;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private Label lblCorreo;
        private Label lblNombre;
        private Button btnAgregar;
    }
}