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
    public partial class Cursos : ApplicationForm
    {
        public Cursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }

        private void tbsNotas_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                Notas not = new Notas(ID);
                not.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbsEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursoDesktop cd = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                cd.ShowDialog();
                this.Listar();
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursoDesktop cd = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                cd.ShowDialog();
                this.Listar();
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbsNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop cd = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            cd.ShowDialog();
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            this.Listar();
            if (formLogin.PersonaActual.TipoPersona != Persona.TipoPersonas.Profesor)
            {
                tbsNotas.Visible = false;
            }
            else if (formLogin.PersonaActual.TipoPersona == Persona.TipoPersonas.Alumno)
            {
                tbsNotas.Visible = false;
                tbsEditar.Visible = false;
                tbsEliminar.Visible = false;
                tbsNuevo.Visible = false;
            }
        }

        public void Listar()
        {
            if (formLogin.PersonaActual.TipoPersona != Persona.TipoPersonas.Profesor)
            {
                DocenteCursoLogic dc = new DocenteCursoLogic();
                dc.GetCursosDocente(formLogin.PersonaActual.ID);

            }
            else
            {
                CursoLogic cl = new CursoLogic();
                this.dgvCursos.DataSource = cl.GetAll();
            }
        }

        private void tbsImprimir_Click(object sender, EventArgs e)
        {
            ReporteCursos frm = new ReporteCursos();
            frm.ShowDialog();
        }
    }
}
