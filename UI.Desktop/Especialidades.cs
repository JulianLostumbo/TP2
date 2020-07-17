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
    public partial class Especialidades : ApplicationForm
    {
        public Especialidades()
        {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
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
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvEspecialidades.SelectedRows != null)
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                //formEspecialidad.MapearADatos();
                formEspecialidad.ShowDialog();
                this.Listar();
            }

        }

        private void tbsEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvEspecialidades.SelectedRows != null)
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
                formEspecialidad.ShowDialog();
                this.Listar();
            }
            
        }

        private void Especialidad_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
