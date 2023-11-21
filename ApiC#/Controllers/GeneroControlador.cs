using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroControlador : ControllerBase
    {
        private readonly GeneroServicio generoServicio;

        public GeneroControlador(GeneroServicio generoServicio)
        {
            this.generoServicio = generoServicio;
        }

        [HttpGet]
        public IEnumerable<Genero> Get()
        {
            return generoServicio.ListaGeneros();
        }

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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            generoServicio.BorrarGenero(id);

            return NoContent();
        }
    }
}

