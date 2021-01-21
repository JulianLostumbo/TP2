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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUser = this.txtUsuario.Text;
            string claveUser = this.txtClave.Text;

            UsuarioLogic BuscarUser = new UsuarioLogic();
            Usuario usuario = BuscarUser.GetOne(nombreUser, claveUser);

            if (nombreUser == usuario.NombreUsuario && claveUser == usuario.Clave)
            {

                PersonaLogic BuscarPersona = new PersonaLogic();
                Session["persona"] = BuscarPersona.GetOne(usuario.IdPersona);
                Session["usuario"] = usuario;
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                
                Response.Write("<script> alert(" + "'Usuario y/o contraseña incorrectos'" + ") </script>");
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Response.Write("<script> alert(" + "'Es Ud. un usuario muy descuidado, haga memoria'" + ") </script>");
        }
    }
}