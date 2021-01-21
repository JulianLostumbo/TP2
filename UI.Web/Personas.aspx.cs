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
    public partial class Personas : System.Web.UI.Page
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


        PersonaLogic _logic;
        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }

        private Persona Entity
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
        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.IDTextBox.Text = this.Entity.ID.ToString();
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.emailTextBox.Text = this.Entity.Email;
            this.telefonoTextBox.Text = this.Entity.Telefono;
            this.fechaNacTextBox.Text = this.Entity.FechaNac.ToString();
            this.idplan.SelectedValue = this.Entity.IdPlan.ToString();
            this.tipoper.SelectedValue = this.Entity.TipoPersona.ToString();
            this.direccionTextBox.Text = this.Entity.Direccion;
            this.nroLegajoTextBox.Text = this.Entity.Legajo.ToString();

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                Entity = (Persona)Session["persona"];
                formPanel.Visible = false;
                if (Entity.TipoPersona != Persona.TipoPersonas.Administrador)
                {
                    nuevoLinkButton.Visible = false;
                    eliminarLinkButton.Visible = false;
                }
                this.LoadGrid();
            }
        }

        private void LoadGrid()
        {
            PersonaLogic pl = new PersonaLogic();
            if (Entity.TipoPersona != Persona.TipoPersonas.Administrador)
            {
                this.gridView.DataSource = pl.GetAll(Entity.ID);
            }
            else
            {
                this.gridView.DataSource = this.Logic.GetAll();
            }
            this.gridView.DataBind();
        }


        private void ClearForm()
        {
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.nroLegajoTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.fechaNacTextBox.Text = string.Empty;

        }

        private void EnableForm(bool enable)
        {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.direccionTextBox.Enabled = enable;
            this.fechaNacTextBox.Enabled = enable;
            this.telefonoTextBox.Enabled = enable;
            this.nroLegajoTextBox.Enabled = enable;



        }

        private void LoadEntity(Persona persona)
        {
            persona.Nombre = this.nombreTextBox.Text;
            persona.Apellido = this.apellidoTextBox.Text;
            persona.Email = this.emailTextBox.Text;
            persona.FechaNac = Convert.ToDateTime(this.fechaNacTextBox);
            persona.IdPlan = int.Parse(this.idplan.SelectedValue);
            persona.TipoPersona = (Persona.TipoPersonas)Enum.Parse(typeof(Persona.TipoPersonas), tipoper.SelectedValue.ToString());
            persona.Direccion = this.direccionTextBox.Text;
            persona.Legajo = int.Parse(this.nroLegajoTextBox.Text);
            persona.Telefono = this.telefonoTextBox.Text;
        }

        private void SaveEntity(Persona persona)
        {
            this.Logic.Save(persona);
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }


        #endregion

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                /*this.formActionsPanel.Visible = true;*/
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.EnableForm(true);
                /*this.formActionsPanel.Visible = true;*/
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            /*this.formActionsPanel.Visible = true;*/
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
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
                    this.Entity = new Persona();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.formPanel.Visible = false;

                    break;
                case FormModes.Alta:
                    this.Entity = new Persona();
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
            this.ClearForm();
            this.LoadGrid();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }
    }
}