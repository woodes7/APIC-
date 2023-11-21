using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioControlador : ControllerBase
    {
        private readonly ServicioUsuario servicioUsuario;

        public UsuarioControlador(ServicioUsuario servicioUsuario)
        {
            this.servicioUsuario = servicioUsuario;
        }

        [HttpGet]
        public List<Usuario> ListaUsuarios()
        {
            return servicioUsuario.ListaUsuarios();
        }

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

        [HttpDelete("{id}")]
        public IActionResult BorrarUsuario(long id)
        {
            servicioUsuario.BorrarUsuario(id);

            return NoContent();
        }
    }
}
