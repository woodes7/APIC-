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
    public class ServicioEstadoPrestamos
    {   /// <summary>
        /// Contexto de base de datos utilizado por el servicio para acceder y manipular datos de estadoPrestamo.
        /// </summary>
        private readonly ApiDBContexto _contexto;
        /// <summary>
        /// Servicio para gestionar operaciones relacionadas con los estadoPrestamo en la base de datos.
        /// </summary>
        /// <param name="contexto">Contexto de base de datos</param>
        public ServicioEstadoPrestamos(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Obtiene la lista de todos los estadoPrestamo.
        /// </summary>
        /// <returns>Lista de estadoPrestamo</returns>
        public List<EstadoPrestamo> ListaEstadoPrestamos()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.EstadosPrestamos.ToList();
            }
        }
        /// <summary>
        /// Obtiene un estadoPrestamo por su ID.
        /// </summary>
        /// <param name="idAcceso">ID del acceso</param>
        /// <returns>EstadoPrestamo con el ID especificado</returns>
        public EstadoPrestamo ObtenerEstadoPrestamoPorId(long idEstadoPrestamos)
        {
            return _contexto.EstadosPrestamos.Find(idEstadoPrestamos);
        }
        /// <summary>
        /// Agrega un nuevo estadoPrestamo.
        /// </summary>
        /// <param name="acceso">Datos del nuevo estadoPrestamo</param>
        public void AgregarEstadoPrestamo(EstadoPrestamo estadoPrestamo)
        {
            _contexto.EstadosPrestamos.Add(estadoPrestamo);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Modifica un estadoPrestamos existente.
        /// </summary>
        /// <param name="estadoPrestamo">Datos del estadoPrestamos actualizado</param>
        public void ModificarEstadoPrestamo(EstadoPrestamo estadoPrestamo)
        {
            _contexto.EstadosPrestamos.Update(estadoPrestamo);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Elimina un estadoPrestamos por su ID.
        /// </summary>
        /// <param name="idEstadoPrestamos">ID del estadoPrestamos a eliminar</param>
        public void BorrarEstadoPrestamo(long idEstadoPrestamos)
        {
            var estadoPrestamo = _contexto.EstadosPrestamos.Find(idEstadoPrestamos);

            if (estadoPrestamo != null)
            {
                _contexto.EstadosPrestamos.Remove(estadoPrestamo);
                _contexto.SaveChanges();
            }
        }
    }
}


