using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrestamoControlador : ControllerBase
    {
        private readonly PrestamoServicio prestamoServicio;

        public PrestamoControlador(PrestamoServicio prestamoServicio)
        {
            this.prestamoServicio = prestamoServicio;
        }

        [HttpGet]
        public IEnumerable<Prestamo> Get()
        {
            return prestamoServicio.ListaPrestamos();
        }

        [HttpGet("{id}")]
        public ActionResult<Prestamo> Get(int id)
        {
            var prestamo = prestamoServicio.ObtenerPrestamoPorId(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return prestamo;
        }

        [HttpPost]
        public ActionResult<Prestamo> Post([FromBody] Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            prestamoServicio.AgregarPrestamo(prestamo);

            return CreatedAtAction(nameof(Get), new { id = prestamo.IdPrestamo }, prestamo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestamo.IdPrestamo)
            {
                return BadRequest();
            }

            prestamoServicio.ModificarPrestamo(prestamo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            prestamoServicio.BorrarPrestamo(id);

            return NoContent();
        }
    }
}
