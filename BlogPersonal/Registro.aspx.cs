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
    public partial class Registro : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != txtPass2.Text)
            {
                lblValida.Visible = true;
                return;
            }
            Usuario usuario = new Usuario();
            UsuarioLogica logica = new UsuarioLogica();
            try
            {
                usuario.Email = txtUsuario.Text;
                usuario.Pass = txtPass.Text;
                if (logica.validarUsuario(usuario.Email))
                {
                    lblError.Text = "El email ya está registrado.";
                    lblError.Visible = true;
                }
                else
                {
                    usuario.Id = logica.InsertarNuevo(usuario);
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtPass2_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text != txtPass2.Text)
            {
                lblValida.Visible = true;
                btnIngresar.Enabled = false;
            }
            else
            {
                lblValida.Visible = false;
                btnIngresar.Enabled = true;
            }
            txtPass.Attributes["value"] = txtPass.Text;
            txtPass2.Attributes["value"] = txtPass2.Text;
        }
    }
}