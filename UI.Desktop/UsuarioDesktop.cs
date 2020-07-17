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

namespace Academia
{
    public partial class UsuarioDesktop :ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public Usuario UsuarioActual { get; set; }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioLogic usuario = new UsuarioLogic();
            UsuarioActual = usuario.GetOne(ID);
            this.MapearDeDatos();
        }

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
            if (Modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
            }
            else
            {
                btnAceptar.Text = "Aceptar";
            }


        }

        public override void MapearADatos() 
        {
            
            if (Modo == ModoForm.Alta)
            {
                Usuario UsuarioNuevo = new Usuario();


                UsuarioNuevo.Habilitado = this.chkHabilitado.Checked;
                UsuarioNuevo.Nombre = this.txtNombre.Text;
                UsuarioNuevo.Apellido = this.txtApellido.Text;
                UsuarioNuevo.Email = this.txtEmail.Text;
                UsuarioNuevo.Clave = this.txtClave.Text;
                UsuarioNuevo.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual = UsuarioNuevo;
                UsuarioLogic nuevousuario = new UsuarioLogic();
                nuevousuario.Save(UsuarioActual);



            }

            else if (Modo == ModoForm.Modificacion)
            {

                UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.Email = this.txtEmail.Text;
                UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;

                UsuarioLogic nuevousuario = new UsuarioLogic();
                nuevousuario.Update(UsuarioActual);


            }
            else if (Modo == ModoForm.Baja)
            {
                UsuarioActual.Habilitado = false;
                UsuarioActual.Nombre = "";
                UsuarioActual.Apellido = "";
                UsuarioActual.Email = "";
                UsuarioActual.Clave = "";
                UsuarioActual.NombreUsuario = "";
                UsuarioLogic nuevousuario = new UsuarioLogic();
                nuevousuario.Delete(UsuarioActual.ID);
            }
            else
                btnAceptar.Text = "Aceptar";
        }

        public override void GuardarCambios() 
        {
            this.MapearADatos();
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

            if (Modo == ModoForm.Alta && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Usuario registrado exitosamente", "Nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Modificacion && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Usuario modificado exitosamente", "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Baja && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Usuario eliminado correctamente", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                this.GuardarCambios();
                MessageBox.Show("Cambios registrados exitosamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            //if (this.Validar() == true)
            //{
            //    this.GuardarCambios();
            //    MessageBox.Show("Usuario registrado exitosamente", "Nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
