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
    public partial class Notas : System.Web.UI.Page
    {
        #region Propiedades
        InscripcionLogic _logic;
        private InscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new InscripcionLogic();
                }
                return _logic;
            }
        }

        private AlumnoInscripcion Entity
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

        private int id;
        public int idCurso
        {
            get { return id; }
            set { id = value; }
        }

        private InscripcionLogic _il;
        public InscripcionLogic il
        {
            get { return _il; }
            set { _il = value; }
        }

        #endregion

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            errorLbl.Visible = false;
            idCurso = int.Parse(Request.QueryString["ID"]);
            il = new InscripcionLogic();
            gridPanel.Visible = true;
            Listar();
            formPanel.Visible = false;
        }


        public void Listar()
        {

            InscripcionLogic ins = new InscripcionLogic();
            this.gridView.DataSource = ins.GetAll(idCurso);
            this.gridView.DataBind();
        }

        protected void btnNota_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
        }

        protected void AceptarBtn_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtNota.Text) > 0 && int.Parse(txtNota.Text) < 10)
            {
                this.Entity = new AlumnoInscripcion();
                Entity = il.GetOne(SelectedID);
                Entity.State = BusinessEntity.States.Modified;
                Entity.Nota = int.Parse(txtNota.Text);
                if (int.Parse(txtNota.Text) > 6)
                {
                    Entity.Condicion = "Aprobado";
                }
                else
                {
                    Entity.Condicion = "No aprobado";
                }
                this.il.Save(Entity);
                this.Listar();
                this.formPanel.Visible = false;
            }
            else
            {
                this.errorLbl.Text = "Debe ingresar un numero";
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }
    }
}