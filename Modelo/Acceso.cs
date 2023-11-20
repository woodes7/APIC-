using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Acceso
    {
        [Key]//Indicar que es una primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
        public int idAcceso { get; set; }
        public string? codigoAcceso { get; set; }
        public string? descripcionAcceso { get; set; }

        public List<Usuario> UsuariosConAcceso { get; set; }

        public Acceso()
        {
            UsuariosConAcceso=new List<Usuario>();
        }

    }
}
