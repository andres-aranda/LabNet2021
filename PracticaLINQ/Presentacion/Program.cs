using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Presentacion
{
    class Program
    {
        #region Iterador generico

        static class Iterador<T>
        {

            public static void Descriptor(List<T> listaEntidades)
            {
                foreach (var entidad in listaEntidades)
                {
                    Type _type = entidad.GetType();

                    PropertyInfo[] listaPropiedades = _type.GetProperties();

                    foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
                    {
                        if (propiedad.GetValue(entidad, null) != null && (
                            propiedad.GetValue(entidad, null).GetType() == typeof(Int16) ||
                            propiedad.GetValue(entidad, null).GetType() == typeof(decimal) ||
                            propiedad.GetValue(entidad, null).GetType() == typeof(string) ||
                            propiedad.GetValue(entidad, null).GetType() == typeof(Int32)))
                        {
                            Console.WriteLine($"{propiedad.Name}:{propiedad.GetValue(entidad, null)}");
                        }
                    }
                    Console.WriteLine();
                }
            }

        }

        #endregion

        static void Main(string[] args)
        {
            #region Declaraciones

            ProductLogic productoLogic = new ProductLogic();
            CategoryLogic categoryLogic = new CategoryLogic();
            CustomerLogic customerLogic = new CustomerLogic();

            #endregion

            #region Devoluciones

            //1. Query para devolver objeto customer
            void DevolverCustomer()
            {
                Console.WriteLine(customerLogic.GetIds());
                Console.Write($"Ingrese ID Customer:");
                Customers customer = customerLogic.GetOne(Console.ReadLine().ToUpper());

                if (customer == null)
                    Console.WriteLine($"No extiste el customer con ese ID;");
                else
                    Console.WriteLine($"ID: {customer.CustomerID}\nNombre: {customer.Nombre}\nDireccion: {customer.Address}");

                Console.ReadKey();
            }

            //2.Query para devolver todos los productos sin stock
            void DevolverProductosSinStock()
            {
                Console.WriteLine($"Productos sin Stock");

                Iterador<Product>.Descriptor(productoLogic.GetProductsSinStock());

                Console.ReadKey();
            }

            //3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad
            void GetProductsStockValenMasDeTres()
            {
                Console.WriteLine($"Productos que tienen stock y que cuestan más de 3 por unidad:");

                Iterador<Product>.Descriptor(productoLogic.GetProductsStockValenMasDeTres());

                Console.ReadKey();
            }

            //4.Query para devolver todos los customers de Washington
            void GetCustomersWashington()
            {
                Console.WriteLine($"Customers de Washington:");

                Iterador<Customers>.Descriptor(customerLogic.GetCustomersWashington());

                Console.ReadKey();
            }

            //5. Query para devolver el primer elemento o nulo de una 
            //lista de productos donde el ID deproducto sea igual a 789
            void GetOneWithId789()
            {
                var product = productoLogic.GetOneWithId789();
                if (product != null)
                    Console.WriteLine(product.Descriptor());
                else Console.WriteLine($"No existe el producto con Id 789");
                Console.ReadKey();
            }

            //6. Query para devolver los nombre de los Customers. Mostrarlos 
            //en Mayuscula y en Minuscula.
            void GetNombres()
            {
                Console.WriteLine($"Customers en mayuscula y minuscula;");
                foreach (var customerName in customerLogic.GetNombreCustomers())
                {
                    Console.WriteLine($"{customerName}\n");
                }
                Console.ReadKey();
            }

            //7. Query para devolver Join entre Customers y Orders donde los 
            //customers sean de Washington y la fecha de orden sea mayor a 1/1/1997.
            void CustomerOrderJoin()
            {
                Console.WriteLine($"Join entre Customers y Orders");
                foreach (var customerOrden in customerLogic.CustomerOrderJoin())
                {
                    Console.WriteLine($"{customerOrden}\n");
                }
                Console.ReadKey();
            }

            //8. Query para devolver los primeros 3 Customers de Washington
            void GetPrimerosTresWhashington()
            {
                Console.WriteLine($"3 Customers de Washington:");

                Iterador<Customers>.Descriptor(customerLogic.GetPrimerosTresWhashington());

                Console.ReadKey();
            }

            //9.Query para devolver lista de productos ordenados por nombre
            void GetAllOrdenadoNombre()
            {
                Console.WriteLine($"Productos ordenados por nombre");

                Iterador<Product>.Descriptor(productoLogic.GetAllOrdenadoNombre());

                Console.ReadKey();
            }

            //10. Query para devolver lista de productos ordenados por unit
            //in stock de mayor a menor.
            void GetAllOrdenadoStock()
            {
                Console.WriteLine($"Productos ordenados por unit in stock\n");

                Iterador<Product>.Descriptor(productoLogic.GetAllOrdenado());

                Console.ReadKey();
            }

            //11. Query para devolver las distintas categorías asociadas a los productos
            void GetCategoriasAsociadas()
            {
                Console.WriteLine($"Categorías asociadas a los productos\n");

                Iterador<Category>.Descriptor(categoryLogic.GetCategoriasAsociadas());

                Console.ReadKey();
            }

            //12. Query para devolver el primer elemento de una lista de productos
            void GetPrimerProducto()
            {
                Console.WriteLine($"Primer producto:\n");

                Console.WriteLine(productoLogic.GetFirst().Descriptor());

                Console.ReadKey();
            }

            // 13.Query para devolver los customer con la cantidad de ordenes asociadas
            void CustomerConOrdenes()
            {
                Console.WriteLine($"Join entre Customers y Orders");
                foreach (var customerOrden in customerLogic.GetCustomersWithOrders())
                {
                    Console.WriteLine($"{customerOrden}\n");
                }
                Console.ReadKey();
            }

            #endregion

            #region Ejecucion

            //DevolverCustomer();
            //Console.Clear();
            //DevolverProductosSinStock();
            //Console.Clear();
            //GetProductsStockValenMasDeTres();
            //Console.Clear();
            //GetCustomersWashington();
            //Console.Clear();
            //GetOneWithId789();
            //Console.Clear();
            //GetNombres();
            //Console.Clear();
            //CustomerOrderJoin();
            //Console.Clear();
            //GetPrimerosTresWhashington();
            //Console.Clear();
            //GetAllOrdenadoNombre();
            //Console.Clear();
            //GetAllOrdenadoStock();
            //Console.Clear();
            GetCategoriasAsociadas();
            //Console.Clear();
            //GetPrimerProducto();
            //Console.Clear();
            //CustomerConOrdenes();
            //Console.Clear();

            #endregion

        }
    }
}
