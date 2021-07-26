using BL.Rentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Rentas
{
    public partial class Form_Clientes : Form
    {
        ClientesBL _cliente;

        public Form_Clientes()
        {
            InitializeComponent();

            _cliente = new ClientesBL();
            listaClientesBindingSource.DataSource = _cliente.ObtenerClientes();
        }
       
        //agregar nuevo cliente
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //idTextBox.ReadOnly(false);

            _cliente.AgregarCliente();

            listaClientesBindingSource.MoveLast();

            DeshabilitarBotones_habilitarBotones(false);
        }

        //Eliminar cliente
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

        private void listaClientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaClientesBindingSource.EndEdit();
            var cliente = (Cliente)listaClientesBindingSource.Current;

            var resultado = _cliente.GuardarCliente(cliente);

            if (resultado.Exitoso == true)
            {
                listaClientesBindingSource.ResetBindings(false);
                DeshabilitarBotones_habilitarBotones(true);
                MessageBox.Show("Se han guardado los cambios");
            }

            else
            {
                MessageBox.Show(resultado.Mensaje);
            }

            DeshabilitarBotones_habilitarBotones(true);
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
            toolStripCancelar.Visible = !valor;

        }

        private void Eliminar(int id)
        {
            var resultado = _cliente.EliminarCliente(id);

            if (resultado == true)
            {
                listaClientesBindingSource.ResetBindings(false);
            }

            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el registro");
            }
        }
    }
}
