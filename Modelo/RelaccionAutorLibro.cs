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
    [PrimaryKey(nameof(IdAutor), nameof(IdLibro))]
    public class RelaccionAutorLibro
    {   //Atributos
        public int IdAutor { get; set; }
        public virtual Autor Autor { get; set; }
        public int IdLibro { get; set; }

        public virtual Libro Libro { get; set; }

    }
}
