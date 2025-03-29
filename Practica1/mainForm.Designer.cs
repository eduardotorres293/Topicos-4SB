namespace Practica1
{
    partial class mainForm
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
            lblTitulo = new Label();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            listBox1 = new ListBox();
            menuStrip1 = new MenuStrip();
            salirToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F);
            lblTitulo.Location = new Point(12, 42);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(306, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestor de contactos";
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 15F);
            btnAgregar.Location = new Point(12, 104);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(196, 38);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar contacto";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 15F);
            btnEliminar.Location = new Point(12, 158);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(196, 38);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar contacto";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI", 15F);
            btnLimpiar.Location = new Point(12, 213);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(196, 38);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar contactos";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(238, 104);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(798, 454);
            listBox1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.Items.AddRange(new ToolStripItem[] { salirToolStripMenuItem, acercaDeToolStripMenuItem, acercaDeToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 29);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            salirToolStripMenuItem.Font = new Font("Segoe UI", 12F);
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(53, 25);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            acercaDeToolStripMenuItem.Font = new Font("Segoe UI", 12F);
            acercaDeToolStripMenuItem.ForeColor = SystemColors.ControlText;
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(89, 25);
            acercaDeToolStripMenuItem.Text = "Acerca de";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // acercaDeToolStripMenuItem1
            // 
            acercaDeToolStripMenuItem1.Name = "acercaDeToolStripMenuItem1";
            acercaDeToolStripMenuItem1.Size = new Size(12, 25);
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(listBox1);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(lblTitulo);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "mainForm";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private ListBox listBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem1;
    }
}
