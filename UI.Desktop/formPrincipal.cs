using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (formLogin.user.Habilitado == false)
            {
                this.nuevoUsuarioMenuItem.Enabled = false;
                this.nuevaComisionMenuItem.Enabled = false;
                this.nuevaEspecialidadMenuItem.Enabled = false;
                this.nuevaMateriaMenuItem.Enabled = false;
                this.nuevoPlanMenuItem.Enabled = false;
            }

            this.lblUser.Text = this.lblUser.Text + ' ' + formLogin.user.Nombre + ' ' + formLogin.user.Apellido;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lblUser.Hide();
            this.Refresh();

            formLogin frm = new formLogin();

            if (frm.ShowDialog() != DialogResult.OK)

            {
                this.Dispose();
            }
            

            if (formLogin.user.Habilitado == false)
            {
                this.nuevoUsuarioMenuItem.Enabled = false;
                this.nuevaComisionMenuItem.Enabled = false;
                this.nuevaEspecialidadMenuItem.Enabled = false;
                this.nuevaMateriaMenuItem.Enabled = false;
                this.nuevoPlanMenuItem.Enabled = false;
            }
            this.lblUser.Show();
            this.lblUser.Text = "Usuario: " + formLogin.user.Nombre + " " + formLogin.user.Apellido;
            
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
            UsuarioDesktop frm = new UsuarioDesktop();
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
            
            ComisionDesktop frm = new ComisionDesktop();
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
            EspecialidadDesktop frm = new EspecialidadDesktop();
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
            MateriaDesktop frm = new MateriaDesktop();
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
            PlanDesktop frm = new PlanDesktop();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
