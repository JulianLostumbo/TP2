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
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        {
            InitializeComponent();
            
        }

        private void formPrincipal_Load(object sender, EventArgs e)
        {
            formLogin frm = new formLogin();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
            else
            {
                Validar(frm.tipoPersona, frm.idAlum);
            }


            this.lblUser.Text = "Usuario: " + formLogin.UsuarioActual.Nombre + "  " + formLogin.UsuarioActual.Apellido;
            this.lblTipo.Text = "Usted ha ingresado como " + formLogin.UsuarioActual.TipoPersona.ToString();

        }

        public void Validar(Persona.TipoPersonas tipoper, int idalum)
        {
            switch (tipoper)
            {

                case Persona.TipoPersonas.Profesor:

                    tsmiComisiones.Visible = false;
                    tsmiDocentes.Visible = false;
                    tsmiEspecialidades.Visible = false;
                    tsmiMaterias.Visible = false;
                    tsmiPlanes.Visible = false;
                    tsmiEstadoAcademico.Visible = false;
                    tsmiUsuarios.Visible = false;
                    tsmiPersonas.Visible = false;
                    tsmiInscripcion.Visible = false;
                    registrarNuevoToolStripMenuItem1.Visible = false;
                    break;
                case Persona.TipoPersonas.Administrador:
                    tsmiInscripcion.Visible = false;
                    tsmiEstadoAcademico.Visible = false;
                    tsmiDatosPersonales.Visible = false;
                    break;
                case Persona.TipoPersonas.Alumno:
                    tsmiComisiones.Visible = false;
                    tsmiDocentes.Visible = false;
                    tsmiEspecialidades.Visible = false;
                    tsmiMaterias.Visible = false;
                    tsmiPlanes.Visible = false;
                    tsmiCursos.Visible = false;
                    tsmiUsuarios.Visible = false;
                    tsmiPersonas.Visible = false;

                    break;
                default:
                    break;
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lblTipo.Hide();
            this.lblUser.Hide();
            this.fechaHoyUserControl1.Hide();
            this.Refresh();

            tsmiUsuarios.Visible = true;
            tsmiPersonas.Visible = true;
            tsmiInscripcion.Visible = true;
            tsmiEstadoAcademico.Visible = true;
            tsmiDatosPersonales.Visible = true;
            tsmiComisiones.Visible = true;
            tsmiDocentes.Visible = true;
            tsmiEspecialidades.Visible = true;
            tsmiMaterias.Visible = true;
            tsmiPlanes.Visible = true;
            tsmiCursos.Visible = true;
            registrarNuevoToolStripMenuItem1.Visible = true;

            formLogin frm = new formLogin();

            if (frm.ShowDialog() != DialogResult.OK)

            {
                this.Dispose();
            }
            else
            {
                Validar(frm.tipoPersona, frm.idAlum);
                this.lblTipo.Show();
                this.lblUser.Show();
                this.fechaHoyUserControl1.Show();

                this.lblTipo.Text = "Usted ha ingresado como " + formLogin.UsuarioActual.TipoPersona.ToString();
                this.lblUser.Text = "Usuario: " + formLogin.UsuarioActual.Nombre + "  " + formLogin.UsuarioActual.Apellido;
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if((MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            Usuarios frm = new Usuarios();
            frm.MdiParent = this;
            frm.Show();

        }

        private void registrarNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioDesktop frm = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            frm.MdiParent = this;
            frm.Show();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Comisiones frm = new Comisiones();
            frm.MdiParent = this;
            frm.Show();
            

        }

        private void registrarNuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ComisionDesktop frm = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            frm.MdiParent = this;
            frm.Show();
        }

        private void listarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Especialidades frm = new Especialidades();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarNuevaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop frm = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            frm.MdiParent = this;
            frm.Show();
        }

        private void listarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Materias frm = new Materias();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarNuevaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MateriaDesktop frm = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            frm.MdiParent = this;
            frm.Show();
        }

        private void listarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Planes frm = new Planes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nuevoPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanDesktop frm = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            frm.MdiParent = this;
            frm.Show();
        }

        private void listadoDeEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarInscripciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inscripcion frm = new Inscripcion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void listarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Personas frm = new Personas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarNuevaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PersonaDesktop frm = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            frm.MdiParent = this;
            frm.Show();
        }

        private void listarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Docentes frm = new Docentes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarNuevoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DocenteDesktop frm = new DocenteDesktop(ApplicationForm.ModoForm.Alta);
            frm.MdiParent = this;
            frm.Show();
        }

        private void listarToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Cursos frm = new Cursos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarNuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CursoDesktop frm = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            frm.MdiParent = this;
            frm.Show();
        }



        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios frm = new Usuarios();
            frm.MdiParent = this;
            frm.Show();
        }

        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas frm = new Personas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiEstadoAcademico_Click(object sender, EventArgs e)
        {
            EstadoAcademico frm = new EstadoAcademico();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
