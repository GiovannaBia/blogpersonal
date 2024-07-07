using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Logica
{
    public class FavoritoLogica
    {
        public void InsertarFavorito(int idEntrada, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO FAVORITO (IdUsuario, IdEntrada) VALUES (@idUsuario, @idEntrada)");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.setearParametro("@idEntrada", idEntrada);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                // Imprime la excepción para depuración
                Console.WriteLine("Error al insertar favorito: " + ex.Message);
                throw ex;  // Re-lanza la excepción para que pueda ser manejada en un nivel superior
            }
        }


    }
}
