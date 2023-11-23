using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioEditorial
    {   /// <summary>
        /// Contexto de base de datos utilizado por el servicio para acceder y manipular datos de editorial.
        /// </summary>
        private readonly ApiDBContexto _contexto;
        /// <summary>
        /// Servicio para gestionar operaciones relacionadas con los editorial en la base de datos.
        /// </summary>
        /// <param name="contexto">Contexto de base de datos</param>
        public ServicioEditorial(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Obtiene la lista de todos los editorial.
        /// </summary>
        /// <returns>Lista de editorial</returns>
        public List<Editorial> ListaEditoriales()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Editoriales.ToList();
            }
        }
        /// <summary>
        /// Obtiene un editorial por su ID.
        /// </summary>
        /// <param name="idEditorial">ID del editorial</param>
        /// <returns>Editorial con el ID especificado</returns>
        public Editorial ObtenerEditorialPorId(long idEditorial)
        {
            return _contexto.Editoriales.Find(idEditorial);
        }
        /// <summary>
        /// Agrega un nuevo editorial.
        /// </summary>
        /// <param name="editorial">Datos del nuevo editorial</param>
        public void AgregarEditorial(Editorial editorial)
        {
            _contexto.Editoriales.Add(editorial);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Modifica un editorial existente.
        /// </summary>
        /// <param name="editorial">Datos del editorial actualizado</param>
        public void ModificarEditorial(Editorial editorial)
        {
            _contexto.Editoriales.Update(editorial);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Elimina un editorial por su ID.
        /// </summary>
        /// <param name="idEditorial">ID del editorial a eliminar</param>
        public void BorrarEditorial(long idEditorial)
        {
            var editorial = _contexto.Editoriales.Find(idEditorial);

            if (editorial != null)
            {
                _contexto.Editoriales.Remove(editorial);
                _contexto.SaveChanges();
            }
        }
    }
}

