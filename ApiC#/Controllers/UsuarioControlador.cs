using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{    /// <summary>
     /// Controlador de Usuario 
     /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UsuarioControlador : ControllerBase
    {     /// <summary>
          /// Servicio para gestionar operaciones relacionadas con las colecciones en la base de datos.
          /// </summary>
        private readonly ServicioUsuario servicioUsuario;
        /// <summary>
        /// Constructor del controlador de usuario
        /// </summary>
        /// <param name="servicioUsuario">Servicio de usuario</param>
        public UsuarioControlador(ServicioUsuario servicioUsuario)
        {
            this.servicioUsuario = servicioUsuario;
        }
        /// <summary>
        /// Obtiene la lista de usuario
        /// </summary>
        /// <returns>Lista de usuario</returns>
        [HttpGet]
        public List<Usuario> ListaUsuarios()
        {
            return servicioUsuario.ListaUsuarios();
        }
        ///<summary>
        /// Obtiene un usuario por su ID
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <returns>Usuario con el ID especificado</returns>
        [HttpGet("{id}")]
        public ActionResult<Usuario> ObtenerUsuarioPorId(long id)
        {
            var usuario = servicioUsuario.ObtenerUsuarioPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
        /// <summary>
        /// Agrega un nuevo usuario
        /// </summary>
        /// <param name="estadoPrestamo">Datos del nuevo usuario</param>
        /// <returns>Usuario recién creado</returns>
        [HttpPost]
        public ActionResult<Usuario> AgregarUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            servicioUsuario.AgregarUsuario(usuario);

            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { IdUsuario = usuario.IdUsuario }, usuario);
        }
        /// <summary>
        /// Modifica un usuario existente
        /// </summary>
        /// <param name="id">ID del usuario a modificar</param>
        /// <param name="usuario">Nuevos datos para el usuario</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpPut("{id}")]
        public IActionResult ModificarUsuario(long id, [FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            servicioUsuario.ModificarUsuario(usuario);

            return NoContent();
        }
        /// <summary>
        /// Borra un usuario por su ID
        /// </summary>
        /// <param name="id">ID del usuario a borrar</param>
        /// <returns>Respuesta sin contenido</returns>
        [HttpDelete("{id}")]
        public IActionResult BorrarUsuario(long id)
        {
            servicioUsuario.BorrarUsuario(id);

            return NoContent();
        }
    }
}
