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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            {
                if (Logica.Seguridad.SesionActiva(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    List<Entrada> entradas = new List<Entrada>();
                    EntradaLogica logica = new EntradaLogica();
                    entradas = logica.ListarPorUsuario(usuario.Id);

                    if (entradas.Count > 0)
                    {
                        Entrada ultima = entradas[entradas.Count - 1];
                        lblTitulo.Text = ultima.Titulo;
                        lblTexto.Text = ultima.ResumenTexto;

                        if (Request.QueryString["id"] != null)
                        {
                            int id = int.Parse(Request.QueryString["id"].ToString());
                            Entrada entrada = logica.CargarEntrada(id);
                            LabelFavorita.Text = entrada.Titulo;
                            LabelFavoritaTexto.Text = entrada.ResumenTexto;
                            if (entrada.UrlImagenEntrada != null)
                            {
                                img.Visible = true;
                                img.ImageUrl = entrada.UrlImagenEntrada;
                            }
                        }
                    }
                    else
                    {
                        // Para Ocultar la card si no hay entradas
                        cardUltimaEntrada.Visible = false;
                    }
                }
            }


        }

    }
}
