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
    public partial class Inscripcion : ApplicationForm
    {
        public Inscripcion()
        {
            InitializeComponent();
            this.dgvInscripcion.AutoGenerateColumns = false;
            InsLog = new InscripcionLogic();
            this.Listar();
        }

        public InscripcionLogic InsLog { get; set; }

        public void Listar()
        {
            dgvInscripcion.DataSource = InsLog.GetCursosAlumno(formLogin.PersonaActual);
        }

        private void tbsNuevo_Click(object sender, EventArgs e)
        {
            Curso cur = (Curso)dgvInscripcion.SelectedRows[0].DataBoundItem;
            DialogResult = MessageBox.Show("Confirma inscripcion?", "Inscripcion", MessageBoxButtons.OKCancel);
            if (DialogResult == DialogResult.OK)
            {

                AlumnoInscripcion ai = new AlumnoInscripcion();
                ai.Condicion = "Regular";
                ai.IDAlumno = formLogin.PersonaActual.ID;
                ai.IDCurso = cur.ID;
                ai.State = BusinessEntity.States.New;
                InsLog.Save(ai);
                MessageBox.Show("La inscripcion se realizo correctamente");
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

        private void Inscripcion_Load(object sender, EventArgs e)
        {
            if (formLogin.PersonaActual.TipoPersona != Persona.TipoPersonas.Alumno)
            {
                tbsNuevo.Enabled = false;
            }
        }
    }
}
