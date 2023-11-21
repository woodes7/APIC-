using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Servicios
{
    public class ServicioColeccion
    {
        private readonly ApiDBContexto contexto;

        public ServicioColeccion(ApiDBContexto contexto)
        {
            this.contexto = contexto;
        }

        public List<Coleccion> ListColeccion()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Colecciones.ToList();
            }
        }

        public Coleccion ObtenerColeccionPorId(long idColeccion)
        {
            return contexto.Colecciones.Find(idColeccion);
        }

        public void AgregarColeccion(Coleccion coleccion)
        {
            contexto.Colecciones.Add(coleccion);
            contexto.SaveChanges();
        }

        public void ModificarColeccion(Coleccion coleccion)
        {
            contexto.Colecciones.Update(coleccion);
            contexto.SaveChanges();
        }

        public void BorrarColeccion(long idColeccion)
        {
            var coleccion = contexto.Colecciones.Find(idColeccion);

            if (coleccion != null)
            {
                contexto.Colecciones.Remove(coleccion);
                contexto.SaveChanges();
            }
        }
    }
}
