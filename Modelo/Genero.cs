using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Genero
    {   //Atributos
        //Primeary Key
        [Key]//Indicar que es una primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
        public int IdGenero { get; set; }

        public string? NombreGenero { get; set; }
        public string? DescripcionGenero { get; set; }

        public List<Libro> LibrosGenero { get; set; }
        //Constructor
        public Genero()
        {
            LibrosGenero = new List<Libro>();
        }
    }
}
