using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Autor
    {

        //Primeary Key
        [Key]//Indicar que es una primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
        public int idAutor { get; set; }

        public string nombreAutor { get; set; }
        public string apellidosAutor { get; set; }

        public List<Libro> Libros {  get; set; }

        public Autor()
        {
            Libros = new List<Libro>();
        }
    }
}
