namespace ProyectoFinal1
{
    partial class Form1
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnProductosVendidos = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbIDVenta = new System.Windows.Forms.ComboBox();
            this.cmbIDUsuario = new System.Windows.Forms.ComboBox();
            this.cmbIDProdVendido = new System.Windows.Forms.ComboBox();
            this.cmbIDProducto = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(35, 38);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(727, 344);
            this.dataGridView.TabIndex = 0;
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(92, 9);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(124, 23);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnProductosVendidos
            // 
            this.btnProductosVendidos.Location = new System.Drawing.Point(283, 8);
            this.btnProductosVendidos.Name = "btnProductosVendidos";
            this.btnProductosVendidos.Size = new System.Drawing.Size(141, 23);
            this.btnProductosVendidos.TabIndex = 2;
            this.btnProductosVendidos.Text = "Productos Vendidos";
            this.btnProductosVendidos.UseVisualStyleBackColor = true;
            this.btnProductosVendidos.Click += new System.EventHandler(this.btnProductosVendidos_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(490, 8);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(107, 23);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new System.Drawing.Point(659, 9);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(103, 23);
            this.btnVentas.TabIndex = 4;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Location = new System.Drawing.Point(485, 403);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(104, 26);
            this.btnIniciarSesion.TabIndex = 5;
            this.btnIniciarSesion.Text = "Iniciar Sesion";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(245, 403);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(102, 23);
            this.txtUsuario.TabIndex = 6;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(353, 403);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(101, 23);
            this.txtContrasena.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Clave";
            // 
            // cmbIDVenta
            // 
            this.cmbIDVenta.FormattingEnabled = true;
            this.cmbIDVenta.Location = new System.Drawing.Point(605, 9);
            this.cmbIDVenta.Name = "cmbIDVenta";
            this.cmbIDVenta.Size = new System.Drawing.Size(53, 23);
            this.cmbIDVenta.TabIndex = 10;
            this.cmbIDVenta.SelectedIndexChanged += new System.EventHandler(this.cmbIDVenta_SelectedIndexChanged);
            // 
            // cmbIDUsuario
            // 
            this.cmbIDUsuario.FormattingEnabled = true;
            this.cmbIDUsuario.Location = new System.Drawing.Point(437, 8);
            this.cmbIDUsuario.Name = "cmbIDUsuario";
            this.cmbIDUsuario.Size = new System.Drawing.Size(53, 23);
            this.cmbIDUsuario.TabIndex = 11;
            this.cmbIDUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbIDUsuario_SelectedIndexChanged);
            // 
            // cmbIDProdVendido
            // 
            this.cmbIDProdVendido.FormattingEnabled = true;
            this.cmbIDProdVendido.Location = new System.Drawing.Point(229, 8);
            this.cmbIDProdVendido.Name = "cmbIDProdVendido";
            this.cmbIDProdVendido.Size = new System.Drawing.Size(53, 23);
            this.cmbIDProdVendido.TabIndex = 12;
            this.cmbIDProdVendido.SelectedIndexChanged += new System.EventHandler(this.cmbIDProdVendido_SelectedIndexChanged);
            // 
            // cmbIDProducto
            // 
            this.cmbIDProducto.FormattingEnabled = true;
            this.cmbIDProducto.Location = new System.Drawing.Point(35, 9);
            this.cmbIDProducto.Name = "cmbIDProducto";
            this.cmbIDProducto.Size = new System.Drawing.Size(53, 23);
            this.cmbIDProducto.TabIndex = 13;
            this.cmbIDProducto.SelectedIndexChanged += new System.EventHandler(this.cmbIDProducto_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbIDProducto);
            this.Controls.Add(this.cmbIDProdVendido);
            this.Controls.Add(this.cmbIDUsuario);
            this.Controls.Add(this.cmbIDVenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnProductosVendidos);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form1";
            this.Text = "Sistema Gestion CH - Curso C#";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView;
        private Button btnProductos;
        private Button btnProductosVendidos;
        private Button btnUsuarios;
        private Button btnVentas;
        private Button btnIniciarSesion;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Label label1;
        private Label label2;
        private ComboBox cmbIDVenta;
        private ComboBox cmbIDUsuario;
        private ComboBox cmbIDProdVendido;
        private ComboBox cmbIDProducto;
    }
}