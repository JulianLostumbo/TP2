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
    public partial class Usuarios : ApplicationForm
    {
        public Usuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
            
        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            if (formLogin.PersonaActual.TipoPersona == Persona.TipoPersonas.Administrador)
            {

                this.dgvUsuarios.DataSource = ul.GetAll();
            }
            else
            {
                tbsEliminar.Visible = false;
                tbsNuevo.Visible = false;
                tbsImprimir.Visible = false;
                this.dgvUsuarios.DataSource = ul.GetAll(formLogin.UsuarioActual.ID);
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
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

        private void tbsNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows != null)
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formUsuario.ShowDialog();
                this.Listar();
            }

        }

        private void tbsEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows != null)
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                formUsuario.ShowDialog();
                this.Listar();
            }
            
        }

        private void tbsImprimir_Click(object sender, EventArgs e)
        {
            ReporteUsuarios frm = new ReporteUsuarios();
            frm.ShowDialog();
        }
    }
}
