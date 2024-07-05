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
            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                EntradaLogica logica = new EntradaLogica();
                List<Entrada> lista = logica.Listar(Request.QueryString["id"].ToString());
                Entrada seleccionada = lista[0];

                txtTitulo.Text = seleccionada.Titulo;
                txtTexto.Text = seleccionada.Texto;
                
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                Entrada nuevaEntrada = new Entrada();
                EntradaLogica logica = new EntradaLogica();
               

                nuevaEntrada.Titulo = txtTitulo.Text;
                nuevaEntrada.Texto = txtTexto.Text;
                nuevaEntrada.IdUsuario = usuario.Id;
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

                if (Request.QueryString["id"] != null)
                {
                    nuevaEntrada.Id = int.Parse(Request.QueryString["id"]);
                    logica.modificar(nuevaEntrada);
                }
                else
                {
                    nuevaEntrada.FechaCreacion = DateTime.Now;
                    //cuando haga registro y login, cargar idusuario, guardar en sesion, etc

                    logica.nuevaEntrada(nuevaEntrada);

                }

                Response.Redirect("Default.aspx", false);
                   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}