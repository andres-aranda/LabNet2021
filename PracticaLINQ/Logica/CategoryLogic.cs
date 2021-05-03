using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CategoryLogic : LogicBase, IABMC<Category>
    {
        public IQueryable GetCategoriasAsociadas()
        {
            var query = from prod in context.Products
                        join idCat in context.Categories on prod.CategoryID equals idCat.CategoryID
                        group idCat by idCat.CategoryName into newGroup
                        select newGroup.Key;

            return query;
        }
        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }
        public Category GetOne(int id)
        {
            return context.Categories.First(c => c.CategoryID == id);
        }

        #region Operaciones con transaccion

        public void Insert(Category newEntity)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Categories.Add(newEntity);
                    context.SaveChanges();
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
                    context.Categories.Remove(GetOne(id));
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
