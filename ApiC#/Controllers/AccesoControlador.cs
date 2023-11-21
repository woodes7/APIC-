using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{
    /// <summary>
    /// Controlador de Acceso 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AccesoControlador : ControllerBase
    {
        private readonly ServicioAcceso servicioAcceso;

        /// <summary>
        /// Constructor del controlador de Acceso
        /// </summary>
        /// <param name="servicioAcceso">Servicio de Acceso</param>
        public AccesoControlador(ServicioAcceso servicioAcceso)
        {
            this.servicioAcceso = servicioAcceso;
        }

        /// <summary>
        /// Obtiene la lista de accesos
        /// </summary>
        /// <returns>Lista de accesos</returns>
        [HttpGet]
        public ActionResult<List<Acceso>> ListaAccesos()
        {
            var accesos = servicioAcceso.ListaAccesos();

            if (accesos.Count == 0)
            {
                return NoContent(); // O cualquier otro código de estado que sea apropiado
            }

            return accesos;
        }

        /// <summary>
        /// Obtiene un acceso por su ID
        /// </summary>
        /// <param name="id">ID del acceso</param>
        /// <returns>Acceso con el ID especificado</returns>
        [HttpGet("{id}")]
        public ActionResult<Acceso> ObtenerAccesoPorId(long id)
        {
            var acceso = servicioAcceso.ObtenerAccesoPorId(id);

            if (acceso == null)
            {
                return NotFound();
            }

            return acceso;
        }

        /// <summary>
        /// Agrega un nuevo acceso
        /// </summary>
        /// <param name="acceso">Datos del nuevo acceso</param>
        /// <returns>Acceso recién creado</returns>
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

        /// <summary>
        /// Modifica un acceso existente
        /// </summary>
        /// <param name="id">ID del acceso a modificar</param>
        /// <param name="acceso">Nuevos datos para el acceso</param>
        /// <returns>Respuesta sin contenido</returns>
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

        /// <summary>
        /// Borra un acceso por su ID
        /// </summary>
        /// <param name="id">ID del acceso a borrar</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpDelete("{id}")]
        public IActionResult BorrarAcceso(long id)
        {
            servicioAcceso.BorrarAcceso(id);

            return NoContent();
        }
    }
}
