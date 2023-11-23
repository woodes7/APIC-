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
    {   /// <summary>
        /// Contexto de base de datos utilizado por el servicio para acceder y manipular datos de coleccion.
        /// </summary>
        private readonly ApiDBContexto contexto;
        /// <summary>
        /// Servicio para gestionar operaciones relacionadas con los coleccion en la base de datos.
        /// </summary>
        /// <param name="contexto">Contexto de base de datos</param>
        public ServicioColeccion(ApiDBContexto contexto)
        {
            this.contexto = contexto;
        }
        /// <summary>
        /// Obtiene la lista de todos los coleccion.
        /// </summary>
        /// <returns>Lista de coleccion</returns>
        public List<Coleccion> ListColeccion()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Colecciones.ToList();
            }
        }
        /// <summary>
        /// Obtiene un coleccion por su ID.
        /// </summary>
        /// <param name="idColeccion">ID del coleccion</param>
        /// <returns>Coleccion con el ID especificado</returns>
        public Coleccion ObtenerColeccionPorId(long idColeccion)
        {
            return contexto.Colecciones.Find(idColeccion);
        }
        /// <summary>
        /// Agrega un nuevo coleccion.
        /// </summary>
        /// <param name="coleccion">Datos del nuevo coleccion</param>
        public void AgregarColeccion(Coleccion coleccion)
        {
            contexto.Colecciones.Add(coleccion);
            contexto.SaveChanges();
        }
        /// <summary>
        /// Modifica un coleccion existente.
        /// </summary>
        /// <param name="coleccion">Datos del coleccion actualizado</param>
        public void ModificarColeccion(Coleccion coleccion)
        {
            contexto.Colecciones.Update(coleccion);
            contexto.SaveChanges();
        }
        /// <summary>
        /// Elimina un coleccion por su ID.
        /// </summary>
        /// <param name="idColeccion">ID del coleccion a eliminar</param>
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
