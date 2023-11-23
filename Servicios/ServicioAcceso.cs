using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioAcceso
    {   /// <summary>
        /// Contexto de base de datos utilizado por el servicio para acceder y manipular datos de accesos.
        /// </summary>
        private readonly ApiDBContexto _contexto;
        /// <summary>
        /// Servicio para gestionar operaciones relacionadas con los accesos en la base de datos.
        /// </summary>
        /// <param name="contexto">Contexto de base de datos</param>
        public ServicioAcceso(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Obtiene la lista de todos los accesos.
        /// </summary>
        /// <returns>Lista de accesos</returns>
        public List<Acceso> ListaAccesos()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Accesos.ToList();
            }
        }
        /// <summary>
        /// Obtiene un acceso por su ID.
        /// </summary>
        /// <param name="idAcceso">ID del acceso</param>
        /// <returns>Acceso con el ID especificado</returns>
        public Acceso ObtenerAccesoPorId(long idAcceso)
        {
            return _contexto.Accesos.Find(idAcceso);
        }
        /// <summary>
        /// Agrega un nuevo acceso.
        /// </summary>
        /// <param name="acceso">Datos del nuevo acceso</param>
        public void AgregarAcceso(Acceso acceso)
        {
            _contexto.Accesos.Add(acceso);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Modifica un acceso existente.
        /// </summary>
        /// <param name="acceso">Datos del acceso actualizado</param>
        public void ModificarAcceso(Acceso acceso)
        {
            _contexto.Accesos.Update(acceso);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Elimina un acceso por su ID.
        /// </summary>
        /// <param name="idAcceso">ID del acceso a eliminar</param>
        public void BorrarAcceso(long idAcceso)
        {
            var acceso = _contexto.Accesos.Find(idAcceso);

            if (acceso != null)
            {
                _contexto.Accesos.Remove(acceso);
                _contexto.SaveChanges();
            }
        }
    }
}
