using Entidades;
using Logica;
using PresentacionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PresentacionMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryLogic logic = new CategoryLogic();
        // GET: Category
        public ActionResult Index()
        {
            List<Category> lista = logic.GetAll();

            List<CategoryView> listaCategorias = lista.Select(x => new CategoryView
            {

                ID = x.CategoryID,
                Descripcion = x.Description,
                Nombre = x.CategoryName,
                Imagen = x.Picture

            }).ToList();


            return View(listaCategorias);
        }
        public ActionResult Delete(int id)
        {
            logic.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult NewEdit(int ID, bool Nuevo)
        {
            CategoryView view = new CategoryView();

            if (!Nuevo)
            {
                CategoryLogic logic = new CategoryLogic();

                Category entity = logic.GetOne((int)ID);

                view = new CategoryView
                {

                    ID = entity.CategoryID,
                    Descripcion = entity.Description,
                    Nombre = entity.CategoryName,
                    Imagen = entity.Picture

                };
            }

            return View(view);
        }
        [HttpPost]
        public ActionResult Insert(CategoryView categoryView)
        {
            try
            {
                Category categoryEntity = new Category
                {
                    CategoryName = categoryView.Nombre,
                    Description = categoryView.Descripcion,
                };

                if (categoryView.ID == 0)
                {
                    logic.Insert(categoryEntity);
                }
                else
                {
                    categoryEntity.CategoryID = categoryView.ID;
                    logic.Update(categoryEntity);
                }


                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}