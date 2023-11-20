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
        public int idUsuario { get; set; }

        public string dni { get; set; }
        public string? nombre { get; set; }
        public string? apellidos { get; set; }
        public string? telefono { get; set; }

        public string? email { get; set; }
        public string clave { get; set; }

        public int idAcceso { get; set; }
        [ForeignKey("idAcceso")]
        public virtual Acceso Acceso { get; set; }
        public bool? estaBloqueado_usuario { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? fchFinBloqueo_usuario { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? fchAltaUsuario { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? fchBajaUsuario { get; set; }

        public List<Prestamo> ListaUsuariosPrestamos;

        public Usuario()
        {
            ListaUsuariosPrestamos = new List<Prestamo>();
        }
    }

}
