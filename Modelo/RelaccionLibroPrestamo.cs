using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Modelo.Libro;

namespace Modelo
{
    [PrimaryKey(nameof(IdPrestamo), nameof(IdLibro))]
    public class RelaccionLibroPrestamo
    {   //Atributos
        public int IdPrestamo { get; set; }

        public virtual Prestamo Prestamo { get; set; }

        public int IdLibro { get; set; }

        public virtual Libro Libro { get; set; }
    }
}
