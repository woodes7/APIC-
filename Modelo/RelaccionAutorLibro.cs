using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Modelo
{
    [PrimaryKey(nameof(idAutor), nameof(idLibro))]
    public class RelaccionAutorLibro
    {
        public int idAutor { get; set; }
        public virtual Autor Autor { get; set; }
        public int idLibro { get; set; }

        public virtual Libro Libro { get; set; }

    }
}
