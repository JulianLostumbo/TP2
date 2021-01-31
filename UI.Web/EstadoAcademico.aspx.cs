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
    public partial class EstadoAcademico : System.Web.UI.Page
    {
        public Persona Per { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                Per = (Persona)Session["persona"];

                if (Per.TipoPersona == Persona.TipoPersonas.Alumno)
                {

                    InscripcionLogic ins = new InscripcionLogic();
                    this.gridView.DataSource = ins.GetEstadoAcademico(Per.ID);
                    this.gridView.DataBind();
                }
                else
                {
                    gridView.Visible = false;
                    lbl.Text = "¡Error! Usted no es un alumno";
                }
            }
            
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridPanel_Load(object sender, EventArgs e)
        {

        }
    }
}