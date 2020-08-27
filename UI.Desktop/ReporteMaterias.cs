using Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Academia
{
    public partial class ReporteMaterias : Form
    {
        public ReporteMaterias()
        {
            InitializeComponent();
        }

        private void ReporteMaterias_Load(object sender, EventArgs e)
        {
            Data.Database.MateriaAdapter dbu = new Data.Database.MateriaAdapter();
            List<Materia> listaMaterias = dbu.GetAll();

            ReportDataSource rds = new ReportDataSource("DataSetMaterias", listaMaterias);
            this.reportViewer1.LocalReport.ReportPath = @"C:\Net\TP2_Academia\UI.Desktop\ReporteMaterias.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();

            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
        }
    }
}
