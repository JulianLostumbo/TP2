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
                cmbPlan.SelectedValue = Entity.IdPlan;

            };
        }

        public void MapearTipoPersonas()
        {
            cmbTipoPersona.DataSource = Enum.GetValues(typeof(Persona.TipoPersonas));

            if (Modo != ModoForm.Alta)
            {
                cmbTipoPersona.SelectedItem = Entity.TipoPersona;

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
                Entity = PersonaNueva;
                PersonaLogic pl = new PersonaLogic();
                PersonaNueva.State = BusinessEntity.States.New;
                pl.Save(PersonaNueva);

            }

            else if (Modo == ModoForm.Modificacion)
            {

                Entity.Nombre = this.txtNombre.Text;
                Entity.Apellido = this.txtApellido.Text;
                Entity.Direccion = this.txtDireccion.Text;
                Entity.Legajo = int.Parse(txtLegajo.Text);
                Entity.Email = this.txtEmail.Text;
                Entity.IdPlan = Convert.ToInt32(cmbPlan.SelectedValue.ToString());
                Entity.TipoPersona = (Persona.TipoPersonas)Enum.Parse(typeof(Persona.TipoPersonas), cmbTipoPersona.SelectedValue.ToString());
                Entity.FechaNac = Convert.ToDateTime(this.txtFechaNac.Text);
                Entity.Telefono = this.txtTelefono.Text;

                PersonaLogic pl = new PersonaLogic();
                Entity.State = BusinessEntity.States.Modified;
                pl.Save(Entity);


            }
            else if (Modo == ModoForm.Baja)
            {

                PersonaLogic pl = new PersonaLogic();
                Entity.State = BusinessEntity.States.Deleted;
                pl.Save(Entity);
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
            if (this.txtApellido.Text.ToString()!="" & this.txtNombre.Text.ToString() != "" & this.txtEmail.Text.ToString() != "" & this.txtEmail.Text.ToString().Contains("@") & this.txtFechaNac.Text.ToString() != "" &
                (this.txtEmail.Text.ToString().Contains(".com") || this.txtEmail.Text.ToString().Contains(".com.ar")) & this.txtDireccion.Text.ToString() != "" & this.txtTelefono.Text.ToString() != "" & int.Parse(this.txtLegajo.Text.ToString()) > 0 & this.txtLegajo.Text.ToString() != "")
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
            if (Modo == ModoForm.Alta && this.Validar())
            {
                this.GuardarCambios();
                MessageBox.Show("Materia registrada exitosamente", "Nueva Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Modificacion && this.Validar())              
            {
                this.GuardarCambios();
                MessageBox.Show("Materia modificada exitosamente", "Modificar Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Baja && this.Validar())
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
