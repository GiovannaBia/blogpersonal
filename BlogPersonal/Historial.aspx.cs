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
    public partial class Historial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                EntradaLogica logica = new EntradaLogica();
                dgvEntradas.DataSource = logica.ListarPorUsuario(usuario.Id);
                dgvEntradas.DataBind();
            }
        }

        protected void dgvEntradas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvEntradas.SelectedDataKey.Value.ToString();
            Response.Redirect("NuevaEntrada.aspx?id=" + id, false);
        }
    }
}