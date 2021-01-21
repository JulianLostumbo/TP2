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
    public partial class PlanDesktop :ApplicationForm
    {
        public PlanDesktop()
        {
            InitializeComponent();
        }

        public Plan PlanActual { get; set; }

        public PlanDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PlanLogic plan = new PlanLogic();
            PlanActual = plan.GetOne(ID);
            this.MapearDeDatos();
            this.MapearEspecialidades();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.cmbEspecialidad.SelectedItem = this.PlanActual.IdEspecialidad.ToString();
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
                Plan planNuevo = new Plan();

                planNuevo.Descripcion = this.txtDescripcion.Text.ToString();
                planNuevo.IdEspecialidad = Convert.ToInt32(this.cmbEspecialidad.SelectedValue.ToString());

                PlanActual = planNuevo;
                PlanLogic nuevoPlan = new PlanLogic();
                nuevoPlan.Save(PlanActual);



            }

            else if (Modo == ModoForm.Modificacion)
            {

                PlanActual.Descripcion = this.txtDescripcion.Text.ToString();
                PlanActual.IdEspecialidad = Convert.ToInt32(this.cmbEspecialidad.SelectedValue.ToString());

                PlanLogic nuevoPlan = new PlanLogic();
                nuevoPlan.Update(PlanActual);


            }
            else if (Modo == ModoForm.Baja)
            {
                PlanActual.Descripcion = "";
                PlanActual.IdEspecialidad = 0;
                PlanLogic nuevoPlan = new PlanLogic();
                nuevoPlan.Delete(PlanActual.ID);
            }
            else
                btnAceptar.Text = "Aceptar";
        }

        public void MapearEspecialidades()
        {
            PlanLogic p1 = new PlanLogic();
            cmbEspecialidad.DataSource = p1.GetEspecialidad();
            cmbEspecialidad.ValueMember = "ID";
            cmbEspecialidad.DisplayMember = "Descripcion";
            if (Modo != ModoForm.Alta)
            {
                cmbEspecialidad.SelectedValue = PlanActual.IdEspecialidad;
            }
        }

        public override void GuardarCambios() 
        {
            this.MapearADatos();
            
        }

        public override bool Validar() 
        {
            if (this.txtDescripcion.ToString()!="" && this.cmbEspecialidad.SelectedItem.ToString() != string.Empty)
            {
                return true;
            }
            else
            {
                this.Notificar("Error", "Los campos no puede estar vacío o con valor '0' ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Plan registrado exitosamente", "Nuevo Plan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Modificacion && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Plan modificado exitosamente", "Modificar Plan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Baja && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Plan eliminado correctamente", "Eliminar Plan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                this.GuardarCambios();
                MessageBox.Show("Cambios registrados exitosamente", "Plan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
