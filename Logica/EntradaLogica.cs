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
                datos.setearConsulta("Insert into ENTRADA (Titulo, Texto, FechaCreacion, IdUsuario ,UrlImagenEntrada) values (@Titulo, @Texto, @FechaCreacion, @IdUsuario, @UrlImagenEntrada)");
                datos.setearParametro("@Titulo", entrada.Titulo);
                datos.setearParametro("@Texto", entrada.Texto);
                datos.setearParametro("@FechaCreacion", entrada.FechaCreacion);
                datos.setearParametro("@IdUsuario", entrada.IdUsuario);
                datos.setearParametro("@UrlImagenEntrada", ((object)entrada.UrlImagenEntrada) ?? DBNull.Value);
             
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

        public List<Entrada> ListarPorUsuario(int idUsuario)
        {
            List<Entrada> listaEntradas = new List<Entrada>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT E.Id, E.Titulo, E.Texto, E.FechaCreacion, E.IdUsuario, E.UrlImagenEntrada FROM ENTRADA E WHERE E.IdUsuario = @UsuarioId");
                datos.setearParametro("@UsuarioId", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Entrada entrada = new Entrada
                    {
                        Id = (int)datos.Lector["Id"],
                        Titulo = (string)datos.Lector["Titulo"],
                        Texto = datos.Lector["Texto"] != DBNull.Value ? (string)datos.Lector["Texto"] : null,
                        FechaCreacion = (DateTime)datos.Lector["FechaCreacion"],
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        UrlImagenEntrada = datos.Lector["UrlImagenEntrada"] != DBNull.Value ? (string)datos.Lector["UrlImagenEntrada"] : null
                    };

                    listaEntradas.Add(entrada);
                }

                return listaEntradas;
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


        public List<Entrada> Listar(string id = "")
        {
            List<Entrada> listaEntradas = new List<Entrada>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("SELECT E.Id, E.Titulo, E.Texto, E.FechaCreacion, E.IdUsuario, E.UrlImagenEntrada, U.Nombre from ENTRADA E, USUARIO U WHERE E.Id = @idEntrada AND E.IdUsuario = U.Id");
                datos.setearParametro("@idEntrada", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Entrada entrada = new Entrada();
                    entrada.Id = (int)datos.Lector["Id"];
                    entrada.Titulo = (string)datos.Lector["Titulo"];
                    entrada.Texto = datos.Lector["Texto"] != DBNull.Value ? (string)datos.Lector["Texto"] : null;
                    entrada.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    entrada.IdUsuario = (int)datos.Lector["IdUsuario"];
                    entrada.UrlImagenEntrada = datos.Lector["UrlImagenEntrada"] != DBNull.Value ? (string)datos.Lector["UrlImagenEntrada"] : null;

                    listaEntradas.Add(entrada);
                }

                return listaEntradas;
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

        public void modificar(Entrada entrada)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ENTRADA SET Titulo=@Titulo, Texto=@Texto, UrlImagenEntrada=@UrlImagenEntrada WHERE Id=@Id");
                datos.setearParametro("@Titulo", entrada.Titulo);
                datos.setearParametro("@Texto", entrada.Texto);

                if (entrada.UrlImagenEntrada != null)
                {
                    datos.setearParametro("@UrlImagenEntrada", entrada.UrlImagenEntrada);
                }
                else
                {
                    datos.setearParametro("@UrlImagenEntrada", DBNull.Value);
                }

                datos.setearParametro("@Id", entrada.Id);
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

        public Entrada CargarEntrada(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Titulo, Texto, FechaCreacion, IdUsuario, UrlImagenEntrada FROM ENTRADA WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                // Asegurarse de que hay datos antes de intentar leer
                if (datos.Lector.Read())
                {
                    Entrada entrada = new Entrada();
                    entrada.Titulo = datos.Lector["Titulo"] != DBNull.Value ? (string)datos.Lector["Titulo"] : null;
                    entrada.Texto = datos.Lector["Texto"] != DBNull.Value ? (string)datos.Lector["Texto"] : null;
                    entrada.FechaCreacion = datos.Lector["FechaCreacion"] != DBNull.Value ? (DateTime)datos.Lector["FechaCreacion"] : DateTime.MinValue;
                    entrada.IdUsuario = datos.Lector["IdUsuario"] != DBNull.Value ? (int)datos.Lector["IdUsuario"] : 0;
                    entrada.UrlImagenEntrada = datos.Lector["UrlImagenEntrada"] != DBNull.Value ? (string)datos.Lector["UrlImagenEntrada"] : null;

                    return entrada;
                }
                else
                {
                    throw new Exception("No se encontraron datos para el Id especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la entrada: " + ex.Message);
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
