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
            this.MapearPersonas();
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioLogic usuario = new UsuarioLogic();
            UsuarioActual = usuario.GetOne(ID);
            this.MapearDeDatos();
            this.MapearPersonas();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            //this.txtPass.Text = this.UsuarioActual.Clave.ToString();
            //this.txtRepetirPass.Text = this.UsuarioActual.Clave.ToString();
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
                txtApellido.Enabled = false;
                txtEmail.Enabled = false;
                txtNombre.Enabled = false;
                txtUsuario.Enabled = false;
                chkHabilitado.Enabled = false;
                cmbLegajo.Enabled = false;
            }
            else
            {
                btnAceptar.Text = "Aceptar";
                txtApellido.Enabled = false;
                txtEmail.Enabled = false;
                txtNombre.Enabled = false;
                txtUsuario.Enabled = false;
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
                UsuarioNuevo.Clave = this.txtPass.Text;
                UsuarioNuevo.NombreUsuario = this.txtUsuario.Text; 
                UsuarioNuevo.IdPersona = Convert.ToInt32(this.cmbLegajo.SelectedValue.ToString());
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
                UsuarioActual.Clave = this.txtPass.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual.IdPersona = Convert.ToInt32(this.cmbLegajo.SelectedValue.ToString());
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

        public void MapearPersonas()
        {
            UsuarioLogic ul = new UsuarioLogic();
            cmbLegajo.DataSource = ul.GetPersonas();
            cmbLegajo.ValueMember = "ID";
            cmbLegajo.DisplayMember = "Legajo";
            if (Modo != ModoForm.Alta)
            {
                cmbLegajo.SelectedItem = UsuarioActual.Legajo;
            }
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
                this.cmbLegajo.SelectedItem.ToString() != string.Empty &&
                this.txtEmail.ToString() != "" &&
                this.txtUsuario.ToString() != "" &&
                this.txtPass.ToString() != "" &&
                this.txtPass.ToString().Length >= 8 &&
                this.txtPass.ToString() == this.txtRepetirPass.ToString() &&
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

        private void button1_Click(object sender, EventArgs e)
        {
            PersonaDesktop frm = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            frm.ShowDialog();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
