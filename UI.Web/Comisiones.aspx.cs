using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Comisiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Usuario user = (Usuario)Session["usuario"];
                if (user.Habilitado == false)
                {
                    //editarLinkButton.Enabled = false;
                    //nuevoLinkButton.Enabled = false;
                    //eliminarLinkButton.Enabled = false;
                    editarLinkButton.Visible = false;
                    nuevoLinkButton.Visible = false;
                    eliminarLinkButton.Visible = false;
                    gridView.Enabled = false;
                    gridView.AutoGenerateSelectButton = false;

                }
                this.LoadGrid();
            }
        }

        ComisionLogic _Logic;
        private ComisionLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new ComisionLogic();
                }
                return _Logic;
            }
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set
            {
                this.ViewState["FormMode"] = value;
            }
        }

        private Comision Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {

            this.Entity = this.Logic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.anioEspecialidadTextBox.Text = Convert.ToString(this.Entity.AnioEspecialidad);
            this.idPlanTextBox.Text = Convert.ToString(this.Entity.IdPlan);
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            this.EnableForm(true);
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }

        }

        private void LoadEntity(Comision comision)
        {
            comision.Descripcion = this.descripcionTextBox.Text;
            comision.AnioEspecialidad = Convert.ToInt32(this.anioEspecialidadTextBox.Text);
            comision.IdPlan = Convert.ToInt32(this.idPlanTextBox.Text);

        }

        private void SaveEntity(Comision comision)
        {
            this.Logic.Save(comision);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Comision();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Comision();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.anioEspecialidadTextBox.Enabled = enable;
            this.idPlanTextBox.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.anioEspecialidadTextBox.Text = string.Empty;
            this.idPlanTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {

            this.formPanel.Visible = false;
            this.ClearForm();
            this.LoadGrid();


        }
    }
}