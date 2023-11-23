using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioPrestamo
    {   /// <summary>
        /// Contexto de base de datos utilizado por el servicio para acceder y manipular datos de prestamo.
        /// </summary>
        private readonly ApiDBContexto _contexto;
        /// <summary>
        /// Servicio para gestionar operaciones relacionadas con los prestamo en la base de datos.
        /// </summary>
        /// <param name="contexto">Contexto de base de datos</param>

        public ServicioPrestamo(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Obtiene la lista de todos los prestamo.
        /// </summary>
        /// <returns>Lista de prestamo</returns>
        public List<Prestamo> ListaPrestamos()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Prestamos.ToList();
            }
        }
        /// <summary>
        /// Obtiene un acceso por su ID.
        /// </summary>
        /// <param name="idPrestamo">ID del prestamo</param>
        /// <returns>Pprestamo con el ID especificado</returns>
        public Prestamo ObtenerPrestamoPorId(long idPrestamo)
        {
            return _contexto.Prestamos.Find(idPrestamo);
        }
        /// <summary>
        /// Agrega un nuevo prestamo.
        /// </summary>
        /// <param name="acceso">Datos del nuevo prestamo</param>
        public void AgregarPrestamo(Prestamo prestamo)
        {
            _contexto.Prestamos.Add(prestamo);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Modifica un prestamo existente.
        /// </summary>
        /// <param name="prestamo">Datos del prestamo actualizado</param>
        public void ModificarPrestamo(Prestamo prestamo)
        {
            _contexto.Prestamos.Update(prestamo);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Elimina un prestamo por su ID.
        /// </summary>
        /// <param name="idPrestamo">ID del prestamo a eliminar</param>
        public void BorrarPrestamo(long idPrestamo)
        {
            var prestamo = _contexto.Prestamos.Find(idPrestamo);

            if (prestamo != null)
            {
                _contexto.Prestamos.Remove(prestamo);
                _contexto.SaveChanges();
            }
        }
    }
}

