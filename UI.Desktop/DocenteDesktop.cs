﻿using Business.Entities;
using Business.Logic;
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
    public partial class DocenteDesktop : ApplicationForm
    {
        public DocenteDesktop()
        {
            InitializeComponent();
        }

        public DocenteCurso DocenteActual { get; set; }

        public DocenteDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public DocenteDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            DocenteCursoLogic docente = new DocenteCursoLogic();
            DocenteActual = docente.GetOne(ID);
            this.MapearDeDatos();
            this.MapearDocentes();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.DocenteActual.ID.ToString();
            this.cmbDocente.SelectedItem = this.DocenteActual.IdDocente;
            this.txtCurso.Text = this.DocenteActual.IdCurso.ToString();
            this.cmbCargo.SelectedItem = this.DocenteActual.Cargo;
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
                cmbDocente.Enabled = false;
                txtCurso.Enabled = false;
                cmbCargo.Enabled = false;
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
                DocenteCurso docNuevo = new DocenteCurso();

                docNuevo.IdCurso = Convert.ToInt32(this.txtCurso.Text);
                docNuevo.IdDocente = Convert.ToInt32(cmbDocente.SelectedValue.ToString());
                if (cmbDocente.SelectedValue.ToString() == "Auxiliar")
                {
                    docNuevo.Cargo = DocenteCurso.TiposCargos.Auxiliar;
                }
                else if (cmbDocente.SelectedValue.ToString() == "Profesor")
                {
                    docNuevo.Cargo = DocenteCurso.TiposCargos.Profesor;
                }

                DocenteActual = docNuevo;
                DocenteCursoLogic nuevoDoc = new DocenteCursoLogic();
                nuevoDoc.Save(DocenteActual);



            }

            else if (Modo == ModoForm.Modificacion)
            {

                DocenteActual.IdCurso = Convert.ToInt32(this.txtCurso.Text);
                DocenteActual.IdDocente = Convert.ToInt32(cmbDocente.SelectedValue.ToString());
                if (cmbDocente.SelectedValue.ToString() == "Auxiliar")
                {
                    DocenteActual.Cargo = DocenteCurso.TiposCargos.Auxiliar;
                }
                else if (cmbDocente.SelectedValue.ToString() == "Profesor")
                {
                    DocenteActual.Cargo = DocenteCurso.TiposCargos.Profesor;
                }

                DocenteCursoLogic nuevoDoc = new DocenteCursoLogic();
                nuevoDoc.Update(DocenteActual);


            }
            else if (Modo == ModoForm.Baja)
            {
                DocenteActual.IdCurso = 0;
                DocenteActual.IdDocente = 0;
                if (cmbDocente.SelectedValue.ToString() == "Auxiliar")
                {
                    DocenteActual.Cargo = DocenteCurso.TiposCargos.Auxiliar;
                }
                else if (cmbDocente.SelectedValue.ToString() == "Profesor")
                {
                    DocenteActual.Cargo = DocenteCurso.TiposCargos.Profesor;
                }

                DocenteCursoLogic nuevoDoc = new DocenteCursoLogic();
                nuevoDoc.Delete(DocenteActual.ID);
            }
            else
                btnAceptar.Text = "Aceptar";
        }

        public void MapearDocentes()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            cmbDocente.DataSource = dcl.GetDocente();
            cmbDocente.ValueMember = "IdDocente";
            cmbDocente.DisplayMember = "Apellido";
            if (Modo != ModoForm.Alta)
            {
                cmbDocente.SelectedValue = DocenteActual.IdDocente;

            };
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();

        }

        public override bool Validar()
        {
            if (this.txtCurso.ToString() != "" && this.txtCurso.ToString() != "0" && this.txtCurso.ToString() != "" && this.cmbCargo.SelectedItem.ToString() != string.Empty && this.cmbDocente.SelectedItem.ToString() != string.Empty)
            {
                return true;
            }
            else
            {
                this.Notificar("Error", "Los campos no pueden estar vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Docente del Curso registrado exitosamente", "Nuevo Docente del Curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Modificacion && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Docente del Curso modificado exitosamente", "Modificar Docente del Curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Baja && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Docente del Curso eliminado correctamente", "Eliminar Docente del Curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                this.GuardarCambios();
                MessageBox.Show("Cambios registrados exitosamente", "Docente del Curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }
    }
}
