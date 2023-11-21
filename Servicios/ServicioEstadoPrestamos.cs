using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioEstadoPrestamos
    {
        public List<EstadoPrestamo> ListaEstadoPrestamos()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.EstadosPrestamos.ToList();
            }
        }
    }
}
