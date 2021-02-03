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
    public partial class Cursos : System.Web.UI.Page
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

        CursoLogic _logic;
        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }

        private Curso Entity
        {
            get;
            set;
        }

        private Persona Per
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
            Per = (Persona)Session["persona"];
            if (Per.TipoPersona == Persona.TipoPersonas.Profesor)
            {
                DocenteCursoLogic dc = new DocenteCursoLogic();
                this.gridView.DataSource = dc.GetCursosDocente(Per.ID);

            }
            else
            {
                CursoLogic cl = new CursoLogic();
                this.gridView.DataSource = cl.GetAll();
            }
            this.gridView.DataBind();
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.IDTextBox.Text = this.Entity.ID.ToString();
            this.añocalTxt.Text = this.Entity.AnioCalendario.ToString();
            this.CupoTxt.Text = this.Entity.Cupo.ToString();
            this.idComi.SelectedValue = Entity.IdComision.ToString();
            this.idMate.SelectedValue = Entity.IdMateria.ToString();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Per = (Persona)Session["persona"];
            if (!this.Page.IsPostBack)
            {

                formPanel.Visible = false;

                IDTextBox.Enabled = false;

                if (Per.TipoPersona != Persona.TipoPersonas.Profesor)
                {
                    notasLinkButton.Visible = false;
                }

                if (Per.TipoPersona == Persona.TipoPersonas.Alumno)
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

        private void ClearForm()
        {
            this.IDTextBox.Text = string.Empty;
            this.añocalTxt.Text = string.Empty;
            this.CupoTxt.Text = string.Empty;

        }

        private void EnableForm(bool enable)
        {
            this.añocalTxt.Enabled = enable;
            this.CupoTxt.Enabled = enable;
            this.idComi.Enabled = enable;
            this.idMate.Enabled = enable;


        }

        private void LoadEntity(Curso cur)
        {
            cur.Cupo = int.Parse(this.CupoTxt.Text);
            cur.AnioCalendario = int.Parse(this.añocalTxt.Text);
            cur.IdMateria = int.Parse(idMate.SelectedValue);
            cur.IdComision = int.Parse(idComi.SelectedValue);
        }

        private void SaveEntity(Curso cur)
        {
            this.Logic.Save(cur);
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        #endregion

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.aceptarLinkButton.Visible = true;
            this.cancelarLinkButton.Visible = true;
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
                this.aceptarLinkButton.Visible = true;
                this.cancelarLinkButton.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.aceptarLinkButton.Visible = true;
                this.cancelarLinkButton.Visible = true;
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
                    this.Entity = new Curso();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;
                case FormModes.Alta:

                    this.Entity = new Curso();
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

        protected void notasLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                Response.Redirect("Notas.aspx?ID=" + SelectedID);
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void imprimirLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportCursos.aspx");
        }
    }
}