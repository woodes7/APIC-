using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Coleccion
    {

        //Primeary Key
        [Key]//Indicar que es una primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
        public int idColeccion { get; set; }

        public string? nombreColeccion { get; set; }

        public List<Libro> LibrosColeccion { get; set; }

        public Coleccion()
        {
            LibrosColeccion = new List<Libro>();
        }
    }
}
