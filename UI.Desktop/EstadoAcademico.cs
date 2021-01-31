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

namespace Academia
{
    public partial class EstadoAcademico : Form
    {

        public EstadoAcademico()
        {
            InitializeComponent();
            this.dgvEstado.AutoGenerateColumns = false;
            this.Listar();
        }

        public void Listar()
        {
            InscripcionLogic ins = new InscripcionLogic();
            this.dgvEstado.DataSource = ins.GetEstadoAcademico(formLogin.PersonaActual.ID);
        }



        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
