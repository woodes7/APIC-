using Contexto;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioUsuario
    {
        private readonly ApiDBContexto _contexto;

        public ServicioUsuario(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }

        public List<Usuario> ListaUsuarios()
        {
            using(var cxt = new ApiDBContexto())
            {
                return cxt.Usuarios.ToList();
            }
        }
       
        public Usuario ObtenerUsuarioPorId(long IdUsuario)
        {
            return _contexto.Usuarios.Find(IdUsuario);
        }

        public void AgregarUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }

        public void ModificarUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
        }

        public void BorrarUsuario(long IdUsuario)
        {
            var usuario = _contexto.Usuarios.Find(IdUsuario);

            if (usuario != null)
            {
                _contexto.Usuarios.Remove(usuario);
                _contexto.SaveChanges();
            }
        }
    }
}
