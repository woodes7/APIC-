using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;

namespace ApiC_.Controllers
{
    public class AccesoControlador : ControllerBase
    {

        private ServicioAcceso servicioAcceso;

        public AccesoControlador()
        {
            servicioAcceso = new ServicioAcceso();
        }

        [HttpGet]
        [Route("")]
        public List<Acceso> ListaUsuario()
        {
            return servicioAcceso.ListAcceso();
        }
    }
}
