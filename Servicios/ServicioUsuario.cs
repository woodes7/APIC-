using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioUsuario
    {

        public List<Usuario> ListaUsuario()
        {
            using(var cxt = new ApiDBContexto())
            {
                return cxt.Usuarios.ToList();
            }
        }
    }
}
