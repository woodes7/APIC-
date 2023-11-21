using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioColeccion
    {
        public List<Coleccion> ListColeccion()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Colecciones.ToList();
            }
        }
        public void AgregarColeccion()
        {

        }

        public void ModificarColeccion()
        {

        }

        public void BorrarColeccion()
        {

        }
    }
}
