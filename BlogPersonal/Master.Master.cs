using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Dominio;

namespace BlogPersonal
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!(Page is Login || Page is Default || Page is Registro ))
            {
                if (!Seguridad.SesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);

                if (Seguridad.SesionActiva(Session["usuario"]))
                {
                    Usuario user = new Usuario();
                    user = (Usuario)Session["usuario"];
                    imagenAvatar.ImageUrl = "~/Imagenes/" + user.UrlImagenPerfil;
                    lblUser.Text = user.Email;
                }
                else
                {
                    imagenAvatar.ImageUrl = "https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg";
                }

            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}