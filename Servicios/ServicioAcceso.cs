using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioAcceso
    {
        private readonly ApiDBContexto _contexto;

        public ServicioAcceso(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }
        public List<Acceso> ListaAccesos()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Accesos.ToList();
            }
        }

        public Acceso ObtenerAccesoPorId(long idAcceso)
        {
            return _contexto.Accesos.Find(idAcceso);
        }

        public void AgregarAcceso(Acceso acceso)
        {
            _contexto.Accesos.Add(acceso);
            _contexto.SaveChanges();
        }

        public void ModificarAcceso(Acceso acceso)
        {
            _contexto.Accesos.Update(acceso);
            _contexto.SaveChanges();
        }

        public void BorrarAcceso(long idAcceso)
        {
            var acceso = _contexto.Accesos.Find(idAcceso);

            if (acceso != null)
            {
                _contexto.Accesos.Remove(acceso);
                _contexto.SaveChanges();
            }
        }
    }
}
