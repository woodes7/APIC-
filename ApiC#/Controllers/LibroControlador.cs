using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{   /// <summary>
    /// Controlador de Libro 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LibroControlador : ControllerBase
    { /// <summary>
      /// Servicio para gestionar operaciones relacionadas con las colecciones en la base de datos.
      /// </summary>
        private readonly ServicioLibro servicioLibro;
        /// <summary>
        /// Constructor del controlador de libro
        /// </summary>
        /// <param name="servicioLibro">Servicio de Libro</param>
        public LibroControlador(ServicioLibro servicioLibro)
        {
            this.servicioLibro = servicioLibro;
        }
        /// <summary>
        /// Obtiene la lista de libro
        /// </summary>
        /// <returns>Lista de libro</returns>
        [HttpGet]
        public List<Libro> Get()
        {
            return servicioLibro.ListaLibros();
        }
        ///<summary>
        /// Obtiene un Libro por su ID
        /// </summary>
        /// <param name="id">ID del libro</param>
        /// <returns>Libro con el ID especificado</returns>
        [HttpGet("{id}")]
        public ActionResult<Libro> Get(int id)
        {
            var libro = servicioLibro.ObtenerLibroPorId(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }
        /// <summary>
        /// Agrega un nuevo libro
        /// </summary>
        /// <param name="libro">Datos del nuevo libro</param>
        /// <returns>Libro recién creado</returns>
        [HttpPost]
        public ActionResult<Libro> Post([FromBody] Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            servicioLibro.AgregarLibro(libro);

            return CreatedAtAction(nameof(Get), new { id = libro.IdLibro }, libro);
        }
        /// <summary>
        /// Modifica un libro existente
        /// </summary>
        /// <param name="id">ID del libro a modificar</param>
        /// <param name="libro">Nuevos datos para el libro</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != libro.IdLibro)
            {
                return BadRequest();
            }

            servicioLibro.ModificarLibro(libro);

            return NoContent();
        }
        /// <summary>
        /// Borra un libro por su ID
        /// </summary>
        /// <param name="id">ID del autor a borrar</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicioLibro.BorrarLibro(id);

            return NoContent();
        }
    }
}
