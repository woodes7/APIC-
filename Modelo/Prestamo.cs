using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Prestamo
    {
        //Primeary Key
        [Key]//Indicar que es una primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para idicar que es incrementable
        public int IdPrestamo { get; set; }

        //ForeignKey de la tabla Usuarios
        public int Id_usuario { get; set; }
        [ForeignKey("idUsuario")]
        public virtual Usuario Usuarios { get; set; }
        public virtual EstadoPrestamo EstadoPrestamo { get; set; }

        //Campos de tiempos
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? FchaInicPrestamo { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? FchFinPrestamo { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? FchEtregPrestamo { get; set; }

        //ForeignKey de la tabla Estado Prestamo
        public int IdEstadoPrestamo { get; set; }
        [ForeignKey("idEstadoPrestamo")]
          
        public virtual List<Prestamo> PrestamosLibros { get; set; }

        public Prestamo()
        {
            PrestamosLibros = new List<Prestamo>();
        }

    }
}
