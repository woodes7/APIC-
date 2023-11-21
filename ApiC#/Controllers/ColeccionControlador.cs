using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColeccionControlador : ControllerBase
    {
        
        private ServicioColeccion servicioColeccion;

        public ColeccionControlador()
        {
            this.servicioColeccion = new ServicioColeccion();
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Coleccion> Get()
        {
            List<Coleccion> listaColecciones = new List<Coleccion>();
            return listaColecciones;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Colecciones coleccion)
        {
            _contexto.Add(coleccion);

        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public void Put([FromBody] Colecciones coleccion)
        {
            _contexto.Update<Colecciones>(coleccion);

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public void Delete([FromBody] Colecciones coleccion)
        {
            _contexto.Remove<Colecciones>(coleccion);

        }
    }
}
