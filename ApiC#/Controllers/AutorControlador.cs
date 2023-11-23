using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{/// <summary>
 /// Controlador de Acceso 
 /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AutorControlador : ControllerBase
    {   /// <summary>
        /// Servicio para gestionar operaciones relacionadas con las colecciones en la base de datos.
        /// </summary>
        private readonly ServicioAutor servicioAutor;

        /// <summary>
        /// Constructor del controlador de Autor
        /// </summary>
        /// <param name="servicioAutor">Servicio de Autor</param>
        public AutorControlador(ServicioAutor servicioAutor)
        {
            this.servicioAutor = servicioAutor;
        }
        /// <summary>
        /// Obtiene la lista de autor
        /// </summary>
        /// <returns>Lista de autor</returns>
        [HttpGet]
        public List<Autor> Get()
        {
            return servicioAutor.ListaAutores();
        }
        ///<summary>
        /// Obtiene un autor por su ID
        /// </summary>
        /// <param name="id">ID del autor</param>
        /// <returns>Autor con el ID especificado</returns>
        [HttpGet("{id}")]
        public ActionResult<Autor> Get(long id)
        {
            var autor = servicioAutor.ObtenerAutorPorId(id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }
        /// <summary>
        /// Agrega un nuevo autor
        /// </summary>
        /// <param name="autor">Datos del nuevo autor</param>
        /// <returns>Autor recién creado</returns>
        [HttpPost]
        public ActionResult<Autor> Post([FromBody] Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            servicioAutor.AgregarAutor(autor);

            return CreatedAtAction(nameof(Get), new { id = autor.IdAutor }, autor);
        }
        /// <summary>
        /// Modifica un autor existente
        /// </summary>
        /// <param name="id">ID del autor a modificar</param>
        /// <param name="autor">Nuevos datos para el autor</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autor.IdAutor)
            {
                return BadRequest();
            }

            servicioAutor.ModificarAutor(autor);

            return NoContent();
        }
        /// <summary>
        /// Borra un acceso por su ID
        /// </summary>
        /// <param name="IdAutor">ID del autor a borrar</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            servicioAutor.BorrarAutor(id);

            return NoContent();
        }
    }
}
