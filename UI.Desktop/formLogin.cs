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

        //private Usuario _UsAct;
        //public Usuario UsuarioActual
        //{
        //    get { return _UsAct; }
        //    set { _UsAct = value; }
        //}

        //private Persona _PerAct;
        //public Persona PersonaActual
        //{
        //    get { return _PerAct; }
        //    set { _PerAct = value; }
        //}

        public static Persona PersonaActual;

        public static Usuario UsuarioActual;

        private Persona.TipoPersonas tipoper;

        public Persona.TipoPersonas tipoPersona
        {
            get { return tipoper; }
            set { tipoper = value; }
        }

        private int _idAlum;

        public int idAlum
        {
            get { return _idAlum; }
            set { _idAlum = value; }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUser = this.txtUsuario.Text;
            string claveUser = this.txtPass.Text;

            UsuarioLogic BuscarUser = new UsuarioLogic();
            /*Usuario user = new Usuario();*/
            UsuarioActual = BuscarUser.GetOne(nombreUser, claveUser);

            if (nombreUser == UsuarioActual.NombreUsuario && claveUser == UsuarioActual.Clave)
            {
                PersonaLogic BuscarPersona = new PersonaLogic();
                /*Persona PersonaActual = new Persona();*/
                PersonaActual = BuscarPersona.GetOne(UsuarioActual.IdPersona);
                idAlum = PersonaActual.ID;
                tipoPersona = PersonaActual.TipoPersona;
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

        private void cbContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (cbContraseña.Checked == false)
            {
                txtPass.PasswordChar = '*';
            }
            else
            {
                txtPass.PasswordChar = '\0';
            }

        }
    }
}
