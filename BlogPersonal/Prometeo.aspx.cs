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
    public partial class Prometeo : System.Web.UI.Page
    {
        public List<Entrada> ListaEntradas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Seguridad.SesionActiva(Session["usuario"]))
            {
                Usuario usuario = (Usuario)Session["usuario"];
                int id = usuario.Id;
                EntradaLogica logica = new EntradaLogica();

                // Obtener las entradas ordenadas por fecha de creación descendente
                ListaEntradas = logica.ListarPorUsuario(id).OrderByDescending(entrada => entrada.FechaCreacion).ToList();


                if (!IsPostBack)
                {
                    repRepetidor.DataSource = ListaEntradas;
                    repRepetidor.DataBind();
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            Response.Redirect("NuevaEntrada.aspx?id=" + id);
        }
    }
}

