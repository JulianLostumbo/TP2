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
using Business.Logic;
using Business.Entities;

namespace Academia
{
    public partial class ReportePlanes : Form
    {
        public ReportePlanes()
        {
            InitializeComponent();
        }

        private void ReportePlanes_Load(object sender, EventArgs e)
        {
            PlanLogic logic = new PlanLogic();
            List<Plan> listaPlanes = logic.GetAll();

            ReportDataSource rds = new ReportDataSource("DataSetPlanes", listaPlanes);
            this.reportViewer1.LocalReport.ReportPath = @"C:\Net\TP2_Academia\UI.Desktop\ReportePlanes.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();

            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
        }
    }
}
