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
    public partial class form_login : Form
    {
        SeguridadBL _seguridad;
        

        public form_login()
        {
            InitializeComponent();

            _seguridad = new SeguridadBL();
        }

        private void form_login_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario;
            string contrasena;

            usuario = textUser.Text;
            contrasena = textPassword.Text;

            var resultado = _seguridad.Autorizacion(usuario, contrasena);

            if (resultado == true)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
        }
    }
}
