using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{

    public class CustomerLogic : LogicBase
    {
        public string GetIds()
        {
            string Ids = "Ids: ";
            foreach (var customer in context.Customers)
            {
                Ids += $" {customer.CustomerID},";
            }

            return Ids;
        }
        public Customers GetOne(string id)
        {
            string idString = id.ToString();
            var query = context.Customers.Where(c => c.CustomerID == idString);
            return query.FirstOrDefault();
        }
        public List<Customers> GetPrimerosTresWhashington()
        {
            var query = context.Customers.Where(c=> c.City == "Washington").Take(3);
            return query.ToList();
        }   
        public List<Customers> GetCustomersWashington()
        {
            //probar con Lyon
            var query = from customer in context.Customers
                        where customer.City == "Washington"
                        select customer;

            return query.ToList();
        }
        public IQueryable CustomerOrderJoin() {
            //probar con Lyon
            var query = context.Customers.Where(c => c.City == "Washington").Join(context.Orders,
                c => c.CustomerID,
                o => o.CustomerID,
                (c,o)=> new {c.Nombre,
                            o.OrderID,
                            o.OrderDate}).Where(o=>o.OrderDate>new DateTime(1997,1,1));
            return query;
        }
        public IQueryable GetNombreCustomers()
        {
          
            var query = from customer in context.Customers
                        select new { nombreMayuscula = customer.Nombre.ToUpper() ,
                            nombreMinuscula = customer.Nombre.ToLower()} ;

            return query;
        }
        public IQueryable GetCustomersWithOrders()
        {

            var query = from cus in context.Customers
                        join ord in context.Orders on cus.CustomerID equals ord.CustomerID
                        group cus by cus.Nombre into cusOrd
                        select new
                        {Nombre = cusOrd.Key , Ordenes = cusOrd.Count() };


            return query;
        }
    }
}
