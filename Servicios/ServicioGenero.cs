using Contexto;
using Modelo;
using System.Linq;

namespace Servicios
{
    public class GeneroServicio
    {
        private readonly ApiDBContexto _contexto;

        public GeneroServicio(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }

        public List<Genero> ListaGeneros()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Generos.ToList();
            }
        }

        public Genero ObtenerGeneroPorId(int id)
        {
            return _contexto.Generos.Find(id);
        }

        public void AgregarGenero(Genero genero)
        {
            _contexto.Generos.Add(genero);
            _contexto.SaveChanges();
        }

        public void ModificarGenero(Genero genero)
        {
            _contexto.Generos.Update(genero);
            _contexto.SaveChanges();
        }

        public void BorrarGenero(int idGenero)
        {
            var genero = _contexto.Generos.Find(idGenero);

            if (genero != null)
            {
                _contexto.Generos.Remove(genero);
                _contexto.SaveChanges();
            }
        }
    }
}
