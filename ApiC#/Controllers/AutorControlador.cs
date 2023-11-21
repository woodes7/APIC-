using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorControlador : ControllerBase
    {
        private readonly ServicioAutor servicioAutor;

        public AutorControlador(ServicioAutor servicioAutor)
        {
            this.servicioAutor = servicioAutor;
        }

        [HttpGet]
        public List<Autor> Get()
        {
            return servicioAutor.ListaAutores();
        }

        [HttpGet("{id}")]
        public ActionResult<Autor> Get(int id)
        {
            var autor = servicioAutor.ObtenerAutorPorId(id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

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

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Autor autor)
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicioAutor.BorrarAutor(id);

            return NoContent();
        }
    }
}
