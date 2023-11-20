using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioLibro
    {
        public List<Libro> ListarLibros() {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Libros.ToList();
            }
        }

        public void AñadirLibro(Libro libro)
        {

        }

        public void SeleccionarLibro(Libro libro)
        {

        }

        public void ModificarLibro(Libro libro)
        {

        }

        public void DarBajaLibro(Libro libro)
        {

        }
    }
}
