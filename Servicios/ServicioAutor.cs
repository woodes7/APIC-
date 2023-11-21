using Contexto;
using Modelo;
using System.Linq;

namespace Servicios
{
    public class ServicioAutor
    {
        private readonly ApiDBContexto _contexto;

        public ServicioAutor(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }
        public List<Autor> ListaAutores()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Autores.ToList();
            }
        }

        public Autor ObtenerAutorPorId(long idAutor)
        {
            return _contexto.Autores.Find(idAutor);
        }

        public void AgregarAutor(Autor autor)
        {
            _contexto.Autores.Add(autor);
            _contexto.SaveChanges();
        }

        public void ModificarAutor(Autor autor)
        {
            _contexto.Autores.Update(autor);
            _contexto.SaveChanges();
        }

        public void BorrarAutor(long idAutor)
        {
            var autor = _contexto.Autores.Find(idAutor);

            if (autor != null)
            {
                _contexto.Autores.Remove(autor);
                _contexto.SaveChanges();
            }
        }
    }
}
