using Entidades;
using Logica;
using MyAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Net;
using System;

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


        public IHttpActionResult Get(int id)
        {
            Product entity = logic.GetOne(id);
            if (entity != null)
            {
                var view = new ProductView
                {

                    ProductID = entity.ProductID,
                    Nombre = entity.ProductName,
                    CantidadPorUnidad = entity.QuantityPerUnit,
                    PrecioUnidad = entity.UnitPrice,
                    UnidadesEnStock = entity.UnitsInStock,
                    UnidadesOrdenadas = entity.UnitsOnOrder

                };
                return Ok(view);
            }

            return NotFound();
        }

        public IHttpActionResult Post(ProductView productView)
        {
            try
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

                return Ok();
            }
            catch
            {
                return InternalServerError();
            }

        }

        public IHttpActionResult Put(int id, ProductView value)
        {
            try
            {
                var entity = logic.GetOne(id);
                entity.ProductName = value.Nombre;
                entity.QuantityPerUnit = value.CantidadPorUnidad;
                entity.UnitPrice = value.PrecioUnidad;
                entity.UnitsOnOrder = value.UnidadesOrdenadas;
                entity.UnitsInStock = value.UnidadesEnStock;
                logic.Update(entity);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }


}
