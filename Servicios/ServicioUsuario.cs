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

        public List<Usuario> ListaUsuario()
        {
            using(var cxt = new ApiDBContexto())
            {
                return cxt.Usuarios.ToList();
            }
        }
        public Usuario SelecciinarUsuario(long idUsuario)
        {

            using (var cxt = new ApiDBContexto())
            {
                return cxt.Usuarios.Where(usu => usu.idUsuario == idUsuario).FirstOrDefault();
            }
        }
        public void CrearUsuario(Usuario usuario)
        {
            using( var cxt = new ApiDBContexto())
            {
               cxt.Usuarios.Add(usuario);
                cxt.SaveChanges();
            }
        }

        public void ModificarUsuario (long idUsuario, Usuario usuarioNuevo)
        {   
           using(var cxt =new ApiDBContexto())
            {
                Usuario usuLocal = SelecciinarUsuario(idUsuario);
                usuarioNuevo.idUsuario = usuLocal.idUsuario;
                cxt.Usuarios.Update(usuarioNuevo);
                cxt.SaveChanges();
            }

        }
      
        public void DarBajaUsuario(long idUsuario)
        {
            using (var cxt = new ApiDBContexto())
            {
                Usuario usuarioAEliminar = SelecciinarUsuario(idUsuario);
                if (usuarioAEliminar != null)
                {
                    cxt.Usuarios.Remove(usuarioAEliminar);
                    cxt.SaveChanges(); 
                }
            }
        }
    }
}
