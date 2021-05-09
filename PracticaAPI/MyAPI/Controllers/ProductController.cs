using Entidades;
using Logica;
using MyAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MyAPI.Controllers
{
    public class ProductController : ApiController
    {
        readonly ProductLogic logic = new ProductLogic();

        public List<ProductView> Get()
        {
            List<Product> lista = logic.GetAll();

            List<ProductView> listaCategorias = lista.Select(x => new ProductView
            {
                ProductID = x.ProductID,
                Nombre = x.ProductName,
                CantidadPorUnidad = x.QuantityPerUnit,
                PrecioUnidad = x.UnitPrice,
                UnidadesEnStock = x.UnitsInStock,
                UnidadesOrdenadas = x.UnitsOnOrder

            }).ToList();

            return listaCategorias;
        }


        public ProductView Get(int id)
        {
            Product entity = logic.GetOne(id);

            var view = new ProductView
            {

                ProductID = entity.ProductID,
                Nombre = entity.ProductName,
                CantidadPorUnidad = entity.QuantityPerUnit,
                PrecioUnidad = entity.UnitPrice,
                UnidadesEnStock = entity.UnitsInStock,
                UnidadesOrdenadas = entity.UnitsOnOrder

            };
            return view;
        }

        public void Post(ProductView productView)
        {
            Product categoryEntity = new Product
            {
                ProductName = productView.Nombre,
                QuantityPerUnit = productView.CantidadPorUnidad,
                UnitPrice = productView.PrecioUnidad,
                UnitsOnOrder = productView.UnidadesOrdenadas,
                UnitsInStock = productView.UnidadesEnStock,
            };

            logic.Insert(categoryEntity);

        }

        public void Put(int id, ProductView value)
        {
            var entity = logic.GetOne(id);
            entity.ProductName = value.Nombre;
            entity.QuantityPerUnit = value.CantidadPorUnidad;
            entity.UnitPrice = value.PrecioUnidad;
            entity.UnitsOnOrder = value.UnidadesOrdenadas;
            entity.UnitsInStock = value.UnidadesEnStock;
            logic.Update(entity);
        }

        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }


}
