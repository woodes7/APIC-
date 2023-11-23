using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{   /// <summary>
    /// Controlador de Prestamo 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PrestamoControlador : ControllerBase
    {   /// <summary>
        /// Servicio para gestionar operaciones relacionadas con las colecciones en la base de datos.
        /// </summary>
        private readonly ServicioPrestamo servicioprestamo;
        /// <summary>
        /// Constructor del controlador de prestamo
        /// </summary>
        /// <param name="prestamoServicio">Servicio de prestamo</param>
        public PrestamoControlador(ServicioPrestamo prestamoServicio)
        {
            this.servicioprestamo = prestamoServicio;
        }
        /// <summary>
        /// Obtiene la lista de prestamo
        /// </summary>
        /// <returns>Lista de prestamo</returns>
        [HttpGet]
        public List<Prestamo> Get()
        {
            return servicioprestamo.ListaPrestamos();
        }
        ///<summary>
        /// Obtiene un prestamo por su ID
        /// </summary>
        /// <param name="id">ID del prestamo</param>
        /// <returns>Prestamo con el ID prestamo</returns>
        [HttpGet("{id}")]
        public ActionResult<Prestamo> Get(int id)
        {
            var prestamo = servicioprestamo.ObtenerPrestamoPorId(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return prestamo;
        }
        /// <summary>
        /// Agrega un nuevo prestamo
        /// </summary>
        /// <param name="prestamo">Datos del nuevo prestamo</param>
        /// <returns>Prestamo recién creado</returns>
        [HttpPost]
        public ActionResult<Prestamo> Post([FromBody] Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            servicioprestamo.AgregarPrestamo(prestamo);

            return CreatedAtAction(nameof(Get), new { id = prestamo.IdPrestamo }, prestamo);
        }
        /// <summary>
        /// Modifica un prestamo existente
        /// </summary>
        /// <param name="id">ID del prestamo a modificar</param>
        /// <param name="estadoPrestamo">Nuevos datos para el prestamo</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestamo.IdPrestamo)
            {
                return BadRequest();
            }

            servicioprestamo.ModificarPrestamo(prestamo);

            return NoContent();
        }

        /// /// <summary>
        /// Borra un prestamo por su ID
        /// </summary>
        /// <param name="id">ID del autor a borrar</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicioprestamo.BorrarPrestamo(id);

            return NoContent();
        }
    }
}
