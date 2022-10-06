using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet 
        public DbSet<Good> Goods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.OrderId);
                e.Property(o => o.OrderDate).HasDefaultValueSql("getutcdate()");
                e.Property(o => o.CustomerName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.HasOne(e => e.Order)
                    .WithMany(e => e.OrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(e => e.Good)
                    .WithMany(e => e.OrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .HasConstraintName("FK_OrderDetail_Good");

            });
        }
    }
}
