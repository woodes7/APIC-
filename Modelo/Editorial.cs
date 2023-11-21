using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Editorial
    {
        //Primeary Key
        [Key]//Indicar que es una primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
        public int IdEditorial { get; set; }

        public string? NombreEditorial { get; set; }

        public List<Libro> LibrosEditorial { get; set; }

        public Editorial()
        {
            LibrosEditorial = new List<Libro>();
        }
    }
}
