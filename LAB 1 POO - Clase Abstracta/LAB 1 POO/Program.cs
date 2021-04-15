using System;
using System.Collections.Generic;

namespace LAB_1_POO
{
    class Program
    {
        static void Main()
        {
            #region Inicializaciones
            //Hard code de lista de transportes
            List<Transporte> transportes = new List<Transporte>
            {
                new Avion("Avion 1",40),
                new Avion("Avion 2",66),
                new Avion("Avion 3",10),
                new Avion("Avion 4",120),
                new Avion("Avion 5",500),
                new Automovil("Automovil 1",3),
                new Automovil("Automovil 2",4),
                new Automovil("Automovil 3",5),
                new Automovil("Automovil 4",2),
                new Automovil("Automovil 5",7),

            };
            #endregion

            #region Procedimientos 
            //Recorro la lista de transportes y muestro sus propiedades
            foreach (var item in transportes)
            {
                Console.WriteLine($"\n El {item.Descripcion} tiene una capacidad para {item.CantidadPasajeros} personas.");
            }

            Console.WriteLine("\n Presione una tecla para iniciar el viaje de los transportes");
            Console.ReadKey();

            //Recorro la lista de transportes ejecuto sus metodos
            foreach (var item in transportes)
            {
                Console.WriteLine($"\n Iniciando viaje del {item.Descripcion}: ");
                Console.Write("INICIO ");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(item.Avanzar());
                }
                Console.WriteLine(item.Detenerse());
            }
            Console.ReadKey();
            #endregion


        }
    }
}
