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
    public partial class Materias : ApplicationForm
    {
        public Materias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
            if (formLogin.user.Habilitado == false)
            {
                this.tbsEditar.Enabled = false;
                this.tbsEliminar.Enabled = false;
                this.tbsNuevo.Enabled = false;
            }
        }

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.DataSource = ml.GetAll();
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
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows != null)
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                //formMateria.MapearADatos();
                formMateria.ShowDialog();
                this.Listar();
            }

        }

        private void tbsEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows != null)
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formMateria.ShowDialog();
                this.Listar();
            }
            
        }
        

        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void tbsImprimir_Click(object sender, EventArgs e)
        {
            ReporteMaterias frm = new ReporteMaterias();
            frm.ShowDialog();
        }
    }
}
