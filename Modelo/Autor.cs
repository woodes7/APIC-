using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Autor
    {
        //Primeary Key
        [Key]//Indicar que es una primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
        public int IdAutor { get; set; }

        public string NombreAutor { get; set; }
        public string ApellidosAutor { get; set; }

        public List<Libro> ListaLibros {  get; set; }

        public Autor()
        {
            ListaLibros = new List<Libro>();
        }
    }
}
