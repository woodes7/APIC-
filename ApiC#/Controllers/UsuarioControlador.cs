using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioControlador : ControllerBase
    {

        private ServicioUsuario servicioUsuario;

        public UsuarioControlador()
        {
            servicioUsuario = new ServicioUsuario();
        }

        [HttpGet]
        [Route("")]
        public List<Usuario> ListaUsuario()
        {
            return servicioUsuario.ListaUsuario();
        }

    }
}
