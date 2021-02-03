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
    public partial class MateriaDesktop :ApplicationForm
    {
        public MateriaDesktop()
        {
            InitializeComponent();
        }

        public Materia MateriaActual { get; set; }

        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            this.MapearPlanes();
        }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaLogic materia = new MateriaLogic();
            MateriaActual = materia.GetOne(ID);
            this.MapearDeDatos();
            this.MapearPlanes();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HsSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HsTotales.ToString();
            this.cmbPlan.SelectedItem = this.MateriaActual.IdPlan;
            if (Modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                txtID.Enabled = false;
                txtDescripcion.Enabled = false;
                txtHsSemanales.Enabled = false;
                txtHsTotales.Enabled = false;
                cmbPlan.Enabled = false;
            }
            else
            {
                btnAceptar.Text = "Aceptar";
            }
        }

        public override void MapearADatos() 
        {
            
            if (Modo == ModoForm.Alta)
            {
                Materia MatNueva = new Materia();

                MatNueva.Descripcion = this.txtDescripcion.Text.ToString();
                MatNueva.HsSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
                MatNueva.HsTotales = Convert.ToInt32(this.txtHsTotales.Text);
                MatNueva.IdPlan = Convert.ToInt32(cmbPlan.SelectedValue.ToString());

                MateriaActual = MatNueva;
                MateriaLogic nuevaMat = new MateriaLogic();
                nuevaMat.Save(MateriaActual);

            }

            else if (Modo == ModoForm.Modificacion)
            {

                MateriaActual.Descripcion = this.txtDescripcion.Text.ToString();
                MateriaActual.HsSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
                MateriaActual.HsTotales = Convert.ToInt32(this.txtHsTotales.Text);
                MateriaActual.IdPlan = Convert.ToInt32(cmbPlan.SelectedValue.ToString());

                MateriaLogic nuevaMat = new MateriaLogic();
                nuevaMat.Update(MateriaActual);


            }
            else if (Modo == ModoForm.Baja)
            {
                MateriaActual.Descripcion = "";
                MateriaActual.HsSemanales = 0;
                MateriaActual.HsTotales = 0;
                MateriaActual.IdPlan = 0;
                MateriaLogic nuevaMat = new MateriaLogic();
                nuevaMat.Delete(MateriaActual.ID);
            }
            else
                btnAceptar.Text = "Aceptar";
        }

        public override void GuardarCambios() 
        {
            this.MapearADatos();
            
        }

        public void MapearPlanes()
        {
            MateriaLogic ml = new MateriaLogic();
            cmbPlan.DataSource = ml.GetPlanes();
            cmbPlan.ValueMember = "ID";
            cmbPlan.DisplayMember = "Descripcion";
            if (Modo != ModoForm.Alta)
            {
                cmbPlan.SelectedItem = MateriaActual.IdPlan;

            };
        }

        public override bool Validar() 
        {
            if (this.txtDescripcion.ToString()!="" && this.txtHsSemanales.ToString() != "" && this.txtHsTotales.ToString() != "0" && this.cmbPlan.ToString() != string.Empty && this.txtHsSemanales.ToString() != "0" && this.txtHsTotales.ToString() != "0")
            {
                return true;
            }
            else
            {
                this.Notificar("Error", "Los campos no pueden estar vacío o valer '0'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Materia registrada exitosamente", "Nueva Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Modificacion && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Materia modificada exitosamente", "Modificar Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Baja && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Materia eliminada correctamente", "Eliminar Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MateriaDesktop_Load(object sender, EventArgs e)
        {

        }
    }
}
