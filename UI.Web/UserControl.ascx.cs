using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class UserControl : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario user = (Usuario)Session["Usuario"];

                string text = string.Format("¡Bienvenido a la Academia: {0}, {1}!", user.Apellido, user.Nombre);
                txtUsuario.Text = text;
            }
        }

        protected void btnCerrarsesion_Click(object sender, ImageClickEventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("/Logout.aspx");
        }
    }
}