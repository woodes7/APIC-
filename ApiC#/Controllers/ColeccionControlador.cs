using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{
    /// <summary>
    /// Controlador para operaciones relacionadas con las colecciones.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ColeccionController : ControllerBase
    {
        private readonly ServicioColeccion servicioColeccion;

        /// <summary>
        /// Constructor del controlador de colecciones.
        /// </summary>
        /// <param name="servicioColeccion">Servicio de colecciones</param>
        public ColeccionController(ServicioColeccion servicioColeccion)
        {
            this.servicioColeccion = servicioColeccion;
        }

        /// <summary>
        /// Obtiene la lista de colecciones.
        /// </summary>
        /// <returns>Lista de colecciones</returns>
        [HttpGet]
        public ActionResult<List<Coleccion>> Get()
        {
            var colecciones = servicioColeccion.ListColeccion();

            if (colecciones.Count == 0)
            {
                return NoContent(); // 204 No Content si no hay colecciones
            }

            return colecciones;
        }

        /// <summary>
        /// Obtiene una colección por su ID.
        /// </summary>
        /// <param name="id">ID de la colección</param>
        /// <returns>Colección con el ID especificado</returns>
        [HttpGet("{id}")]
        public ActionResult<Coleccion> Get(int id)
        {
            var coleccion = servicioColeccion.ObtenerColeccionPorId(id);

            if (coleccion == null)
            {
                return NotFound(); // 404 Not Found si la colección no se encuentra
            }

            return coleccion;
        }

        /// <summary>
        /// Agrega una nueva colección.
        /// </summary>
        /// <param name="coleccion">Datos de la nueva colección</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost]
        public ActionResult<Coleccion> Post([FromBody] Coleccion coleccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            servicioColeccion.AgregarColeccion(coleccion);

            return CreatedAtAction(nameof(Get), new { id = coleccion.IdColeccion }, coleccion);
        }

        /// <summary>
        /// Modifica una colección existente.
        /// </summary>
        /// <param name="id">ID de la colección a modificar</param>
        /// <param name="coleccion">Nuevos datos para la colección</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Coleccion coleccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coleccion.IdColeccion)
            {
                return BadRequest(); // 400 Bad Request si el ID no coincide
            }

            servicioColeccion.ModificarColeccion(coleccion);

            return NoContent(); // 204 No Content si la actualización fue exitosa
        }

        /// <summary>
        /// Elimina una colección por su ID.
        /// </summary>
        /// <param name="id">ID de la colección a eliminar</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicioColeccion.BorrarColeccion(id);

            return NoContent(); // 204 No Content si la eliminación fue exitosa
        }
    }
}
