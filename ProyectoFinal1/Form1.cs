using ProyectoFinal1.Modelos;
using ProyectoFinal1.ADONET;

namespace ProyectoFinal1

{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            List<Producto> productos = CRUDProducto.TraerListaProductos();
            dataGridView.DataSource = null;
            dataGridView.ColumnCount = 0;

            dataGridView.DataSource = productos;
            cmbIDProducto.Items.Clear();
            for (int i = 0; i < productos.Count; i++)
            {
                cmbIDProducto.Items.Add(productos[i].Id);
            }

            cmbIDProdVendido.Items.Clear();
            cmbIDUsuario.Items.Clear();
            cmbIDVenta.Items.Clear();
        }

        private void btnProductosVendidos_Click(object sender, EventArgs e)
        {
            List<ProductoVendido> productosVendidos = CRUDProductoVendido.TraerListaProductoVendidos();

            dataGridView.DataSource = null;
            dataGridView.ColumnCount = 0;


            dataGridView.DataSource = productosVendidos;
            cmbIDProdVendido.Items.Clear();
            for (int i = 0; i < productosVendidos.Count; i++)
            {
                cmbIDProdVendido.Items.Add(productosVendidos[i].Id);
            }
            cmbIDProducto.Items.Clear();

            cmbIDUsuario.Items.Clear();
            cmbIDVenta.Items.Clear();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            List<Usuario> usuarios = CRUDUsuario.TraerListaUsuarios();
            dataGridView.DataSource = null;
            dataGridView.ColumnCount = 0;

            dataGridView.DataSource = usuarios;
            cmbIDUsuario.Items.Clear();
            for (int i = 0; i < usuarios.Count; i++)
            {
                cmbIDUsuario.Items.Add(usuarios[i].Id);
            }
            cmbIDProducto.Items.Clear();
            cmbIDProdVendido.Items.Clear();

            cmbIDVenta.Items.Clear();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            List<Venta> ventas = CRUDVenta.TraerListaVentas();
            dataGridView.DataSource = null;
            dataGridView.ColumnCount = 0; 

            dataGridView.DataSource = ventas;
            cmbIDVenta.Items.Clear();
            for (int i = 0; i < ventas.Count; i++)
            {
                cmbIDVenta.Items.Add(ventas[i].Id);
            }
            cmbIDProducto.Items.Clear();
            cmbIDProdVendido.Items.Clear();
            cmbIDUsuario.Items.Clear();

        }



        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string contraseña = txtContrasena.Text;

            Usuario usuario = ADO_Sesion.IniciarSesion(nombreUsuario, contraseña);

            if (usuario != null)
            {
                MessageBox.Show("Usuario Correcto");
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            {
                switch (e.CloseReason)
                {
                    case CloseReason.UserClosing:
                        if (MessageBox.Show("Estas seguro de salir",
                                            "Salida de Sistema Gestion?",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question) == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                        break;
                }
            }
        }

        private void cmbIDProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto producto = CRUDProducto.TraerProductoPorId((int)cmbIDProducto.SelectedItem);
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();


            string[] row0 = { producto.Id.ToString(), producto.Descripcion.ToString(),
                producto.Costo.ToString(),  producto.PrecioVenta.ToString(),
                producto.Stock.ToString(),producto.IdUsuario.ToString() };
                        
            dataGridView.ColumnCount = row0.Length;

            dataGridView.Columns[0].Name = "ID";
            dataGridView.Columns[1].Name = "Descripción";
            dataGridView.Columns[2].Name = "Costo";
            dataGridView.Columns[3].Name = "PrecioVenta";
            dataGridView.Columns[4].Name = "Stock";
            dataGridView.Columns[5].Name = "IDUsuario";

            dataGridView.Rows.Add(row0);



        }

        private void cmbIDProdVendido_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoVendido prodvendido = CRUDProductoVendido.TraerProductoVendidoPorId((int)cmbIDProdVendido.SelectedItem);
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();


            string[] row0 = { prodvendido.Id.ToString(), prodvendido.Stock.ToString(),
                prodvendido.IdProducto.ToString(),  prodvendido.IdVenta.ToString()};

            dataGridView.ColumnCount = row0.Length;

            dataGridView.Columns[0].Name = "ID";
            dataGridView.Columns[1].Name = "Stock";
            dataGridView.Columns[2].Name = "IDProducto";
            dataGridView.Columns[3].Name = "IDVenta";

            dataGridView.Rows.Add(row0);
        }

        private void cmbIDUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuario = CRUDUsuario.TraerUsuarioPorId((int)cmbIDUsuario.SelectedItem);
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();


            string[] row0 = {usuario.Id.ToString(), usuario.Nombre.ToString(),
                usuario.Apellido.ToString(),  usuario.NombreUsuario.ToString(),
                usuario.Contraseña.ToString(),usuario.Mail.ToString() };

            dataGridView.ColumnCount = row0.Length;

            dataGridView.Columns[0].Name = "ID";
            dataGridView.Columns[1].Name = "Nombre";
            dataGridView.Columns[2].Name = "Apellido";
            dataGridView.Columns[3].Name = "Nombre Usuario";
            dataGridView.Columns[4].Name = "Clave Acceso";
            dataGridView.Columns[5].Name = "Email";

            dataGridView.Rows.Add(row0);
        }

        private void cmbIDVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Venta venta = CRUDVenta.TraerVentaPorId((int)cmbIDVenta.SelectedItem);
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();


            string[] row0 = { venta.Id.ToString(), venta.Comentarios.ToString(),
                venta.IdUsuario.ToString()};

            dataGridView.ColumnCount = row0.Length;

            dataGridView.Columns[0].Name = "ID";
            dataGridView.Columns[1].Name = "Comentarios";
            dataGridView.Columns[2].Name = "IDUsuario";

            dataGridView.Rows.Add(row0);
        }
    }
}


        