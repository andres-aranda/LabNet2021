namespace MyAPI.Models
{
    public class ProductView
    {
        public int ProductID { get; set; }
        public string Nombre { get; set; }
        public string CantidadPorUnidad { get; set; }

        public decimal? PrecioUnidad { get; set; }

        public short? UnidadesEnStock { get; set; }

        public short? UnidadesOrdenadas { get; set; }

    }
}