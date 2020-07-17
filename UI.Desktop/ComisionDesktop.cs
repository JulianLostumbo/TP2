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
    public partial class ComisionDesktop :ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public Comision ComisionActual { get; set; }

        public ComisionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ComisionLogic comision = new ComisionLogic();
            ComisionActual = comision.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtIdPlan.Text = this.ComisionActual.IdPlan.ToString();
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
                Comision ComNueva = new Comision();

                ComNueva.Descripcion = this.txtDescripcion.Text.ToString();
                ComNueva.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text);
                ComNueva.IdPlan = Convert.ToInt32(this.txtIdPlan.Text);

                ComisionActual = ComNueva;
                ComisionLogic nuevaCom = new ComisionLogic();
                nuevaCom.Save(ComisionActual);



            }

            else if (Modo == ModoForm.Modificacion)
            {

                ComisionActual.Descripcion = this.txtDescripcion.Text.ToString();
                ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text);
                ComisionActual.IdPlan = Convert.ToInt32(this.txtIdPlan.Text);

                ComisionLogic nuevaCom = new ComisionLogic();
                nuevaCom.Update(ComisionActual);


            }
            else if (Modo == ModoForm.Baja)
            {
                ComisionActual.Descripcion = "";
                ComisionActual.AnioEspecialidad = 0;
                ComisionActual.IdPlan = 0;
                ComisionLogic nuevaCom = new ComisionLogic();
                nuevaCom.Delete(ComisionActual.ID);
            }
            else
                btnAceptar.Text = "Aceptar";
        }

        public override void GuardarCambios() 
        {
            this.MapearADatos();
            
        }

        public override bool Validar() 
        {
            if (this.txtDescripcion.ToString() != "" && this.txtAnioEspecialidad.ToString() != "" && this.txtIdPlan.ToString() != "0"  && this.txtAnioEspecialidad.ToString() != "0" && this.txtIdPlan.ToString() != "0" )
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
                MessageBox.Show("Comisión registrada exitosamente", "Nueva Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Modificacion && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Comisión modificada exitosamente", "Modificar Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Baja && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Comisión eliminada correctamente", "Eliminar Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                this.GuardarCambios();
                MessageBox.Show("Cambios registrados exitosamente", "Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
