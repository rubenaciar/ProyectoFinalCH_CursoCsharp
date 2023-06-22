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
            dataGridView.DataSource = productos;
        }

        private void btnProductosVendidos_Click(object sender, EventArgs e)
        {
            List<ProductoVendido> productosVendidos = CRUDProductoVendido.TraerListaProductoVendidos();
            dataGridView.DataSource = productosVendidos;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            List<Usuario> usuarios = CRUDUsuario.TraerListaUsuarios();
            dataGridView.DataSource = usuarios;
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            List<Venta> ventas = CRUDVenta.TraerListaVentas();
            dataGridView.DataSource = ventas;
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}