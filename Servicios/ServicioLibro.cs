using Contexto;
using Modelo;
using System.Linq;

namespace Servicios
{   
    public class ServicioLibro
    {   /// <summary>
        /// Contexto de base de datos utilizado por el servicio para acceder y manipular datos de libro.
        /// </summary>
        private readonly ApiDBContexto _contexto;
        /// <summary>
        /// Servicio para gestionar operaciones relacionadas con los libro en la base de datos.
        /// </summary>
        /// <param name="contexto">Contexto de base de datos</param>

        public ServicioLibro(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Obtiene la lista de todos los libro.
        /// </summary>
        /// <returns>Lista de libro</returns>
        public List<Libro> ListaLibros()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Libros.ToList();
            }
        }
        /// <summary>
        /// Obtiene un libro por su ID.
        /// </summary>
        /// <param name="idLibro">ID del libro</param>
        /// <returns>Libro con el ID especificado</returns>
        public Libro ObtenerLibroPorId(long idLibro)
        {
            return _contexto.Libros.Find(idLibro);
        }
        /// <summary>
        /// Agrega un nuevo libro.
        /// </summary>
        /// <param name="libro">Datos del nuevo libro</param>
        public void AgregarLibro(Libro libro)
        {
            _contexto.Libros.Add(libro);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Modifica un libro existente.
        /// </summary>
        /// <param name="libro">Datos del libro actualizado</param>
        public void ModificarLibro(Libro libro)
        {
            _contexto.Libros.Update(libro);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Elimina un libro por su ID.
        /// </summary>
        /// <param name="idLibro">ID del libro a eliminar</param>
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
