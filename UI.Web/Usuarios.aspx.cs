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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Per = (Persona)Session["persona"];
            User = (Usuario)Session["usuario"];
            if (IsPostBack==false)
            {
                formPanel.Visible = false;
                IDTextBox.Enabled = false;
                perLogic = new PersonaLogic();
                ddlPersona.DataSource = perLogic.GetAll();
                ddlPersona.SelectedIndex = -1;
                ddlPersona.DataTextField = "NomApe";
                ddlPersona.DataValueField = "ID";
                ddlPersona.DataBind();
                if (Per.TipoPersona != Persona.TipoPersonas.Administrador)
                {
                    imprimirLinkButton.Visible = false;
                    eliminarLinkButton.Visible = false;
                    nuevoLinkButton.Visible = false;
                }
                this.LoadGrid();
            }                      
        }

        UsuarioLogic _Logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new UsuarioLogic();
                }
                return _Logic;
            }
        }

        public PersonaLogic perLogic { get; set; }

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

        private Usuario Entity
        {
            get;
            set;
        }

        public Usuario User { get; set; }

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

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        private void LoadGrid()
        {
            UsuarioLogic ul = new UsuarioLogic();
            if (Per.TipoPersona != Persona.TipoPersonas.Administrador)
            {
                this.gridView.DataSource = ul.GetAll(User.ID);
            }
            else
            {
                this.gridView.DataSource = ul.GetAll();
            }
            this.gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {

            this.Entity = this.Logic.GetOne(id);
            this.IDTextBox.Text = Convert.ToString(this.Entity.ID);
            this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
            this.ddlPersona.SelectedValue = Convert.ToString(this.Entity.IdPersona);
            if ((Per.TipoPersona != Persona.TipoPersonas.Administrador))
            {
                this.claveTextBox.Text = this.Entity.Clave.ToString();
            }
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

        private void LoadEntity(Usuario usuario)
        {
            PersonaLogic pl = new PersonaLogic();
            Persona p=pl.GetOne(Convert.ToInt32(this.ddlPersona.SelectedValue));
            usuario.Nombre = p.Nombre;
            usuario.Apellido = p.Apellido;
            usuario.Email = p.Email;
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
            usuario.IdPersona = Convert.ToInt32(this.ddlPersona.SelectedValue);

        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.Entity = this.Logic.GetOne(SelectedID);
                    if ((Entity.Clave == this.claveTextBox.Text.ToString() && Per.TipoPersona == Persona.TipoPersonas.Administrador) ||
                        Per.TipoPersona != Persona.TipoPersonas.Administrador)
                    {
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                    }
                    else
                    {
                        Response.Write("<script> alert(" + "'¡ERROR! Contraseña incorrecta'" + ") </script>");
                    }
                    break;
                case FormModes.Modificacion:
                    this.Entity = this.Logic.GetOne(SelectedID);
                    if ((Entity.Clave == this.claveTextBox.Text.ToString() && Per.TipoPersona == Persona.TipoPersonas.Administrador) || 
                        Per.TipoPersona != Persona.TipoPersonas.Administrador)
                    {
                        this.Entity = new Usuario();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                    }
                    else
                    {
                        Response.Write("<script> alert(" + "'¡ERROR! Contraseña incorrecta'" + ") </script>");
                    }
                    break;
                case FormModes.Alta:
                    this.Entity = new Usuario();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.nombreUsuarioTextBox.Enabled = enable;
            this.ddlPersona.Enabled = enable;
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
            this.habilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
            this.claveTextBox.Text = string.Empty;

        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.ClearForm();
            this.LoadGrid();
        }        

        protected void imprimirLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportUsuarios.aspx");
        }

        
    }
}