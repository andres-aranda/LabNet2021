using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CustomExeption : Exception
    {
       public CustomExeption() : base($"Esta es una exepcion personalizada.")
        {

        }
    }
}
