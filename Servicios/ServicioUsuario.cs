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
    {   /// <summary>
        /// Contexto de base de datos utilizado por el servicio para acceder y manipular datos de usuario.
        /// </summary>
        private readonly ApiDBContexto _contexto;
        /// <summary>
        /// Servicio para gestionar operaciones relacionadas con los usuario en la base de datos.
        /// </summary>
        /// <param name="contexto">Contexto de base de datos</param>

        public ServicioUsuario(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Obtiene la lista de todos los usuario.
        /// </summary>
        /// <returns>Lista de usuario</returns>
        public List<Usuario> ListaUsuarios()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Usuarios.ToList();
            }
        }
        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <returns>Usuario con el ID especificado</returns>
        public Usuario ObtenerUsuarioPorId(long idUsuario)
        {
            return _contexto.Usuarios.Find(idUsuario);
        }
        /// <summary>
        /// Agrega un nuevo usuario.
        /// </summary>
        /// <param name="acceso">Datos del nuevo usuario</param>
        public void AgregarUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Modifica un usuario existente.
        /// </summary>
        /// <param name="usuario">Datos del usuario actualizado</param>
        public void ModificarUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
        }
        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a eliminar</param>
        public void BorrarUsuario(long idUsuario)
        {
            var usuario = _contexto.Usuarios.Find(idUsuario);

            if (usuario != null)
            {
                _contexto.Usuarios.Remove(usuario);
                _contexto.SaveChanges();
            }
        }
    }
}
