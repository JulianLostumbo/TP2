﻿using System;
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
            this.MapearPlanes();
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ComisionLogic comision = new ComisionLogic();
            ComisionActual = comision.GetOne(ID);
            this.MapearDeDatos();
            this.MapearPlanes();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
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
                txtAnioEspecialidad.Enabled = false;
                cmbPlanes.Enabled = false;
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
                ComNueva.IdPlan = Convert.ToInt32(cmbPlanes.SelectedValue.ToString());

                ComisionActual = ComNueva;
                ComisionLogic nuevaCom = new ComisionLogic();
                nuevaCom.Save(ComisionActual);



            }

            else if (Modo == ModoForm.Modificacion)
            {

                ComisionActual.Descripcion = this.txtDescripcion.Text.ToString();
                ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text);
                ComisionActual.IdPlan = Convert.ToInt32(cmbPlanes.SelectedValue.ToString());

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

        public void MapearPlanes()
        {
            ComisionLogic cl = new ComisionLogic();
            cmbPlanes.DataSource = cl.GetPlanes();
            cmbPlanes.ValueMember = "ID";
            cmbPlanes.DisplayMember = "Descripcion";
            if (Modo != ModoForm.Alta)
            {
                cmbPlanes.SelectedValue= ComisionActual.IdPlan;

            };
        }

        public override void GuardarCambios() 
        {
            this.MapearADatos();
            
        }

        public override bool Validar() 
        {
            if (this.txtDescripcion.Text.ToString() != "" && this.txtAnioEspecialidad.Text.ToString() != "" && this.cmbPlanes.SelectedItem.ToString() != string.Empty  && this.txtAnioEspecialidad.Text.ToString() != "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar() == false)
            {
                this.Notificar("Error", "Los campos no pueden estar vacío o valer '0'", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Modo == ModoForm.Alta && this.Validar() == true)
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

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
        }
    }
}
