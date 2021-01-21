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
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
        }

        public PersonaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            this.MapearPlanes();
            this.MapearTipoPersonas();
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PersonaLogic persona = new PersonaLogic();
            formLogin.PersonaActual = persona.GetOne(ID);
            this.MapearDeDatos();
            this.MapearPlanes();
            this.MapearTipoPersonas();

        }

        public void MapearPlanes()
        {
            PersonaLogic pl = new PersonaLogic();
            cmbPlan.DataSource = pl.GetPlanes();
            cmbPlan.ValueMember = "ID";
            cmbPlan.DisplayMember = "Descripcion";
            if (Modo != ModoForm.Alta)
            {
                cmbPlan.SelectedValue = formLogin.PersonaActual.IdPlan;

            };
        }

        public void MapearTipoPersonas()
        {
            cmbTipoPersona.DataSource = Enum.GetValues(typeof(Persona.TipoPersonas));

            if (Modo != ModoForm.Alta)
            {
                cmbTipoPersona.SelectedItem = formLogin.PersonaActual.TipoPersona;

            }

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = formLogin.PersonaActual.ID.ToString();
            this.txtNombre.Text = formLogin.PersonaActual.Nombre;
            this.txtApellido.Text = formLogin.PersonaActual.Apellido;
            this.txtEmail.Text = formLogin.PersonaActual.Email;
            this.txtDireccion.Text = formLogin.PersonaActual.Direccion;
            this.txtLegajo.Text = formLogin.PersonaActual.Legajo.ToString();
            this.txtTelefono.Text = formLogin.PersonaActual.Telefono;
            this.txtFechaNac.Text = formLogin.PersonaActual.FechaNac.ToString();


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
                txtApellido.Enabled = false;
                txtEmail.Enabled = false;
                txtNombre.Enabled = false;
                txtDireccion.Enabled = false;
                txtLegajo.Enabled = false;
                txtTelefono.Enabled = false;
                txtFechaNac.Enabled = false;
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Persona PersonaNueva = new Persona();

                PersonaNueva.Nombre = this.txtNombre.Text;
                PersonaNueva.Apellido = this.txtApellido.Text;
                PersonaNueva.Legajo = int.Parse(this.txtLegajo.Text);
                PersonaNueva.Direccion = this.txtDireccion.Text;
                PersonaNueva.IdPlan = Convert.ToInt32(cmbPlan.SelectedValue.ToString());
                PersonaNueva.TipoPersona = (Persona.TipoPersonas)Enum.Parse(typeof(Persona.TipoPersonas), cmbTipoPersona.SelectedValue.ToString());
                PersonaNueva.Email = this.txtEmail.Text;
                PersonaNueva.FechaNac = Convert.ToDateTime(this.txtFechaNac.Text);
                PersonaNueva.Telefono = this.txtTelefono.Text;
                formLogin.PersonaActual = PersonaNueva;
                PersonaLogic pl = new PersonaLogic();
                PersonaNueva.State = BusinessEntity.States.New;
                pl.Save(PersonaNueva);

            }

            else if (Modo == ModoForm.Modificacion)
            {

                formLogin.PersonaActual.Nombre = this.txtNombre.Text;
                formLogin.PersonaActual.Apellido = this.txtApellido.Text;
                formLogin.PersonaActual.Direccion = this.txtDireccion.Text;
                formLogin.PersonaActual.Legajo = int.Parse(txtLegajo.Text);
                formLogin.PersonaActual.Email = this.txtEmail.Text;
                formLogin.PersonaActual.IdPlan = Convert.ToInt32(cmbPlan.SelectedValue.ToString());
                formLogin.PersonaActual.TipoPersona = (Persona.TipoPersonas)Enum.Parse(typeof(Persona.TipoPersonas), cmbTipoPersona.SelectedValue.ToString());
                formLogin.PersonaActual.FechaNac = Convert.ToDateTime(this.txtFechaNac.Text);
                formLogin.PersonaActual.Telefono = this.txtTelefono.Text;

                PersonaLogic pl = new PersonaLogic();
                formLogin.PersonaActual.State = BusinessEntity.States.Modified;
                pl.Save(formLogin.PersonaActual);


            }
            else if (Modo == ModoForm.Baja)
            {

                PersonaLogic pl = new PersonaLogic();
                formLogin.PersonaActual.State = BusinessEntity.States.Deleted;
                pl.Save(formLogin.PersonaActual);
            }
            else
                btnAceptar.Text = "Aceptar";
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
        }

        public bool Validar(string apellido, string nombre, string email, string direc, string tel, int leg)
        {
            if (apellido.Length != 0 & nombre.Length != 0 & email.Length != 0 & email.Length != 0 & tel.Length != 0 & leg > 0)
            {
                return true;
            }
            else
            {
                this.Notificar("Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string Apellido = this.txtApellido.Text;
            string Nombre = this.txtNombre.Text;
            string Email = this.txtEmail.Text;
            string Telefono = this.txtTelefono.Text;
            string Direccion = this.txtDireccion.Text;
            int Legajo = int.Parse(this.txtLegajo.Text);


            if (Validar(Apellido, Nombre, Email, Direccion, Telefono, Legajo) == true)
            {
                this.GuardarCambios();
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
