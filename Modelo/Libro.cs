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
        //Atributos
        //Primeary Key
        [Key]//Indicar que es una primary key
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
            public int IdLibro { get; set; }

            public string? IsbnLibro { get; set; }
            public string? TituloLibro { get; set; }
            public string? EdicionLibro { get; set; }
            public int? CantidadLibro { get; set; }
            //ForeignKey de la tabla Editoriales
            public int IdEditorial { get; set; }
            [ForeignKey("id_editorial")]
            public virtual Editorial Editorial { get; set; }

            //ForeignKey de la tabla Generos
            public int IdGenero { get; set; }
            [ForeignKey("id_genero")]
            public virtual Genero Genero { get; set; }

            //ForeignKey de la tabla Generos
            public int IdColeccion { get; set; }
            [ForeignKey("id_coleccion")]
            public virtual Coleccion Coleccion { get; set; }

            public List<Prestamo> Prestamos {  get; set; }
           
            public  List<Autor> Autores { get; set; }
        //Constructor
        public Libro()
        {
            Autores = new List<Autor>();
            Prestamos = new List<Prestamo>();
        }
    }
}
