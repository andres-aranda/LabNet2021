using Entidades;
using Logica;
using MyAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MyAPI.Controllers
{
    public class CategoryController : ApiController
    {
        readonly CategoryLogic logic = new CategoryLogic();

        public List<CategoryView> Get()
        {
            List<Category> lista = logic.GetAll();

            List<CategoryView> listaCategorias = lista.Select(x => new CategoryView
            {
                Descripcion = x.Description,
                Nombre = x.CategoryName

            }).ToList();

            return listaCategorias;
        }


        public CategoryView Get(int id)
        {
            Category entity = logic.GetOne(id);

            var view = new CategoryView
            {

                ID = entity.CategoryID,
                Descripcion = entity.Description,
                Nombre = entity.CategoryName

            };
            return view;
        }


        public void Post(CategoryView categoryView)
        {
            Category categoryEntity = new Category
            {
                CategoryName = categoryView.Nombre,
                Description = categoryView.Descripcion,
            };

            logic.Insert(categoryEntity);
        }


        public void Put(int id, CategoryView value)
        {
            var entity = logic.GetOne(id);
            entity.CategoryName = value.Nombre;
            entity.Description = value.Descripcion;

            logic.Update(entity);
        }


        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }


}
