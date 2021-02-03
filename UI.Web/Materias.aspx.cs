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
    public partial class Materias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
            
                Per = (Persona)Session["persona"];
                IDTextBox.Enabled = false;
                formPanel.Visible = false;
                if (Per.TipoPersona != Persona.TipoPersonas.Administrador)
                {
                    nuevoLinkButton.Visible = false;
                    eliminarLinkButton.Visible = false;
                    editarLinkButton.Visible = false;
                    imprimirLinkButton.Visible = false;
                    gridView.Enabled = false;
                    gridView.AutoGenerateSelectButton = false;
                }
                this.LoadGrid();
            }
        }

        MateriaLogic _Logic;
        private MateriaLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new MateriaLogic();
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

        public Persona Per { get; set; }

        private Materia Entity
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
            MateriaLogic ml = new MateriaLogic();
            this.gridView.DataSource = ml.GetAll();
            this.gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {

            this.Entity = this.Logic.GetOne(id);
            this.IDTextBox.Text = this.Entity.ID.ToString();
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.hsSemanalesTextBox.Text = Convert.ToString(this.Entity.HsSemanales);
            this.hsTotalesTextBox.Text = Convert.ToString(this.Entity.HsTotales);
            this.idplan.SelectedValue = this.Entity.IdPlan.ToString();
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

        private void LoadEntity(Materia materia)
        {
            materia.ID = int.Parse(this.IDTextBox.Text);
            materia.Descripcion = this.descripcionTextBox.Text;
            materia.HsSemanales = Convert.ToInt32(this.hsSemanalesTextBox.Text);
            materia.HsTotales = Convert.ToInt32(this.hsTotalesTextBox.Text);
            materia.IdPlan = int.Parse(this.idplan.SelectedValue);

        }

        private void SaveEntity(Materia materia)
        {
            this.Logic.Save(materia);
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
                    this.Entity = new Materia();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Materia();
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
            this.hsSemanalesTextBox.Enabled = enable;
            this.hsTotalesTextBox.Enabled = enable;
            this.idplan.Enabled = enable;
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
            this.IDTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
            this.hsSemanalesTextBox.Text = string.Empty;
            this.hsTotalesTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {

            this.formPanel.Visible = false;
            this.ClearForm();
            this.LoadGrid();


        }

        protected void imprimirLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportMaterias.aspx");
        }

    
    }
}