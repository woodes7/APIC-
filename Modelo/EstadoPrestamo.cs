using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class EstadoPrestamo
    {
        //Primeary Key
        [Key]//Indicar que es una primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
        public int IdEstadoPrestamo { get; set; }

        public string CodigoEstadoPrestamo { get; set; }
        public string DescripcionEstadoPrestamo { get; set; }


    }
}
