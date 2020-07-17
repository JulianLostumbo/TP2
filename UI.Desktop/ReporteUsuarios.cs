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
    public partial class ReporteUsuarios : Form
    {
        public ReporteUsuarios()
        {
            InitializeComponent();
        }

        private void ReporteUsuarios_Load(object sender, EventArgs e)
        {
            Data.Database.UsuarioAdapter dbu = new Data.Database.UsuarioAdapter();           
            List<Usuario> listaUsuarios = dbu.GetAll();
            
            ReportDataSource rds = new ReportDataSource("ReporteUsuarios", listaUsuarios);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReporteUsuarios.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
        }
    }
}
