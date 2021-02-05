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
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            if (formLogin.PersonaActual.TipoPersona!=Persona.TipoPersonas.Administrador)
            {
                this.txtPass.Text = this.UsuarioActual.Clave.ToString();
            }
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
                cmbPersona.Enabled = false;
                txtUsuario.Enabled = false;
                chkHabilitado.Enabled = false;
            }
            else
            {
                btnAceptar.Text = "Aceptar";
                cmbPersona.Enabled = false;
                txtUsuario.Enabled = false;
            }


        }

        public override void MapearADatos() 
        {
            
            if (Modo == ModoForm.Alta)
            {
                Usuario UsuarioNuevo = new Usuario();
                UsuarioNuevo.Habilitado = this.chkHabilitado.Checked;
                UsuarioNuevo.Nombre = ((Persona)(this.cmbPersona.SelectedItem)).Nombre;
                UsuarioNuevo.Apellido = ((Persona)(this.cmbPersona.SelectedItem)).Apellido;
                UsuarioNuevo.Legajo = ((Persona)(this.cmbPersona.SelectedItem)).Legajo;
                UsuarioNuevo.IdPersona = ((Persona)(this.cmbPersona.SelectedItem)).ID;
                UsuarioNuevo.Email = ((Persona)(this.cmbPersona.SelectedItem)).Email;
                UsuarioNuevo.Clave = this.txtPass.Text;
                UsuarioNuevo.NombreUsuario = this.txtUsuario.Text; 
                UsuarioActual = UsuarioNuevo;
                UsuarioLogic nuevousuario = new UsuarioLogic();
                nuevousuario.Save(UsuarioActual);
            }

            else if (Modo == ModoForm.Modificacion)
            {

                UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                UsuarioActual.Nombre = ((Persona)(this.cmbPersona.SelectedItem)).Nombre;
                UsuarioActual.Apellido = ((Persona)(this.cmbPersona.SelectedItem)).Apellido;
                UsuarioActual.Legajo = ((Persona)(this.cmbPersona.SelectedItem)).Legajo;
                UsuarioActual.Email = ((Persona)(this.cmbPersona.SelectedItem)).Email;
                UsuarioActual.Clave = this.txtPass.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual.IdPersona = ((Persona)(this.cmbPersona.SelectedItem)).ID;
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
            PersonaLogic pl = new PersonaLogic();
            cmbPersona.DataSource = pl.GetAll();
            cmbPersona.ValueMember = "ID";
            cmbPersona.DisplayMember = "NomApe";
            if (Modo != ModoForm.Alta)
            {
                Persona Per = pl.GetOne(UsuarioActual.IdPersona);
                cmbPersona.SelectedValue = Per.ID;
            }
        }

        public override void GuardarCambios() 
        {
            this.MapearADatos();
        }

        public override bool Validar() 
        {
            if (
                ((Modo == ApplicationForm.ModoForm.Alta && this.txtUsuario.Text.ToString() != "") | 
                (Modo != ApplicationForm.ModoForm.Alta &&
                formLogin.PersonaActual.TipoPersona == Persona.TipoPersonas.Administrador &&
                UsuarioActual.Clave == this.txtPass.Text.ToString()) |
                (Modo != ApplicationForm.ModoForm.Alta &&
                formLogin.PersonaActual.TipoPersona != Persona.TipoPersonas.Administrador)) &
                this.txtPass.Text.ToString() != "" &
                this.txtRepetirPass.Text.ToString()!="" &
                this.txtPass.Text.ToString().Length >= 8 &
                this.txtPass.Text.ToString() == this.txtRepetirPass.Text.ToString())
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

            if (Validar())
            {
                if (Modo == ModoForm.Alta)
                {
                    this.GuardarCambios();
                    MessageBox.Show("Usuario registrado exitosamente", "Nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (Modo == ModoForm.Modificacion)
                {
                    this.GuardarCambios();
                    MessageBox.Show("Usuario modificado exitosamente", "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (Modo == ModoForm.Baja)
                {
                    this.GuardarCambios();
                    MessageBox.Show("Usuario eliminado correctamente", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

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

        private void chkClave_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClave.Checked == false)
            {
                txtPass.PasswordChar = '*';
            }
            else
            {
                txtPass.PasswordChar = '\0';
            }
        }

        private void chkConfirmarClave_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConfirmarClave.Checked == false)
            {
                txtRepetirPass.PasswordChar = '*';
            }
            else
            {
                txtRepetirPass.PasswordChar = '\0';
            }
        }
    }
}
