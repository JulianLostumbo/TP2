using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace WindowsFormsApp1
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public Usuario UsuarioActual { get; set; }

        public UsuarioDesktop(ModoForm modo) : this() { }

        public UsuarioDesktop(int ID, ModoForm modo) : this() { }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave.ToString();
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave.ToString();
        }        

        public override void MapearADatos() 
        {   
            if ( this.Modo  == ModoForm.Alta)
            {
                Usuario UsuarioActual1 = new Usuario();
                if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
                {
                    UsuarioActual.Nombre = this.txtNombre.Text;
                    UsuarioActual.Apellido = this.txtApellido.Text;
                    UsuarioActual.Email = this.txtEmail.ToString();
                    UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                    UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                    UsuarioActual.Clave = this.txtClave.ToString();

                }
                if (this.Modo == ModoForm.Alta) 
                { 
                    UsuarioActual.State = Usuario.States.New; 
                }
                else if (this.Modo == ModoForm.Baja) 
                { 
                    UsuarioActual.State = Usuario.States.Deleted; 
                }
                else if (this.Modo == ModoForm.Modificacion) 
                { 
                    UsuarioActual.State = Usuario.States.Modified; 
                }
                else
                {
                    UsuarioActual.State = Usuario.States.Unmodified;
                }
            }
        }

        public override void GuardarCambios() 
        {
            this.MapearADatos();
            UsuarioLogic nuevoUsuario = new UsuarioLogic();
            nuevoUsuario.Save(UsuarioActual);
        }

        public override bool Validar() 
        {
            if (this.txtNombre.ToString() != "" &&
                this.txtApellido.ToString() != "" &&
                this.txtNombre.ToString() != "" &&
                this.txtEmail.ToString() != "" &&
                this.txtUsuario.ToString() != "" &&
                this.txtClave.ToString() != "" &&
                this.txtClave.ToString().Length >= 8 &&
                this.txtClave.ToString() == this.txtConfirmarClave.ToString() &&
                this.txtEmail.ToString().Contains("@") &&
                (this.txtEmail.ToString().Contains(".com") || this.txtEmail.ToString().Contains(".com.ar")))
            {
                return true;
            }
            else
            {
                this.Notificar("Error", "Campo/s introducidos inválidos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar() == true)
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
