using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Coleccion
    {   //Atributos

        //Primeary Key
        [Key]//Indicar que es una primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
        public int IdColeccion { get; set; }

        public string? NombreColeccion { get; set; }

        public List<Libro> LibrosColeccion { get; set; }

        //Constructor
        public Coleccion()
        {
            LibrosColeccion = new List<Libro>();
        }
    }
}
