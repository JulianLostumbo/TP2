﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Planes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Per = (Persona)Session["persona"];
            if (IsPostBack == false)
            {
                formPanel.Visible = false;
                IDTextBox.Enabled = false;
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

        PlanLogic _Logic;
        private PlanLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new PlanLogic();
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

        private Plan Entity
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
            PlanLogic pl = new PlanLogic();
            this.gridView.DataSource = pl.GetAll();
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
            this.idespec.SelectedValue = this.Entity.IdEspecialidad.ToString();
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

        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = this.descripcionTextBox.Text;
            plan.IdEspecialidad = int.Parse(this.idespec.SelectedValue);

        }

        private void SaveEntity(Plan plan)
        {
            this.Logic.Save(plan);
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
                    this.Entity = new Plan();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Plan();
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
            this.idespec.Enabled = enable;
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
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {

            this.formPanel.Visible = false;
            this.ClearForm();
            this.LoadGrid();


        }

        protected void imprimirLinkButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/ReportPlanes.aspx");
        }
    }
}