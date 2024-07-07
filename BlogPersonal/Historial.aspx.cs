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
                if (!Seguridad.SesionActiva(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    CargarEntradas();
                }
            }
        }

        private void CargarEntradas()
        {
            Usuario usuario = (Usuario)Session["usuario"];
            EntradaLogica logica = new EntradaLogica();
            dgvEntradas.DataSource = null; // Para limpiar cualquier dato previo
            dgvEntradas.DataSource = logica.ListarPorUsuario(usuario.Id);
            dgvEntradas.DataBind();
        }




        protected void dgvEntradas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editar" || e.CommandName == "AgregarFavoritos")
                {
                    // Obtener el índice de la fila
                    int index = Convert.ToInt32(e.CommandArgument);
                    // Obtener la fila basada en el índice
                    GridViewRow row = dgvEntradas.Rows[index];
                    // Obtener el ID de la clave primaria desde DataKeys
                    int id = Convert.ToInt32(dgvEntradas.DataKeys[row.RowIndex].Value);

                    // Para depuración
                    Console.WriteLine($"Command: {e.CommandName}, Index: {index}, ID: {id}");

                    Usuario usuario = (Usuario)Session["usuario"];
                    int idUsuario = usuario.Id;

                    if (e.CommandName == "Editar")
                    {
                        Response.Redirect("NuevaEntrada.aspx?id=" + id, false);
                    }
                    else if (e.CommandName == "AgregarFavoritos")
                    {
                        FavoritoLogica logica = new FavoritoLogica();
                        logica.InsertarFavorito(id, idUsuario);
                        Response.Redirect("Default.aspx?id=" + id, false);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log de la excepción
                Console.WriteLine("Error al procesar el comando: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
            }
        }

    }
}

    

  
        
    
