using Business;
using System;
using System.Collections.Generic;
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
using Data;
using System.Xml.Linq;
using Entity;

namespace WPFLab07
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BProduct business = new BProduct();
            
            String nombre = txtNombreProducto.Text;
            var products = business.GetByName(nombre);
            McDataGrid.ItemsSource = products;

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            BProduct business = new BProduct();

            string nombre = txtNombreProducto.Text;
            string precio = txtPrecioProducto.Text;
            string cantidad = txtCantidadProducto.Text;

            if (!string.IsNullOrEmpty(nombre) && double.TryParse(precio, out double precioValue) && int.TryParse(cantidad, out int cantidadValue))
            {
                Product newProduct = new Product
                {
                    Name = nombre,
                    Price = precioValue.ToString(),
                    Stock = cantidadValue
                };

                bool insertSuccess = business.InsertProduct(newProduct);

                if (insertSuccess)
                {
                    MessageBox.Show("Producto ingresada correctamente.");
                    var products = business.GetByName(string.Empty); 
                    McDataGrid.ItemsSource = products;
                    txtNombreProducto.Clear();
                    txtPrecioProducto.Clear();
                    txtCantidadProducto.Clear();
                }
                else
                {

                    MessageBox.Show("No se pudo insertar el producto. Verifique los datos e inténtelo de nuevo.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese valores válidos para el nombre, precio y cantidad.");
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            BProduct business = new BProduct();

            if (int.TryParse(txtIDProducto.Text, out int productIdToDelete))
            {
                bool deleteSuccess = business.DeleteProduct(productIdToDelete);

                if (deleteSuccess)
                {
                    
                    var products = business.GetByName(string.Empty); 
                    McDataGrid.ItemsSource = products;

                    txtIDProducto.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el producto. Verifique el ID e inténtelo de nuevo.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID de producto válido para eliminar.");
            }
        }


    }
}
