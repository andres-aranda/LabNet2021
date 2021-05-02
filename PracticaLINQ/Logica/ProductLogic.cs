using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ProductLogic : LogicBase, IABMC<Product>
    {
        public List<Product> GetProductsSinStock()
        {
            var query = from product in context.Products
                        where product.Stock == 0 || product.Stock == null
                        select product;

            return query.ToList();
        }
        public List<Product> GetProductsStockValenMasDeTres()
        {
            var query = context.Products.Where(p=>p.UnitPrice>=3 && p.Stock !=0 && p.Stock != null);

            return query.ToList();
        }
        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }
        public List<Product> GetAllOrdenado()
        {
            var query = context.Products.OrderByDescending(p => p.Stock);

            return query.ToList();
        }
        public List<Product> GetAllOrdenadoNombre()
        {
            var query = from product in context.Products
                        orderby product.Producto
                        select product;

            return query.ToList();
        }
        public Product GetOneWithId789()
        {
            var query = context.Products.Where(p=>p.ProductID == 789);
            return query.FirstOrDefault();
        }
        public Product GetOne(int id)
        {
            return context.Products.Find(id);
        }
        public Product GetFirst()
        {
            var query = context.Products.Take(1);
            return query.FirstOrDefault();
        }

        #region Operaciones con transaccion

        public void Insert(Product newEntity)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Products.Add(newEntity);
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                }

                catch
                {
                    dbContextTransaction.Rollback();
                }
            };
        }

        public void Update(Product updatedEntity)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Entry(updatedEntity).State = EntityState.Modified;
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                }

                catch
                {
                    dbContextTransaction.Rollback();
                }
            };
        }

        public void Delete(int id)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Products.Remove(GetOne(id));
                    dbContextTransaction.Commit();
                }

                catch
                {
                    dbContextTransaction.Rollback();
                }
            };
        }

        #endregion

    }
}
