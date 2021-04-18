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
        public static decimal DividirPor(this int dividendo, int divisor )
        {
            
            return Math.Round((decimal)dividendo / (decimal)divisor,2);
        }
    }
}
