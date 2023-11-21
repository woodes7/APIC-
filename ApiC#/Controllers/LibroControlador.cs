﻿using Microsoft.AspNetCore.Mvc;
using Modelo;
using Servicios;
using System.Collections.Generic;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibroControlador : ControllerBase
    {
        private readonly ServicioLibro servicioLibro;

        public LibroControlador(ServicioLibro servicioLibro)
        {
            this.servicioLibro = servicioLibro;
        }

        [HttpGet]
        public List<Libro> Get()
        {
            return servicioLibro.ListaLibros();
        }

        [HttpGet("{id}")]
        public ActionResult<Libro> Get(int id)
        {
            var libro = servicioLibro.ObtenerLibroPorId(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        [HttpPost]
        public ActionResult<Libro> Post([FromBody] Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            servicioLibro.AgregarLibro(libro);

            return CreatedAtAction(nameof(Get), new { id = libro.IdLibro }, libro);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != libro.IdLibro)
            {
                return BadRequest();
            }

            servicioLibro.ModificarLibro(libro);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicioLibro.BorrarLibro(id);

            return NoContent();
        }
    }
}
