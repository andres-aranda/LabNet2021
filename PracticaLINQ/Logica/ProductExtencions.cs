using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public static class ProductExtencions
    {
        public static string Descriptor(this Product product)
        {
            string descripcion = $"Nombre:{product.Producto}\n" +
                $"Precio unitario:{product.UnitPrice}\n" +
                $"Categoria:{product.Category.CategoryName}\n" +
                $"Proveedor:{product.Supplier.CompanyName}\n" +
                $"Stock actual:{product.Stock}\n" +
                $"Unidade ordenadas;{product.Ordenadas}\n";
            return descripcion;
        }
    }
}
