using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Academia;

namespace UI.Desktop
{
    public partial class FechaHoyUserControl : UserControl
    {
        public FechaHoyUserControl()
        {
            InitializeComponent();
        }

        private void FechaHoyUserControl_Load(object sender, EventArgs e)
        {
            this.lblFecha.Text = "Fecha: " + DateTime.Today.ToString("D");
        }
    }
}
