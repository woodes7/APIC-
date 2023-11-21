using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class EditorialControlador : ControllerBase
        {
            private readonly ServicioEditorial servicioEditorial;

            public EditorialControlador(ServicioEditorial servicioEditorial)
            {
                this.servicioEditorial = servicioEditorial;
            }

            [HttpGet]
            public IEnumerable<Editorial> Get()
            {
                return servicioEditorial.ListaEditoriales();
            }

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

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                servicioEditorial.BorrarEditorial(id);

                return NoContent();
            }
        }
    }

