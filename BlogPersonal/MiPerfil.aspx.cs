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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.SesionActiva(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    txtEmail.Text = usuario.Email;
                    txtEmail.ReadOnly = true;
                    txtNombre.Text = usuario.Nombre;
                    txtBiografia.Text = usuario.Biografia;
                    imgNuevoPerfil.ImageUrl = "~/Imagenes/" + usuario.UrlImagenPerfil;

                }
                else
                {
                    Response.Redirect("LoginPagina.aspx", false);
                }
  
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                UsuarioLogica logica = new UsuarioLogica();
                usuario.Nombre = txtNombre.Text;
                usuario.Biografia = txtBiografia.Text;
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("~/Imagenes/");
                    string fileName = "perfil-" + usuario.Id + "-" + usuario.Nombre + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                    txtImagen.PostedFile.SaveAs(ruta + fileName);
                    usuario.UrlImagenPerfil = fileName; ;
                }
                else           
                {
                    usuario.UrlImagenPerfil = null;
                }
                    logica.guardarPërfil(usuario);
                    lblSuccess.Text = "Perfil actualizado correctamente.";
                    lblSuccess.Visible = true;

                // Verificar que la master page no sea nula
                if (Master != null)
                {
                    Image img = (Image)Master.FindControl("imagenAvatar");
                    if (img != null)
                    {
                        // Añadir un parámetro aleatorio para evitar caché
                        img.ImageUrl = "~/Imagenes/" + usuario.UrlImagenPerfil;
                    }
                    else
                    {
                        throw new Exception("Control imgAvatar no encontrado en la Master Page.");
                    }
                }

                Response.Redirect("Default.aspx", false);
            }
            
            catch (Exception ex)
            {
                lblError.Text = "Error al guardar el perfil del usuario: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}