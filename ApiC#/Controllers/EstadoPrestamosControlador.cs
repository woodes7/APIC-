using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadoPrestamoControlador : ControllerBase
    {
        private readonly ServicioEstadoPrestamos servicioEstadoPrestamo;

        public EstadoPrestamoControlador(ServicioEstadoPrestamos servicioEstadoPrestamo)
        {
            this.servicioEstadoPrestamo = servicioEstadoPrestamo;
        }

        [HttpGet]
        public List<EstadoPrestamo> Get()
        {
            return servicioEstadoPrestamo.ListaEstadoPrestamos();
        }

        [HttpGet("{id}")]
        public ActionResult<EstadoPrestamo> Get(int id)
        {
            var estadoPrestamo = servicioEstadoPrestamo.ObtenerEstadoPrestamoPorId(id);

            if (estadoPrestamo == null)
            {
                return NotFound();
            }

            return estadoPrestamo;
        }

        [HttpPost]
        public ActionResult<EstadoPrestamo> Post([FromBody] EstadoPrestamo estadoPrestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            servicioEstadoPrestamo.AgregarEstadoPrestamo(estadoPrestamo);

            return CreatedAtAction(nameof(Get), new { id = estadoPrestamo.IdEstadoPrestamo }, estadoPrestamo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EstadoPrestamo estadoPrestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadoPrestamo.IdEstadoPrestamo)
            {
                return BadRequest();
            }

            servicioEstadoPrestamo.ModificarEstadoPrestamo(estadoPrestamo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicioEstadoPrestamo.BorrarEstadoPrestamo(id);

            return NoContent();
        }
    }
}

