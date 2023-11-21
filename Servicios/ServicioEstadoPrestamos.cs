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

        public EstadoPrestamo ObtenerEstadoPrestamoPorId(int id)
        {
            return _contexto.EstadosPrestamos.Find(id);
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

        public void BorrarEstadoPrestamo(int idEstadoPrestamo)
        {
            var estadoPrestamo = _contexto.EstadosPrestamos.Find(idEstadoPrestamo);

            if (estadoPrestamo != null)
            {
                _contexto.EstadosPrestamos.Remove(estadoPrestamo);
                _contexto.SaveChanges();
            }
        }
    }
}


