using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Modelo.Libro;

namespace Modelo
{
    [PrimaryKey(nameof(idPrestamo), nameof(idLibro))]
    public class RelaccionLibroPrestamo
    {
        public int idPrestamo { get; set; }

        public virtual Prestamo prestamo { get; set; }

        public int idLibro { get; set; }

        public virtual Libro libro { get; set; }
    }
}
