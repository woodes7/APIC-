using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    internal class ServicioGenero
    {
        public List<Genero> ListaGeneros()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Generos.ToList();
            }
        }
    }
}
