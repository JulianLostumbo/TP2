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

        public Persona Entity { get; set; }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PersonaLogic persona = new PersonaLogic();
            Entity = persona.GetOne(ID);
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
            this.txtID.Text = Entity.ID.ToString();
            this.txtNombre.Text = Entity.Nombre;
            this.txtApellido.Text = Entity.Apellido;
            this.txtEmail.Text = Entity.Email;
            this.txtDireccion.Text = Entity.Direccion;
            this.txtLegajo.Text = Entity.Legajo.ToString();
            this.txtTelefono.Text = Entity.Telefono;
            this.txtFechaNac.Text = Entity.FechaNac.ToString();


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
                txtDireccion.Enabled = false;
                txtLegajo.Enabled = false;
                txtTelefono.Enabled = false;
                txtFechaNac.Enabled = false;
                cmbPlan.Enabled = false;
                cmbTipoPersona.Enabled = false;
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
            if (Modo == ModoForm.Alta && this.Validar(Apellido, Nombre, Email, Direccion, Telefono, Legajo) == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Materia registrada exitosamente", "Nueva Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Modificacion && this.Validar(Apellido, Nombre, Email, Direccion, Telefono, Legajo) == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Materia modificada exitosamente", "Modificar Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Baja && this.Validar(Apellido, Nombre, Email, Direccion, Telefono, Legajo) == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Materia eliminada correctamente", "Eliminar Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
