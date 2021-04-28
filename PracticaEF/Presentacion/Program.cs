using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Declaraciones

            ProductLogic productoLogic = new ProductLogic();
            CategoryLogic categoryLogic = new CategoryLogic();

            #endregion

            #region Menus

            void Menu()
            {
                int op = 0;
                do
                {

                    Console.Clear();
                    Console.WriteLine($"1-Listar productos.\n2-AMBC de Categorias\n3-Salir");

                    try
                    {
                        op = int.Parse(Console.ReadLine());

                    }
                    catch
                    {
                        Console.WriteLine($"Ingreso una letra o no ingreso nada.");
                        Console.ReadKey();
                    }
                    switch (op)
                    {
                        case 1:
                            ListarProductos();
                            break;
                        case 2:
                            MenuABM();
                            break;
                        default:
                            break;
                    }
                } while (op != 3);

            }
            void MenuABM()
            {
                int op = 0;
                do
                {
                    Console.Clear();

                    Console.WriteLine($"1-Nuevo\n2-Editar\n3-Borrar\n4-Salir");

                    try
                    {
                        op = int.Parse(Console.ReadLine());

                    }
                    catch
                    {
                        Console.WriteLine($"Ingreso una opcion incorrecta o no ingreso nada.");
                        Console.ReadKey();
                    }

                    switch (op)
                    {
                        case 1:
                            Agregar();
                            break;
                        case 2:
                            Editar();
                            break;
                        case 3:
                            Eliminar();
                            break;
                        case 4:
                            Menu();
                            break;
                        default:
                            break;
                    }
                } while (op != 4);

            }

            #endregion

            #region Listados 

            void ListarProductos()
            {
                Console.Clear();
                foreach (var producto in productoLogic.GetAll())
                {
                    Console.WriteLine(producto.Descriptor());
                }
                Console.ReadKey();

            }
            void ListarCategorias()
            {
                Console.Clear();
                foreach (var categoria in categoryLogic.GetAll())
                {
                    Console.WriteLine($"ID: {categoria.CategoryID}\nNombre: {categoria.CategoryName}\nDescripcion: {categoria.Description}\n");
                }

            }

            #endregion

            #region ABM

            void Editar()
            {

                var categoria = new Category();
                int op = 0;

                ListarCategorias();

                Console.WriteLine($"Seleccione id de la categoria a editar. X para salir");

                try
                {
                    var auxOp = Console.ReadLine();

                    if (auxOp.ToUpper() == "X") Menu();
                    op = int.Parse(auxOp);

                    categoria = categoryLogic.GetOne(op);

                    Console.Write($"Ingrese nuevo nombre: ");
                    categoria.CategoryName = Console.ReadLine();

                    Console.Write($"Ingrese nueva descripcion: ");
                    categoria.Description = Console.ReadLine();

                    categoryLogic.Update(categoria);
                    Console.Write($"Datos guardados.");
                    Console.ReadKey();
                    MenuABM();

                }
                catch
                {
                    Console.WriteLine($"Ingreso una opcion incorrecta o no ingreso nada.");
                    Console.ReadKey();
                    Editar();
                }

            };
            void Eliminar()
            {

                int op = 0;

                ListarCategorias();

                Console.WriteLine($"Seleccione id de la categoria a Eliminar. X para salir");

                try
                {
                    var auxOp = Console.ReadLine();

                    if (auxOp.ToUpper() == "X") Menu();
                    op = int.Parse(auxOp);

                    categoryLogic.Delete(op);
                    Console.Write($"Categoria eliminada.");
                    Console.ReadKey();
                    MenuABM();

                }
                catch
                {
                    Console.WriteLine($"Ingreso una opcion incorrecta o no ingreso nada.");
                    Console.ReadKey();
                    Editar();
                }
            };
            void Agregar()
            {
                var categoria = new Category();

                try
                {

                    Console.Write($"Ingrese nuevo nombre: ");
                    categoria.CategoryName = Console.ReadLine();

                    Console.Write($"Ingrese nueva descripcion: ");
                    categoria.Description = Console.ReadLine();

                    categoryLogic.Insert(categoria);
                    Console.Write($"Datos guardados.");
                    Console.ReadKey();
                    MenuABM();

                }
                catch
                {
                    Console.WriteLine($"Ingreso una opcion incorrecta o no ingreso nada.");
                    Console.ReadKey();
                    Editar();
                }
            };

            #endregion

            Menu();
        }
    }
}
