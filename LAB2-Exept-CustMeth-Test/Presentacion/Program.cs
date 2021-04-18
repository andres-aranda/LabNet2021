using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;


namespace Presentacion
{
    class Program
    {
        static void Main()
        {
            #region Dividir por cero.

            try
            {
                int numero = 10;
                Console.WriteLine($"Vamos a dividir {numero} por cero a ver que sucede...");
                numero.DividirPorCero();

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"Operacion finalizada \n");
            }

            #endregion


            #region Dividir dos numeros

            int divisor =1;
            int dividendo=1;
            try
            {
             

                Console.WriteLine($"Te toca dividir a vos ahora :D \nIngrese el dividendo:");
                dividendo = int.Parse(Console.ReadLine());

                Console.WriteLine($"Genial! ahora ingrese el divisor:");
                divisor = int.Parse(Console.ReadLine());

                Console.WriteLine($"El resultado es... {dividendo.DividirPor(divisor)} \n");


            }
            catch (DivideByZeroException ex)
            {
                if (divisor == 0 && dividendo == 0)
                    Console.WriteLine($"Imagínate que tienes cero galletas y se reparten entre cero amigos.\n¿Cuántas galletas le tocarán a cada amigo? No tiene sentido.\n¿Lo ves? Así el Monstruo de las Galletas está muy triste porque no tiene galletas \ny tú estás muy triste porque no tienes amigos \n{ex.Message}");
                else
                    Console.WriteLine($"Solo Chuck Norris divide por cero!\n{ex.Message}");
            }
            catch (Exception exe)
            {
                Console.WriteLine($"Seguro Ingreso una letra o no ingreso nada!\n{exe.Message}");
            }

            #endregion

            #region Producir Exepcion

            try
            {
                Console.WriteLine("Vamos a romper todo! presiona una tecla para generar una exepcion 3:)");
                Console.ReadKey();
                Logic.ProducirExepcion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se ah producido una exepcion de tipo: {ex.GetType()} con el siguiente mensaje: '{ex.Message}'");
            }


            #endregion

            #region Exepcion personalizada

            Console.Write($"Pf que aburrido.. Y si generamos una exepcion personalizada? \n Si quieres puedes comentarla. Vamos escribe algo: ");
            string comentario=Console.ReadLine();
            try
            {
                Logic.ProducirExepcionPersonalizada();
            }
            catch (CustomExeption ex)
            {

              
                MessageBox.Show(ex.AgregarComentario(comentario));
            

            }

            #endregion

            Console.ReadKey();
        }
    }
}
