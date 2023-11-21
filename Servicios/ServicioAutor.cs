using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioAutor
    {
        public List<Autor> ListaAutores()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Autores.ToList();
            }
        }

        public void agregarAutor() { 
        
        }

        public void ModificarAutor()
        {

        }
        public void borrarAutor()
        {

        }

       
                
    }
}
