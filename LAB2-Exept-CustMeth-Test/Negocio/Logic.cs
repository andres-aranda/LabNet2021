using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class Logic
    {
        public static void ProducirExepcion()
        {
            try
            {
                int numero = int.Parse("trece");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void ProducirExepcionPersonalizada()
        {
            throw new CustomExeption();
        }
    }
}
