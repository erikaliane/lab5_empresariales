using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;

namespace Lab05
{
    /// <summary>
    /// Lógica de interacción para Listar.xaml
    /// </summary>
    public partial class Listar : Window
    {
        public Listar()
        {
            InitializeComponent();

            // Configurar la cadena de conexión a tu base de datos
            string connectionString = "Data Source=DESKTOP-DE20VUT\\SQLEXPRESS ;Initial Catalog=Neptuno3;User ID=tecsup;Password=tecsup";

            try
            {
                // Crear una conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Crear un comando para ejecutar el procedimiento almacenado
                    using (SqlCommand command = new SqlCommand("ListarProductos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Crear un lector de datos
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Producto> productos = new List<Producto>();

                            // Leer los datos y agregarlos a la lista de productos
                            while (reader.Read())
                            {
                                Producto producto = new Producto
                                {
                                    IdProducto = Convert.ToInt32(reader["idproducto"]),
                                    NombreProducto = reader["nombreProducto"].ToString(),
                                    IdProveedor = Convert.ToInt32(reader["idProveedor"]),
                                    IdCategoria = Convert.ToInt32(reader["idCategoria"]),
                                    CantidadPorUnidad = reader["cantidadPorUnidad"].ToString(),
                                    PrecioUnidad = Convert.ToDecimal(reader["precioUnidad"]),
                                    UnidadesEnExistencia = Convert.ToInt32(reader["unidadesEnExistencia"]),
                                    UnidadesEnPedido = Convert.ToInt32(reader["unidadesEnPedido"]),
                                    NivelNuevoPedido = Convert.ToInt32(reader["nivelNuevoPedido"]),
                                    CategoriaProducto = reader["categoriaProducto"].ToString()
                                };

                                productos.Add(producto);
                            }

                            // Asignar la lista de productos al DataGrid
                            dataGrid.ItemsSource = productos;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
            }
        }
    }
}
