using Contexto;
using Modelo;
using System.Linq;

namespace Servicios
{
    public class ServicioLibros
    {
        private readonly ApiDBContexto _contexto;

        public ServicioLibros(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }

        public List<Libro> ListaLibros()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Libros.ToList();
            }
        }

        public Libro ObtenerLibroPorId(int id)
        {
            return _contexto.Libros.Find(id);
        }

        public void AgregarLibro(Libro libro)
        {
            _contexto.Libros.Add(libro);
            _contexto.SaveChanges();
        }

        public void ModificarLibro(Libro libro)
        {
            _contexto.Libros.Update(libro);
            _contexto.SaveChanges();
        }

        public void BorrarLibro(int idLibro)
        {
            var libro = _contexto.Libros.Find(idLibro);

            if (libro != null)
            {
                _contexto.Libros.Remove(libro);
                _contexto.SaveChanges();
            }
        }
    }
}
