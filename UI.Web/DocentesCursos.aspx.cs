using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class DocentesCursos : System.Web.UI.Page
    {
        #region Enum
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        #endregion

        #region Propiedades
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        DocenteCursoLogic _logic;
        private DocenteCursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new DocenteCursoLogic();
                }
                return _logic;
            }
        }

        public Persona Per { get; set; }

        private DocenteCurso Entity
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

        private bool isEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }
        #endregion

        #region Metodos

        private void LoadGrid()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            this.gridView.DataSource = dcl.GetAll();
            this.gridView.DataBind();
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.IDTextBox.Text = this.Entity.ID.ToString();
            this.idDocente.SelectedValue = this.Entity.IdDocente.ToString();
            this.curso.SelectedValue = this.Entity.IdCurso.ToString();
            this.cargoTextBox.Text = this.Entity.Cargo.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                formPanel.Visible = false; 
                IDTextBox.Enabled = false;
                Per = (Persona)Session["persona"];

                if (Per.TipoPersona != Persona.TipoPersonas.Administrador)
                {
                    nuevoLinkButton.Visible = false;
                    eliminarLinkButton.Visible = false;
                    editarLinkButton.Visible = false;
                    gridView.Enabled = false;
                    gridView.AutoGenerateSelectButton = false;
                }
                this.LoadGrid();
            }
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            this.IDTextBox.Text = string.Empty;
            this.cargoTextBox.Text = string.Empty;

        }

        private void EnableForm(bool enable)
        {
            this.idDocente.Enabled = enable;
            this.curso.Enabled = enable;
            this.cargoTextBox.Enabled = enable;
            this.ddlCargo.Enabled = enable;

        }

        private void LoadEntity(DocenteCurso docentecurso)
        {
            docentecurso.ID = int.Parse(this.IDTextBox.Text);
            docentecurso.IdDocente = int.Parse(this.idDocente.SelectedValue);
            if (this.ddlCargo.SelectedValue.ToString() == "Auxiliar")
            {
                docentecurso.Cargo = DocenteCurso.TiposCargos.Auxiliar;
            }
            else if (this.ddlCargo.SelectedValue.ToString() == "Profesor")
            {
                docentecurso.Cargo = DocenteCurso.TiposCargos.Profesor;
            }
            
            docentecurso.IdCurso = int.Parse(this.curso.SelectedValue);

        }

        private void SaveEntity(DocenteCurso docentecurso)
        {
            this.Logic.Save(docentecurso);
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        #endregion

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:

                    this.DeleteEntity(this.SelectedID);
                    this.formPanel.Visible = false;
                    this.LoadGrid();

                    break;
                case FormModes.Modificacion:
                    this.Entity = new DocenteCurso();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;
                case FormModes.Alta:

                    this.Entity = new DocenteCurso();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;
            }
            this.formPanel.Visible = false;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }
    }
}