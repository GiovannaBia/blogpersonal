using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Entrada
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
      
        public string ResumenTexto
        {
            get
            {
                if (string.IsNullOrEmpty(Texto))
                    return string.Empty;
                return Texto.Length <= 100 ? Texto : Texto.Substring(0, 100) + "...";
            }
        }       
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
        public string UrlImagenEntrada { get; set; }
    }
}
