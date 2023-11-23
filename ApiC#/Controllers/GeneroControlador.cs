using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{   /// <summary>
    /// Controlador para operaciones relacionadas con las Genero.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GeneroControlador : ControllerBase
        {/// <summary>
         /// Servicio para gestionar operaciones relacionadas con las colecciones en la base de datos.
         /// </summary>
        private readonly GeneroServicio generoServicio;
        /// <summary>
        /// Constructor del controlador de Genero
        /// </summary>
        /// <param name="generoServicio">Servicio de Genero</param>
        public GeneroControlador(GeneroServicio generoServicio)
        {
            this.generoServicio = generoServicio;
        }
        /// <summary>
        /// Obtiene la lista de Genero
        /// </summary>
        /// <returns>Lista de Genero</returns>
        [HttpGet]
        public List<Genero> Get()
        {
            return generoServicio.ListaGeneros();
        }
        ///<summary>
        /// Obtiene un Genero por su ID
        /// </summary>
        /// <param name="id">ID del Genero</param>
        /// <returns>Autor con el ID especificado</returns>
        [HttpGet("{id}")]
        [HttpGet("{id}")]
        public ActionResult<Genero> Get(int id)
        {
            var genero = generoServicio.ObtenerGeneroPorId(id);

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }
        /// <summary>
        /// Agrega un nuevo Genero
        /// </summary>
        /// <param name="genero">Datos del nuevo Genero</param>
        /// <returns>Editorial recién creado</returns>
        [HttpPost]
        public ActionResult<Genero> Post([FromBody] Genero genero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            generoServicio.AgregarGenero(genero);

            return CreatedAtAction(nameof(Get), new { id = genero.IdGenero }, genero);
        }
        /// <summary>
        /// Modifica un Genero existente
        /// </summary>
        /// <param name="id">ID del Genero a modificar</param>
        /// <param name="genero">Nuevos datos para el Genero</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Genero genero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genero.IdGenero)
            {
                return BadRequest();
            }

            generoServicio.ModificarGenero(genero);

            return NoContent();
        }
        /// <summary>
        /// Borra un Genero por su ID
        /// </summary>
        /// <param name="id">ID del autor a borrar</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            generoServicio.BorrarGenero(id);

            return NoContent();
        }
    }
}

