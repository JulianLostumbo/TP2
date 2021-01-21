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
    public partial class Comisiones : ApplicationForm
    {
        public Comisiones()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
            /*if (formLogin.UsuarioActual.Habilitado == false)
            {
                this.tbsEditar.Enabled = false;
                this.tbsEliminar.Enabled = false;
                this.tbsNuevo.Enabled = false;
                this.dgvComisiones.Enabled = false;
            }*/
        }

        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            this.dgvComisiones.DataSource = cl.GetAll();
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
            ComisionDesktop formComision = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows != null)
            {
                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                //formComision.MapearADatos();
                formComision.ShowDialog();
                this.Listar();
            }

        }

        private void tbsEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows != null)
            {
                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
                formComision.ShowDialog();
                this.Listar();
            }
            
        }
        
        private void Comision_Load(object sender, EventArgs e)
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
