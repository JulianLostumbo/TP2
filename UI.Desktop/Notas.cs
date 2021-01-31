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
    public partial class Notas : ApplicationForm
    {
        private Curso _cur;
        public Curso cur
        {
            get { return _cur; }
            set { _cur = value; ; }
        }

        public int idcur { get; set; }

        public Notas(int idcur)
        {
            InitializeComponent(); 
            CursoLogic cl = new CursoLogic();
            cur = cl.GetOne(idcur);
            this.dgvNotas.AutoGenerateColumns = false;
            this.Listar();
        }

        public void Listar()
        {
            idcur = cur.ID;
            InscripcionLogic ins = new InscripcionLogic();
            this.dgvNotas.DataSource = ins.GetAll(idcur);
        }

        private void tbsNota_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvNotas.SelectedRows[0].DataBoundItem).ID;
                NotaDesktop cd = new NotaDesktop(ID);
                cd.ShowDialog();
                this.Listar();
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
