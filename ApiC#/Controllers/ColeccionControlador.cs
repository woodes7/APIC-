using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColeccionControlador : ControllerBase
    {
        private readonly ServicioColeccion servicioColeccion;

        public ColeccionControlador(ServicioColeccion servicioColeccion)
        {
            this.servicioColeccion = servicioColeccion;
        }

        // GET: api/ColeccionControlador
        [HttpGet]
        public IEnumerable<Coleccion> Get()
        {
            return servicioColeccion.ListColeccion();
        }

        // GET api/ColeccionControlador/5
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

        // POST api/ColeccionControlador
        [HttpPost]
        public ActionResult<Coleccion> Post([FromBody] Coleccion coleccion)
        {
            // Validar el modelo antes de agregarlo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            servicioColeccion.AgregarColeccion(coleccion);

            // Devolver la colección recién creada y la URL de ubicación
            return CreatedAtAction(nameof(Get), new { id = coleccion.IdColeccion }, coleccion);
        }

        // PUT api/ColeccionControlador/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Coleccion coleccion)
        {
            // Validar el modelo antes de actualizarlo
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

        // DELETE api/ColeccionControlador/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicioColeccion.BorrarColeccion(id);

            return NoContent(); // 204 No Content si la eliminación fue exitosa
        }
    }
}
