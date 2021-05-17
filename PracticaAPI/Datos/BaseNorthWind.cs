using Entidades;
using System.Data.Entity;

namespace Datos
{
    public partial class BaseNorthWind : DbContext
    {
        public BaseNorthWind()
            : base("name=BaseNorthWindConection")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Order_Detail> Order_Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order_Detail>()
              .Property(e => e.UnitPrice)
              .HasPrecision(19, 4);
        }
    }
}
