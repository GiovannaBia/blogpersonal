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
    public partial class NuevaEntrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Entrada nuevaEntrada = new Entrada();
            EntradaLogica logica = new EntradaLogica();
            try
            {
                nuevaEntrada.Titulo = txtTitulo.Text;
                nuevaEntrada.Texto = txtTexto.Text;
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Imagenes/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + nuevaEntrada.Id + "-" + nuevaEntrada.Titulo + ".jpg");
                    nuevaEntrada.UrlImagenEntrada = "perfil-" + nuevaEntrada.Id + "-" + nuevaEntrada.Titulo + ".jpg";
                }
                else
                {
                    nuevaEntrada.UrlImagenEntrada = null;
                }
                nuevaEntrada.FechaCreacion = DateTime.Now;
                //cuando haga registro y login, cargar idusuario, guardar en sesion, etc

                logica.nuevaEntrada(nuevaEntrada);

                Response.Redirect("Default.aspx", false);
                   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}