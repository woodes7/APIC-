using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorControlador : ControllerBase
    {
        private ServicioAutor servicioAutor;

        public AutorControlador(ServicioAutor servicioAutor)
        {
            this.servicioAutor = servicioAutor;
        }

        [HttpGet]
        [Route("")]
        public List<Usuario> ListaAutores()
        {
            return servicioAutor.ListaAutores();
        }

    }
}



