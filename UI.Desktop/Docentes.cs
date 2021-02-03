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
    public partial class Docentes : ApplicationForm
    {
        public Docentes()
        {
            InitializeComponent();
            this.dgvDocentes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            DocenteCursoLogic cl = new DocenteCursoLogic();
            this.dgvDocentes.DataSource = cl.GetAll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DocenteDesktop formComision = new DocenteDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentes.SelectedRows != null)
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                DocenteDesktop formComision = new DocenteDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formComision.ShowDialog();
                this.Listar();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentes.SelectedRows != null)
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                DocenteDesktop formComision = new DocenteDesktop(ID, ApplicationForm.ModoForm.Baja);
                formComision.ShowDialog();
                this.Listar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Docentes_Load(object sender, EventArgs e)
        {
            Listar();
            if (formLogin.PersonaActual.TipoPersona != Persona.TipoPersonas.Administrador)
            {
                tbsEditar.Enabled = false;
                tbsEliminar.Enabled = false;
                tbsNuevo.Enabled = false;
            }
        }
    }
}
