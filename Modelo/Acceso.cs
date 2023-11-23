using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Acceso
    {   //Atributos
        [Key]//Indicar que es una primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
        public int IdAcceso { get; set; }
        public string? CodigoAcceso { get; set; }
        public string? DescripcionAcceso { get; set; }
        
        public List<Usuario> UsuariosConAcceso { get; set; }
        
        //Constructor
        public Acceso()
        {
            UsuariosConAcceso=new List<Usuario>();
        }

    }
}
