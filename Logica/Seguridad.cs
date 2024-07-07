using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Logica
{
   public static class Seguridad
    {
        public static bool SesionActiva(object usuario)
        {
            Usuario user = usuario != null ? (Usuario)usuario : null;

            if (user != null && user.Id != 0)
                return true;   //Si hay un user "vivo" y tiene datos en la DB retorno true
            else
                return false;
        }
    }
} 
