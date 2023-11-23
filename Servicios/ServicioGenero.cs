using Contexto;
using Modelo;
using System.Linq;

namespace Servicios
{
    public class GeneroServicio
    {   /// <summary>
        /// Contexto de base de datos utilizado por el servicio para acceder y manipular datos de genero.
        /// </summary>
        private readonly ApiDBContexto _contexto;
        /// <summary>
        /// Servicio para gestionar operaciones relacionadas con los genero en la base de datos.
        /// </summary>
        /// <param name="contexto">Contexto de base de datos</param>

        public GeneroServicio(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Obtiene la lista de todos los genero.
        /// </summary>
        /// <returns>Lista de genero</returns>
        public List<Genero> ListaGeneros()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Generos.ToList();
            }
        }
        /// <summary>
        /// Obtiene un genero por su ID.
        /// </summary>
        /// <param name="idGenero">ID del genero</param>
        /// <returns>Genero con el ID especificado</returns>
        public Genero ObtenerGeneroPorId(long idGenero)
        {
            return _contexto.Generos.Find(idGenero);
        }
        /// <summary>
        /// Agrega un nuevo genero.
        /// </summary>
        /// <param name="acceso">Datos del nuevo genero</param>
        public void AgregarGenero(Genero genero)
        {
            _contexto.Generos.Add(genero);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Modifica un genero existente.
        /// </summary>
        /// <param name="genero">Datos del genero actualizado</param>
        public void ModificarGenero(Genero genero)
        {
            _contexto.Generos.Update(genero);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Elimina un genero por su ID.
        /// </summary>
        /// <param name="idGenero">ID del genero a eliminar</param>
        public void BorrarGenero(long idGenero)
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
