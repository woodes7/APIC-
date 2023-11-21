using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Servicios
{
    public class ServicioEstadoPrestamos
    {
        private readonly ApiDBContexto _contexto;
        public ServicioEstadoPrestamos(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }
        public List<EstadoPrestamo> ListaEstadoPrestamos()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.EstadosPrestamos.ToList();
            }
        }      

        public EstadoPrestamo ObtenerEstadoPrestamoPorId(long idEstadoPrestamos)
        {
            return _contexto.EstadosPrestamos.Find(idEstadoPrestamos);
        }

        public void AgregarEstadoPrestamo(EstadoPrestamo estadoPrestamo)
        {
            _contexto.EstadosPrestamos.Add(estadoPrestamo);
            _contexto.SaveChanges();
        }

        public void ModificarEstadoPrestamo(EstadoPrestamo estadoPrestamo)
        {
            _contexto.EstadosPrestamos.Update(estadoPrestamo);
            _contexto.SaveChanges();
        }

        public void BorrarEstadoPrestamo(long idEstadoPrestamos)
        {
            var estadoPrestamo = _contexto.EstadosPrestamos.Find(idEstadoPrestamos);

            if (estadoPrestamo != null)
            {
                _contexto.EstadosPrestamos.Remove(estadoPrestamo);
                _contexto.SaveChanges();
            }
        }
    }
}


