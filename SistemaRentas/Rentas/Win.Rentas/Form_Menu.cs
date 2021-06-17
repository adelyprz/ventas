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
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
        }

        private void Login()
        {
            var form_login = new form_login();
            form_login.ShowDialog();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void rentarToolStripMenuItem_Click(object sender, EventArgs e) //Productos
        {
            var Form_Productos = new Form_Productos();
            Form_Productos.MdiParent = this;
            Form_Productos.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Form_Clientes = new Form_Clientes();
            Form_Clientes.MdiParent = this;
            Form_Clientes.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Form_Ventas = new Form_Ventas();
            Form_Ventas.MdiParent = this;
            Form_Ventas.Show();
        }

        private void Form_Menu_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void reporteDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormReporte_Clientes = new FormReporte_Clientes();
            FormReporte_Clientes.MdiParent = this;
            FormReporte_Clientes.Show();
        }

        private void reporteDeRentasToolStripMenuItem_Click(object sender, EventArgs e) //Reporte de Productos
        {
            var FormReporte_Productos = new FormReporte_Productos();
            FormReporte_Productos.MdiParent = this;
            FormReporte_Productos.Show();
        }

        private void reporteDeVentasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var FormReporte_Ventas = new FormReporte_Ventas();
            FormReporte_Ventas.MdiParent = this;
            FormReporte_Ventas.Show();
        }
    }
}
