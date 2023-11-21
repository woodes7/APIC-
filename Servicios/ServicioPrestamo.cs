using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
    {
        public class PrestamoServicio
        {
            private readonly ApiDBContexto _contexto;

            public PrestamoServicio(ApiDBContexto contexto)
            {
                _contexto = contexto;
            }

            public List<Prestamo> ListaPrestamos()
            {
                using (var cxt = new ApiDBContexto())
                {
                    return cxt.Prestamos.ToList();
                }
            }

            public Prestamo ObtenerPrestamoPorId(int id)
            {
                return _contexto.Prestamos.Find(id);
            }

            public void AgregarPrestamo(Prestamo prestamo)
            {
                _contexto.Prestamos.Add(prestamo);
                _contexto.SaveChanges();
            }

            public void ModificarPrestamo(Prestamo prestamo)
            {
                _contexto.Prestamos.Update(prestamo);
                _contexto.SaveChanges();
            }

            public void BorrarPrestamo(int idPrestamo)
            {
                var prestamo = _contexto.Prestamos.Find(idPrestamo);

                if (prestamo != null)
                {
                    _contexto.Prestamos.Remove(prestamo);
                    _contexto.SaveChanges();
                }
            }
        }
    }

