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
    public partial class EspecialidadDesktop :ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public Especialidad EspecialidadActual { get; set; }

        public EspecialidadDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            EspecialidadLogic especialidad = new EspecialidadLogic();
            EspecialidadActual = especialidad.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
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
                this.txtDescripcion.Enabled = false;
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
                Especialidad EspNueva = new Especialidad();

                EspNueva.Descripcion = this.txtDescripcion.Text.ToString();
                
                EspecialidadActual = EspNueva;
                EspecialidadLogic nuevaEsp = new EspecialidadLogic();
                nuevaEsp.Save(EspecialidadActual);



            }

            else if (Modo == ModoForm.Modificacion)
            {

                EspecialidadActual.Descripcion = this.txtDescripcion.Text.ToString();

                EspecialidadLogic nuevaEsp = new EspecialidadLogic();
                nuevaEsp.Update(EspecialidadActual);


            }
            else if (Modo == ModoForm.Baja)
            {
                EspecialidadActual.Descripcion = "";
                EspecialidadLogic nuevaEsp = new EspecialidadLogic();
                nuevaEsp.Delete(EspecialidadActual.ID);
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
            if (this.txtDescripcion.ToString()!="")
            {
                return true;
            }
            else
            {
                this.Notificar("Error", "El campo Descripcion no puede estar vacío ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Especialidad registrada exitosamente", "Nueva Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Modificacion && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Especialidad modificada exitosamente", "Modificar Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Baja && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Especialidad eliminada correctamente", "Eliminar Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
