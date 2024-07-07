using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Logica
{
   public class UsuarioLogica
    {
        public bool validarUsuario(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Email, Id from USUARIO where Email = @email ");
                datos.setearParametro("@email", email);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                    return true;
                else
                    return false;
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

        public bool Login (Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos(); 
            try
            {
                datos.setearConsulta("select Id, Nombre, Email, Pass, UrlImagenPerfil, Biografia from USUARIO where Email=@email and Pass=@pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["UrlImagenPerfil"] is DBNull))
                        usuario.UrlImagenPerfil = (string)datos.Lector["UrlImagenPerfil"];
                    if (!(datos.Lector["Biografia"] is DBNull))
                        usuario.Biografia = (string)datos.Lector["Biografia"];
                    return true;
                }
                else 

                    return false;
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

        public Usuario ObtenerPorId (int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, Nombre, Email, Biografia, UrlImagenPerfil from USUARIO WHERE Id = @Id");
                datos.setearParametro("@Id", Id);
                datos.ejecutarLectura();

                Usuario usuario = new Usuario();
                usuario.Id = (int)datos.Lector["Id"];
                usuario.Nombre = datos.Lector["Nombre"] != DBNull.Value ? (string)datos.Lector["Nombre"] : null;
                usuario.Email = (string)datos.Lector["Email"];
                usuario.Biografia = datos.Lector["Biografia"] != DBNull.Value ? (string)datos.Lector["Biografia"] : null;
                usuario.UrlImagenPerfil = datos.Lector["UrlImagenPerfil"] != DBNull.Value ? (string)datos.Lector["UrlImagenPerfil"] : null;

                return usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void guardarPërfil(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE USUARIO SET Nombre = @Nombre, UrlImagenPerfil = @UrlImagenPerfil, Biografia = @Biografia where Id = @Id");
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@UrlImagenPerfil", (object)usuario.UrlImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@Biografia", usuario.Biografia);
                datos.setearParametro("@Id", usuario.Id);

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

        public int InsertarNuevo (Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT into USUARIO (Email, Pass) OUTPUT inserted.Id VALUES (@email, @pass)");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);

                return datos.ejecutarAccionScalar();
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

        //falta validar contraseña!!
    }
}
