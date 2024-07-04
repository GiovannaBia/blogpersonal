using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Logica;

namespace BlogPersonal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioLogica logica = new UsuarioLogica();

            try
            {
                usuario.Email = txtUsuario.Text;
                usuario.Pass = txtPass.Text;

                if (logica.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}