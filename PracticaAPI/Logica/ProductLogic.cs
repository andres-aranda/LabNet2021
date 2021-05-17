using Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Logica
{
    public class ProductLogic : LogicBase, IABMC<Product>
    {
        public List<Product> GetAll()
        {
            return DbContext.Products.ToList();
        }

        public Product GetOne(int id)
        {
            return DbContext.Products.Find(id);
        }

        #region Operaciones con transaccion

        public void Insert(Product newEntity)
        {
            using (var dbContextTransaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    DbContext.Products.Add(newEntity);
                    DbContext.SaveChanges();
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
            using (var dbContextTransaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    DbContext.Entry(updatedEntity).State = EntityState.Modified;
                    DbContext.SaveChanges();
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
            using (var dbContextTransaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    DbContext.Products.Remove(GetOne(id));
                    DbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }

                catch
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            };
        }

        #endregion

    }
}
