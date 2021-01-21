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
    public partial class Inscripciones : System.Web.UI.Page
    {
        
        public Persona Per { get; set; }

        public Business.Logic.InscripcionLogic Insc { get; set; }

        private InscripcionLogic _logic;
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

        public AlumnoInscripcion Entity { get; set; }

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

        protected void ButtonInsc_Click(object sender, EventArgs e)
        {
            CursoLogic cl = new CursoLogic();
            Curso cur = cl.GetOne((int)this.gridView.SelectedValue);
            AlumnoInscripcion alum = new AlumnoInscripcion();
            alum.Condicion = "Regular";
            alum.IDAlumno = Per.ID;
            alum.IDCurso = cur.ID;
            alum.State = BusinessEntity.States.New;
            Insc.Save(alum);
            this.Listar();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelError.Visible = false;
            Usuario user = new Usuario();
            user = (Usuario)Session["Usuario"];
            PersonaLogic pl = new PersonaLogic();
            Per = pl.GetOne(user.IdPersona);
            if (Per.TipoPersona == Persona.TipoPersonas.Alumno)
            {
                Insc = new InscripcionLogic();
                this.Listar();
                LabelError.Visible = true;
                LabelError.Text = "Inscripcion registrada correctamente!";
            }
            else
            {
                gridView.Visible = false;
                ButtonInsc.Visible = false;
                LabelError.Visible = true;
            }
        }

        public void Listar()
        {
            gridView.DataSource = Insc.GetCursosAlumno(Per);
            gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void gridPanel_Load(object sender, EventArgs e)
        {

        }
    }
}