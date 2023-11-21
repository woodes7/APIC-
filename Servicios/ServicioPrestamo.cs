using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioPrestamo
    {
        public List<Prestamo> ListaPrestamos()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Prestamos.ToList();
            }
        }
        public void AgregarPrestamo()
        {

        }
       
        public void finalizarPrestamo()
        {

        }

        public void AnularPrestamo()
        {

        }

    }
}
