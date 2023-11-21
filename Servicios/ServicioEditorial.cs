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
        public List<Editorial> ListaEditoriales()
        {
            using (var cxt = new ApiDBContexto())
            {
                return cxt.Editoriales.ToList();
            }
        }
    }
}
