using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccesoControlador : ControllerBase
    {
        private readonly ServicioAcceso servicioAcceso;

        public AccesoControlador(ServicioAcceso servicioAcceso)
        {
            this.servicioAcceso = servicioAcceso;
        }

        [HttpGet]
        public List<Acceso> ListaAccesos()
        {
            return servicioAcceso.ListaAccesos();
        }

        [HttpGet("{id}")]
        public ActionResult<Acceso> ObtenerAccesoPorId(int id)
        {
            var acceso = servicioAcceso.ObtenerAccesoPorId(id);

            if (acceso == null)
            {
                return NotFound();
            }

            return acceso;
        }

        [HttpPost]
        public ActionResult<Acceso> AgregarAcceso([FromBody] Acceso acceso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            servicioAcceso.AgregarAcceso(acceso);

            return CreatedAtAction(nameof(ObtenerAccesoPorId), new { id = acceso.IdAcceso }, acceso);
        }

        [HttpPut("{id}")]
        public IActionResult ModificarAcceso(int id, [FromBody] Acceso acceso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acceso.IdAcceso)
            {
                return BadRequest();
            }

            servicioAcceso.ModificarAcceso(acceso);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarAcceso(int id)
        {
            servicioAcceso.BorrarAcceso(id);

            return NoContent();
        }
    }
}
