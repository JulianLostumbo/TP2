using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Business.Entities;
using System.Data.Common;

namespace Academia
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {            
            SqlConnection conn = new SqlConnection("Server = localhost; Initial Catalog = tp2_net; Integrated Security = True;");
            try
            {
                conn.Open();

                string nombreUser = this.txtUsuario.Text;
                string claveUser = this.txtPass.Text;
                Usuario user = new Usuario();
                string sqlconsulta = "select * from usuarios where nombre_usuario= @username and clave= @pass";

                SqlCommand cmd = new SqlCommand(sqlconsulta, conn);
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = nombreUser;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = claveUser;

                SqlDataReader drUsuarios = cmd.ExecuteReader();
                if (drUsuarios.Read())
                {
                    user.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    user.Clave = (string)drUsuarios["clave"];
                }

                conn.Close();

                if (this.txtUsuario.Text == user.NombreUsuario && this.txtPass.Text == user.Clave)

                {

                    this.DialogResult = DialogResult.OK;
                    

                }

                else

                {

                    MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",

            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            //console.wirte
        }
    }
}
