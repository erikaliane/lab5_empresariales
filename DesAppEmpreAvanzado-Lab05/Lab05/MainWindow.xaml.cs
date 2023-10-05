
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            }
            private void GuardarClick(object sender, RoutedEventArgs e)
            {
                try
                {
                    string connectionString = "Data Source=DESKTOP-DE20VUT\\SQLEXPRESS ;Initial Catalog=Neptuno3;User ID=tecsup;Password=tecsup";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("CrearProducto", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idProducto", int.Parse(txtIdProducto.Text));
                        cmd.Parameters.AddWithValue("@nombreProducto", txtNombreProducto.Text);
                        cmd.Parameters.AddWithValue("@idProveedor", int.Parse(txtIdProveedor.Text));
                        cmd.Parameters.AddWithValue("@idCategoria", int.Parse(txtIdCategoria.Text));
                        cmd.Parameters.AddWithValue("@cantidadPorUnidad", txtCantidadPorUnidad.Text);
                        cmd.Parameters.AddWithValue("@precioUnidad", decimal.Parse(txtPrecioUnidad.Text));

                        cmd.Parameters.AddWithValue("@unidadesEnExistencia", int.Parse(txtUnidadesEnExistencia.Text));
                        cmd.Parameters.AddWithValue("@unidadesEnPedido", int.Parse(txtUnidadesEnPedido.Text));
                        cmd.Parameters.AddWithValue("@nivelNuevoPedido", int.Parse(txtNivelNuevoPedido.Text));
                        cmd.Parameters.AddWithValue("@categoriaProducto", txtCategoriaProducto.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Producto ingresada correctamente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ingresar Producto: " + ex.Message);
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Listar window = new Listar();
            this.Close();
            window.Show();
        }
    }
}
