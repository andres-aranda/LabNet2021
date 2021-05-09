using Entidades;

namespace Logica
{
    public static class ProductExtencions
    {
        public static string Descriptor(this Product product)
        {
            string descripcion = $"Nombre:{product.ProductName}\n" +
                $"Precio unitario:{product.UnitPrice}\n" +
                $"Categoria:{product.Category.CategoryName}\n" +
                $"Proveedor:{product.Supplier.CompanyName}\n" +
                $"Stock actual:{product.UnitsInStock}\n" +
                $"Unidade ordenadas;{product.UnitsOnOrder}\n";
            return descripcion;
        }
    }
}
