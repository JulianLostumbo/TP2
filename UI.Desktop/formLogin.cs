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
using Business.Logic;

namespace Academia
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        public static Usuario user;

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUser = this.txtUsuario.Text;
            string claveUser = this.txtPass.Text;

            UsuarioLogic BuscarUser = new UsuarioLogic();
            user = BuscarUser.GetOne(nombreUser, claveUser);

            if (nombreUser == user.NombreUsuario && claveUser == user.Clave)
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
