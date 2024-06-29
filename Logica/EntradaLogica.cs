using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Logica
{
   public  class EntradaLogica
    {
        public void nuevaEntrada(Entrada entrada)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into ENTRADA (Titulo, Texto, FechaCreacion, UrlImagenEntrada) values (@Titulo, @Texto, @FechaCreacion, @UrlImagenEntrada)");
                datos.setearParametro("@Titulo", entrada.Titulo);
                datos.setearParametro("@Texto", entrada.Texto);
                datos.setearParametro("@FechaCreacion", entrada.FechaCreacion);
                datos.setearParametro("@UrlImagenEntrada", ((object)entrada.UrlImagenEntrada) ?? DBNull.Value);
             
                // por ahora no le cargo el idusuario porque no hice login ni registro
                //pendiente importante : pagina de Error!
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
