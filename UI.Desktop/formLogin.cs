using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Business.Entities;
using System.Data.Common;
using Data.Database;

namespace Academia
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUser = this.txtUsuario.Text;
            string claveUser = this.txtPass.Text;

            UsuarioAdapter BuscarUser = new UsuarioAdapter();
            Usuario usuario = BuscarUser.GetOne(nombreUser, claveUser);

            if (nombreUser == usuario.NombreUsuario && claveUser == usuario.Clave)
            {
               this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",

            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


    }
}
