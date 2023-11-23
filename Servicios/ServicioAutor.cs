using Contexto;
using Modelo;
using System.Linq;

namespace Servicios
{
    public class ServicioAutor
    {   /// <summary>
        /// Contexto de base de datos utilizado por el servicio para acceder y manipular datos de autor.
        /// </summary>
        private readonly ApiDBContexto _contexto;
        /// <summary>
        /// Servicio para gestionar operaciones relacionadas con los accesos en la base de datos.
        /// </summary>
        /// <param name="contexto">Contexto de base de datos</param>
        public ServicioAutor(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Obtiene la lista de todos los autor.
        /// </summary>
        /// <returns>Lista de autor</returns>
        public List<Autor> ListaAutores()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Autores.ToList();
            }
        }
        /// <summary>
        /// Obtiene un autor por su ID.
        /// </summary>
        /// <param name="idAutor">ID del autor</param>
        /// <returns>Autor con el ID especificado</returns>
        public Autor ObtenerAutorPorId(long idAutor)
        {
            return _contexto.Autores.Find(idAutor);
        }
        /// <summary>
        /// Agrega un nuevo autor.
        /// </summary>
        /// <param name="autor">Datos del nuevo autor</param>
        public void AgregarAutor(Autor autor)
        {
            _contexto.Autores.Add(autor);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Modifica un autor existente.
        /// </summary>
        /// <param name="autor">Datos del autor actualizado</param>
        public void ModificarAutor(Autor autor)
        {
            _contexto.Autores.Update(autor);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Elimina un autor por su ID.
        /// </summary>
        /// <param name="idAutor">ID del autor a eliminar</param>
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
