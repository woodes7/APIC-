using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibroControlador : ControllerBase
    {
        private readonly ServicioLibros servicoLibro;

        public LibroControlador(ServicioLibros servicoLibro)
        {
            this.servicoLibro = servicoLibro;
        }

        [HttpGet]
        public IEnumerable<Libro> Get()
        {
            return servicoLibro.ListaLibros();
        }

        [HttpGet("{id}")]
        public ActionResult<Libro> Get(int id)
        {
            var libro = servicoLibro.ObtenerLibroPorId(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        [HttpPost]
        public ActionResult<Libro> Post([FromBody] Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            servicoLibro.AgregarLibro(libro);

            return CreatedAtAction(nameof(Get), new { id = libro.IdLibro }, libro);
        }

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

            servicoLibro.ModificarLibro(libro);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicoLibro.BorrarLibro(id);

            return NoContent();
        }
    }
}
