using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Semana06
{
    /// <summary>
    /// Lógica de interacción para ManProducto.xaml
    /// </summary>
    public partial class ManProducto : Window
    {
        public int ID { get; set; }
        public ManProducto(int Id)
        {
            InitializeComponent();
            ID = Id;
            if (ID > 0)
            {
                BProducto bProducto = new BProducto();
                List<Producto> productos = new List<Producto>();
                productos = bProducto.Listar(ID);
                if (productos.Count > 0)
                {
                    txtId.Text = productos[0].IdProducto.ToString();
                    txtNombre.Text = productos[0].NombreProducto;
                    txtProveedor.Text = productos[0].idProveedor.ToString();
                    txtCategoria.Text = productos[0].idCategoria.ToString();
                    txtCantUni.Text = productos[0].cantidadPorUnidad;
                    txtPrecUni.Text = productos[0].precioUnidadDecimal.ToString();
                    txtUniExist.Text = productos[0].unidadesEnExistencia.ToString();
                    txtUnidPed.Text = productos[0].unidadesEnPedido.ToString();
                    txtNivelPedido.Text = productos[0].nivelNuevoPedido.ToString();
                    txtSuspendido.Text = productos[0].Suspendido.ToString();
                    txtCatProd.Text = productos[0].categoriaProducto;
                }
            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto = null;
            bool result = true;
            try
            {
                bProducto = new BProducto();
                if (ID > 0)
                {
                    result = bProducto.Actualizar(new Producto{ 
                        IdProducto = ID,
                        NombreProducto = txtNombre.Text,
                        idProveedor = Convert.ToInt32(txtProveedor.Text),
                        idCategoria = Convert.ToInt32(txtCategoria.Text),
                        cantidadPorUnidad = txtCantUni.Text,
                        precioUnidadDecimal = Convert.ToInt32(txtPrecUni.Text),
                        unidadesEnExistencia = Convert.ToInt32(txtUniExist.Text),
                        unidadesEnPedido = Convert.ToInt32(txtUnidPed.Text),
                        nivelNuevoPedido = Convert.ToInt32(txtNivelPedido.Text),
                        Suspendido = Convert.ToInt32(txtSuspendido.Text),
                        categoriaProducto = txtCatProd.Text,
                    });
                }
                else
                    result = bProducto.Insertar(new Producto{
                        NombreProducto = txtNombre.Text,
                        idProveedor = Convert.ToInt32(txtProveedor.Text),
                        idCategoria = Convert.ToInt32(txtCategoria.Text),
                        cantidadPorUnidad = txtCantUni.Text,
                        precioUnidadDecimal = Convert.ToInt32(txtPrecUni.Text),
                        unidadesEnExistencia = Convert.ToInt32(txtUniExist.Text),
                        unidadesEnPedido = Convert.ToInt32(txtUnidPed.Text),
                        nivelNuevoPedido = Convert.ToInt32(txtNivelPedido.Text),
                        Suspendido = Convert.ToInt32(txtSuspendido.Text),
                        categoriaProducto = txtCatProd.Text,
                    });
                if (!result)
                {
                    MessageBox.Show("Comunicarse con el administrador  !!!");
                }
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Comunicarse con el administrador");
            }
            finally
            {
                bProducto = null;
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto= null;
            bool result = true;
            try
            {
                bProducto = new BProducto();
                if (ID > 0)
                {
                    result = bProducto.Eliminar(ID);
                }
                if (result)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Comunicarse con el administrador -- problemas para eliminar");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el administrador");
            }
        }
    }
}
