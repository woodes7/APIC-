using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Genero
    {
        //Primeary Key
        [Key]//Indicar que es una primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
        public int idGenero { get; set; }

        public string? nombreGenero { get; set; }
        public string? descripcionGenero { get; set; }

        public List<Libro> LibrosGenero { get; set; }
        public Genero()
        {
            LibrosGenero = new List<Libro>();
        }
    }
}
