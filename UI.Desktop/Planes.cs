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
    public partial class Planes : ApplicationForm
    {
        public Planes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
            /*if (formLogin.UsuarioActual.Habilitado == false)
            {
                this.tbsEditar.Enabled = false;
                this.tbsEliminar.Enabled = false;
                this.tbsNuevo.Enabled = false;
                this.dgvPlanes.Enabled = false;
            }*/
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.DataSource = pl.GetAll();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbsNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows != null)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                //formPlan.MapearADatos();
                formPlan.ShowDialog();
                this.Listar();
            }

        }

        private void tbsEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows != null)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPlan.ShowDialog();
                this.Listar();
            }
            
        }

        private void Especialidad_Load(object sender, EventArgs e)
        {
            Listar();
            if (formLogin.PersonaActual.TipoPersona != Persona.TipoPersonas.Administrador)
            {
                tbsEditar.Enabled = false;
                tbsEliminar.Enabled = false;
                tbsNuevo.Enabled = false;
            }
        }

        private void tbsImprimir_Click(object sender, EventArgs e)
        {
            ReportePlanes frm = new ReportePlanes();
            frm.ShowDialog();
        }
    }
}
