using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {


        [Key]//Indicar que es una primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
        public int IdUsuario { get; set; }

        public string Dni { get; set; }
        public string? Napellidos { get; set; }
        public string? Telefono { get; set; }

        public string? Email { get; set; }
        public string Clave { get; set; }

        public int IdAcceso { get; set; }
        [ForeignKey("idAcceso")]
        public virtual Acceso Acceso { get; set; }
        public bool? EstaBloqueadoUsuario { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? FchFinBloqueoUsuario { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? FchAltaUsuario { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? FchBajaUsuario { get; set; }

        public List<Prestamo> ListaUsuariosPrestamos;

        public Usuario()
        {
            ListaUsuariosPrestamos = new List<Prestamo>();
        }
    }

}s
