using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{    /// <summary>
     /// Controlador para operaciones relacionadas con las estadoPrestamo.
     /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EstadoPrestamoControlador : ControllerBase
    {
        /// <summary>
        /// Servicio para gestionar operaciones relacionadas con las colecciones en la base de datos.
        /// </summary>
        private readonly ServicioEstadoPrestamos servicioEstadoPrestamo;

        /// <summary>
        /// Constructor del controlador de estadoPrestamo
        /// </summary>
        /// <param name="servicioEstadoPrestamo">Servicio de estadoPrestamo</param>
        public EstadoPrestamoControlador(ServicioEstadoPrestamos servicioEstadoPrestamo)
        {
            this.servicioEstadoPrestamo = servicioEstadoPrestamo;
        }
        /// <summary>
        /// Obtiene la lista de estadoPrestamo
        /// </summary>
        /// <returns>Lista de estadoPrestamo</returns>
        [HttpGet]
        public List<EstadoPrestamo> Get()
        {
            return servicioEstadoPrestamo.ListaEstadoPrestamos();
        }
        ///<summary>
        /// Obtiene un estadoPrestamo por su ID
        /// </summary>
        /// <param name="id">ID del estadoPrestamo</param>
        /// <returns>EstadoPrestamo con el ID especificado</returns>
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
        /// <summary>
        /// Agrega un nuevo estadoPrestamo
        /// </summary>
        /// <param name="estadoPrestamo">Datos del nuevo estadoPrestamo</param>
        /// <returns>EstadoPrestamo recién creado</returns>
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
        /// <summary>
        /// Modifica un estadoPrestamo existente
        /// </summary>
        /// <param name="id">ID del estadoPrestamo a modificar</param>
        /// <param name="estadoPrestamo">Nuevos datos para el estadoPrestamo</param>
        /// <returns>Respuesta sin contenido</returns>
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
        /// <summary>
        /// Borra un estadoPrestamo por su ID
        /// </summary>
        /// <param name="id">ID del estadoPrestamo a borrar</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicioEstadoPrestamo.BorrarEstadoPrestamo(id);

            return NoContent();
        }
    }
}

