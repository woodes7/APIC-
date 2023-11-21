using Contexto;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioEditorial
    {
        private readonly ApiDBContexto _contexto;

        public ServicioEditorial(ApiDBContexto contexto)
        {
            _contexto = contexto;
        }
        public List<Editorial> ListaEditoriales()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Editoriales.ToList();
            }
        }       

        public Editorial ObtenerEditorialPorId(int id)
        {
            return _contexto.Editoriales.Find(id);
        }

        public void AgregarEditorial(Editorial editorial)
        {
            _contexto.Editoriales.Add(editorial);
            _contexto.SaveChanges();
        }

        public void ModificarEditorial(Editorial editorial)
        {
            _contexto.Editoriales.Update(editorial);
            _contexto.SaveChanges();
        }

        public void BorrarEditorial(int idEditorial)
        {
            var editorial = _contexto.Editoriales.Find(idEditorial);

            if (editorial != null)
            {
                _contexto.Editoriales.Remove(editorial);
                _contexto.SaveChanges();
            }
        }
    }
}

