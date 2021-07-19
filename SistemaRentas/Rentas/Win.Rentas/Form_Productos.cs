using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Rentas;
using System.IO;

namespace Win.Rentas
{
    public partial class Form_Productos : Form
    {
        ProductosBL _productos;

        public Form_Productos()
        {
            InitializeComponent();

            _productos = new ProductosBL();
            listaProductosBindingSource.DataSource = _productos.ObtenerProductos();
        }

        //Boton de guardar productos
        private void listaProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaProductosBindingSource.EndEdit();
            var producto = (Producto)listaProductosBindingSource.Current;

            if (fotoPictureBox.Image != null)
            {
                producto.Foto = Program.imageToByteArray(fotoPictureBox.Image);
            }

            else
            {
                producto.Foto = null;
            }


            var resultado = _productos.GuardarProducto(producto);

            if (resultado.Exitoso == true)
            {
                listaProductosBindingSource.ResetBindings(false);
                DeshabilitarBotones_habilitarBotones(true);
                MessageBox.Show("Se han guardado los cambios");
            }

            else
            {
                MessageBox.Show(resultado.Mensaje);
            }

            DeshabilitarBotones_habilitarBotones(true);

        }

        // Boton de agregar nuevo producto
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e) 
        {
            //idTextBox.ReadOnly(false);

            _productos.AgregarProducto();

            listaProductosBindingSource.MoveLast();

            DeshabilitarBotones_habilitarBotones(false);
        }

        //Habilitar o deshabilitar botones
        private void DeshabilitarBotones_habilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;

        }

        //Eliminar producto
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) 
        {
            var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);            

            if (idTextBox.Text != "")
            {
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
            
        }

            private void Eliminar(int id)
            {
                var resultado = _productos.EliminarProducto(id);

                if (resultado == true)
                {
                    listaProductosBindingSource.ResetBindings(false);
                }

                else
                {
                    MessageBox.Show("Ocurrio un error al eliminar el producto");
                }
            }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarBotones_habilitarBotones(true);
            Eliminar(0);
        }

        private void btn_agregFoto_Click(object sender, EventArgs e)
        {
            var producto = (Producto)listaProductosBindingSource.Current;

            if (producto != null)
            {
                openFileDialog1.ShowDialog();

                var archivo = openFileDialog1.FileName;
                if (archivo != "")
                {
                    var fileinfo = new FileInfo(archivo);
                    var fileStream = fileinfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }
            }
            
            else
            {
                MessageBox.Show("Debe crear un producto antes de asignar una imagen");
            }
        }

        private void btn_removFoto_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }
    }
}
