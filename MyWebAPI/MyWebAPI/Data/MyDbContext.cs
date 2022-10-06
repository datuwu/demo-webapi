using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet 
        public DbSet<Good> Goods { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion
    }
}
