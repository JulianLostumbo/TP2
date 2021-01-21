using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace Academia
{
    public partial class NotaDesktop : Form
    {
        public AlumnoInscripcion AlumAct { get; set; }

        public NotaDesktop(int id)
        {
            InitializeComponent();
            InscripcionLogic ins = new InscripcionLogic();
            AlumAct = ins.GetOne(id);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtNota.Text) > 0 && int.Parse(txtNota.Text) <= 10)
            {
                AlumAct.Nota = int.Parse(txtNota.Text);
                if (int.Parse(txtNota.Text) >= 6)
                {
                    AlumAct.Condicion = "Aprobado";
                }
                else
                {
                    AlumAct.Condicion = "Desaprobado";
                }
                AlumAct.State = BusinessEntity.States.Modified;
                InscripcionLogic ins = new InscripcionLogic();
                ins.Save(AlumAct);
                MessageBox.Show("La nota fue subida correctamente", "Nota", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
