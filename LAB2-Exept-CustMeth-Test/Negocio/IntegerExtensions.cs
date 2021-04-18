using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class IntegerExtensions
    {
        public static int DividirPorCero(this int value)
        {
            return value / 0;
        }
        public static double DividirPor(this int dividendo, int divisor )
        {
            return (Double)(dividendo / divisor);
        }
    }
}
