using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{   /// <summary>
    /// Controlador para operaciones relacionadas con las editorial.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EditorialControlador : ControllerBase
    {   /// <summary>
        /// Servicio para gestionar operaciones relacionadas con las colecciones en la base de datos.
        /// </summary>
        private readonly ServicioEditorial servicioEditorial;

        /// <summary>
        /// Constructor del controlador de editorial
        /// </summary>
        /// <param name="servicioEditorial">Servicio de editorial</param>
        public EditorialControlador(ServicioEditorial servicioEditorial)
        {
            this.servicioEditorial = servicioEditorial;
        }
        /// <summary>
        /// Obtiene la lista de editorial
        /// </summary>
        /// <returns>Lista de editorial</returns>
        [HttpGet]
        public List<Editorial> Get()
        {
            return servicioEditorial.ListaEditoriales();
        }
        ///<summary>
        /// Obtiene un editorial por su ID
        /// </summary>
        /// <param name="id">ID del editorial</param>
        /// <returns>Autor con el ID especificado</returns>
        [HttpGet("{id}")]
        public ActionResult<Editorial> Get(int id)
        {
            var editorial = servicioEditorial.ObtenerEditorialPorId(id);

            if (editorial == null)
            {
                return NotFound();
            }

            return editorial;
        }
        /// <summary>
        /// Agrega un nuevo editorial
        /// </summary>
        /// <param name="editorial">Datos del nuevo editorial</param>
        /// <returns>Editorial recién creado</returns>
        [HttpPost]
        public ActionResult<Editorial> Post([FromBody] Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            servicioEditorial.AgregarEditorial(editorial);

            return CreatedAtAction(nameof(Get), new { id = editorial.IdEditorial }, editorial);
        }
        /// <summary>
        /// Modifica un editorial existente
        /// </summary>
        /// <param name="id">ID del editorial a modificar</param>
        /// <param name="editorial">Nuevos datos para el editorial</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != editorial.IdEditorial)
            {
                return BadRequest();
            }

            servicioEditorial.ModificarEditorial(editorial);

            return NoContent();
        }
        /// <summary>
        /// Borra un editorial por su ID
        /// </summary>
        /// <param name="id">ID del autor a borrar</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            servicioEditorial.BorrarEditorial(id);

            return NoContent();
        }
    }
}

