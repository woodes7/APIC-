using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Libro
    {
           
            //Primeary Key
            [Key]//Indicar que es una primary key
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
            public int idLibro { get; set; }

            public string? isbnLibro { get; set; }
            public string? tituloLibro { get; set; }
            public string? edicionLibro { get; set; }
            public int? cantidadLibro { get; set; }
            //ForeignKey de la tabla Editoriales
            public int idEditorial { get; set; }
            [ForeignKey("id_editorial")]
            public virtual Editorial Editorial { get; set; }

            //ForeignKey de la tabla Generos
            public int idGenero { get; set; }
            [ForeignKey("id_genero")]
            public virtual Genero Genero { get; set; }

            //ForeignKey de la tabla Generos
            public int idColeccion { get; set; }
            [ForeignKey("id_coleccion")]
            public virtual Coleccion Coleccion { get; set; }

            public List<Prestamo> Prestamos {  get; set; }
           
            public  List<Autor> Autores { get; set; }

        public Libro()
        {
            Autores = new List<Autor>();
            Prestamos = new List<Prestamo>();
        }
    }
}
