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
        private readonly ApiDBContexto _contexto;

        public ServicioColeccion(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }

        public List<Coleccion> ListColeccion()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Colecciones.ToList();
            }
        }

        public Coleccion ObtenerColeccionPorId(int id)
        {
            return _contexto.Colecciones.Find(id);
        }

        public void AgregarColeccion(Coleccion coleccion)
        {
            _contexto.Colecciones.Add(coleccion);
            _contexto.SaveChanges();
        }

        public void ModificarColeccion(Coleccion coleccion)
        {
            // Aquí puedes implementar la lógica de actualización según tus necesidades
            _contexto.Colecciones.Update(coleccion);
            _contexto.SaveChanges();
        }

        public void BorrarColeccion(int idColeccion)
        {
            var coleccion = _contexto.Colecciones.Find(idColeccion);

            if (coleccion != null)
            {
                _contexto.Colecciones.Remove(coleccion);
                _contexto.SaveChanges();
            }
        }
    }
}
