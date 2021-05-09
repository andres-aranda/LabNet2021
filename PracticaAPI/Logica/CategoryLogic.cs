using Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Logica
{
    public class CategoryLogic : LogicBase, IABMC<Category>
    {

        public List<Category> GetAll()
        {
            return DbContext.Categories.ToList();
        }

        public Category GetOne(int id)
        {
            return DbContext.Categories.First(c => c.CategoryID == id);
        }

        #region Operaciones con transaccion

        public void Insert(Category newEntity)
        {
            using (var dbContextTransaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    DbContext.Categories.Add(newEntity);
                    DbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }

                catch
                {
                    dbContextTransaction.Rollback();
                }
            };
        }

        public void Update(Category updatedEntity)
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
                    DbContext.Categories.Remove(GetOne(id));
                    DbContext.SaveChanges();
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
