using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class ExepcitonsExtencions
    {
        public static string AgregarComentario(this CustomExeption ex, string comentario)
        {
            return $"{comentario} {ex.Message}";
        }
    }
}
