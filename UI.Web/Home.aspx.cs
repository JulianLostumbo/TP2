using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VerificarSesion();
                Usuario Usuario = (Usuario)Session["usuario"];

            }

        }

        private void VerificarSesion()
        {
            if (Session["usuario"] == null)
            {
                
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}