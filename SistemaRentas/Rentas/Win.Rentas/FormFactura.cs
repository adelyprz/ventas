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
    public partial class FormFactura : Form
    {
        FacturaBL _facturaBL;
        ProductosBL _productosBL;
        ClientesBL _clientesBL;

        public FormFactura()
        {
            InitializeComponent();

            _facturaBL = new FacturaBL();
            listaFacturasBindingSource.DataSource = _facturaBL.ObtenerFacturas();

            _productosBL = new ProductosBL();
            listaProductosBindingSource.DataSource = _productosBL.ObtenerProductos();

            _clientesBL = new ClientesBL();
            listaClientesBindingSource.DataSource = _clientesBL.ObtenerClientes();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _facturaBL.AgregarFactura();
            listaFacturasBindingSource.MoveLast();

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
            toolStripBtnCancelar.Visible = !valor;

        }

        private void listaFacturasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaFacturasBindingSource.EndEdit();

            var factura = (Factura)listaFacturasBindingSource.Current;
            var resultado = _facturaBL.GuardarFactura(factura);

            if (resultado.Exitoso == true)
            {
                listaFacturasBindingSource.ResetBindings(false);
                DeshabilitarBotones_habilitarBotones(true);
                MessageBox.Show("Factura Guardada");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void toolStripBtnCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarBotones_habilitarBotones(true);
            _facturaBL.CancelarCambios();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var factura = (Factura)listaFacturasBindingSource.Current;
            _facturaBL.AgregarFacturaDetalle(factura);

            DeshabilitarBotones_habilitarBotones(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var factura = (Factura)listaFacturasBindingSource.Current;
            var facturaDetalle = (FacturaDetalle)facturaDetalleBindingSource.Current;

            _facturaBL.RemoverFacturaDetalle(factura, facturaDetalle);

            DeshabilitarBotones_habilitarBotones(false);
        }

        private void facturaDetalleDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void facturaDetalleDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var factura = (Factura)listaFacturasBindingSource.Current;
            _facturaBL.CalcularFactura(factura);

            listaFacturasBindingSource.ResetBindings(false);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea anular esta factura?", "Anular", MessageBoxButtons.YesNo);
                if(resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Anular(id);
                }
            }
        }

        private void Anular (int id)
        {
            var resultado = _facturaBL.AnularFactura(id);

            if (resultado == true)
            {
                listaFacturasBindingSource.ResetBindings(false);
            }

            else
            {
                MessageBox.Show("Ocurrio un error al anular la factura");
            }
        }

        private void listaFacturasBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var factura = (Factura)listaFacturasBindingSource.Current;

            if(factura != null && factura.Id != 0 && factura.Activo == false)
            {
                factAnulada.Visible = true;
            }
            else
            {
                factAnulada.Visible = false;
            }
        }
    }
}
